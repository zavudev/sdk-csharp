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
/// Contacts sync status details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsAppSyncContacts, WhatsAppSyncContactsFromRaw>))]
public sealed record class WhatsAppSyncContacts : JsonModel
{
    /// <summary>
    /// Whether contacts sync can be initiated.
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
    /// Status of WhatsApp contacts sync.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
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
        _ = this.RequestedAt;
    }

    public WhatsAppSyncContacts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsAppSyncContacts(WhatsAppSyncContacts whatsAppSyncContacts)
        : base(whatsAppSyncContacts) { }
#pragma warning restore CS8618

    public WhatsAppSyncContacts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsAppSyncContacts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsAppSyncContactsFromRaw.FromRawUnchecked"/>
    public static WhatsAppSyncContacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsAppSyncContactsFromRaw : IFromRawJson<WhatsAppSyncContacts>
{
    /// <inheritdoc/>
    public WhatsAppSyncContacts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsAppSyncContacts.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of WhatsApp contacts sync.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotRequested,
    Pending,
    Syncing,
    Completed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_requested" => Status.NotRequested,
            "pending" => Status.Pending,
            "syncing" => Status.Syncing,
            "completed" => Status.Completed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.NotRequested => "not_requested",
                Status.Pending => "pending",
                Status.Syncing => "syncing",
                Status.Completed => "completed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
