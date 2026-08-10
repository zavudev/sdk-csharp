using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressCreateResponse, AddressCreateResponseFromRaw>))]
public sealed record class AddressCreateResponse : JsonModel
{
    /// <summary>
    /// A regulatory address for phone number requirements.
    /// </summary>
    public required Address Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Address>("address");
        }
        init { this._rawData.Set("address", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Address.Validate();
    }

    public AddressCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressCreateResponse(AddressCreateResponse addressCreateResponse)
        : base(addressCreateResponse) { }
#pragma warning restore CS8618

    public AddressCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressCreateResponseFromRaw.FromRawUnchecked"/>
    public static AddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddressCreateResponse(Address address)
        : this()
    {
        this.Address = address;
    }
}

class AddressCreateResponseFromRaw : IFromRawJson<AddressCreateResponse>
{
    /// <inheritdoc/>
    public AddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddressCreateResponse.FromRawUnchecked(rawData);
}
