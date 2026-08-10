using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Tests.Models.Functions.Secrets;

public class SecretListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SecretListResponse
        {
            Secrets =
            [
                new()
                {
                    ID = "id",
                    Key = "key",
                    ValueLast4 = "valueLast4",
                    CreatedAt = 0,
                    SyncedToAws = true,
                    UpdatedAt = 0,
                },
            ],
        };

        List<Secret> expectedSecrets =
        [
            new()
            {
                ID = "id",
                Key = "key",
                ValueLast4 = "valueLast4",
                CreatedAt = 0,
                SyncedToAws = true,
                UpdatedAt = 0,
            },
        ];

        Assert.Equal(expectedSecrets.Count, model.Secrets.Count);
        for (int i = 0; i < expectedSecrets.Count; i++)
        {
            Assert.Equal(expectedSecrets[i], model.Secrets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SecretListResponse
        {
            Secrets =
            [
                new()
                {
                    ID = "id",
                    Key = "key",
                    ValueLast4 = "valueLast4",
                    CreatedAt = 0,
                    SyncedToAws = true,
                    UpdatedAt = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SecretListResponse
        {
            Secrets =
            [
                new()
                {
                    ID = "id",
                    Key = "key",
                    ValueLast4 = "valueLast4",
                    CreatedAt = 0,
                    SyncedToAws = true,
                    UpdatedAt = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SecretListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Secret> expectedSecrets =
        [
            new()
            {
                ID = "id",
                Key = "key",
                ValueLast4 = "valueLast4",
                CreatedAt = 0,
                SyncedToAws = true,
                UpdatedAt = 0,
            },
        ];

        Assert.Equal(expectedSecrets.Count, deserialized.Secrets.Count);
        for (int i = 0; i < expectedSecrets.Count; i++)
        {
            Assert.Equal(expectedSecrets[i], deserialized.Secrets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SecretListResponse
        {
            Secrets =
            [
                new()
                {
                    ID = "id",
                    Key = "key",
                    ValueLast4 = "valueLast4",
                    CreatedAt = 0,
                    SyncedToAws = true,
                    UpdatedAt = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SecretListResponse
        {
            Secrets =
            [
                new()
                {
                    ID = "id",
                    Key = "key",
                    ValueLast4 = "valueLast4",
                    CreatedAt = 0,
                    SyncedToAws = true,
                    UpdatedAt = 0,
                },
            ],
        };

        SecretListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SecretTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
            CreatedAt = 0,
            SyncedToAws = true,
            UpdatedAt = 0,
        };

        string expectedID = "id";
        string expectedKey = "key";
        string expectedValueLast4 = "valueLast4";
        double expectedCreatedAt = 0;
        bool expectedSyncedToAws = true;
        double expectedUpdatedAt = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValueLast4, model.ValueLast4);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedSyncedToAws, model.SyncedToAws);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
            CreatedAt = 0,
            SyncedToAws = true,
            UpdatedAt = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Secret>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
            CreatedAt = 0,
            SyncedToAws = true,
            UpdatedAt = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Secret>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedKey = "key";
        string expectedValueLast4 = "valueLast4";
        double expectedCreatedAt = 0;
        bool expectedSyncedToAws = true;
        double expectedUpdatedAt = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValueLast4, deserialized.ValueLast4);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedSyncedToAws, deserialized.SyncedToAws);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
            CreatedAt = 0,
            SyncedToAws = true,
            UpdatedAt = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.SyncedToAws);
        Assert.False(model.RawData.ContainsKey("syncedToAws"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            SyncedToAws = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.SyncedToAws);
        Assert.False(model.RawData.ContainsKey("syncedToAws"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            SyncedToAws = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Secret
        {
            ID = "id",
            Key = "key",
            ValueLast4 = "valueLast4",
            CreatedAt = 0,
            SyncedToAws = true,
            UpdatedAt = 0,
        };

        Secret copied = new(model);

        Assert.Equal(model, copied);
    }
}
