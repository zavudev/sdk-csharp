using System;
using System.Collections.Generic;
using Tools = Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "foo",
                        new() { Description = "description", Type = "type" }
                    },
                },
                Required = ["string"],
                Type = Tools::Type.Object,
            },
            WebhookSecret = "webhookSecret",
            WebhookUrl = "https://example.com",
        };

        string expectedSenderID = "senderId";
        string expectedToolID = "toolId";
        string expectedDescription = "description";
        bool expectedEnabled = true;
        string expectedName = "name";
        Tools::ToolParameters expectedParameters = new()
        {
            Properties = new Dictionary<string, Tools::PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Tools::Type.Object,
        };
        string expectedWebhookSecret = "webhookSecret";
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedToolID, parameters.ToolID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedParameters, parameters.Parameters);
        Assert.Equal(expectedWebhookSecret, parameters.WebhookSecret);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            WebhookSecret = "webhookSecret",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Parameters);
        Assert.False(parameters.RawBodyData.ContainsKey("parameters"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            WebhookSecret = "webhookSecret",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Enabled = null,
            Name = null,
            Parameters = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Parameters);
        Assert.False(parameters.RawBodyData.ContainsKey("parameters"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "foo",
                        new() { Description = "description", Type = "type" }
                    },
                },
                Required = ["string"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://example.com",
        };

        Assert.Null(parameters.WebhookSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "foo",
                        new() { Description = "description", Type = "type" }
                    },
                },
                Required = ["string"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://example.com",

            WebhookSecret = null,
        };

        Assert.Null(parameters.WebhookSecret);
        Assert.True(parameters.RawBodyData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        Tools::ToolUpdateParams parameters = new() { SenderID = "senderId", ToolID = "toolId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/tools/toolId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Tools::ToolUpdateParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "foo",
                        new() { Description = "description", Type = "type" }
                    },
                },
                Required = ["string"],
                Type = Tools::Type.Object,
            },
            WebhookSecret = "webhookSecret",
            WebhookUrl = "https://example.com",
        };

        Tools::ToolUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
