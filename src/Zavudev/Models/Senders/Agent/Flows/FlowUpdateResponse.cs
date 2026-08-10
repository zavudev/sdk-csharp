using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowUpdateResponse, FlowUpdateResponseFromRaw>))]
public sealed record class FlowUpdateResponse : JsonModel
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

    public FlowUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowUpdateResponse(FlowUpdateResponse flowUpdateResponse)
        : base(flowUpdateResponse) { }
#pragma warning restore CS8618

    public FlowUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FlowUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowUpdateResponse(AgentFlow flow)
        : this()
    {
        this.Flow = flow;
    }
}

class FlowUpdateResponseFromRaw : IFromRawJson<FlowUpdateResponse>
{
    /// <inheritdoc/>
    public FlowUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlowUpdateResponse.FromRawUnchecked(rawData);
}
