using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent;

[JsonConverter(typeof(JsonModelConverter<AgentResponse, AgentResponseFromRaw>))]
public sealed record class AgentResponse : JsonModel
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

    public AgentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentResponse(AgentResponse agentResponse)
        : base(agentResponse) { }
#pragma warning restore CS8618

    public AgentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentResponseFromRaw.FromRawUnchecked"/>
    public static AgentResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentResponse(AgentAgent agent)
        : this()
    {
        this.Agent = agent;
    }
}

class AgentResponseFromRaw : IFromRawJson<AgentResponse>
{
    /// <inheritdoc/>
    public AgentResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentResponse.FromRawUnchecked(rawData);
}
