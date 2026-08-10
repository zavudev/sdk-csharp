using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "brandId",
            City = "city",
            CompanyName = "companyName",
            Country = "xx",
            DisplayName = "displayName",
            Ein = "ein",
            Email = "dev@stainless.com",
            EntityType = BrandUpdateParamsEntityType.PrivateProfit,
            FirstName = "firstName",
            LastName = "lastName",
            Phone = "phone",
            PostalCode = "postalCode",
            State = "state",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            Street = "street",
            Vertical = "vertical",
            Website = "https://example.com",
        };

        string expectedBrandID = "brandId";
        string expectedCity = "city";
        string expectedCompanyName = "companyName";
        string expectedCountry = "xx";
        string expectedDisplayName = "displayName";
        string expectedEin = "ein";
        string expectedEmail = "dev@stainless.com";
        ApiEnum<string, BrandUpdateParamsEntityType> expectedEntityType =
            BrandUpdateParamsEntityType.PrivateProfit;
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        string expectedPhone = "phone";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";
        string expectedStockExchange = "stockExchange";
        string expectedStockSymbol = "stockSymbol";
        string expectedStreet = "street";
        string expectedVertical = "vertical";
        string expectedWebsite = "https://example.com";

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCity, parameters.City);
        Assert.Equal(expectedCompanyName, parameters.CompanyName);
        Assert.Equal(expectedCountry, parameters.Country);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedEin, parameters.Ein);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedEntityType, parameters.EntityType);
        Assert.Equal(expectedFirstName, parameters.FirstName);
        Assert.Equal(expectedLastName, parameters.LastName);
        Assert.Equal(expectedPhone, parameters.Phone);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedStockExchange, parameters.StockExchange);
        Assert.Equal(expectedStockSymbol, parameters.StockSymbol);
        Assert.Equal(expectedStreet, parameters.Street);
        Assert.Equal(expectedVertical, parameters.Vertical);
        Assert.Equal(expectedWebsite, parameters.Website);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandUpdateParams { BrandID = "brandId" };

        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("companyName"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Ein);
        Assert.False(parameters.RawBodyData.ContainsKey("ein"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EntityType);
        Assert.False(parameters.RawBodyData.ContainsKey("entityType"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postalCode"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.StockExchange);
        Assert.False(parameters.RawBodyData.ContainsKey("stockExchange"));
        Assert.Null(parameters.StockSymbol);
        Assert.False(parameters.RawBodyData.ContainsKey("stockSymbol"));
        Assert.Null(parameters.Street);
        Assert.False(parameters.RawBodyData.ContainsKey("street"));
        Assert.Null(parameters.Vertical);
        Assert.False(parameters.RawBodyData.ContainsKey("vertical"));
        Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "brandId",

            // Null should be interpreted as omitted for these properties
            City = null,
            CompanyName = null,
            Country = null,
            DisplayName = null,
            Ein = null,
            Email = null,
            EntityType = null,
            FirstName = null,
            LastName = null,
            Phone = null,
            PostalCode = null,
            State = null,
            StockExchange = null,
            StockSymbol = null,
            Street = null,
            Vertical = null,
            Website = null,
        };

        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("companyName"));
        Assert.Null(parameters.Country);
        Assert.False(parameters.RawBodyData.ContainsKey("country"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Ein);
        Assert.False(parameters.RawBodyData.ContainsKey("ein"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EntityType);
        Assert.False(parameters.RawBodyData.ContainsKey("entityType"));
        Assert.Null(parameters.FirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("firstName"));
        Assert.Null(parameters.LastName);
        Assert.False(parameters.RawBodyData.ContainsKey("lastName"));
        Assert.Null(parameters.Phone);
        Assert.False(parameters.RawBodyData.ContainsKey("phone"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postalCode"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.StockExchange);
        Assert.False(parameters.RawBodyData.ContainsKey("stockExchange"));
        Assert.Null(parameters.StockSymbol);
        Assert.False(parameters.RawBodyData.ContainsKey("stockSymbol"));
        Assert.Null(parameters.Street);
        Assert.False(parameters.RawBodyData.ContainsKey("street"));
        Assert.Null(parameters.Vertical);
        Assert.False(parameters.RawBodyData.ContainsKey("vertical"));
        Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandUpdateParams parameters = new() { BrandID = "brandId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/brands/brandId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandUpdateParams
        {
            BrandID = "brandId",
            City = "city",
            CompanyName = "companyName",
            Country = "xx",
            DisplayName = "displayName",
            Ein = "ein",
            Email = "dev@stainless.com",
            EntityType = BrandUpdateParamsEntityType.PrivateProfit,
            FirstName = "firstName",
            LastName = "lastName",
            Phone = "phone",
            PostalCode = "postalCode",
            State = "state",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            Street = "street",
            Vertical = "vertical",
            Website = "https://example.com",
        };

        BrandUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BrandUpdateParamsEntityTypeTest : TestBase
{
    [Theory]
    [InlineData(BrandUpdateParamsEntityType.PrivateProfit)]
    [InlineData(BrandUpdateParamsEntityType.PublicProfit)]
    [InlineData(BrandUpdateParamsEntityType.NonProfit)]
    [InlineData(BrandUpdateParamsEntityType.Government)]
    [InlineData(BrandUpdateParamsEntityType.SoleProprietor)]
    public void Validation_Works(BrandUpdateParamsEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrandUpdateParamsEntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrandUpdateParamsEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BrandUpdateParamsEntityType.PrivateProfit)]
    [InlineData(BrandUpdateParamsEntityType.PublicProfit)]
    [InlineData(BrandUpdateParamsEntityType.NonProfit)]
    [InlineData(BrandUpdateParamsEntityType.Government)]
    [InlineData(BrandUpdateParamsEntityType.SoleProprietor)]
    public void SerializationRoundtrip_Works(BrandUpdateParamsEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BrandUpdateParamsEntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrandUpdateParamsEntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BrandUpdateParamsEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BrandUpdateParamsEntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
