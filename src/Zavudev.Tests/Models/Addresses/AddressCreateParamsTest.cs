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
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
            FirstName = "John",
            LastName = "Doe",
        };

        string expectedCountryCode = "DE";
        string expectedLocality = "Berlin";
        string expectedPostalCode = "10115";
        string expectedStreetAddress = "123 Main St";
        string expectedAdministrativeArea = "administrativeArea";
        string expectedBusinessName = "businessName";
        string expectedExtendedAddress = "extendedAddress";
        string expectedFirstName = "John";
        string expectedLastName = "Doe";

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedLocality, parameters.Locality);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedStreetAddress, parameters.StreetAddress);
        Assert.Equal(expectedAdministrativeArea, parameters.AdministrativeArea);
        Assert.Equal(expectedBusinessName, parameters.BusinessName);
        Assert.Equal(expectedExtendedAddress, parameters.ExtendedAddress);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
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
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddressCreateParams
        {
            CountryCode = "DE",
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",

            // Null should be interpreted as omitted for these properties
            AdministrativeArea = null,
            BusinessName = null,
            ExtendedAddress = null,
            FirstName = null,
            LastName = null,
        };

        Assert.Null(parameters.AdministrativeArea);
        Assert.False(parameters.RawBodyData.ContainsKey("administrativeArea"));
        Assert.Null(parameters.BusinessName);
        Assert.False(parameters.RawBodyData.ContainsKey("businessName"));
        Assert.Null(parameters.ExtendedAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("extendedAddress"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
    }

    [Fact]
    public void Url_Works()
    {
        AddressCreateParams parameters = new()
        {
            CountryCode = "DE",
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
            Locality = "Berlin",
            PostalCode = "10115",
            StreetAddress = "123 Main St",
            AdministrativeArea = "administrativeArea",
            BusinessName = "businessName",
            ExtendedAddress = "extendedAddress",
            FirstName = "John",
            LastName = "Doe",
        };

        AddressCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
