using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentTestResponse, AgentTestResponseFromRaw>))]
public sealed record class AgentTestResponse : JsonModel
{
    public required string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
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

    /// <summary>
    /// Knowledge-base chunks retrieved for this message. Zero means the answer was
    /// not grounded in your documents.
    /// </summary>
    public required long KnowledgeChunksUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("knowledgeChunksUsed");
        }
        init { this._rawData.Set("knowledgeChunksUsed", value); }
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

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// What the agent would reply.
    /// </summary>
    public required string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Things that are true of this agent but that a dry run cannot prove. Surfaced
    /// so a passing dry run is never mistaken for proof that the agent works live.
    ///
    /// <para>- The agent being disabled. - Enabled tools that were **not offered
    /// to the model** here — the model never saw them, so a reply that looks like
    /// a lookup was invented. Live conversations on every channel do offer them;
    /// running them here would cause real side effects. - An agent whose sender has
    /// none of the channels it triggers on, which answers every dry run and no real
    /// message. - Contact metadata that exists on a real conversation but not here.</para>
    /// </summary>
    public required IReadOnlyList<string> Warnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("warnings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "warnings",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Tools that actually ran, in order, when the request set `executeTools`. Empty
    /// on a normal dry run, where nothing is executed. An entry with `ok: false`
    /// means the agent saw an error and answered around it, which is what a customer
    /// would have received.
    /// </summary>
    public IReadOnlyList<ExecutedToolCall>? ExecutedToolCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ExecutedToolCall>>(
                "executedToolCalls"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ExecutedToolCall>?>(
                "executedToolCalls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.InputTokens;
        _ = this.KnowledgeChunksUsed;
        _ = this.LatencyMs;
        _ = this.OutputTokens;
        _ = this.Success;
        _ = this.Text;
        _ = this.Warnings;
        foreach (var item in this.ExecutedToolCalls ?? [])
        {
            item.Validate();
        }
    }

    public AgentTestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTestResponse(AgentTestResponse agentTestResponse)
        : base(agentTestResponse) { }
#pragma warning restore CS8618

    public AgentTestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentTestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentTestResponseFromRaw.FromRawUnchecked"/>
    public static AgentTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentTestResponseFromRaw : IFromRawJson<AgentTestResponse>
{
    /// <inheritdoc/>
    public AgentTestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentTestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ExecutedToolCall, ExecutedToolCallFromRaw>))]
public sealed record class ExecutedToolCall : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required bool Ok
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("ok");
        }
        init { this._rawData.Set("ok", value); }
    }

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Ok;
        _ = this.Error;
    }

    public ExecutedToolCall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutedToolCall(ExecutedToolCall executedToolCall)
        : base(executedToolCall) { }
#pragma warning restore CS8618

    public ExecutedToolCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutedToolCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutedToolCallFromRaw.FromRawUnchecked"/>
    public static ExecutedToolCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExecutedToolCallFromRaw : IFromRawJson<ExecutedToolCall>
{
    /// <inheritdoc/>
    public ExecutedToolCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExecutedToolCall.FromRawUnchecked(rawData);
}
