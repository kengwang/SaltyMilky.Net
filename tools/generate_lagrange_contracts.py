"""Regenerate SDK wire DTOs from a local Lagrange.Milky checkout (no server execution)."""
import re
import sys
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
SDK = ROOT / 'SaltyMilky.Net'
SOURCE = Path(sys.argv[1]) / 'Lagrange.Milky'

def balanced(text, start, left='{', right='}'):
    depth = 0
    # Ignore strings/comments while counting C# delimiters.
    mask = re.sub(r'//[^\n]*|/\*.*?\*/|"(?:\\.|[^"\\])*"', lambda m: ' ' * len(m[0]), text, flags=re.S)
    for i in range(start, len(text)):
        if mask[i] == left: depth += 1
        elif mask[i] == right:
            depth -= 1
            if depth == 0: return i
    raise ValueError(text[start:start+80])

def declarations(text):
    output = []
    for m in re.finditer(r'public\s+(?:(?:sealed|abstract|partial)\s+)*(?:class|record(?:\s+class)?)\s+(\w+)', text):
        end = m.end()
        primary = ''
        while end < len(text) and text[end].isspace(): end += 1
        if text[end:end+1] == '(':
            close = balanced(text, end, '(', ')')
            primary = text[end+1:close]
            end = close+1
        brace = text.find('{', end)
        semi = text.find(';', end)
        if semi >= 0 and (brace < 0 or semi < brace):
            output.append((m[1], primary, '', m.start(), semi+1))
        elif brace >= 0:
            close = balanced(text, brace)
            output.append((m[1], primary, text[brace+1:close], m.start(), close+1))
    return output

PROP = re.compile(r'\[JsonPropertyName\("([^"]+)"\)[^\]]*\]\s*(?:\[[^\]]*\]\s*)*public\s+(?:required\s+)?([\w.<>?, \[\]]+?)\s+(\w+)\s*\{')
POS = re.compile(r'\[property:\s*JsonPropertyName\("([^"]+)"\)\]\s*([\w.<>?, \[\]]+?)\s+(\w+)(?=\s*(?:,|$))')

def properties(decl):
    name, primary, body, *_ = decl
    result = []
    defaults = dict(re.findall(r'\b(\w+)\s*=\s*([^,]+)', primary))
    for m in PROP.finditer(body):
        close = balanced(body, m.end()-1)
        tail = body[close+1:]
        init = re.match(r'\s*=\s*([^;]+);', tail)
        value = init[1].strip() if init else None
        if value in defaults: value = defaults[value]
        # Only literal wire defaults; server-side projection expressions are not DTO defaults.
        if value and not re.fullmatch(r'(?:null|true|false|\[\]|string.Empty|"[^"]*"|-?[0-9]+(?:[uUlLfFdD]+)?)', value): value = None
        result.append((m[1], m[2].strip(), m[3], value))
    result.extend((m[1], m[2].strip(), m[3], None) for m in POS.finditer(primary))
    return result

known = {
    'IncomingMessageBase':'MilkyIncomingMessage', 'IncomingForwardedMessage':'MilkyIncomingForwardedMessage',
    'OutgoingForwardedMessage':'MilkyOutgoingForwardedMessage', 'OutgoingSegmentBase':'MilkyOutgoingSegment',
    'IncomingSegmentBase':'MilkyIncomingSegment', 'MessageStyle':'MilkyMessageStyle',
    'Friend':'MilkyFriendEntity', 'FriendCategory':'MilkyFriendCategoryEntity', 'Group':'MilkyGroupEntity',
    'GroupMember':'MilkyGroupMemberEntity', 'GroupAnnouncement':'MilkyGroupAnnouncementEntity',
    'GroupFile':'MilkyGroupFileEntity', 'GroupFolder':'MilkyGroupFolderEntity', 'FriendRequest':'MilkyFriendRequest',
    'GroupNotification':'MilkyGroupNotification', 'GroupNotificationBase':'MilkyGroupNotification', 'GroupEssenceMessage':'MilkyGroupEssenceMessage',
    'RawPacketData':'MilkyRawPacketData',
}
shared = {}
model_sources = {}
for path in (SOURCE / 'Models').rglob('*.cs'):
    text = path.read_text(encoding='utf-8-sig')
    for decl in declarations(text):
        shared[decl[0]] = decl
        model_sources[decl[0]] = text
for name, decl in list(shared.items()):
    header = model_sources[name][decl[3]:model_sources[name].find('{',decl[3])]
    parent = re.search(r':\s*(\w+)\s*$',header.strip())
    if parent and parent[1] in shared:
        base = shared[parent[1]]
        shared[name] = (decl[0],decl[1],base[2]+'\n'+decl[2],decl[3],decl[4])

emitted = {}
def emit(decl, target, local=None):
    if target in emitted: return target
    emitted[target] = ''
    local = local or {}
    def translate(t):
        t = t.replace('Models.Messages.', '').replace('Models.', '')
        def replace(m):
            n = m[0]
            if n in local:
                mapped, d = local[n]
                emit(d, mapped, local)
                return mapped
            if n in known:
                if n in ('MessageStyle','RawPacketData'): emit(shared[n], known[n])
                return known[n]
            if n in shared:
                mapped = 'Milky' + n
                emit(shared[n], mapped)
                return mapped
            return n
        return re.sub(r'\b\w+\b', replace, t)
    lines = [f'/// <summary>Wire contract for {target[5:]}.</summary>', f'public sealed record class {target}', '{']
    for wire, typ, prop, default in properties(decl):
        typ = translate(typ)
        if default is None and not typ.endswith('?'):
            if typ == 'string': default = 'string.Empty'
            elif re.match(r'(?:IReadOnlyList|List|IEnumerable)<', typ) or typ.endswith('[]'): default = '[]'
            elif typ.startswith(('IReadOnlyDictionary<','Dictionary<')): default = 'new Dictionary' + typ[typ.index('<'):] + '()'
            elif typ.startswith('Milky'): default = 'null!'
        ignore = ', JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)' if typ.endswith('?') else ''
        if target == 'MilkySendPacketRequest': ignore = ', JsonIgnore(Condition = JsonIgnoreCondition.Never)'
        lines += [f'    /// <summary>Gets or sets {wire}.</summary>', f'    [JsonPropertyName("{wire}"){ignore}]', f'    public {typ} {prop} {{ get; set; }}' + (f' = {default};' if default is not None else '')]
    lines.append('}')
    body = '\n'.join(lines)
    if target == 'MilkyRequestDecryptKeyRequest':
        body = body.replace(f'public sealed record class {target}',f'[JsonConverter(typeof(MilkyRequestDecryptKeyRequestJsonConverter))]\npublic sealed record class {target}')
        body = body.replace('public string? KeyMeta { get; set; }','public string? KeyMeta { get => _keyMeta; set { _keyMeta = value; HasKeyMeta = true; } }\n    private string? _keyMeta;\n    [JsonIgnore]\n    internal bool HasKeyMeta { get; private set; }')
    emitted[target] = body
    return target

def pascal(route): return ''.join(x.capitalize() for x in route.split('_'))
constants_text = (SDK / 'MilkyConstants.cs').read_text()
api_constants = dict((v,k) for k,v in re.findall(r'const string (\w+) = "([a-z_]+)";', constants_text.split('public static class GroupFile')[0]))
extensions = (SDK / 'MilkyApiExtensions.cs').read_text()
existing_methods = {}
for line in extensions.splitlines():
    m = re.search(r'public static Task<(.*?)> (\w+)\(.*?MilkyConstant.Api.(\w+)', line)
    if m:
        existing_methods[m[3]] = (m[2].removesuffix('Async').removesuffix('Raw'), m[1])

methods = []
entries = []
test_specs = []
added_constants = []
for path in sorted((SOURCE / 'Api/Handlers').rglob('*.cs')):
    text = path.read_text(encoding='utf-8-sig')
    for handler in declarations(text):
        name, primary, body, start, end = handler
        route = re.search(r'Post\("/api/([^"]+)"\)', body)
        if not route: continue
        route = route[1]
        # Ignore nested declarations by requiring an Endpoint base in the header.
        header = text[start:text.find('{',start)]
        if 'Endpoint' not in header: continue
        action = api_constants.get(route, pascal(route))
        if route not in api_constants: added_constants.append((action,route))
        op = existing_methods.get(action, (pascal(route),None))[0]
        nested = declarations(body)
        local = {d[0]: ('Milky'+op+d[0], d) for d in nested}
        req = local.get('Request') if 'EndpointWithoutRequest' not in header else None
        if req: emit(req[1], req[0], local)
        result_match = re.search(r'MilkyApiResponse<([\w.]+)>', header)
        result = None
        if result_match:
            result_name = result_match[1].split('.')[-1]
            if action in existing_methods:
                result = re.search(r'MilkyActionResult<([^>]+)>', existing_methods[action][1])
                result = result[1] if result else None
            elif result_name in local:
                result = emit(local[result_name][1], local[result_name][0], local)
            elif result_name in known:
                result = known[result_name]
                emit(shared[result_name], result)
            else: raise ValueError((route,result_name))
        ret = 'MilkyActionResult' + (f'<{result}>' if result else '')
        if req or action not in existing_methods or op == 'GetFriendRequests':
            args = f'{req[0]} request, ' if req else ''
            invoke = f'session.InvokeApiAsync{f"<{result}>" if result else ""}'
            param = f'JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.{req[0]})!.AsObject()' if req else 'MilkyEmptyObject.Instance'
            token_default = '' if op == 'GetFriendRequests' else ' = default'
            methods += [f'    /// <summary>Invokes {route}.</summary>', f'    public static Task<{ret}?> {op}Async(this IMilkyActionSession session, {args}CancellationToken cancellationToken{token_default})', f'        => {invoke}(MilkyConstant.Api.{action}, {param}, cancellationToken);', '']
        entries.append((route,req[0] if req else '—',result or '—',op+'Async',str(path.relative_to(SOURCE)).replace('\\','/')))
        test_specs.append((route, op, req, result, local, result_match[1].split('.')[-1] if result_match else None))

(SDK / 'MilkyLagrangeApiModels.cs').write_text('using System.Text.Json.Serialization;\n\nnamespace SaltyMilky.Net;\n\n'+'\n\n'.join(emitted.values())+'\n',encoding='utf-8')
(SDK / 'MilkyLagrangeApiExtensions.cs').write_text('using System.Text.Json;\n\nnamespace SaltyMilky.Net;\n\npublic static partial class MilkyActionSessionExtensions\n{\n'+'\n'.join(methods)+'}\n',encoding='utf-8')
for name,route in added_constants:
    constants_text = constants_text.replace('        public const string PathPrefix', f'        /// <summary>The {route} endpoint.</summary>\n        public const string {name} = "{route}";\n        public const string PathPrefix',1)
(SDK / 'MilkyConstants.cs').write_text(constants_text,encoding='utf-8')
context = (SDK / 'MilkyJsonSerializerContext.cs').read_text()
for name in emitted:
    if f'typeof({name})' not in context: context = context.replace('[JsonSourceGenerationOptions',f'[JsonSerializable(typeof({name}))]\n[JsonSourceGenerationOptions',1)
(SDK / 'MilkyJsonSerializerContext.cs').write_text(context,encoding='utf-8')
(ROOT / 'LagrangeApiCoverage.md').write_text('# Lagrange API coverage\n\nBaseline: `3a690b2919712b10cfcf77276decbb6e95e330a7`. Source: local HTTP handlers; all methods use POST.\n\n| API | Request | Result | SDK method | Source |\n|---|---|---|---|---|\n'+''.join('| '+' | '.join(e)+' |\n' for e in sorted(entries)),encoding='utf-8')
print(f'{len(entries)} routes, {len(emitted)} DTOs, {len(added_constants)} new constants')

def split_types(text):
    parts, depth, start = [], 0, 0
    for i,c in enumerate(text):
        if c == '<': depth += 1
        elif c == '>': depth -= 1
        elif c == ',' and depth == 0: parts.append(text[start:i].strip()); start = i+1
    return parts+[text[start:].strip()]

def fixture(typ, local, depth=0):
    typ = typ.removesuffix('?').replace('Lagrange.Milky.Models.','').replace('Models.Messages.','').replace('Models.','')
    if depth > 10: return None
    if typ == 'string': return 'fixture'
    if typ == 'DateTime': return '2026-10-14T00:00:00'
    if typ == 'object': return {}
    if typ == 'bool': return True
    if typ in ('byte','sbyte','short','ushort','int','uint','long','ulong','float','double','decimal'): return 23
    if typ.endswith('[]'): return [fixture(typ[:-2],local,depth+1)]
    if '<' in typ:
        args = split_types(typ[typ.index('<')+1:-1])
        if 'Dictionary' in typ.split('<')[0]: return {'fixture':fixture(args[1],local,depth+1)}
        return [fixture(args[0],local,depth+1)]
    if typ in ('IncomingSegmentBase','OutgoingSegmentBase'): return {'type':'text','data':{'text':'fixture'}}
    if typ == 'IncomingMessageBase':
        return dict(fixture('FriendIncomingMessage',local,depth+1), message_scene='friend')
    if typ == 'GroupNotificationBase':
        return dict(fixture('JoinRequestGroupNotification',local,depth+1),type='join_request')
    decl = local[typ][1] if typ in local else shared.get(typ)
    if decl is None: raise ValueError(('fixture',typ))
    return {wire:fixture(t,local,depth+1) for wire,t,prop,default in properties(decl)}

test_lines = ['using System.Text.Json;', 'using System.Text.Json.Nodes;', 'using SaltyMilky.Net;', 'using TUnit.Core;', '', 'namespace SaltyMilky.Net.Tests;', '', 'public sealed class LagrangeApiContractTests', '{']
for route,op,req,result,local,result_name in test_specs:
    response = fixture(result_name,local) if result else {}
    expected = fixture('Request',local) if req else {}
    request_json = json.dumps(expected,separators=(',',':'))
    response_json = json.dumps({'status':'ok','retcode':0,'message':None,'data':response},separators=(',',':'))
    # Raw literal fixture values are derived from server DTOs, independently of SDK serialization.
    test_lines += ['    [Test]', f'    public async Task {op}_MatchesServerWireContract()', '    {', f'        using ContractHttpHandler handler = new("{route}", """{request_json}""", """{response_json}""");', '        using HttpClient client = new(handler);', '        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });', '        using CancellationTokenSource cancellation = new();']
    if req: test_lines += [f'        {req[0]} request = JsonSerializer.Deserialize("""{request_json}""", MilkyJson.GetTypeInfo<{req[0]}>())!;']
    args = 'request, ' if req else ''
    test_lines += [f'        var result = await session.{op}Async({args}cancellationToken: cancellation.Token);', '        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");', '        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");']
    if result: test_lines += [f'        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<{result}>());', f'        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{json.dumps(response,separators=(",",":"))}"""));']
    test_lines += ['    }','']
    if req:
        defaults = {wire:json.loads(value.replace('string.Empty','""').rstrip('uUlLfFdD')) for wire,t,p,value in properties(req[1]) if value is not None and value != 'null'}
        if defaults:
            test_lines += ['    [Test]', f'    public void {op}_PreservesServerDefaults()', '    {', f'        var actual = JsonSerializer.SerializeToNode(new {req[0]}(), MilkyJson.GetTypeInfo<{req[0]}>());', f'        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{json.dumps(defaults,separators=(",",":"))}"""));','    }','']
test_lines += ['}']
(ROOT / 'SaltyMilky.Net.Tests/LagrangeApiContractTests.cs').write_text('\n'.join(test_lines)+'\n',encoding='utf-8')
smoke = [line for line in test_lines if line not in ('using TUnit.Core;', '    [Test]')]
smoke = [line.replace('class LagrangeApiContractTests','class LagrangeApiContractSmoke') for line in smoke]
default_calls = ''.join(f'        {m[1]}();\n' for m in re.finditer(r'public void (\w+_PreservesServerDefaults)\(', '\n'.join(test_lines)))
smoke.insert(smoke.index('{')+1, '    public async Task RunAsync()\n    {\n'+''.join(f'        await {op}_MatchesServerWireContract();\n' for route,op,*rest in test_specs)+default_calls+'    }')
(ROOT / 'SaltyMilky.Net.NativeAotSmoke/LagrangeApiContractSmoke.cs').write_text('\n'.join(smoke)+'\n',encoding='utf-8')
