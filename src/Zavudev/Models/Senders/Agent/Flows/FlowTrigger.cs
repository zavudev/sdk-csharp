using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowTrigger, FlowTriggerFromRaw>))]
public sealed record class FlowTrigger : JsonModel
{
    /// <summary>
    /// Type of trigger for a flow.
    /// </summary>
    public required ApiEnum<string, FlowTriggerType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FlowTriggerType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Intent that triggers the flow (for intent type).
    /// </summary>
    public string? Intent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("intent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("intent", value);
        }
    }

    /// <summary>
    /// Keywords that trigger the flow (for keyword type).
    /// </summary>
    public IReadOnlyList<string>? Keywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("keywords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "keywords",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Intent;
        _ = this.Keywords;
    }

    public FlowTrigger() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowTrigger(FlowTrigger flowTrigger)
        : base(flowTrigger) { }
#pragma warning restore CS8618

    public FlowTrigger(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowTrigger(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowTriggerFromRaw.FromRawUnchecked"/>
    public static FlowTrigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowTrigger(ApiEnum<string, FlowTriggerType> type)
        : this()
    {
        this.Type = type;
    }
}

class FlowTriggerFromRaw : IFromRawJson<FlowTrigger>
{
    /// <inheritdoc/>
    public FlowTrigger FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlowTrigger.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of trigger for a flow.
/// </summary>
[JsonConverter(typeof(FlowTriggerTypeConverter))]
public enum FlowTriggerType
{
    Keyword,
    Intent,
    Always,
    Manual,
}

sealed class FlowTriggerTypeConverter : JsonConverter<FlowTriggerType>
{
    public override FlowTriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "keyword" => FlowTriggerType.Keyword,
            "intent" => FlowTriggerType.Intent,
            "always" => FlowTriggerType.Always,
            "manual" => FlowTriggerType.Manual,
            _ => (FlowTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FlowTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FlowTriggerType.Keyword => "keyword",
                FlowTriggerType.Intent => "intent",
                FlowTriggerType.Always => "always",
                FlowTriggerType.Manual => "manual",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
