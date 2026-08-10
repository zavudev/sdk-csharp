using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "Client ABC";
        ApiEnum<string, SubAccountStatus> expectedStatus = SubAccountStatus.Active;
        long expectedTotalSpent = 0;
        string expectedApiKey = "apiKey";
        long expectedCreditLimit = 0;
        string expectedExternalID = "externalId";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalSpent, model.TotalSpent);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedCreditLimit, model.CreditLimit);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "Client ABC";
        ApiEnum<string, SubAccountStatus> expectedStatus = SubAccountStatus.Active;
        long expectedTotalSpent = 0;
        string expectedApiKey = "apiKey";
        long expectedCreditLimit = 0;
        string expectedExternalID = "externalId";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalSpent, deserialized.TotalSpent);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedCreditLimit, deserialized.CreditLimit);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("apiKey"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
        };

        Assert.Null(model.CreditLimit);
        Assert.False(model.RawData.ContainsKey("creditLimit"));
        Assert.Null(model.ExternalID);
        Assert.False(model.RawData.ContainsKey("externalId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",

            CreditLimit = null,
            ExternalID = null,
            Metadata = null,
        };

        Assert.Null(model.CreditLimit);
        Assert.True(model.RawData.ContainsKey("creditLimit"));
        Assert.Null(model.ExternalID);
        Assert.True(model.RawData.ContainsKey("externalId"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",

            CreditLimit = null,
            ExternalID = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubAccount
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "Client ABC",
            Status = SubAccountStatus.Active,
            TotalSpent = 0,
            ApiKey = "apiKey",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        SubAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(SubAccountStatus.Active)]
    [InlineData(SubAccountStatus.Inactive)]
    public void Validation_Works(SubAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubAccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubAccountStatus.Active)]
    [InlineData(SubAccountStatus.Inactive)]
    public void SerializationRoundtrip_Works(SubAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubAccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubAccountStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubAccountStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
