using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.WhatsappSync;

[JsonConverter(
    typeof(JsonModelConverter<WhatsappSyncRetrieveResponse, WhatsappSyncRetrieveResponseFromRaw>)
)]
public sealed record class WhatsappSyncRetrieveResponse : JsonModel
{
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
        this.Sync.Validate();
    }

    public WhatsappSyncRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappSyncRetrieveResponse(WhatsappSyncRetrieveResponse whatsappSyncRetrieveResponse)
        : base(whatsappSyncRetrieveResponse) { }
#pragma warning restore CS8618

    public WhatsappSyncRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappSyncRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappSyncRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappSyncRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WhatsappSyncRetrieveResponse(WhatsAppSyncStatus sync)
        : this()
    {
        this.Sync = sync;
    }
}

class WhatsappSyncRetrieveResponseFromRaw : IFromRawJson<WhatsappSyncRetrieveResponse>
{
    /// <inheritdoc/>
    public WhatsappSyncRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappSyncRetrieveResponse.FromRawUnchecked(rawData);
}
