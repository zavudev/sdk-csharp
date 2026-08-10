using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(
    typeof(JsonModelConverter<SenderUpdateProfileResponse, SenderUpdateProfileResponseFromRaw>)
)]
public sealed record class SenderUpdateProfileResponse : JsonModel
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

    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Profile.Validate();
        _ = this.Success;
    }

    public SenderUpdateProfileResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderUpdateProfileResponse(SenderUpdateProfileResponse senderUpdateProfileResponse)
        : base(senderUpdateProfileResponse) { }
#pragma warning restore CS8618

    public SenderUpdateProfileResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderUpdateProfileResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderUpdateProfileResponseFromRaw.FromRawUnchecked"/>
    public static SenderUpdateProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderUpdateProfileResponseFromRaw : IFromRawJson<SenderUpdateProfileResponse>
{
    /// <inheritdoc/>
    public SenderUpdateProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderUpdateProfileResponse.FromRawUnchecked(rawData);
}
