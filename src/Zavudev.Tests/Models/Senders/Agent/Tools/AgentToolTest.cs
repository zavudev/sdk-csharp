using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Tools = Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class AgentToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
            WebhookSecret = "whsec_abc123...",
        };

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnabled = true;
        string expectedName = "get_order_status";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebhookUrl = "https://example.com";
        string expectedWebhookSecret = "whsec_abc123...";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParameters, model.Parameters);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
        Assert.Equal(expectedWebhookSecret, model.WebhookSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
            WebhookSecret = "whsec_abc123...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::AgentTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
            WebhookSecret = "whsec_abc123...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::AgentTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedEnabled = true;
        string expectedName = "get_order_status";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebhookUrl = "https://example.com";
        string expectedWebhookSecret = "whsec_abc123...";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParameters, deserialized.Parameters);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
        Assert.Equal(expectedWebhookSecret, deserialized.WebhookSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
            WebhookSecret = "whsec_abc123...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
        };

        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            WebhookSecret = null,
        };

        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            WebhookSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tools::AgentTool
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            Enabled = true,
            Name = "get_order_status",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookUrl = "https://example.com",
            WebhookSecret = "whsec_abc123...",
        };

        Tools::AgentTool copied = new(model);

        Assert.Equal(model, copied);
    }
}
