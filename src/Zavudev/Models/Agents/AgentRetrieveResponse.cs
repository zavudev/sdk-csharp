using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentRetrieveResponse, AgentRetrieveResponseFromRaw>))]
public sealed record class AgentRetrieveResponse : JsonModel
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

    public AgentRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentRetrieveResponse(AgentRetrieveResponse agentRetrieveResponse)
        : base(agentRetrieveResponse) { }
#pragma warning restore CS8618

    public AgentRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AgentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentRetrieveResponse(AgentAgent agent)
        : this()
    {
        this.Agent = agent;
    }
}

class AgentRetrieveResponseFromRaw : IFromRawJson<AgentRetrieveResponse>
{
    /// <inheritdoc/>
    public AgentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentRetrieveResponse.FromRawUnchecked(rawData);
}
