using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentUpdateResponse, AgentUpdateResponseFromRaw>))]
public sealed record class AgentUpdateResponse : JsonModel
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

    public AgentUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentUpdateResponse(AgentUpdateResponse agentUpdateResponse)
        : base(agentUpdateResponse) { }
#pragma warning restore CS8618

    public AgentUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentUpdateResponseFromRaw.FromRawUnchecked"/>
    public static AgentUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentUpdateResponse(AgentAgent agent)
        : this()
    {
        this.Agent = agent;
    }
}

class AgentUpdateResponseFromRaw : IFromRawJson<AgentUpdateResponse>
{
    /// <inheritdoc/>
    public AgentUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentUpdateResponse.FromRawUnchecked(rawData);
}
