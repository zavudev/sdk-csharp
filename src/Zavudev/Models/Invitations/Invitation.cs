using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Invitations;

[JsonConverter(typeof(JsonModelConverter<Invitation, InvitationFromRaw>))]
public sealed record class Invitation : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Unique invitation token.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expiresAt");
        }
        init { this._rawData.Set("expiresAt", value); }
    }

    /// <summary>
    /// Current status of the partner invitation.
    ///
    /// <para>`failed` means the client started the connection and it did not finish
    /// (they cancelled Meta's dialog, denied a permission, or abandoned the tab).
    /// A failed invitation is still usable: the same link can be retried, and it
    /// moves back to `in_progress` when the client tries again.</para>
    /// </summary>
    public required ApiEnum<string, InvitationStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InvitationStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Full URL to share with the client.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public string? ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clientEmail");
        }
        init { this._rawData.Set("clientEmail", value); }
    }

    public string? ClientName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clientName");
        }
        init { this._rawData.Set("clientName", value); }
    }

    public string? ClientPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("clientPhone");
        }
        init { this._rawData.Set("clientPhone", value); }
    }

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
    /// The account the client linked, populated once the invitation is `completed`.
    /// Null before that. Use it to show the partner what was connected without fetching
    /// the sender.
    /// </summary>
    public ConnectedAccount? ConnectedAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectedAccount>("connectedAccount");
        }
        init { this._rawData.Set("connectedAccount", value); }
    }

    /// <summary>
    /// Which Meta channel the client connects: `whatsapp_waba` (official WhatsApp
    /// Cloud API via embedded signup) or `messenger` (a Facebook Page's Messenger
    /// inbox, including Marketplace chats).
    /// </summary>
    public ApiEnum<string, InvitationConnectionType>? ConnectionType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InvitationConnectionType>>(
                "connectionType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("connectionType", value);
        }
    }

    public DateTimeOffset? FailedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("failedAt");
        }
        init { this._rawData.Set("failedAt", value); }
    }

    /// <summary>
    /// Stable code for why the last attempt failed, present when `status` is `failed`.
    /// Values include `fb_cancelled` (client closed Meta's dialog), `fb_not_authorized`
    /// (permission denied), `signup_abandoned` (started but never finished), `meta_no_pages`
    /// (the client administers no Facebook Page), and `internal_error`. Treat unknown
    /// codes as a generic failure.
    /// </summary>
    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failureReason");
        }
        init { this._rawData.Set("failureReason", value); }
    }

    /// <summary>
    /// ID of a pre-assigned Zavu phone number for WhatsApp registration. Always null
    /// for `messenger` invitations.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumberId");
        }
        init { this._rawData.Set("phoneNumberId", value); }
    }

    /// <summary>
    /// ID of the sender created when invitation is completed.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init { this._rawData.Set("senderId", value); }
    }

    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    public DateTimeOffset? ViewedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("viewedAt");
        }
        init { this._rawData.Set("viewedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Token;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.Url;
        _ = this.ClientEmail;
        _ = this.ClientName;
        _ = this.ClientPhone;
        _ = this.CompletedAt;
        this.ConnectedAccount?.Validate();
        this.ConnectionType?.Validate();
        _ = this.FailedAt;
        _ = this.FailureReason;
        _ = this.PhoneNumberID;
        _ = this.SenderID;
        _ = this.StartedAt;
        _ = this.ViewedAt;
    }

    public Invitation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invitation(Invitation invitation)
        : base(invitation) { }
#pragma warning restore CS8618

    public Invitation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invitation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationFromRaw.FromRawUnchecked"/>
    public static Invitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvitationFromRaw : IFromRawJson<Invitation>
{
    /// <inheritdoc/>
    public Invitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invitation.FromRawUnchecked(rawData);
}

/// <summary>
/// Current status of the partner invitation.
///
/// <para>`failed` means the client started the connection and it did not finish
/// (they cancelled Meta's dialog, denied a permission, or abandoned the tab). A
/// failed invitation is still usable: the same link can be retried, and it moves
/// back to `in_progress` when the client tries again.</para>
/// </summary>
[JsonConverter(typeof(InvitationStatusConverter))]
public enum InvitationStatus
{
    Pending,
    InProgress,
    Completed,
    Expired,
    Cancelled,
    Failed,
}

sealed class InvitationStatusConverter : JsonConverter<InvitationStatus>
{
    public override InvitationStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => InvitationStatus.Pending,
            "in_progress" => InvitationStatus.InProgress,
            "completed" => InvitationStatus.Completed,
            "expired" => InvitationStatus.Expired,
            "cancelled" => InvitationStatus.Cancelled,
            "failed" => InvitationStatus.Failed,
            _ => (InvitationStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationStatus.Pending => "pending",
                InvitationStatus.InProgress => "in_progress",
                InvitationStatus.Completed => "completed",
                InvitationStatus.Expired => "expired",
                InvitationStatus.Cancelled => "cancelled",
                InvitationStatus.Failed => "failed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The account the client linked, populated once the invitation is `completed`. Null
/// before that. Use it to show the partner what was connected without fetching the sender.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConnectedAccount, ConnectedAccountFromRaw>))]
public sealed record class ConnectedAccount : JsonModel
{
    /// <summary>
    /// Provider-side identifier: the WhatsApp phone number ID, or the Facebook Page ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, Channel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Channel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Display name of the connected account: the WhatsApp verified name, or the
    /// Facebook Page name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channel.Validate();
        _ = this.Name;
    }

    public ConnectedAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectedAccount(ConnectedAccount connectedAccount)
        : base(connectedAccount) { }
#pragma warning restore CS8618

    public ConnectedAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectedAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConnectedAccountFromRaw.FromRawUnchecked"/>
    public static ConnectedAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConnectedAccountFromRaw : IFromRawJson<ConnectedAccount>
{
    /// <inheritdoc/>
    public ConnectedAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConnectedAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ChannelConverter))]
public enum Channel
{
    Whatsapp,
    Messenger,
}

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp" => Channel.Whatsapp,
            "messenger" => Channel.Messenger,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.Whatsapp => "whatsapp",
                Channel.Messenger => "messenger",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Which Meta channel the client connects: `whatsapp_waba` (official WhatsApp Cloud
/// API via embedded signup) or `messenger` (a Facebook Page's Messenger inbox, including
/// Marketplace chats).
/// </summary>
[JsonConverter(typeof(InvitationConnectionTypeConverter))]
public enum InvitationConnectionType
{
    WhatsappWaba,
    Messenger,
}

sealed class InvitationConnectionTypeConverter : JsonConverter<InvitationConnectionType>
{
    public override InvitationConnectionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp_waba" => InvitationConnectionType.WhatsappWaba,
            "messenger" => InvitationConnectionType.Messenger,
            _ => (InvitationConnectionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvitationConnectionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvitationConnectionType.WhatsappWaba => "whatsapp_waba",
                InvitationConnectionType.Messenger => "messenger",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
