using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent;

[JsonConverter(typeof(JsonModelConverter<AgentExecution, AgentExecutionFromRaw>))]
public sealed record class AgentExecution : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentId");
        }
        init { this._rawData.Set("agentId", value); }
    }

    /// <summary>
    /// Cost in USD.
    /// </summary>
    public required double Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("inputTokens");
        }
        init { this._rawData.Set("inputTokens", value); }
    }

    public required long LatencyMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("latencyMs");
        }
        init { this._rawData.Set("latencyMs", value); }
    }

    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("outputTokens");
        }
        init { this._rawData.Set("outputTokens", value); }
    }

    /// <summary>
    /// Status of an agent execution.
    /// </summary>
    public required ApiEnum<string, AgentExecutionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AgentExecutionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    public string? InboundMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inboundMessageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("inboundMessageId", value);
        }
    }

    /// <summary>
    /// Knowledge-base chunks retrieved for this answer. Zero on an agent that has
    /// documents attached means the reply was not grounded in them, which is otherwise
    /// indistinguishable from a correct answer in this record. Absent on executions
    /// recorded before this field existed, which is not the same as zero.
    /// </summary>
    public long? KnowledgeChunksUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("knowledgeChunksUsed");
        }
        init { this._rawData.Set("knowledgeChunksUsed", value); }
    }

    public string? ResponseMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("responseMessageId");
        }
        init { this._rawData.Set("responseMessageId", value); }
    }

    public string? ResponseText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("responseText");
        }
        init { this._rawData.Set("responseText", value); }
    }

    /// <summary>
    /// Tools the agent called while producing this reply. Zero on an agent that has
    /// tools configured means it answered without calling any — the case where a
    /// reply says it will look something up and nothing ever reaches your endpoint.
    /// Absent on executions recorded before this field existed, which is not the
    /// same as zero.
    /// </summary>
    public long? ToolCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("toolCalls");
        }
        init { this._rawData.Set("toolCalls", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.Cost;
        _ = this.CreatedAt;
        _ = this.InputTokens;
        _ = this.LatencyMs;
        _ = this.OutputTokens;
        this.Status.Validate();
        _ = this.ErrorMessage;
        _ = this.InboundMessageID;
        _ = this.KnowledgeChunksUsed;
        _ = this.ResponseMessageID;
        _ = this.ResponseText;
        _ = this.ToolCalls;
    }

    public AgentExecution() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentExecution(AgentExecution agentExecution)
        : base(agentExecution) { }
#pragma warning restore CS8618

    public AgentExecution(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentExecution(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentExecutionFromRaw.FromRawUnchecked"/>
    public static AgentExecution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentExecutionFromRaw : IFromRawJson<AgentExecution>
{
    /// <inheritdoc/>
    public AgentExecution FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentExecution.FromRawUnchecked(rawData);
}
