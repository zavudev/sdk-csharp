using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Tools = Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<Tools::AgentTool> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::ToolListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tools::ToolListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Tools::AgentTool> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tools::ToolListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        Tools::ToolListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
