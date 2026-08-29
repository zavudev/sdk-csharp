using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Start sending the broadcast immediately or schedule for later.
///
/// <para>**The account must be past the sandbox level to send, except on WhatsApp.**
/// An account that has verified nothing is refused with `403` and code `kyc_required`
/// on every channel other than `whatsapp`. Any one of these lifts it: identity verification
/// (KYC), a saved payment method, a settled deposit, or a paid plan. Business verification
/// (KYB) is not required to broadcast; it gates 10DLC registration only. A `whatsapp`
/// broadcast is exempt: it can only be built on a template, and Meta vets the business
/// and the content when it approves that template, so an unapproved template is
/// refused instead. `smart` is not exempt, since it can route a contact to SMS or
/// email. Drafts can be created, edited and kept without any check. Every send path
/// (dashboard, API and CLI) enforces the same rule.</para>
///
/// <para>**Daily ceilings apply per recipient.** Each message a broadcast sends
/// counts against the channel's daily ceiling (see `POST /v1/messages`). Once the
/// ceiling is reached, the remaining recipients are marked `failed` with `errorCode`
/// `DAILY_LIMIT_EXCEEDED`; they are not retried the next day.</para>
///
/// <para>**Review depends on the channel, and cannot be bypassed.** A draft is submitted
/// to automated content review here; it does not go straight out. A WhatsApp broadcast
/// built on a Meta-approved template skips review (Meta already vetted the content)
/// and begins sending. An email broadcast sends as soon as the automated review
/// passes. Every other channel moves to `pending_admin_review` and waits for a person.
/// If the review rejects it, use PATCH to edit the content then call POST /retry-review.</para>
///
/// <para>Calling this on a broadcast that is already `approved` or `scheduled` sends
/// or reschedules it directly, since it has already been reviewed. Reserves the
/// estimated cost from your balance.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BroadcastSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? BroadcastID { get; init; }

    /// <summary>
    /// Schedule for future delivery. Omit to send immediately.
    /// </summary>
    public DateTimeOffset? ScheduledAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<DateTimeOffset>("scheduledAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("scheduledAt", value);
        }
    }

    public BroadcastSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastSendParams(BroadcastSendParams broadcastSendParams)
        : base(broadcastSendParams)
    {
        this.BroadcastID = broadcastSendParams.BroadcastID;

        this._rawBodyData = new(broadcastSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BroadcastSendParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastSendParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string broadcastID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.BroadcastID = broadcastID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BroadcastSendParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string broadcastID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            broadcastID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BroadcastID"] = JsonSerializer.SerializeToElement(this.BroadcastID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BroadcastSendParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BroadcastID?.Equals(other.BroadcastID) ?? other.BroadcastID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/broadcasts/{0}/send", this.BroadcastID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
