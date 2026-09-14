using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents.Senders;

[JsonConverter(typeof(JsonModelConverter<SenderConnectResponse, SenderConnectResponseFromRaw>))]
public sealed record class SenderConnectResponse : JsonModel
{
    /// <summary>
    /// AI Agent configuration for a sender.
    /// </summary>
    public required AgentAgent Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentAgent>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Agent.Validate();
    }

    public SenderConnectResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderConnectResponse(SenderConnectResponse senderConnectResponse)
        : base(senderConnectResponse) { }
#pragma warning restore CS8618

    public SenderConnectResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderConnectResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderConnectResponseFromRaw.FromRawUnchecked"/>
    public static SenderConnectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SenderConnectResponse(AgentAgent agent)
        : this()
    {
        this.Agent = agent;
    }
}

class SenderConnectResponseFromRaw : IFromRawJson<SenderConnectResponse>
{
    /// <inheritdoc/>
    public SenderConnectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderConnectResponse.FromRawUnchecked(rawData);
}
