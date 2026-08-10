using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Flows = Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class AgentFlowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Flows::AgentFlow
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

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedEnabled = true;
        string expectedName = "name";
        long expectedPriority = 0;
        List<Flows::FlowStep> expectedSteps =
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
        ];
        Flows::FlowTrigger expectedTrigger = new()
        {
            Type = Flows::FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPriority, model.Priority);
        Assert.Equal(expectedSteps.Count, model.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], model.Steps[i]);
        }
        Assert.Equal(expectedTrigger, model.Trigger);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Flows::AgentFlow
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::AgentFlow>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Flows::AgentFlow
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Flows::AgentFlow>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedEnabled = true;
        string expectedName = "name";
        long expectedPriority = 0;
        List<Flows::FlowStep> expectedSteps =
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
        ];
        Flows::FlowTrigger expectedTrigger = new()
        {
            Type = Flows::FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPriority, deserialized.Priority);
        Assert.Equal(expectedSteps.Count, deserialized.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], deserialized.Steps[i]);
        }
        Assert.Equal(expectedTrigger, deserialized.Trigger);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Flows::AgentFlow
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Flows::AgentFlow
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
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Flows::AgentFlow
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Flows::AgentFlow
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

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Flows::AgentFlow
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

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Flows::AgentFlow
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

        Flows::AgentFlow copied = new(model);

        Assert.Equal(model, copied);
    }
}
