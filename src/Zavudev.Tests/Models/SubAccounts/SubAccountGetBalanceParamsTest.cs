using System;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountGetBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubAccountGetBalanceParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SubAccountGetBalanceParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/sub-accounts/id/balance"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubAccountGetBalanceParams { ID = "id" };

        SubAccountGetBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
