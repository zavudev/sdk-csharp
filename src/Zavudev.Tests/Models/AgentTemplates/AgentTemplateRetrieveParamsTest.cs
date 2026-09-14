using System;
using Zavudev.Models.AgentTemplates;

namespace Zavudev.Tests.Models.AgentTemplates;

public class AgentTemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentTemplateRetrieveParams { TemplateID = "fermi" };

        string expectedTemplateID = "fermi";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void Url_Works()
    {
        AgentTemplateRetrieveParams parameters = new() { TemplateID = "fermi" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/agent-templates/fermi"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentTemplateRetrieveParams { TemplateID = "fermi" };

        AgentTemplateRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
