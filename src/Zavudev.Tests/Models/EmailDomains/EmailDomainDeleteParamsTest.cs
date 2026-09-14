using System;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Tests.Models.EmailDomains;

public class EmailDomainDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EmailDomainDeleteParams { DomainID = "domainId" };

        string expectedDomainID = "domainId";

        Assert.Equal(expectedDomainID, parameters.DomainID);
    }

    [Fact]
    public void Url_Works()
    {
        EmailDomainDeleteParams parameters = new() { DomainID = "domainId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/email-domains/domainId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EmailDomainDeleteParams { DomainID = "domainId" };

        EmailDomainDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
