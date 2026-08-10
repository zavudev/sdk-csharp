using System;
using Zavudev.Models.Urls;

namespace Zavudev.Tests.Models.Urls;

public class UrlSubmitForVerificationParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlSubmitForVerificationParams
        {
            UrlValue = "https://example.com/page",
        };

        string expectedUrlValue = "https://example.com/page";

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
    }

    [Fact]
    public void Url_Works()
    {
        UrlSubmitForVerificationParams parameters = new() { UrlValue = "https://example.com/page" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/urls"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlSubmitForVerificationParams
        {
            UrlValue = "https://example.com/page",
        };

        UrlSubmitForVerificationParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
