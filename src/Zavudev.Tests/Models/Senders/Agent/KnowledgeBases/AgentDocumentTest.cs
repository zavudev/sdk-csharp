using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class AgentDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDocument
        {
            ID = "id",
            ChunkCount = 0,
            ContentLength = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsProcessed = true,
            KnowledgeBaseID = "knowledgeBaseId",
            Title = "title",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        long expectedChunkCount = 0;
        long expectedContentLength = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsProcessed = true;
        string expectedKnowledgeBaseID = "knowledgeBaseId";
        string expectedTitle = "title";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChunkCount, model.ChunkCount);
        Assert.Equal(expectedContentLength, model.ContentLength);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIsProcessed, model.IsProcessed);
        Assert.Equal(expectedKnowledgeBaseID, model.KnowledgeBaseID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentDocument
        {
            ID = "id",
            ChunkCount = 0,
            ContentLength = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsProcessed = true,
            KnowledgeBaseID = "knowledgeBaseId",
            Title = "title",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDocument
        {
            ID = "id",
            ChunkCount = 0,
            ContentLength = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsProcessed = true,
            KnowledgeBaseID = "knowledgeBaseId",
            Title = "title",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedChunkCount = 0;
        long expectedContentLength = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedIsProcessed = true;
        string expectedKnowledgeBaseID = "knowledgeBaseId";
        string expectedTitle = "title";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChunkCount, deserialized.ChunkCount);
        Assert.Equal(expectedContentLength, deserialized.ContentLength);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIsProcessed, deserialized.IsProcessed);
        Assert.Equal(expectedKnowledgeBaseID, deserialized.KnowledgeBaseID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentDocument
        {
            ID = "id",
            ChunkCount = 0,
            ContentLength = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsProcessed = true,
            KnowledgeBaseID = "knowledgeBaseId",
            Title = "title",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentDocument
        {
            ID = "id",
            ChunkCount = 0,
            ContentLength = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsProcessed = true,
            KnowledgeBaseID = "knowledgeBaseId",
            Title = "title",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AgentDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}
