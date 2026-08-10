using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubAccountRetrieveResponse
        {
            SubAccount = new()
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
            },
        };

        SubAccount expectedSubAccount = new()
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

        Assert.Equal(expectedSubAccount, model.SubAccount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubAccountRetrieveResponse
        {
            SubAccount = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubAccountRetrieveResponse
        {
            SubAccount = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubAccount expectedSubAccount = new()
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

        Assert.Equal(expectedSubAccount, deserialized.SubAccount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubAccountRetrieveResponse
        {
            SubAccount = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubAccountRetrieveResponse
        {
            SubAccount = new()
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
            },
        };

        SubAccountRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
