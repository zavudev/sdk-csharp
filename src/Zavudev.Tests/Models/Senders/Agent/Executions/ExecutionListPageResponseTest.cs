using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Tests.Models.Senders.Agent.Executions;

public class ExecutionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
            NextCursor = "nextCursor",
        };

        List<AgentExecution> expectedItems =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InputTokens = 0,
                LatencyMs = 0,
                OutputTokens = 0,
                Status = AgentExecutionStatus.Success,
                ErrorMessage = "errorMessage",
                InboundMessageID = "inboundMessageId",
                KnowledgeChunksUsed = 0,
                ResponseMessageID = "responseMessageId",
                ResponseText = "responseText",
                ToolCalls = 0,
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
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentExecution> expectedItems =
        [
            new()
            {
                ID = "id",
                AgentID = "agentId",
                Cost = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InputTokens = 0,
                LatencyMs = 0,
                OutputTokens = 0,
                Status = AgentExecutionStatus.Success,
                ErrorMessage = "errorMessage",
                InboundMessageID = "inboundMessageId",
                KnowledgeChunksUsed = 0,
                ResponseMessageID = "responseMessageId",
                ResponseText = "responseText",
                ToolCalls = 0,
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
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
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
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    AgentID = "agentId",
                    Cost = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InputTokens = 0,
                    LatencyMs = 0,
                    OutputTokens = 0,
                    Status = AgentExecutionStatus.Success,
                    ErrorMessage = "errorMessage",
                    InboundMessageID = "inboundMessageId",
                    KnowledgeChunksUsed = 0,
                    ResponseMessageID = "responseMessageId",
                    ResponseText = "responseText",
                    ToolCalls = 0,
                },
            ],
            NextCursor = "nextCursor",
        };

        ExecutionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
