using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Templates;

/// <summary>
/// WhatsApp template category.
/// </summary>
[JsonConverter(typeof(WhatsappCategoryConverter))]
public enum WhatsappCategory
{
    Utility,
    Marketing,
    Authentication,
}

sealed class WhatsappCategoryConverter : JsonConverter<WhatsappCategory>
{
    public override WhatsappCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UTILITY" => WhatsappCategory.Utility,
            "MARKETING" => WhatsappCategory.Marketing,
            "AUTHENTICATION" => WhatsappCategory.Authentication,
            _ => (WhatsappCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WhatsappCategory.Utility => "UTILITY",
                WhatsappCategory.Marketing => "MARKETING",
                WhatsappCategory.Authentication => "AUTHENTICATION",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
