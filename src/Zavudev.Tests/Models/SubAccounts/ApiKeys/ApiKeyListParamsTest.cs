using System;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Tests.Models.SubAccounts.ApiKeys;

public class ApiKeyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyListParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyListParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/sub-accounts/id/api-keys"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyListParams { ID = "id" };

        ApiKeyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
