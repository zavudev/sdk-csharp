using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Tests.Models.Senders.Agent.Executions;

public class ExecutionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutionRetrieveResponse
        {
            Execution = new()
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
        };

        AgentExecution expectedExecution = new()
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
        };

        Assert.Equal(expectedExecution, model.Execution);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutionRetrieveResponse
        {
            Execution = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutionRetrieveResponse
        {
            Execution = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentExecution expectedExecution = new()
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
        };

        Assert.Equal(expectedExecution, deserialized.Execution);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutionRetrieveResponse
        {
            Execution = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutionRetrieveResponse
        {
            Execution = new()
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
        };

        ExecutionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
