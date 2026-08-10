using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new KnowledgeBaseCreateResponse
        {
            KnowledgeBase = new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentCount = 0,
                Name = "name",
                TotalChunks = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        };

        AgentKnowledgeBase expectedKnowledgeBase = new()
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

        Assert.Equal(expectedKnowledgeBase, model.KnowledgeBase);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new KnowledgeBaseCreateResponse
        {
            KnowledgeBase = new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentCount = 0,
                Name = "name",
                TotalChunks = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeBaseCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new KnowledgeBaseCreateResponse
        {
            KnowledgeBase = new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentCount = 0,
                Name = "name",
                TotalChunks = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeBaseCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentKnowledgeBase expectedKnowledgeBase = new()
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

        Assert.Equal(expectedKnowledgeBase, deserialized.KnowledgeBase);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new KnowledgeBaseCreateResponse
        {
            KnowledgeBase = new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentCount = 0,
                Name = "name",
                TotalChunks = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new KnowledgeBaseCreateResponse
        {
            KnowledgeBase = new()
            {
                ID = "id",
                AgentID = "agentId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentCount = 0,
                Name = "name",
                TotalChunks = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
            },
        };

        KnowledgeBaseCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
