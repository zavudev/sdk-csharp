using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Addresses;

[JsonConverter(typeof(JsonModelConverter<AddressRetrieveResponse, AddressRetrieveResponseFromRaw>))]
public sealed record class AddressRetrieveResponse : JsonModel
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

    public AddressRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AddressRetrieveResponse(AddressRetrieveResponse addressRetrieveResponse)
        : base(addressRetrieveResponse) { }
#pragma warning restore CS8618

    public AddressRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddressRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AddressRetrieveResponse(Address address)
        : this()
    {
        this.Address = address;
    }
}

class AddressRetrieveResponseFromRaw : IFromRawJson<AddressRetrieveResponse>
{
    /// <inheritdoc/>
    public AddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AddressRetrieveResponse.FromRawUnchecked(rawData);
}
