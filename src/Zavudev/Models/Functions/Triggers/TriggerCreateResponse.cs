using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions.Triggers;

[JsonConverter(typeof(JsonModelConverter<TriggerCreateResponse, TriggerCreateResponseFromRaw>))]
public sealed record class TriggerCreateResponse : JsonModel
{
    public required long Added
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("added");
        }
        init { this._rawData.Set("added", value); }
    }

    /// <summary>
    /// Number of triggers that already existed.
    /// </summary>
    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    public required IReadOnlyList<Trigger> Triggers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Trigger>>("triggers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Trigger>>(
                "triggers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Added;
        _ = this.Skipped;
        foreach (var item in this.Triggers)
        {
            item.Validate();
        }
    }

    public TriggerCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TriggerCreateResponse(TriggerCreateResponse triggerCreateResponse)
        : base(triggerCreateResponse) { }
#pragma warning restore CS8618

    public TriggerCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TriggerCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerCreateResponseFromRaw.FromRawUnchecked"/>
    public static TriggerCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TriggerCreateResponseFromRaw : IFromRawJson<TriggerCreateResponse>
{
    /// <inheritdoc/>
    public TriggerCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TriggerCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A subscription that runs a Zavu Function when a messaging event fires.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Trigger, TriggerFromRaw>))]
public sealed record class Trigger : JsonModel
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

    public Trigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Trigger(Trigger trigger)
        : base(trigger) { }
#pragma warning restore CS8618

    public Trigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerFromRaw.FromRawUnchecked"/>
    public static Trigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TriggerFromRaw : IFromRawJson<Trigger>
{
    /// <inheritdoc/>
    public Trigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trigger.FromRawUnchecked(rawData);
}
