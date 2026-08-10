using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandCreateParams
        {
            City = "San Francisco",
            Country = "US",
            DisplayName = "Acme Corp",
            Email = "compliance@acme.com",
            EntityType = EntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "94102",
            State = "CA",
            Street = "123 Main St",
            Vertical = "Technology",
            CompanyName = "Acme Corporation",
            Ein = "12-3456789",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            Website = "https://acme.com",
        };

        string expectedCity = "San Francisco";
        string expectedCountry = "US";
        string expectedDisplayName = "Acme Corp";
        string expectedEmail = "compliance@acme.com";
        ApiEnum<string, EntityType> expectedEntityType = EntityType.PrivateProfit;
        string expectedPhone = "+14155551234";
        string expectedPostalCode = "94102";
        string expectedState = "CA";
        string expectedStreet = "123 Main St";
        string expectedVertical = "Technology";
        string expectedCompanyName = "Acme Corporation";
        string expectedEin = "12-3456789";
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        string expectedStockExchange = "stockExchange";
        string expectedStockSymbol = "stockSymbol";
        string expectedWebsite = "https://acme.com";

        Assert.Equal(expectedCity, parameters.City);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedEntityType, parameters.EntityType);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedStreet, parameters.Street);
        Assert.Equal(expectedVertical, parameters.Vertical);
        Assert.Equal(expectedCompanyName, parameters.CompanyName);
        Assert.Equal(expectedEin, parameters.Ein);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedStockExchange, parameters.StockExchange);
        Assert.Equal(expectedStockSymbol, parameters.StockSymbol);
        Assert.Equal(expectedWebsite, parameters.Website);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandCreateParams
        {
            City = "San Francisco",
            Country = "US",
            DisplayName = "Acme Corp",
            Email = "compliance@acme.com",
            EntityType = EntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "94102",
            State = "CA",
            Street = "123 Main St",
            Vertical = "Technology",
        };

        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("companyName"));
        Assert.Null(parameters.Ein);
        Assert.False(parameters.RawBodyData.ContainsKey("ein"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.StockExchange);
        Assert.False(parameters.RawBodyData.ContainsKey("stockExchange"));
        Assert.Null(parameters.StockSymbol);
        Assert.False(parameters.RawBodyData.ContainsKey("stockSymbol"));
        Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BrandCreateParams
        {
            City = "San Francisco",
            Country = "US",
            DisplayName = "Acme Corp",
            Email = "compliance@acme.com",
            EntityType = EntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "94102",
            State = "CA",
            Street = "123 Main St",
            Vertical = "Technology",

            // Null should be interpreted as omitted for these properties
            CompanyName = null,
            Ein = null,
            FirstName = null,
            LastName = null,
            StockExchange = null,
            StockSymbol = null,
            Website = null,
        };

        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("companyName"));
        Assert.Null(parameters.Ein);
        Assert.False(parameters.RawBodyData.ContainsKey("ein"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.StockExchange);
        Assert.False(parameters.RawBodyData.ContainsKey("stockExchange"));
        Assert.Null(parameters.StockSymbol);
        Assert.False(parameters.RawBodyData.ContainsKey("stockSymbol"));
        Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandCreateParams parameters = new()
        {
            City = "San Francisco",
            Country = "US",
            DisplayName = "Acme Corp",
            Email = "compliance@acme.com",
            EntityType = EntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "94102",
            State = "CA",
            Street = "123 Main St",
            Vertical = "Technology",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/brands"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandCreateParams
        {
            City = "San Francisco",
            Country = "US",
            DisplayName = "Acme Corp",
            Email = "compliance@acme.com",
            EntityType = EntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "94102",
            State = "CA",
            Street = "123 Main St",
            Vertical = "Technology",
            CompanyName = "Acme Corporation",
            Ein = "12-3456789",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            Website = "https://acme.com",
        };

        BrandCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EntityTypeTest : TestBase
{
    [Theory]
    [InlineData(EntityType.PrivateProfit)]
    [InlineData(EntityType.PublicProfit)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.Government)]
    [InlineData(EntityType.SoleProprietor)]
    public void Validation_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityType.PrivateProfit)]
    [InlineData(EntityType.PublicProfit)]
    [InlineData(EntityType.NonProfit)]
    [InlineData(EntityType.Government)]
    [InlineData(EntityType.SoleProprietor)]
    public void SerializationRoundtrip_Works(EntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
