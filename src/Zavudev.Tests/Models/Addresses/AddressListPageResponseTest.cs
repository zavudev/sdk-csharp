using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<Address> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddressListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Address> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddressListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        AddressListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
