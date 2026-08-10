using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class BalanceServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var balance = await this.client.Balance.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        balance.Validate();
    }
}
