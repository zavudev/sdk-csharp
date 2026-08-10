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
/// WhatsApp coexistence sync status.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsAppSyncStatus, WhatsAppSyncStatusFromRaw>))]
public sealed record class WhatsAppSyncStatus : JsonModel
{
    /// <summary>
    /// Contacts sync status details.
    /// </summary>
    public required WhatsAppSyncContacts Contacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsAppSyncContacts>("contacts");
        }
        init { this._rawData.Set("contacts", value); }
    }

    /// <summary>
    /// History sync status details.
    /// </summary>
    public required WhatsAppSyncHistory History
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WhatsAppSyncHistory>("history");
        }
        init { this._rawData.Set("history", value); }
    }

    /// <summary>
    /// Whether the account is in coexistence mode.
    /// </summary>
    public required bool IsCoexistence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isCoexistence");
        }
        init { this._rawData.Set("isCoexistence", value); }
    }

    /// <summary>
    /// WhatsApp account status.
    /// </summary>
    public required ApiEnum<string, WhatsAppSyncStatusStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsAppSyncStatusStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Contacts.Validate();
        this.History.Validate();
        _ = this.IsCoexistence;
        this.Status.Validate();
    }

    public WhatsAppSyncStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsAppSyncStatus(WhatsAppSyncStatus whatsAppSyncStatus)
        : base(whatsAppSyncStatus) { }
#pragma warning restore CS8618

    public WhatsAppSyncStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsAppSyncStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsAppSyncStatusFromRaw.FromRawUnchecked"/>
    public static WhatsAppSyncStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsAppSyncStatusFromRaw : IFromRawJson<WhatsAppSyncStatus>
{
    /// <inheritdoc/>
    public WhatsAppSyncStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WhatsAppSyncStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp account status.
/// </summary>
[JsonConverter(typeof(WhatsAppSyncStatusStatusConverter))]
public enum WhatsAppSyncStatusStatus
{
    PendingVerification,
    PendingRegistration,
    Active,
    Disconnected,
    Error,
}

sealed class WhatsAppSyncStatusStatusConverter : JsonConverter<WhatsAppSyncStatusStatus>
{
    public override WhatsAppSyncStatusStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_verification" => WhatsAppSyncStatusStatus.PendingVerification,
            "pending_registration" => WhatsAppSyncStatusStatus.PendingRegistration,
            "active" => WhatsAppSyncStatusStatus.Active,
            "disconnected" => WhatsAppSyncStatusStatus.Disconnected,
            "error" => WhatsAppSyncStatusStatus.Error,
            _ => (WhatsAppSyncStatusStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WhatsAppSyncStatusStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WhatsAppSyncStatusStatus.PendingVerification => "pending_verification",
                WhatsAppSyncStatusStatus.PendingRegistration => "pending_registration",
                WhatsAppSyncStatusStatus.Active => "active",
                WhatsAppSyncStatusStatus.Disconnected => "disconnected",
                WhatsAppSyncStatusStatus.Error => "error",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
