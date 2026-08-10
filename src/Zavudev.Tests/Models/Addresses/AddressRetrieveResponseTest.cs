using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddressRetrieveResponse
        {
            Address = new()
            {
                ID = "id",
                CountryCode = "DE",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Locality = "locality",
                PostalCode = "postalCode",
                Status = AddressStatus.Pending,
                StreetAddress = "streetAddress",
                AdministrativeArea = "administrativeArea",
                BusinessName = "businessName",
                ExtendedAddress = "extendedAddress",
                FirstName = "firstName",
                LastName = "lastName",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Address expectedAddress = new()
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
            FirstName = "firstName",
            LastName = "lastName",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAddress, model.Address);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddressRetrieveResponse
        {
            Address = new()
            {
                ID = "id",
                CountryCode = "DE",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Locality = "locality",
                PostalCode = "postalCode",
                Status = AddressStatus.Pending,
                StreetAddress = "streetAddress",
                AdministrativeArea = "administrativeArea",
                BusinessName = "businessName",
                ExtendedAddress = "extendedAddress",
                FirstName = "firstName",
                LastName = "lastName",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddressRetrieveResponse
        {
            Address = new()
            {
                ID = "id",
                CountryCode = "DE",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Locality = "locality",
                PostalCode = "postalCode",
                Status = AddressStatus.Pending,
                StreetAddress = "streetAddress",
                AdministrativeArea = "administrativeArea",
                BusinessName = "businessName",
                ExtendedAddress = "extendedAddress",
                FirstName = "firstName",
                LastName = "lastName",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Address expectedAddress = new()
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
            FirstName = "firstName",
            LastName = "lastName",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedAddress, deserialized.Address);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddressRetrieveResponse
        {
            Address = new()
            {
                ID = "id",
                CountryCode = "DE",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Locality = "locality",
                PostalCode = "postalCode",
                Status = AddressStatus.Pending,
                StreetAddress = "streetAddress",
                AdministrativeArea = "administrativeArea",
                BusinessName = "businessName",
                ExtendedAddress = "extendedAddress",
                FirstName = "firstName",
                LastName = "lastName",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddressRetrieveResponse
        {
            Address = new()
            {
                ID = "id",
                CountryCode = "DE",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Locality = "locality",
                PostalCode = "postalCode",
                Status = AddressStatus.Pending,
                StreetAddress = "streetAddress",
                AdministrativeArea = "administrativeArea",
                BusinessName = "businessName",
                ExtendedAddress = "extendedAddress",
                FirstName = "firstName",
                LastName = "lastName",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        AddressRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
