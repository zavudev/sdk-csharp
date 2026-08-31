using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions.Triggers;

[JsonConverter(typeof(JsonModelConverter<TriggerListResponse, TriggerListResponseFromRaw>))]
public sealed record class TriggerListResponse : JsonModel
{
    public required IReadOnlyList<TriggerListResponseTrigger> Triggers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TriggerListResponseTrigger>>(
                "triggers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TriggerListResponseTrigger>>(
                "triggers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Triggers)
        {
            item.Validate();
        }
    }

    public TriggerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TriggerListResponse(TriggerListResponse triggerListResponse)
        : base(triggerListResponse) { }
#pragma warning restore CS8618

    public TriggerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TriggerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerListResponseFromRaw.FromRawUnchecked"/>
    public static TriggerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TriggerListResponse(IReadOnlyList<TriggerListResponseTrigger> triggers)
        : this()
    {
        this.Triggers = triggers;
    }
}

class TriggerListResponseFromRaw : IFromRawJson<TriggerListResponse>
{
    /// <inheritdoc/>
    public TriggerListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TriggerListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A subscription that runs a Zavu Function when a messaging event fires.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TriggerListResponseTrigger, TriggerListResponseTriggerFromRaw>)
)]
public sealed record class TriggerListResponseTrigger : JsonModel
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

    public required bool Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("active");
        }
        init { this._rawData.Set("active", value); }
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

    /// <summary>
    /// Event type that fires the function. See GET /v1/functions/event-types for
    /// the supported list. The special type `cron` fires on a schedule instead of
    /// a messaging event and carries a `cron` expression.
    /// </summary>
    public required string EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("eventType");
        }
        init { this._rawData.Set("eventType", value); }
    }

    public required string FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionId");
        }
        init { this._rawData.Set("functionId", value); }
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

    /// <summary>
    /// 5-field cron expression (minute hour day-of-month month day-of-week), evaluated
    /// in UTC. Present only on `cron` triggers.
    /// </summary>
    public string? Cron
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cron");
        }
        init { this._rawData.Set("cron", value); }
    }

    /// <summary>
    /// Last time the schedule fired. Null until the first fire.
    /// </summary>
    public DateTimeOffset? LastRunAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastRunAt");
        }
        init { this._rawData.Set("lastRunAt", value); }
    }

    /// <summary>
    /// Next scheduled fire time. Present only on `cron` triggers.
    /// </summary>
    public DateTimeOffset? NextRunAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("nextRunAt");
        }
        init { this._rawData.Set("nextRunAt", value); }
    }

    /// <summary>
    /// Restrict the trigger to a single sender. Null means all senders in the project.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init { this._rawData.Set("senderId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.EventType;
        _ = this.FunctionID;
        _ = this.UpdatedAt;
        _ = this.Cron;
        _ = this.LastRunAt;
        _ = this.NextRunAt;
        _ = this.SenderID;
    }

    public TriggerListResponseTrigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TriggerListResponseTrigger(TriggerListResponseTrigger triggerListResponseTrigger)
        : base(triggerListResponseTrigger) { }
#pragma warning restore CS8618

    public TriggerListResponseTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TriggerListResponseTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerListResponseTriggerFromRaw.FromRawUnchecked"/>
    public static TriggerListResponseTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TriggerListResponseTriggerFromRaw : IFromRawJson<TriggerListResponseTrigger>
{
    /// <inheritdoc/>
    public TriggerListResponseTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TriggerListResponseTrigger.FromRawUnchecked(rawData);
}
