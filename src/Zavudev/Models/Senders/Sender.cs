using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(typeof(JsonModelConverter<Sender, SenderFromRaw>))]
public sealed record class Sender : JsonModel
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Phone number in E.164 format.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <summary>
    /// Channels this sender can actually send on right now, computed from its configuration.
    /// Empty means the sender cannot send or receive anything yet: a phoneNumber
    /// alone does not enable SMS or voice. Check this rather than inferring capability
    /// from phoneNumber or emailAddress.
    /// </summary>
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// From-address for the email channel, if configured.
    /// </summary>
    public string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emailAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailAddress", value);
        }
    }

    /// <summary>
    /// Whether catch-all receiving is enabled. When true (and emailReceivingEnabled
    /// is true), this sender receives email addressed to any local part at its domain,
    /// not just its own address. The original recipient is delivered in the message.inbound
    /// webhook's data.to.
    /// </summary>
    public bool? EmailCatchAllEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("emailCatchAllEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailCatchAllEnabled", value);
        }
    }

    /// <summary>
    /// Whether inbound email receiving is enabled for this sender.
    /// </summary>
    public bool? EmailReceivingEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("emailReceivingEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailReceivingEnabled", value);
        }
    }

    /// <summary>
    /// Whether this sender is the project's default.
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isDefault");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isDefault", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <summary>
    /// Webhook configuration for the sender.
    /// </summary>
    public SenderWebhook? Webhook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SenderWebhook>("webhook");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhook", value);
        }
    }

    /// <summary>
    /// WhatsApp Business Account information. Only present if a WABA is connected.
    /// </summary>
    public Whatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Whatsapp>("whatsapp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.PhoneNumber;
        _ = this.Channels;
        _ = this.CreatedAt;
        _ = this.EmailAddress;
        _ = this.EmailCatchAllEnabled;
        _ = this.EmailReceivingEnabled;
        _ = this.IsDefault;
        _ = this.UpdatedAt;
        this.Webhook?.Validate();
        this.Whatsapp?.Validate();
    }

    public Sender() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sender(Sender sender)
        : base(sender) { }
#pragma warning restore CS8618

    public Sender(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Sender(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderFromRaw.FromRawUnchecked"/>
    public static Sender FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderFromRaw : IFromRawJson<Sender>
{
    /// <inheritdoc/>
    public Sender FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Sender.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp Business Account information. Only present if a WABA is connected.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Whatsapp, WhatsappFromRaw>))]
public sealed record class Whatsapp : JsonModel
{
    /// <summary>
    /// Display phone number.
    /// </summary>
    public string? DisplayPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayPhoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayPhoneNumber", value);
        }
    }

    /// <summary>
    /// Payment configuration status from Meta.
    /// </summary>
    public PaymentStatus? PaymentStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaymentStatus>("paymentStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paymentStatus", value);
        }
    }

    /// <summary>
    /// WhatsApp phone number ID from Meta.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumberId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneNumberId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayPhoneNumber;
        this.PaymentStatus?.Validate();
        _ = this.PhoneNumberID;
    }

    public Whatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Whatsapp(Whatsapp whatsapp)
        : base(whatsapp) { }
#pragma warning restore CS8618

    public Whatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Whatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappFromRaw.FromRawUnchecked"/>
    public static Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappFromRaw : IFromRawJson<Whatsapp>
{
    /// <inheritdoc/>
    public Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Whatsapp.FromRawUnchecked(rawData);
}

/// <summary>
/// Payment configuration status from Meta.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaymentStatus, PaymentStatusFromRaw>))]
public sealed record class PaymentStatus : JsonModel
{
    /// <summary>
    /// Whether template messages can be sent. Requires setupStatus=COMPLETE and methodStatus=VALID.
    /// </summary>
    public bool? CanSendTemplates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("canSendTemplates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("canSendTemplates", value);
        }
    }

    /// <summary>
    /// Payment method status (VALID, NONE, etc.).
    /// </summary>
    public string? MethodStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("methodStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("methodStatus", value);
        }
    }

    /// <summary>
    /// Payment setup status (COMPLETE, NOT_STARTED, etc.).
    /// </summary>
    public string? SetupStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("setupStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("setupStatus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CanSendTemplates;
        _ = this.MethodStatus;
        _ = this.SetupStatus;
    }

    public PaymentStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaymentStatus(PaymentStatus paymentStatus)
        : base(paymentStatus) { }
#pragma warning restore CS8618

    public PaymentStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaymentStatusFromRaw.FromRawUnchecked"/>
    public static PaymentStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentStatusFromRaw : IFromRawJson<PaymentStatus>
{
    /// <inheritdoc/>
    public PaymentStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PaymentStatus.FromRawUnchecked(rawData);
}
