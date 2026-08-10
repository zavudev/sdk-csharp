using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowDuplicateResponse, FlowDuplicateResponseFromRaw>))]
public sealed record class FlowDuplicateResponse : JsonModel
{
    public required AgentFlow Flow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentFlow>("flow");
        }
        init { this._rawData.Set("flow", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Flow.Validate();
    }

    public FlowDuplicateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowDuplicateResponse(FlowDuplicateResponse flowDuplicateResponse)
        : base(flowDuplicateResponse) { }
#pragma warning restore CS8618

    public FlowDuplicateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowDuplicateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowDuplicateResponseFromRaw.FromRawUnchecked"/>
    public static FlowDuplicateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowDuplicateResponse(AgentFlow flow)
        : this()
    {
        this.Flow = flow;
    }
}

class FlowDuplicateResponseFromRaw : IFromRawJson<FlowDuplicateResponse>
{
    /// <inheritdoc/>
    public FlowDuplicateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FlowDuplicateResponse.FromRawUnchecked(rawData);
}
