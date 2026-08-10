using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(PhoneNumberStatusConverter))]
public enum PhoneNumberStatus
{
    Active,
    Suspended,
    Pending,
}

sealed class PhoneNumberStatusConverter : JsonConverter<PhoneNumberStatus>
{
    public override PhoneNumberStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => PhoneNumberStatus.Active,
            "suspended" => PhoneNumberStatus.Suspended,
            "pending" => PhoneNumberStatus.Pending,
            _ => (PhoneNumberStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhoneNumberStatus.Active => "active",
                PhoneNumberStatus.Suspended => "suspended",
                PhoneNumberStatus.Pending => "pending",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
