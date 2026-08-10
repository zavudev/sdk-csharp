using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentExecutionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentExecution
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

        string expectedID = "id";
        string expectedAgentID = "agentId";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedInputTokens = 0;
        long expectedLatencyMs = 0;
        long expectedOutputTokens = 0;
        ApiEnum<string, AgentExecutionStatus> expectedStatus = AgentExecutionStatus.Success;
        string expectedErrorMessage = "errorMessage";
        string expectedInboundMessageID = "inboundMessageId";
        long expectedKnowledgeChunksUsed = 0;
        string expectedResponseMessageID = "responseMessageId";
        string expectedResponseText = "responseText";
        long expectedToolCalls = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentID, model.AgentID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedLatencyMs, model.LatencyMs);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedInboundMessageID, model.InboundMessageID);
        Assert.Equal(expectedKnowledgeChunksUsed, model.KnowledgeChunksUsed);
        Assert.Equal(expectedResponseMessageID, model.ResponseMessageID);
        Assert.Equal(expectedResponseText, model.ResponseText);
        Assert.Equal(expectedToolCalls, model.ToolCalls);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentExecution
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentExecution>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentExecution
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentExecution>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAgentID = "agentId";
        double expectedCost = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedInputTokens = 0;
        long expectedLatencyMs = 0;
        long expectedOutputTokens = 0;
        ApiEnum<string, AgentExecutionStatus> expectedStatus = AgentExecutionStatus.Success;
        string expectedErrorMessage = "errorMessage";
        string expectedInboundMessageID = "inboundMessageId";
        long expectedKnowledgeChunksUsed = 0;
        string expectedResponseMessageID = "responseMessageId";
        string expectedResponseText = "responseText";
        long expectedToolCalls = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentID, deserialized.AgentID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedLatencyMs, deserialized.LatencyMs);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedInboundMessageID, deserialized.InboundMessageID);
        Assert.Equal(expectedKnowledgeChunksUsed, deserialized.KnowledgeChunksUsed);
        Assert.Equal(expectedResponseMessageID, deserialized.ResponseMessageID);
        Assert.Equal(expectedResponseText, deserialized.ResponseText);
        Assert.Equal(expectedToolCalls, deserialized.ToolCalls);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentExecution
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentExecution
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
            KnowledgeChunksUsed = 0,
            ResponseMessageID = "responseMessageId",
            ResponseText = "responseText",
            ToolCalls = 0,
        };

        Assert.Null(model.InboundMessageID);
        Assert.False(model.RawData.ContainsKey("inboundMessageId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentExecution
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
            KnowledgeChunksUsed = 0,
            ResponseMessageID = "responseMessageId",
            ResponseText = "responseText",
            ToolCalls = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentExecution
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
            KnowledgeChunksUsed = 0,
            ResponseMessageID = "responseMessageId",
            ResponseText = "responseText",
            ToolCalls = 0,

            // Null should be interpreted as omitted for these properties
            InboundMessageID = null,
        };

        Assert.Null(model.InboundMessageID);
        Assert.False(model.RawData.ContainsKey("inboundMessageId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentExecution
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
            KnowledgeChunksUsed = 0,
            ResponseMessageID = "responseMessageId",
            ResponseText = "responseText",
            ToolCalls = 0,

            // Null should be interpreted as omitted for these properties
            InboundMessageID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentExecution
        {
            ID = "id",
            AgentID = "agentId",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InputTokens = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Status = AgentExecutionStatus.Success,
            InboundMessageID = "inboundMessageId",
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.KnowledgeChunksUsed);
        Assert.False(model.RawData.ContainsKey("knowledgeChunksUsed"));
        Assert.Null(model.ResponseMessageID);
        Assert.False(model.RawData.ContainsKey("responseMessageId"));
        Assert.Null(model.ResponseText);
        Assert.False(model.RawData.ContainsKey("responseText"));
        Assert.Null(model.ToolCalls);
        Assert.False(model.RawData.ContainsKey("toolCalls"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentExecution
        {
            ID = "id",
            AgentID = "agentId",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InputTokens = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Status = AgentExecutionStatus.Success,
            InboundMessageID = "inboundMessageId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentExecution
        {
            ID = "id",
            AgentID = "agentId",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InputTokens = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Status = AgentExecutionStatus.Success,
            InboundMessageID = "inboundMessageId",

            ErrorMessage = null,
            KnowledgeChunksUsed = null,
            ResponseMessageID = null,
            ResponseText = null,
            ToolCalls = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.KnowledgeChunksUsed);
        Assert.True(model.RawData.ContainsKey("knowledgeChunksUsed"));
        Assert.Null(model.ResponseMessageID);
        Assert.True(model.RawData.ContainsKey("responseMessageId"));
        Assert.Null(model.ResponseText);
        Assert.True(model.RawData.ContainsKey("responseText"));
        Assert.Null(model.ToolCalls);
        Assert.True(model.RawData.ContainsKey("toolCalls"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentExecution
        {
            ID = "id",
            AgentID = "agentId",
            Cost = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InputTokens = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Status = AgentExecutionStatus.Success,
            InboundMessageID = "inboundMessageId",

            ErrorMessage = null,
            KnowledgeChunksUsed = null,
            ResponseMessageID = null,
            ResponseText = null,
            ToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentExecution
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

        AgentExecution copied = new(model);

        Assert.Equal(model, copied);
    }
}
