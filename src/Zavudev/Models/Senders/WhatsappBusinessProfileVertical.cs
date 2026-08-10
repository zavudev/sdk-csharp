using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders;

/// <summary>
/// Business category for WhatsApp Business profile.
/// </summary>
[JsonConverter(typeof(WhatsappBusinessProfileVerticalConverter))]
public enum WhatsappBusinessProfileVertical
{
    Undefined,
    Other,
    Auto,
    Beauty,
    Apparel,
    Edu,
    Entertain,
    EventPlan,
    Finance,
    Grocery,
    Govt,
    Hotel,
    Health,
    Nonprofit,
    ProfServices,
    Retail,
    Travel,
    Restaurant,
    NotABiz,
}

sealed class WhatsappBusinessProfileVerticalConverter
    : JsonConverter<WhatsappBusinessProfileVertical>
{
    public override WhatsappBusinessProfileVertical Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "UNDEFINED" => WhatsappBusinessProfileVertical.Undefined,
            "OTHER" => WhatsappBusinessProfileVertical.Other,
            "AUTO" => WhatsappBusinessProfileVertical.Auto,
            "BEAUTY" => WhatsappBusinessProfileVertical.Beauty,
            "APPAREL" => WhatsappBusinessProfileVertical.Apparel,
            "EDU" => WhatsappBusinessProfileVertical.Edu,
            "ENTERTAIN" => WhatsappBusinessProfileVertical.Entertain,
            "EVENT_PLAN" => WhatsappBusinessProfileVertical.EventPlan,
            "FINANCE" => WhatsappBusinessProfileVertical.Finance,
            "GROCERY" => WhatsappBusinessProfileVertical.Grocery,
            "GOVT" => WhatsappBusinessProfileVertical.Govt,
            "HOTEL" => WhatsappBusinessProfileVertical.Hotel,
            "HEALTH" => WhatsappBusinessProfileVertical.Health,
            "NONPROFIT" => WhatsappBusinessProfileVertical.Nonprofit,
            "PROF_SERVICES" => WhatsappBusinessProfileVertical.ProfServices,
            "RETAIL" => WhatsappBusinessProfileVertical.Retail,
            "TRAVEL" => WhatsappBusinessProfileVertical.Travel,
            "RESTAURANT" => WhatsappBusinessProfileVertical.Restaurant,
            "NOT_A_BIZ" => WhatsappBusinessProfileVertical.NotABiz,
            _ => (WhatsappBusinessProfileVertical)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsappBusinessProfileVertical value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WhatsappBusinessProfileVertical.Undefined => "UNDEFINED",
                WhatsappBusinessProfileVertical.Other => "OTHER",
                WhatsappBusinessProfileVertical.Auto => "AUTO",
                WhatsappBusinessProfileVertical.Beauty => "BEAUTY",
                WhatsappBusinessProfileVertical.Apparel => "APPAREL",
                WhatsappBusinessProfileVertical.Edu => "EDU",
                WhatsappBusinessProfileVertical.Entertain => "ENTERTAIN",
                WhatsappBusinessProfileVertical.EventPlan => "EVENT_PLAN",
                WhatsappBusinessProfileVertical.Finance => "FINANCE",
                WhatsappBusinessProfileVertical.Grocery => "GROCERY",
                WhatsappBusinessProfileVertical.Govt => "GOVT",
                WhatsappBusinessProfileVertical.Hotel => "HOTEL",
                WhatsappBusinessProfileVertical.Health => "HEALTH",
                WhatsappBusinessProfileVertical.Nonprofit => "NONPROFIT",
                WhatsappBusinessProfileVertical.ProfServices => "PROF_SERVICES",
                WhatsappBusinessProfileVertical.Retail => "RETAIL",
                WhatsappBusinessProfileVertical.Travel => "TRAVEL",
                WhatsappBusinessProfileVertical.Restaurant => "RESTAURANT",
                WhatsappBusinessProfileVertical.NotABiz => "NOT_A_BIZ",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
