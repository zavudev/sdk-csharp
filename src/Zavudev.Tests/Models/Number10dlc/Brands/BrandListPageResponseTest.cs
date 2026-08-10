using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<TenDlcBrand> expectedItems =
        [
            new()
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
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TenDlcBrand> expectedItems =
        [
            new()
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
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        BrandListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
