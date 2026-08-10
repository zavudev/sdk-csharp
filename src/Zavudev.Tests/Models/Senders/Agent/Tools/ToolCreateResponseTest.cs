using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Tools = Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tools::ToolCreateResponse
        {
            Tool = new()
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
            },
        };

        Tools::AgentTool expectedTool = new()
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

        Assert.Equal(expectedTool, model.Tool);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tools::ToolCreateResponse
        {
            Tool = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::ToolCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tools::ToolCreateResponse
        {
            Tool = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::ToolCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Tools::AgentTool expectedTool = new()
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

        Assert.Equal(expectedTool, deserialized.Tool);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tools::ToolCreateResponse
        {
            Tool = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tools::ToolCreateResponse
        {
            Tool = new()
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
            },
        };

        Tools::ToolCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
