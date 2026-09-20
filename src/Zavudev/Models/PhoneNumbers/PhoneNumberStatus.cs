using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Billing state of an owned number, separate from `regulatoryStatus`. `pending`
/// is legacy and is not written to numbers today. The SDKs carry `active`, `suspended`
/// and `pending` only; `releasing` and `released` are returned by the REST API until
/// their next release.
/// </summary>
[JsonConverter(typeof(PhoneNumberStatusConverter))]
public enum PhoneNumberStatus
{
    Active,
    Suspended,
    Pending,
    Releasing,
    Released,
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
            "releasing" => PhoneNumberStatus.Releasing,
            "released" => PhoneNumberStatus.Released,
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
                PhoneNumberStatus.Releasing => "releasing",
                PhoneNumberStatus.Released => "released",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
