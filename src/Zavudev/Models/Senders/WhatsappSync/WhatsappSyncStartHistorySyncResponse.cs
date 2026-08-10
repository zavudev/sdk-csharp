using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.WhatsappSync;

[JsonConverter(
    typeof(JsonModelConverter<
        WhatsappSyncStartHistorySyncResponse,
        WhatsappSyncStartHistorySyncResponseFromRaw
    >)
)]
public sealed record class WhatsappSyncStartHistorySyncResponse : JsonModel
{
    /// <summary>
    /// Success message.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// WhatsApp coexistence sync status.
    /// </summary>
    public required WhatsAppSyncStatus Sync
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsAppSyncStatus>("sync");
        }
        init { this._rawData.Set("sync", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Sync.Validate();
    }

    public WhatsappSyncStartHistorySyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappSyncStartHistorySyncResponse(
        WhatsappSyncStartHistorySyncResponse whatsappSyncStartHistorySyncResponse
    )
        : base(whatsappSyncStartHistorySyncResponse) { }
#pragma warning restore CS8618

    public WhatsappSyncStartHistorySyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappSyncStartHistorySyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappSyncStartHistorySyncResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappSyncStartHistorySyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappSyncStartHistorySyncResponseFromRaw
    : IFromRawJson<WhatsappSyncStartHistorySyncResponse>
{
    /// <inheritdoc/>
    public WhatsappSyncStartHistorySyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappSyncStartHistorySyncResponse.FromRawUnchecked(rawData);
}
