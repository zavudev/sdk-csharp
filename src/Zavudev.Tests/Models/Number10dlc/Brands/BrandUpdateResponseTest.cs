using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandUpdateResponse
        {
            Brand = new()
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
            },
        };

        TenDlcBrand expectedBrand = new()
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

        Assert.Equal(expectedBrand, model.Brand);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandUpdateResponse
        {
            Brand = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandUpdateResponse
        {
            Brand = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TenDlcBrand expectedBrand = new()
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

        Assert.Equal(expectedBrand, deserialized.Brand);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandUpdateResponse
        {
            Brand = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandUpdateResponse
        {
            Brand = new()
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
            },
        };

        BrandUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
