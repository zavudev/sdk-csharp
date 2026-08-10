using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Addresses;

[JsonConverter(typeof(AddressStatusConverter))]
public enum AddressStatus
{
    Pending,
    Verified,
    Rejected,
}

sealed class AddressStatusConverter : JsonConverter<AddressStatus>
{
    public override AddressStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => AddressStatus.Pending,
            "verified" => AddressStatus.Verified,
            "rejected" => AddressStatus.Rejected,
            _ => (AddressStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AddressStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AddressStatus.Pending => "pending",
                AddressStatus.Verified => "verified",
                AddressStatus.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
