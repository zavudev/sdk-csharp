using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local,
    National,
    TollFree,
}

sealed class PhoneNumberTypeConverter : JsonConverter<PhoneNumberType>
{
    public override PhoneNumberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local" => PhoneNumberType.Local,
            "national" => PhoneNumberType.National,
            "tollFree" => PhoneNumberType.TollFree,
            _ => (PhoneNumberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberType.Local => "local",
                PhoneNumberType.National => "national",
                PhoneNumberType.TollFree => "tollFree",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
