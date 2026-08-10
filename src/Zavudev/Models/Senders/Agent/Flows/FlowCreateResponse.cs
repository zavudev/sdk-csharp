using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowCreateResponse, FlowCreateResponseFromRaw>))]
public sealed record class FlowCreateResponse : JsonModel
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

    public FlowCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowCreateResponse(FlowCreateResponse flowCreateResponse)
        : base(flowCreateResponse) { }
#pragma warning restore CS8618

    public FlowCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowCreateResponseFromRaw.FromRawUnchecked"/>
    public static FlowCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowCreateResponse(AgentFlow flow)
        : this()
    {
        this.Flow = flow;
    }
}

class FlowCreateResponseFromRaw : IFromRawJson<FlowCreateResponse>
{
    /// <inheritdoc/>
    public FlowCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlowCreateResponse.FromRawUnchecked(rawData);
}
