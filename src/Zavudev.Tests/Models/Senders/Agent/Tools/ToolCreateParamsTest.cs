using System;
using System.Collections.Generic;
using Tools = Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Tools::ToolCreateParams
        {
            SenderID = "senderId",
            Description = "Get the status of a customer order",
            Name = "get_order_status",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "order_id",
                        new() { Description = "The order ID to look up", Type = "string" }
                    },
                },
                Required = ["order_id"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://api.example.com/webhooks/order-status",
            Enabled = true,
            WebhookSecret = "whsec_...",
        };

        string expectedSenderID = "senderId";
        string expectedDescription = "Get the status of a customer order";
        string expectedName = "get_order_status";
        Tools::ToolParameters expectedParameters = new()
        {
            Properties = new Dictionary<string, Tools::PropertiesItem>()
            {
                {
                    "order_id",
                    new() { Description = "The order ID to look up", Type = "string" }
                },
            },
            Required = ["order_id"],
            Type = Tools::Type.Object,
        };
        string expectedWebhookUrl = "https://api.example.com/webhooks/order-status";
        bool expectedEnabled = true;
        string expectedWebhookSecret = "whsec_...";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedParameters, parameters.Parameters);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedWebhookSecret, parameters.WebhookSecret);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Tools::ToolCreateParams
        {
            SenderID = "senderId",
            Description = "Get the status of a customer order",
            Name = "get_order_status",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "order_id",
                        new() { Description = "The order ID to look up", Type = "string" }
                    },
                },
                Required = ["order_id"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://api.example.com/webhooks/order-status",
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.WebhookSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Tools::ToolCreateParams
        {
            SenderID = "senderId",
            Description = "Get the status of a customer order",
            Name = "get_order_status",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "order_id",
                        new() { Description = "The order ID to look up", Type = "string" }
                    },
                },
                Required = ["order_id"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://api.example.com/webhooks/order-status",

            // Null should be interpreted as omitted for these properties
            Enabled = null,
            WebhookSecret = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.WebhookSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void Url_Works()
    {
        Tools::ToolCreateParams parameters = new()
        {
            SenderID = "senderId",
            Description = "Get the status of a customer order",
            Name = "get_order_status",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "order_id",
                        new() { Description = "The order ID to look up", Type = "string" }
                    },
                },
                Required = ["order_id"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://api.example.com/webhooks/order-status",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/agent/tools"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Tools::ToolCreateParams
        {
            SenderID = "senderId",
            Description = "Get the status of a customer order",
            Name = "get_order_status",
            Parameters = new()
            {
                Properties = new Dictionary<string, Tools::PropertiesItem>()
                {
                    {
                        "order_id",
                        new() { Description = "The order ID to look up", Type = "string" }
                    },
                },
                Required = ["order_id"],
                Type = Tools::Type.Object,
            },
            WebhookUrl = "https://api.example.com/webhooks/order-status",
            Enabled = true,
            WebhookSecret = "whsec_...",
        };

        Tools::ToolCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
