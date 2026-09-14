using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentCreateResponse, AgentCreateResponseFromRaw>))]
public sealed record class AgentCreateResponse : JsonModel
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

    public AgentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentCreateResponse(AgentCreateResponse agentCreateResponse)
        : base(agentCreateResponse) { }
#pragma warning restore CS8618

    public AgentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentCreateResponseFromRaw.FromRawUnchecked"/>
    public static AgentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentCreateResponse(AgentAgent agent)
        : this()
    {
        this.Agent = agent;
    }
}

class AgentCreateResponseFromRaw : IFromRawJson<AgentCreateResponse>
{
    /// <inheritdoc/>
    public AgentCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentCreateResponse.FromRawUnchecked(rawData);
}
