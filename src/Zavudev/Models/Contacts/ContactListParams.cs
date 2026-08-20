using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Contacts;

/// <summary>
/// List contacts with their communication channels.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContactListParams : ParamsBase
{
    /// <summary>
    /// Opaque cursor from a previous response's `nextCursor`. Do not construct it.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Exact match on the contact's primary phone number, in E.164.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// Free-text match over the contact's name (`displayName` and the WhatsApp profile
    /// name), phone numbers and email addresses. Case- and accent-insensitive. A
    /// phone number matches on a trailing fragment too, so `5551234` finds `+14155551234`.
    ///
    /// <para>Contacts created automatically from an inbound message have no `displayName`
    /// — they are matched by their identifier until you set one with `PATCH /v1/contacts/{contactId}`.</para>
    ///
    /// <para>Results come back in relevance order rather than newest-first. `cursor`
    /// is opaque in both modes; pass back exactly what the previous response returned,
    /// and start a new pagination run when the search term changes.</para>
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search", value);
        }
    }

    /// <summary>
    /// Tag name. Repeatable: `?tag=vip&amp;tag=chile` returns contacts carrying **every**
    /// tag given, not any of them — the same rule the dashboard filter applies.
    ///
    /// <para>Tags are matched by name, case-insensitively. An unknown tag returns
    /// 400 rather than being ignored, because a typo that silently matched every
    /// contact would be a worse answer than an error.</para>
    /// </summary>
    public IReadOnlyList<string>? Tag
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("tag");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "tag",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ContactListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactListParams(ContactListParams contactListParams)
        : base(contactListParams) { }
#pragma warning restore CS8618

    public ContactListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ContactListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ContactListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/contacts")
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
