using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders.WhatsappSync;

/// <summary>
/// History sync status details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsAppSyncHistory, WhatsAppSyncHistoryFromRaw>))]
public sealed record class WhatsAppSyncHistory : JsonModel
{
    /// <summary>
    /// Whether history sync can be initiated.
    /// </summary>
    public required bool CanSync
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("canSync");
        }
        init { this._rawData.Set("canSync", value); }
    }

    /// <summary>
    /// Status of WhatsApp message history sync.
    /// </summary>
    public required ApiEnum<string, WhatsAppSyncHistoryStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsAppSyncHistoryStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the sync was completed.
    /// </summary>
    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init { this._rawData.Set("completedAt", value); }
    }

    /// <summary>
    /// When the sync was last requested.
    /// </summary>
    public DateTimeOffset? RequestedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("requestedAt");
        }
        init { this._rawData.Set("requestedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanSync;
        this.Status.Validate();
        _ = this.CompletedAt;
        _ = this.RequestedAt;
    }

    public WhatsAppSyncHistory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsAppSyncHistory(WhatsAppSyncHistory whatsAppSyncHistory)
        : base(whatsAppSyncHistory) { }
#pragma warning restore CS8618

    public WhatsAppSyncHistory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsAppSyncHistory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsAppSyncHistoryFromRaw.FromRawUnchecked"/>
    public static WhatsAppSyncHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsAppSyncHistoryFromRaw : IFromRawJson<WhatsAppSyncHistory>
{
    /// <inheritdoc/>
    public WhatsAppSyncHistory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WhatsAppSyncHistory.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of WhatsApp message history sync.
/// </summary>
[JsonConverter(typeof(WhatsAppSyncHistoryStatusConverter))]
public enum WhatsAppSyncHistoryStatus
{
    NotRequested,
    Pending,
    Syncing,
    Completed,
    Rejected,
}

sealed class WhatsAppSyncHistoryStatusConverter : JsonConverter<WhatsAppSyncHistoryStatus>
{
    public override WhatsAppSyncHistoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_requested" => WhatsAppSyncHistoryStatus.NotRequested,
            "pending" => WhatsAppSyncHistoryStatus.Pending,
            "syncing" => WhatsAppSyncHistoryStatus.Syncing,
            "completed" => WhatsAppSyncHistoryStatus.Completed,
            "rejected" => WhatsAppSyncHistoryStatus.Rejected,
            _ => (WhatsAppSyncHistoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsAppSyncHistoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WhatsAppSyncHistoryStatus.NotRequested => "not_requested",
                WhatsAppSyncHistoryStatus.Pending => "pending",
                WhatsAppSyncHistoryStatus.Syncing => "syncing",
                WhatsAppSyncHistoryStatus.Completed => "completed",
                WhatsAppSyncHistoryStatus.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
