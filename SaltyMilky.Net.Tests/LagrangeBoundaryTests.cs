using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class LagrangeBoundaryTests
{
    [Test]
    public Task BoundaryContracts_WorkWithoutReflection() => LagrangeBoundaryContracts.RunAsync();
}
