using System;
using Zavudev.Models.Urls;

namespace Zavudev.Tests.Models.Urls;

public class UrlEscalateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlEscalateParams
        {
            UrlID = "urlId",
            Reason = "This is our official landing page and was rejected in error.",
        };

        string expectedUrlID = "urlId";
        string expectedReason = "This is our official landing page and was rejected in error.";

        Assert.Equal(expectedUrlID, parameters.UrlID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void Url_Works()
    {
        UrlEscalateParams parameters = new()
        {
            UrlID = "urlId",
            Reason = "This is our official landing page and was rejected in error.",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/urls/urlId/escalate"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlEscalateParams
        {
            UrlID = "urlId",
            Reason = "This is our official landing page and was rejected in error.",
        };

        UrlEscalateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
