using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowStep, FlowStepFromRaw>))]
public sealed record class FlowStep : JsonModel
{
    /// <summary>
    /// Unique step identifier.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Step configuration (varies by type).
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("config");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "config",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Type of flow step.
    /// </summary>
    public required ApiEnum<string, global::Zavudev.Models.Senders.Agent.Flows.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Zavudev.Models.Senders.Agent.Flows.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ID of the next step to execute.
    /// </summary>
    public string? NextStepID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextStepId");
        }
        init { this._rawData.Set("nextStepId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Config;
        this.Type.Validate();
        _ = this.NextStepID;
    }

    public FlowStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowStep(FlowStep flowStep)
        : base(flowStep) { }
#pragma warning restore CS8618

    public FlowStep(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowStep(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowStepFromRaw.FromRawUnchecked"/>
    public static FlowStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FlowStepFromRaw : IFromRawJson<FlowStep>
{
    /// <inheritdoc/>
    public FlowStep FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FlowStep.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of flow step.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Message,
    Collect,
    Condition,
    Tool,
    Llm,
    Transfer,
}

sealed class TypeConverter : JsonConverter<global::Zavudev.Models.Senders.Agent.Flows.Type>
{
    public override global::Zavudev.Models.Senders.Agent.Flows.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message" => global::Zavudev.Models.Senders.Agent.Flows.Type.Message,
            "collect" => global::Zavudev.Models.Senders.Agent.Flows.Type.Collect,
            "condition" => global::Zavudev.Models.Senders.Agent.Flows.Type.Condition,
            "tool" => global::Zavudev.Models.Senders.Agent.Flows.Type.Tool,
            "llm" => global::Zavudev.Models.Senders.Agent.Flows.Type.Llm,
            "transfer" => global::Zavudev.Models.Senders.Agent.Flows.Type.Transfer,
            _ => (global::Zavudev.Models.Senders.Agent.Flows.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Zavudev.Models.Senders.Agent.Flows.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Zavudev.Models.Senders.Agent.Flows.Type.Message => "message",
                global::Zavudev.Models.Senders.Agent.Flows.Type.Collect => "collect",
                global::Zavudev.Models.Senders.Agent.Flows.Type.Condition => "condition",
                global::Zavudev.Models.Senders.Agent.Flows.Type.Tool => "tool",
                global::Zavudev.Models.Senders.Agent.Flows.Type.Llm => "llm",
                global::Zavudev.Models.Senders.Agent.Flows.Type.Transfer => "transfer",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
