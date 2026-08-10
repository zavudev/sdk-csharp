using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Introspect;

/// <summary>
/// Type of phone line.
/// </summary>
[JsonConverter(typeof(LineTypeConverter))]
public enum LineType
{
    Mobile,
    Landline,
    Voip,
    TollFree,
    Unknown,
}

sealed class LineTypeConverter : JsonConverter<LineType>
{
    public override LineType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mobile" => LineType.Mobile,
            "landline" => LineType.Landline,
            "voip" => LineType.Voip,
            "toll_free" => LineType.TollFree,
            "unknown" => LineType.Unknown,
            _ => (LineType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, LineType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineType.Mobile => "mobile",
                LineType.Landline => "landline",
                LineType.Voip => "voip",
                LineType.TollFree => "toll_free",
                LineType.Unknown => "unknown",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
