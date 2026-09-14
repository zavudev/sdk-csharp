using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Type of phone number. `mobile` is stocked in countries where no geographic (`local`)
/// or non-geographic (`national`) inventory exists, and in several markets it is
/// the only type that can receive SMS.
/// </summary>
[JsonConverter(typeof(PhoneNumberTypeConverter))]
public enum PhoneNumberType
{
    Local,
    National,
    TollFree,
    Mobile,
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
            "mobile" => PhoneNumberType.Mobile,
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
                PhoneNumberType.Mobile => "mobile",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
