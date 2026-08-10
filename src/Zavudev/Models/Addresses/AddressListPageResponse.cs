using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressListPageResponse, AddressListPageResponseFromRaw>))]
public sealed record class AddressListPageResponse : JsonModel
{
    public required IReadOnlyList<Address> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Address>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Address>>(
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

    public AddressListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressListPageResponse(AddressListPageResponse addressListPageResponse)
        : base(addressListPageResponse) { }
#pragma warning restore CS8618

    public AddressListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressListPageResponseFromRaw.FromRawUnchecked"/>
    public static AddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddressListPageResponse(IReadOnlyList<Address> items)
        : this()
    {
        this.Items = items;
    }
}

class AddressListPageResponseFromRaw : IFromRawJson<AddressListPageResponse>
{
    /// <inheritdoc/>
    public AddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddressListPageResponse.FromRawUnchecked(rawData);
}
