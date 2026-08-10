using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class IntrospectServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ValidatePhone_Works()
    {
        var response = await this.client.Introspect.ValidatePhone(
            new() { PhoneNumber = "+56912345678" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
