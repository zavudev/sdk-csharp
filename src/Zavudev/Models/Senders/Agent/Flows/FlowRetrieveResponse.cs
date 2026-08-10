using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowRetrieveResponse, FlowRetrieveResponseFromRaw>))]
public sealed record class FlowRetrieveResponse : JsonModel
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

    public FlowRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowRetrieveResponse(FlowRetrieveResponse flowRetrieveResponse)
        : base(flowRetrieveResponse) { }
#pragma warning restore CS8618

    public FlowRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FlowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowRetrieveResponse(AgentFlow flow)
        : this()
    {
        this.Flow = flow;
    }
}

class FlowRetrieveResponseFromRaw : IFromRawJson<FlowRetrieveResponse>
{
    /// <inheritdoc/>
    public FlowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FlowRetrieveResponse.FromRawUnchecked(rawData);
}
