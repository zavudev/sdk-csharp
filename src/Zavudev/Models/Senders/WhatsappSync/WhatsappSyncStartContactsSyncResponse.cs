using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.WhatsappSync;

[JsonConverter(
    typeof(JsonModelConverter<
        WhatsappSyncStartContactsSyncResponse,
        WhatsappSyncStartContactsSyncResponseFromRaw
    >)
)]
public sealed record class WhatsappSyncStartContactsSyncResponse : JsonModel
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

    public WhatsappSyncStartContactsSyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappSyncStartContactsSyncResponse(
        WhatsappSyncStartContactsSyncResponse whatsappSyncStartContactsSyncResponse
    )
        : base(whatsappSyncStartContactsSyncResponse) { }
#pragma warning restore CS8618

    public WhatsappSyncStartContactsSyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappSyncStartContactsSyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappSyncStartContactsSyncResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappSyncStartContactsSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappSyncStartContactsSyncResponseFromRaw
    : IFromRawJson<WhatsappSyncStartContactsSyncResponse>
{
    /// <inheritdoc/>
    public WhatsappSyncStartContactsSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappSyncStartContactsSyncResponse.FromRawUnchecked(rawData);
}
