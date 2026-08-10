using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<AgentKnowledgeBase> expectedItems =
        [
            new()
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
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeBaseListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<KnowledgeBaseListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentKnowledgeBase> expectedItems =
        [
            new()
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
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new KnowledgeBaseListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        KnowledgeBaseListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
