using System;
using Zavudev.Core;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateSubmitParams
        {
            TemplateID = "templateId",
            SenderID = "sender_abc123",
            Category = WhatsappCategory.Utility,
        };

        string expectedTemplateID = "templateId";
        string expectedSenderID = "sender_abc123";
        ApiEnum<string, WhatsappCategory> expectedCategory = WhatsappCategory.Utility;

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedCategory, parameters.Category);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateSubmitParams
        {
            TemplateID = "templateId",
            SenderID = "sender_abc123",
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateSubmitParams
        {
            TemplateID = "templateId",
            SenderID = "sender_abc123",

            // Null should be interpreted as omitted for these properties
            Category = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateSubmitParams parameters = new()
        {
            TemplateID = "templateId",
            SenderID = "sender_abc123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/templates/templateId/submit"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateSubmitParams
        {
            TemplateID = "templateId",
            SenderID = "sender_abc123",
            Category = WhatsappCategory.Utility,
        };

        TemplateSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
