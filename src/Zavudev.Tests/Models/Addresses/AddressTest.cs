using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
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

        string expectedID = "id";
        string expectedCountryCode = "DE";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLocality = "locality";
        string expectedPostalCode = "postalCode";
        ApiEnum<string, AddressStatus> expectedStatus = AddressStatus.Pending;
        string expectedStreetAddress = "streetAddress";
        string expectedAdministrativeArea = "administrativeArea";
        string expectedBusinessName = "businessName";
        string expectedExtendedAddress = "extendedAddress";
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLocality, model.Locality);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStreetAddress, model.StreetAddress);
        Assert.Equal(expectedAdministrativeArea, model.AdministrativeArea);
        Assert.Equal(expectedBusinessName, model.BusinessName);
        Assert.Equal(expectedExtendedAddress, model.ExtendedAddress);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Address
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCountryCode = "DE";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLocality = "locality";
        string expectedPostalCode = "postalCode";
        ApiEnum<string, AddressStatus> expectedStatus = AddressStatus.Pending;
        string expectedStreetAddress = "streetAddress";
        string expectedAdministrativeArea = "administrativeArea";
        string expectedBusinessName = "businessName";
        string expectedExtendedAddress = "extendedAddress";
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLocality, deserialized.Locality);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStreetAddress, deserialized.StreetAddress);
        Assert.Equal(expectedAdministrativeArea, deserialized.AdministrativeArea);
        Assert.Equal(expectedBusinessName, deserialized.BusinessName);
        Assert.Equal(expectedExtendedAddress, deserialized.ExtendedAddress);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Address
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
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Address
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Address
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

            // Null should be interpreted as omitted for these properties
            UpdatedAt = null,
        };

        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Address
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

            // Null should be interpreted as omitted for these properties
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Address
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AdministrativeArea);
        Assert.False(model.RawData.ContainsKey("administrativeArea"));
        Assert.Null(model.BusinessName);
        Assert.False(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.ExtendedAddress);
        Assert.False(model.RawData.ContainsKey("extendedAddress"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Address
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Address
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AdministrativeArea = null,
            BusinessName = null,
            ExtendedAddress = null,
            FirstName = null,
            LastName = null,
        };

        Assert.Null(model.AdministrativeArea);
        Assert.True(model.RawData.ContainsKey("administrativeArea"));
        Assert.Null(model.BusinessName);
        Assert.True(model.RawData.ContainsKey("businessName"));
        Assert.Null(model.ExtendedAddress);
        Assert.True(model.RawData.ContainsKey("extendedAddress"));
        Assert.Null(model.FirstName);
        Assert.True(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.True(model.RawData.ContainsKey("lastName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Address
        {
            ID = "id",
            CountryCode = "DE",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Locality = "locality",
            PostalCode = "postalCode",
            Status = AddressStatus.Pending,
            StreetAddress = "streetAddress",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AdministrativeArea = null,
            BusinessName = null,
            ExtendedAddress = null,
            FirstName = null,
            LastName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Address
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

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}
