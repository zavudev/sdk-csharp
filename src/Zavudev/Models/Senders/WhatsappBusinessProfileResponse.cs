using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(
    typeof(JsonModelConverter<
        WhatsappBusinessProfileResponse,
        WhatsappBusinessProfileResponseFromRaw
    >)
)]
public sealed record class WhatsappBusinessProfileResponse : JsonModel
{
    /// <summary>
    /// WhatsApp Business profile information.
    /// </summary>
    public required WhatsappBusinessProfile Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsappBusinessProfile>("profile");
        }
        init { this._rawData.Set("profile", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Profile.Validate();
    }

    public WhatsappBusinessProfileResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappBusinessProfileResponse(
        WhatsappBusinessProfileResponse whatsappBusinessProfileResponse
    )
        : base(whatsappBusinessProfileResponse) { }
#pragma warning restore CS8618

    public WhatsappBusinessProfileResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappBusinessProfileResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappBusinessProfileResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappBusinessProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WhatsappBusinessProfileResponse(WhatsappBusinessProfile profile)
        : this()
    {
        this.Profile = profile;
    }
}

class WhatsappBusinessProfileResponseFromRaw : IFromRawJson<WhatsappBusinessProfileResponse>
{
    /// <inheritdoc/>
    public WhatsappBusinessProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappBusinessProfileResponse.FromRawUnchecked(rawData);
}
