using System;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateDeleteParams { TemplateID = "templateId" };

        string expectedTemplateID = "templateId";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }

    [Fact]
    public void Url_Works()
    {
        TemplateDeleteParams parameters = new() { TemplateID = "templateId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/templates/templateId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateDeleteParams { TemplateID = "templateId" };

        TemplateDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
