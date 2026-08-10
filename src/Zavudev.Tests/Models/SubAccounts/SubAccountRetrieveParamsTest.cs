using System;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubAccountRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SubAccountRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/sub-accounts/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubAccountRetrieveParams { ID = "id" };

        SubAccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
