using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Flows = Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowDuplicateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Flows::FlowDuplicateResponse
        {
            Flow = new()
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
        };

        Flows::AgentFlow expectedFlow = new()
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
        };

        Assert.Equal(expectedFlow, model.Flow);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Flows::FlowDuplicateResponse
        {
            Flow = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::FlowDuplicateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Flows::FlowDuplicateResponse
        {
            Flow = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::FlowDuplicateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Flows::AgentFlow expectedFlow = new()
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
        };

        Assert.Equal(expectedFlow, deserialized.Flow);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Flows::FlowDuplicateResponse
        {
            Flow = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Flows::FlowDuplicateResponse
        {
            Flow = new()
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
        };

        Flows::FlowDuplicateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
