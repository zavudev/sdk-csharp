using System;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
            FirstName = "John",
            LastName = "Doe",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
        };

        string expectedCountryCode = "DE";
        string expectedFirstName = "John";
        string expectedLastName = "Doe";
        string expectedLocality = "Berlin";
        string expectedPostalCode = "10115";
        string expectedStreetAddress = "123 Main St";
        string expectedAdministrativeArea = "administrativeArea";
        string expectedBusinessName = "businessName";
        string expectedExtendedAddress = "extendedAddress";

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedLocality, parameters.Locality);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedStreetAddress, parameters.StreetAddress);
        Assert.Equal(expectedAdministrativeArea, parameters.AdministrativeArea);
        Assert.Equal(expectedBusinessName, parameters.BusinessName);
        Assert.Equal(expectedExtendedAddress, parameters.ExtendedAddress);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
            FirstName = "John",
            LastName = "Doe",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
        };

        Assert.Null(parameters.AdministrativeArea);
        Assert.False(parameters.RawBodyData.ContainsKey("administrativeArea"));
        Assert.Null(parameters.BusinessName);
        Assert.False(parameters.RawBodyData.ContainsKey("businessName"));
        Assert.Null(parameters.ExtendedAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("extendedAddress"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
            FirstName = "John",
            LastName = "Doe",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",

            // Null should be interpreted as omitted for these properties
            AdministrativeArea = null,
            BusinessName = null,
            ExtendedAddress = null,
        };

        Assert.Null(parameters.AdministrativeArea);
        Assert.False(parameters.RawBodyData.ContainsKey("administrativeArea"));
        Assert.Null(parameters.BusinessName);
        Assert.False(parameters.RawBodyData.ContainsKey("businessName"));
        Assert.Null(parameters.ExtendedAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("extendedAddress"));
    }

    [Fact]
    public void Url_Works()
    {
        AddressCreateParams parameters = new()
        {
            CountryCode = "DE",
            FirstName = "John",
            LastName = "Doe",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/addresses"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
            FirstName = "John",
            LastName = "Doe",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
        };

        AddressCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
