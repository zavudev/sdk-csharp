using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts.Contacts;

[JsonConverter(typeof(JsonModelConverter<ContactListPageResponse, ContactListPageResponseFromRaw>))]
public sealed record class ContactListPageResponse : JsonModel
{
    public required IReadOnlyList<BroadcastContact> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BroadcastContact>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BroadcastContact>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public ContactListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactListPageResponse(ContactListPageResponse contactListPageResponse)
        : base(contactListPageResponse) { }
#pragma warning restore CS8618

    public ContactListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactListPageResponseFromRaw.FromRawUnchecked"/>
    public static ContactListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContactListPageResponse(IReadOnlyList<BroadcastContact> items)
        : this()
    {
        this.Items = items;
    }
}

class ContactListPageResponseFromRaw : IFromRawJson<ContactListPageResponse>
{
    /// <inheritdoc/>
    public ContactListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContactListPageResponse.FromRawUnchecked(rawData);
}
