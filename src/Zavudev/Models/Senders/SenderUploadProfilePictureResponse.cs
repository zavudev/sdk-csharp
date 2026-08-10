using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(
    typeof(JsonModelConverter<
        SenderUploadProfilePictureResponse,
        SenderUploadProfilePictureResponseFromRaw
    >)
)]
public sealed record class SenderUploadProfilePictureResponse : JsonModel
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

    public SenderUploadProfilePictureResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderUploadProfilePictureResponse(
        SenderUploadProfilePictureResponse senderUploadProfilePictureResponse
    )
        : base(senderUploadProfilePictureResponse) { }
#pragma warning restore CS8618

    public SenderUploadProfilePictureResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderUploadProfilePictureResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderUploadProfilePictureResponseFromRaw.FromRawUnchecked"/>
    public static SenderUploadProfilePictureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderUploadProfilePictureResponseFromRaw : IFromRawJson<SenderUploadProfilePictureResponse>
{
    /// <inheritdoc/>
    public SenderUploadProfilePictureResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderUploadProfilePictureResponse.FromRawUnchecked(rawData);
}
