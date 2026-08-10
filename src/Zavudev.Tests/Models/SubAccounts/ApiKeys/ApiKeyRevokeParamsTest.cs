using System;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Tests.Models.SubAccounts.ApiKeys;

public class ApiKeyRevokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeyRevokeParams { ID = "id", KeyID = "keyId" };

        string expectedID = "id";
        string expectedKeyID = "keyId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedKeyID, parameters.KeyID);
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeyRevokeParams parameters = new() { ID = "id", KeyID = "keyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/sub-accounts/id/api-keys/keyId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeyRevokeParams { ID = "id", KeyID = "keyId" };

        ApiKeyRevokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
