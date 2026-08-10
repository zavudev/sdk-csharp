using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<AgentFlow, AgentFlowFromRaw>))]
public sealed record class AgentFlow : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentId");
        }
        init { this._rawData.Set("agentId", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Priority when multiple flows match (higher = more priority).
    /// </summary>
    public required long Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("priority");
        }
        init { this._rawData.Set("priority", value); }
    }

    public required IReadOnlyList<FlowStep> Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FlowStep>>("steps");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FlowStep>>(
                "steps",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required FlowTrigger Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FlowTrigger>("trigger");
        }
        init { this._rawData.Set("trigger", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.CreatedAt;
        _ = this.Enabled;
        _ = this.Name;
        _ = this.Priority;
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
        this.Trigger.Validate();
        _ = this.UpdatedAt;
        _ = this.Description;
    }

    public AgentFlow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentFlow(AgentFlow agentFlow)
        : base(agentFlow) { }
#pragma warning restore CS8618

    public AgentFlow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentFlow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentFlowFromRaw.FromRawUnchecked"/>
    public static AgentFlow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentFlowFromRaw : IFromRawJson<AgentFlow>
{
    /// <inheritdoc/>
    public AgentFlow FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentFlow.FromRawUnchecked(rawData);
}
