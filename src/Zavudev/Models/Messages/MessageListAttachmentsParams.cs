using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

/// <summary>
/// List the stored file attachments for an email message and get a short-lived signed
/// `downloadUrl` for each. Works for both inbound emails (received via `message.inbound`)
/// and outbound emails you sent with attachments. Messages without stored attachments
/// (including SMS, WhatsApp, and other channels) return an empty list. Each `downloadUrl`
/// is generated fresh per request and expires — fetch the file promptly and do not
/// cache the URL.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageListAttachmentsParams : ParamsBase
{
    public string? MessageID { get; init; }

    public MessageListAttachmentsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListAttachmentsParams(MessageListAttachmentsParams messageListAttachmentsParams)
        : base(messageListAttachmentsParams)
    {
        this.MessageID = messageListAttachmentsParams.MessageID;
    }
#pragma warning restore CS8618

    public MessageListAttachmentsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListAttachmentsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string messageID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MessageID = messageID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MessageListAttachmentsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string messageID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            messageID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MessageListAttachmentsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MessageID?.Equals(other.MessageID) ?? other.MessageID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/messages/{0}/attachments", this.MessageID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
