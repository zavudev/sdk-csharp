using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolParameters, ToolParametersFromRaw>))]
public sealed record class ToolParameters : JsonModel
{
    public required IReadOnlyDictionary<string, PropertiesItem> Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, PropertiesItem>>(
                "properties"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, PropertiesItem>>(
                "properties",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<string> Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("required");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "required",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, global::Zavudev.Models.Senders.Agent.Tools.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Zavudev.Models.Senders.Agent.Tools.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Properties.Values)
        {
            item.Validate();
        }
        _ = this.Required;
        this.Type.Validate();
    }

    public ToolParameters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolParameters(ToolParameters toolParameters)
        : base(toolParameters) { }
#pragma warning restore CS8618

    public ToolParameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolParameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolParametersFromRaw.FromRawUnchecked"/>
    public static ToolParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolParametersFromRaw : IFromRawJson<ToolParameters>
{
    /// <inheritdoc/>
    public ToolParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolParameters.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PropertiesItem, PropertiesItemFromRaw>))]
public sealed record class PropertiesItem : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Type;
    }

    public PropertiesItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PropertiesItem(PropertiesItem propertiesItem)
        : base(propertiesItem) { }
#pragma warning restore CS8618

    public PropertiesItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PropertiesItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PropertiesItemFromRaw.FromRawUnchecked"/>
    public static PropertiesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PropertiesItemFromRaw : IFromRawJson<PropertiesItem>
{
    /// <inheritdoc/>
    public PropertiesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PropertiesItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Object,
}

sealed class TypeConverter : JsonConverter<global::Zavudev.Models.Senders.Agent.Tools.Type>
{
    public override global::Zavudev.Models.Senders.Agent.Tools.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object" => global::Zavudev.Models.Senders.Agent.Tools.Type.Object,
            _ => (global::Zavudev.Models.Senders.Agent.Tools.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Zavudev.Models.Senders.Agent.Tools.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Zavudev.Models.Senders.Agent.Tools.Type.Object => "object",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
