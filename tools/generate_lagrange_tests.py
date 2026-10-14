"""Generate server-derived message/event wire fixtures in addition to API fixtures."""
import re
import runpy
from pathlib import Path
g = runpy.run_path(str(Path(__file__).with_name('generate_lagrange_contracts.py')))
source,sdk,root = g['SOURCE'],g['SDK'],g['ROOT']
fixture, declarations, properties = (g[k] for k in ('fixture','declarations','properties'))
json = g['json']
lines = ['using System.Text.Json;', 'using System.Text.Json.Nodes;', 'using SaltyMilky.Net;', 'using TUnit.Core;', '', 'namespace SaltyMilky.Net.Tests;', '', 'public sealed class LagrangeMessageEventContractTests', '{']
registry = (source / 'Models/Segments/SegmentBase.cs').read_text()
for direction in ('Incoming','Outgoing'):
    reg = registry.split('[JsonPolymorphic')[1 if direction=='Incoming' else 2]
    for source_name,wire in re.findall(r'JsonDerivedType\(typeof\((\w+)\), "([^"]+)"',reg):
        data_name = source_name+'Data'
        if data_name not in g['shared']: data_name = source_name.replace(direction,'')+'Data'
        if wire == 'mention_all': data_name = 'object'
        expected = {'type':wire,'data':fixture(data_name,{})}
        js = json.dumps(expected,separators=(',',':'))
        lines += ['    [Test]',f'    public void {source_name}_RetainsAllServerFields()', '    {',f'        const string json = """{js}""";',f'        var segment = JsonSerializer.Deserialize(json, MilkyJson.{direction}SegmentTypeInfo)!;',f'        ContractHttpHandler.Check(segment.Type == "{wire}", "Known segment should retain its type.");',f'        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.{direction}SegmentTypeInfo);','        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));','    }','']

new_events = {'packet_received','group_member_card_change','friend_remark_changed','friend_input_status','online_devices_changed','friend_profile_like','group_special_title_change','friend_added','group_self_joined'}
callbacks = []
seen = set()
for path in sorted((source / 'Events/Converters').glob('*.cs')):
    text = path.read_text()
    for decl in declarations(text):
        name,primary,body,start,end = decl
        match = re.search(r'public string Name => "([^"]+)"',body)
        if not match or match[1] in seen: continue
        wire = match[1]; op = g['pascal'](wire)
        local = {d[0]:(d[0],d) for d in declarations(text)}
        local.update({d[0]:(d[0],d) for d in declarations(body)})
        header = text[start:text.find('{',start)]
        payload_match = re.search(r'IEventConverter<[^,]+,\s*([\w.]+)>',header)
        if payload_match is None: continue
        seen.add(wire)
        payload_type = payload_match[1].split('.')[-1]
        expected = {'event_type':wire,'time':23,'self_id':23,'data':fixture(payload_type,local)}
        js = json.dumps(expected,separators=(',',':'))
        lines += ['    [Test]',f'    public async Task {op}_ParsesSerializesAndDispatches()', '    {',f'        const string json = """{js}""";', '        var evt = MilkyEventParser.ParseJson(json)!;', '        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");', '        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;', '        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);', '        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });', '        using CancellationTokenSource cancellation = new();', '        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);', '        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");']
        if wire in new_events:
            dtype,ctype = 'Milky'+op+'EventData','Milky'+op+'Context'
            lines += [f'        ContractHttpHandler.Check(evt.Data is {dtype} && context is {ctype}, "Expected specialized event and context.");','        CountingPlugin plugin = new();','        session.UsePlugin(plugin);','        int registered = 0;',f'        session.Use{op}((data, envelope) => {{ registered++; }});',f'        session.Use{op}((data, envelope) => {{ registered++; return Task.CompletedTask; }});',f'        session.Use{op}(async (data, envelope, next) => {{ registered++; await next(); }});','        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);','        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");']
            callbacks += [f'        public override Task On{op}Async({dtype} data, MilkyEvent evt) {{ DataCalls++; return Task.CompletedTask; }}', f'        protected override Task On{op}Async({ctype} context) {{ ContextCalls++; return Task.CompletedTask; }}']
        else: lines += ['        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);']
        lines += ['    }','']
lines += ['    private sealed class CountingPlugin : MilkyEventPlugin','    {','        public int DataCalls;','        public int ContextCalls;']+callbacks+['    }','}']
(root / 'SaltyMilky.Net.Tests/LagrangeMessageEventContractTests.cs').write_text('\n'.join(lines)+'\n',encoding='utf-8')
smoke = [line for line in lines if line not in ('using TUnit.Core;', '    [Test]')]
smoke = [line.replace('class LagrangeMessageEventContractTests','class LagrangeMessageEventContractSmoke') for line in smoke]
calls = []
for line in lines:
    m = re.match(r'    public (async Task|void) (\w+)\(',line)
    if m: calls.append('        '+('await ' if m[1]=='async Task' else '')+m[2]+'();')
smoke.insert(smoke.index('{')+1,'    public async Task RunAsync()\n    {\n'+'\n'.join(calls)+'\n    }')
(root / 'SaltyMilky.Net.NativeAotSmoke/LagrangeMessageEventContractSmoke.cs').write_text('\n'.join(smoke)+'\n',encoding='utf-8')
print(f'{len(seen)} event fixtures generated')
