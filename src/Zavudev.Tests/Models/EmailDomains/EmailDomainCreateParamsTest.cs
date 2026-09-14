using System;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Tests.Models.EmailDomains;

public class EmailDomainCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EmailDomainCreateParams { Domain = "example.com" };

        string expectedDomain = "example.com";

        Assert.Equal(expectedDomain, parameters.Domain);
    }

    [Fact]
    public void Url_Works()
    {
        EmailDomainCreateParams parameters = new() { Domain = "example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/email-domains"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EmailDomainCreateParams { Domain = "example.com" };

        EmailDomainCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
