using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Type of requirement field.
/// </summary>
[JsonConverter(typeof(RequirementFieldTypeConverter))]
public enum RequirementFieldType
{
    Textual,
    Address,
    Document,
    Action,
}

sealed class RequirementFieldTypeConverter : JsonConverter<RequirementFieldType>
{
    public override RequirementFieldType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "textual" => RequirementFieldType.Textual,
            "address" => RequirementFieldType.Address,
            "document" => RequirementFieldType.Document,
            "action" => RequirementFieldType.Action,
            _ => (RequirementFieldType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequirementFieldType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequirementFieldType.Textual => "textual",
                RequirementFieldType.Address => "address",
                RequirementFieldType.Document => "document",
                RequirementFieldType.Action => "action",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
