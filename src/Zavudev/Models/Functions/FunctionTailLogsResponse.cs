using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<FunctionTailLogsResponse, FunctionTailLogsResponseFromRaw>)
)]
public sealed record class FunctionTailLogsResponse : JsonModel
{
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pass to the next request to fetch the following page of logs.
    /// </summary>
    public string? NextToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextToken");
        }
        init { this._rawData.Set("nextToken", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        _ = this.NextToken;
    }

    public FunctionTailLogsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionTailLogsResponse(FunctionTailLogsResponse functionTailLogsResponse)
        : base(functionTailLogsResponse) { }
#pragma warning restore CS8618

    public FunctionTailLogsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionTailLogsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionTailLogsResponseFromRaw.FromRawUnchecked"/>
    public static FunctionTailLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionTailLogsResponse(IReadOnlyList<Event> events)
        : this()
    {
        this.Events = events;
    }
}

class FunctionTailLogsResponseFromRaw : IFromRawJson<FunctionTailLogsResponse>
{
    /// <inheritdoc/>
    public FunctionTailLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionTailLogsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Event, EventFromRaw>))]
public sealed record class Event : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required DateTimeOffset Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Timestamp;
    }

    public Event() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Event(Event event_)
        : base(event_) { }
#pragma warning restore CS8618

    public Event(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Event(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EventFromRaw.FromRawUnchecked"/>
    public static Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EventFromRaw : IFromRawJson<Event>
{
    /// <inheritdoc/>
    public Event FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Event.FromRawUnchecked(rawData);
}
