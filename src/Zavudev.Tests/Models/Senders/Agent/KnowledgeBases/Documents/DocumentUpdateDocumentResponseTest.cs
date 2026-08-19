using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentUpdateDocumentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentUpdateDocumentResponse
        {
            Document = new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentLength = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsProcessed = true,
                KnowledgeBaseID = "knowledgeBaseId",
                Title = "title",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        AgentDocument expectedDocument = new()
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

        Assert.Equal(expectedDocument, model.Document);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentUpdateDocumentResponse
        {
            Document = new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentLength = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsProcessed = true,
                KnowledgeBaseID = "knowledgeBaseId",
                Title = "title",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentUpdateDocumentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentUpdateDocumentResponse
        {
            Document = new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentLength = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsProcessed = true,
                KnowledgeBaseID = "knowledgeBaseId",
                Title = "title",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentUpdateDocumentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentDocument expectedDocument = new()
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

        Assert.Equal(expectedDocument, deserialized.Document);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentUpdateDocumentResponse
        {
            Document = new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentLength = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsProcessed = true,
                KnowledgeBaseID = "knowledgeBaseId",
                Title = "title",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentUpdateDocumentResponse
        {
            Document = new()
            {
                ID = "id",
                ChunkCount = 0,
                ContentLength = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                IsProcessed = true,
                KnowledgeBaseID = "knowledgeBaseId",
                Title = "title",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        DocumentUpdateDocumentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
