using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<AgentDocument> expectedItems =
        [
            new()
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
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentDocument> expectedItems =
        [
            new()
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
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        DocumentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
