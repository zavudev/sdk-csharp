using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Contacts.Channels;

/// <summary>
/// Set a channel as the primary channel for its type.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ChannelSetPrimaryParams : ParamsBase
{
    public required string ContactID { get; init; }

    public string? ChannelID { get; init; }

    public ChannelSetPrimaryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelSetPrimaryParams(ChannelSetPrimaryParams channelSetPrimaryParams)
        : base(channelSetPrimaryParams)
    {
        this.ContactID = channelSetPrimaryParams.ContactID;
        this.ChannelID = channelSetPrimaryParams.ChannelID;
    }
#pragma warning restore CS8618

    public ChannelSetPrimaryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelSetPrimaryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string contactID,
        string channelID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ContactID = contactID;
        this.ChannelID = channelID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ChannelSetPrimaryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string contactID,
        string channelID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            contactID,
            channelID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ContactID"] = JsonSerializer.SerializeToElement(this.ContactID),
                    ["ChannelID"] = JsonSerializer.SerializeToElement(this.ChannelID),
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

    public virtual bool Equals(ChannelSetPrimaryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ContactID.Equals(other.ContactID)
            && (this.ChannelID?.Equals(other.ChannelID) ?? other.ChannelID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/contacts/{0}/channels/{1}/primary",
                    this.ContactID,
                    this.ChannelID
                )
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
