using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class AgentKnowledgeBaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDocumentCount = 0;
        string expectedName = "name";
        long expectedTotalChunks = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDocumentCount, model.DocumentCount);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTotalChunks, model.TotalChunks);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentKnowledgeBase>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentKnowledgeBase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDocumentCount = 0;
        string expectedName = "name";
        long expectedTotalChunks = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDocumentCount, deserialized.DocumentCount);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTotalChunks, deserialized.TotalChunks);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentKnowledgeBase
        {
            ID = "id",
            AgentID = "agentId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentCount = 0,
            Name = "name",
            TotalChunks = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
        };

        AgentKnowledgeBase copied = new(model);

        Assert.Equal(model, copied);
    }
}
