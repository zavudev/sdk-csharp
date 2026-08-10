using System;
using Zavudev.Models.Urls;

namespace Zavudev.Tests.Models.Urls;

public class UrlRetrieveDetailsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlRetrieveDetailsParams { UrlID = "urlId" };

        string expectedUrlID = "urlId";

        Assert.Equal(expectedUrlID, parameters.UrlID);
    }

    [Fact]
    public void Url_Works()
    {
        UrlRetrieveDetailsParams parameters = new() { UrlID = "urlId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/urls/urlId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlRetrieveDetailsParams { UrlID = "urlId" };

        UrlRetrieveDetailsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
