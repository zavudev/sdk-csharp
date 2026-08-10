using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent;

[JsonConverter(typeof(JsonModelConverter<AgentStats, AgentStatsFromRaw>))]
public sealed record class AgentStats : JsonModel
{
    public required long ErrorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("errorCount");
        }
        init { this._rawData.Set("errorCount", value); }
    }

    public required long SuccessCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("successCount");
        }
        init { this._rawData.Set("successCount", value); }
    }

    /// <summary>
    /// Total cost in USD.
    /// </summary>
    public required double TotalCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("totalCost");
        }
        init { this._rawData.Set("totalCost", value); }
    }

    public required long TotalInvocations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalInvocations");
        }
        init { this._rawData.Set("totalInvocations", value); }
    }

    public required long TotalTokensUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalTokensUsed");
        }
        init { this._rawData.Set("totalTokensUsed", value); }
    }

    public double? AvgLatencyMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("avgLatencyMs");
        }
        init { this._rawData.Set("avgLatencyMs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCount;
        _ = this.SuccessCount;
        _ = this.TotalCost;
        _ = this.TotalInvocations;
        _ = this.TotalTokensUsed;
        _ = this.AvgLatencyMs;
    }

    public AgentStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentStats(AgentStats agentStats)
        : base(agentStats) { }
#pragma warning restore CS8618

    public AgentStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentStatsFromRaw.FromRawUnchecked"/>
    public static AgentStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentStatsFromRaw : IFromRawJson<AgentStats>
{
    /// <inheritdoc/>
    public AgentStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentStats.FromRawUnchecked(rawData);
}
