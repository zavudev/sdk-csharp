using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class TenDlcBrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
            BrandRelationship = "brandRelationship",
            BrandScore = 0,
            CompanyName = "companyName",
            Ein = "12-3456789",
            FailureReason = "failureReason",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Website = "https://example.com",
        };

        string expectedID = "id";
        string expectedCity = "city";
        string expectedCountry = "US";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "Acme Corp";
        string expectedEmail = "dev@stainless.com";
        ApiEnum<string, TenDlcBrandEntityType> expectedEntityType =
            TenDlcBrandEntityType.PrivateProfit;
        string expectedPhone = "+14155551234";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedStreet = "street";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVertical = "Technology";
        string expectedBrandRelationship = "brandRelationship";
        long expectedBrandScore = 0;
        string expectedCompanyName = "companyName";
        string expectedEin = "12-3456789";
        string expectedFailureReason = "failureReason";
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        string expectedStockExchange = "stockExchange";
        string expectedStockSymbol = "stockSymbol";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedVerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebsite = "https://example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedEntityType, model.EntityType);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVertical, model.Vertical);
        Assert.Equal(expectedBrandRelationship, model.BrandRelationship);
        Assert.Equal(expectedBrandScore, model.BrandScore);
        Assert.Equal(expectedCompanyName, model.CompanyName);
        Assert.Equal(expectedEin, model.Ein);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedStockExchange, model.StockExchange);
        Assert.Equal(expectedStockSymbol, model.StockSymbol);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedVerifiedAt, model.VerifiedAt);
        Assert.Equal(expectedWebsite, model.Website);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
            BrandRelationship = "brandRelationship",
            BrandScore = 0,
            CompanyName = "companyName",
            Ein = "12-3456789",
            FailureReason = "failureReason",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Website = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcBrand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
            BrandRelationship = "brandRelationship",
            BrandScore = 0,
            CompanyName = "companyName",
            Ein = "12-3456789",
            FailureReason = "failureReason",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Website = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcBrand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCity = "city";
        string expectedCountry = "US";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDisplayName = "Acme Corp";
        string expectedEmail = "dev@stainless.com";
        ApiEnum<string, TenDlcBrandEntityType> expectedEntityType =
            TenDlcBrandEntityType.PrivateProfit;
        string expectedPhone = "+14155551234";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedStreet = "street";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedVertical = "Technology";
        string expectedBrandRelationship = "brandRelationship";
        long expectedBrandScore = 0;
        string expectedCompanyName = "companyName";
        string expectedEin = "12-3456789";
        string expectedFailureReason = "failureReason";
        string expectedFirstName = "firstName";
        string expectedLastName = "lastName";
        string expectedStockExchange = "stockExchange";
        string expectedStockSymbol = "stockSymbol";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedVerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedWebsite = "https://example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedEntityType, deserialized.EntityType);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVertical, deserialized.Vertical);
        Assert.Equal(expectedBrandRelationship, deserialized.BrandRelationship);
        Assert.Equal(expectedBrandScore, deserialized.BrandScore);
        Assert.Equal(expectedCompanyName, deserialized.CompanyName);
        Assert.Equal(expectedEin, deserialized.Ein);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedStockExchange, deserialized.StockExchange);
        Assert.Equal(expectedStockSymbol, deserialized.StockSymbol);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedVerifiedAt, deserialized.VerifiedAt);
        Assert.Equal(expectedWebsite, deserialized.Website);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
            BrandRelationship = "brandRelationship",
            BrandScore = 0,
            CompanyName = "companyName",
            Ein = "12-3456789",
            FailureReason = "failureReason",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Website = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
        };

        Assert.Null(model.BrandRelationship);
        Assert.False(model.RawData.ContainsKey("brandRelationship"));
        Assert.Null(model.BrandScore);
        Assert.False(model.RawData.ContainsKey("brandScore"));
        Assert.Null(model.CompanyName);
        Assert.False(model.RawData.ContainsKey("companyName"));
        Assert.Null(model.Ein);
        Assert.False(model.RawData.ContainsKey("ein"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.StockExchange);
        Assert.False(model.RawData.ContainsKey("stockExchange"));
        Assert.Null(model.StockSymbol);
        Assert.False(model.RawData.ContainsKey("stockSymbol"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.VerifiedAt);
        Assert.False(model.RawData.ContainsKey("verifiedAt"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",

            BrandRelationship = null,
            BrandScore = null,
            CompanyName = null,
            Ein = null,
            FailureReason = null,
            FirstName = null,
            LastName = null,
            StockExchange = null,
            StockSymbol = null,
            SubmittedAt = null,
            VerifiedAt = null,
            Website = null,
        };

        Assert.Null(model.BrandRelationship);
        Assert.True(model.RawData.ContainsKey("brandRelationship"));
        Assert.Null(model.BrandScore);
        Assert.True(model.RawData.ContainsKey("brandScore"));
        Assert.Null(model.CompanyName);
        Assert.True(model.RawData.ContainsKey("companyName"));
        Assert.Null(model.Ein);
        Assert.True(model.RawData.ContainsKey("ein"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.FirstName);
        Assert.True(model.RawData.ContainsKey("firstName"));
        Assert.Null(model.LastName);
        Assert.True(model.RawData.ContainsKey("lastName"));
        Assert.Null(model.StockExchange);
        Assert.True(model.RawData.ContainsKey("stockExchange"));
        Assert.Null(model.StockSymbol);
        Assert.True(model.RawData.ContainsKey("stockSymbol"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.VerifiedAt);
        Assert.True(model.RawData.ContainsKey("verifiedAt"));
        Assert.Null(model.Website);
        Assert.True(model.RawData.ContainsKey("website"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",

            BrandRelationship = null,
            BrandScore = null,
            CompanyName = null,
            Ein = null,
            FailureReason = null,
            FirstName = null,
            LastName = null,
            StockExchange = null,
            StockSymbol = null,
            SubmittedAt = null,
            VerifiedAt = null,
            Website = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenDlcBrand
        {
            ID = "id",
            City = "city",
            Country = "US",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DisplayName = "Acme Corp",
            Email = "dev@stainless.com",
            EntityType = TenDlcBrandEntityType.PrivateProfit,
            Phone = "+14155551234",
            PostalCode = "postalCode",
            State = "state",
            Status = Status.Draft,
            Street = "street",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Vertical = "Technology",
            BrandRelationship = "brandRelationship",
            BrandScore = 0,
            CompanyName = "companyName",
            Ein = "12-3456789",
            FailureReason = "failureReason",
            FirstName = "firstName",
            LastName = "lastName",
            StockExchange = "stockExchange",
            StockSymbol = "stockSymbol",
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VerifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Website = "https://example.com",
        };

        TenDlcBrand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TenDlcBrandEntityTypeTest : TestBase
{
    [Theory]
    [InlineData(TenDlcBrandEntityType.PrivateProfit)]
    [InlineData(TenDlcBrandEntityType.PublicProfit)]
    [InlineData(TenDlcBrandEntityType.NonProfit)]
    [InlineData(TenDlcBrandEntityType.Government)]
    [InlineData(TenDlcBrandEntityType.SoleProprietor)]
    public void Validation_Works(TenDlcBrandEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenDlcBrandEntityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenDlcBrandEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TenDlcBrandEntityType.PrivateProfit)]
    [InlineData(TenDlcBrandEntityType.PublicProfit)]
    [InlineData(TenDlcBrandEntityType.NonProfit)]
    [InlineData(TenDlcBrandEntityType.Government)]
    [InlineData(TenDlcBrandEntityType.SoleProprietor)]
    public void SerializationRoundtrip_Works(TenDlcBrandEntityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TenDlcBrandEntityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TenDlcBrandEntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TenDlcBrandEntityType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TenDlcBrandEntityType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Verified)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Verified)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
