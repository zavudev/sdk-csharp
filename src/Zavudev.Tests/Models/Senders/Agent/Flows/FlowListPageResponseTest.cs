using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Flows = Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Flows::AgentFlow> expectedItems =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Enabled = true,
                Name = "name",
                Priority = 0,
                Steps =
                [
                    new()
                    {
                        ID = "id",
                        Config = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Flows::Type.Message,
                        NextStepID = "nextStepId",
                    },
                ],
                Trigger = new()
                {
                    Type = Flows::FlowTriggerType.Keyword,
                    Intent = "intent",
                    Keywords = ["string"],
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
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
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::FlowListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::FlowListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Flows::AgentFlow> expectedItems =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Enabled = true,
                Name = "name",
                Priority = 0,
                Steps =
                [
                    new()
                    {
                        ID = "id",
                        Config = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Flows::Type.Message,
                        NextStepID = "nextStepId",
                    },
                ],
                Trigger = new()
                {
                    Type = Flows::FlowTriggerType.Keyword,
                    Intent = "intent",
                    Keywords = ["string"],
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
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
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
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
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Flows::FlowListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Enabled = true,
                    Name = "name",
                    Priority = 0,
                    Steps =
                    [
                        new()
                        {
                            ID = "id",
                            Config = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type = Flows::Type.Message,
                            NextStepID = "nextStepId",
                        },
                    ],
                    Trigger = new()
                    {
                        Type = Flows::FlowTriggerType.Keyword,
                        Intent = "intent",
                        Keywords = ["string"],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                },
            ],
            NextCursor = "nextCursor",
        };

        Flows::FlowListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
