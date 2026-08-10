using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Tests.Models.SubAccounts.ApiKeys;

public class ApiKeyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    Environment = ItemEnvironment.Live,
                    KeyPrefix = "keyPrefix",
                    Name = "name",
                    Key = "key",
                    LastUsedAt = 0,
                    Permissions = ["string"],
                    RevokedAt = 0,
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = 0,
                Environment = ItemEnvironment.Live,
                KeyPrefix = "keyPrefix",
                Name = "name",
                Key = "key",
                LastUsedAt = 0,
                Permissions = ["string"],
                RevokedAt = 0,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    Environment = ItemEnvironment.Live,
                    KeyPrefix = "keyPrefix",
                    Name = "name",
                    Key = "key",
                    LastUsedAt = 0,
                    Permissions = ["string"],
                    RevokedAt = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    Environment = ItemEnvironment.Live,
                    KeyPrefix = "keyPrefix",
                    Name = "name",
                    Key = "key",
                    LastUsedAt = 0,
                    Permissions = ["string"],
                    RevokedAt = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = 0,
                Environment = ItemEnvironment.Live,
                KeyPrefix = "keyPrefix",
                Name = "name",
                Key = "key",
                LastUsedAt = 0,
                Permissions = ["string"],
                RevokedAt = 0,
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    Environment = ItemEnvironment.Live,
                    KeyPrefix = "keyPrefix",
                    Name = "name",
                    Key = "key",
                    LastUsedAt = 0,
                    Permissions = ["string"],
                    RevokedAt = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    Environment = ItemEnvironment.Live,
                    KeyPrefix = "keyPrefix",
                    Name = "name",
                    Key = "key",
                    LastUsedAt = 0,
                    Permissions = ["string"],
                    RevokedAt = 0,
                },
            ],
        };

        ApiKeyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            LastUsedAt = 0,
            Permissions = ["string"],
            RevokedAt = 0,
        };

        string expectedID = "id";
        double expectedCreatedAt = 0;
        ApiEnum<string, ItemEnvironment> expectedEnvironment = ItemEnvironment.Live;
        string expectedKeyPrefix = "keyPrefix";
        string expectedName = "name";
        string expectedKey = "key";
        double expectedLastUsedAt = 0;
        List<string> expectedPermissions = ["string"];
        double expectedRevokedAt = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedKeyPrefix, model.KeyPrefix);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLastUsedAt, model.LastUsedAt);
        Assert.NotNull(model.Permissions);
        Assert.Equal(expectedPermissions.Count, model.Permissions.Count);
        for (int i = 0; i < expectedPermissions.Count; i++)
        {
            Assert.Equal(expectedPermissions[i], model.Permissions[i]);
        }
        Assert.Equal(expectedRevokedAt, model.RevokedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            LastUsedAt = 0,
            Permissions = ["string"],
            RevokedAt = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            LastUsedAt = 0,
            Permissions = ["string"],
            RevokedAt = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedCreatedAt = 0;
        ApiEnum<string, ItemEnvironment> expectedEnvironment = ItemEnvironment.Live;
        string expectedKeyPrefix = "keyPrefix";
        string expectedName = "name";
        string expectedKey = "key";
        double expectedLastUsedAt = 0;
        List<string> expectedPermissions = ["string"];
        double expectedRevokedAt = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedKeyPrefix, deserialized.KeyPrefix);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLastUsedAt, deserialized.LastUsedAt);
        Assert.NotNull(deserialized.Permissions);
        Assert.Equal(expectedPermissions.Count, deserialized.Permissions.Count);
        for (int i = 0; i < expectedPermissions.Count; i++)
        {
            Assert.Equal(expectedPermissions[i], deserialized.Permissions[i]);
        }
        Assert.Equal(expectedRevokedAt, deserialized.RevokedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            LastUsedAt = 0,
            Permissions = ["string"],
            RevokedAt = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            LastUsedAt = 0,
            RevokedAt = 0,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Permissions);
        Assert.False(model.RawData.ContainsKey("permissions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            LastUsedAt = 0,
            RevokedAt = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            LastUsedAt = 0,
            RevokedAt = 0,

            // Null should be interpreted as omitted for these properties
            Key = null,
            Permissions = null,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Permissions);
        Assert.False(model.RawData.ContainsKey("permissions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            LastUsedAt = 0,
            RevokedAt = 0,

            // Null should be interpreted as omitted for these properties
            Key = null,
            Permissions = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            Permissions = ["string"],
        };

        Assert.Null(model.LastUsedAt);
        Assert.False(model.RawData.ContainsKey("lastUsedAt"));
        Assert.Null(model.RevokedAt);
        Assert.False(model.RawData.ContainsKey("revokedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            Permissions = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            Permissions = ["string"],

            LastUsedAt = null,
            RevokedAt = null,
        };

        Assert.Null(model.LastUsedAt);
        Assert.True(model.RawData.ContainsKey("lastUsedAt"));
        Assert.Null(model.RevokedAt);
        Assert.True(model.RawData.ContainsKey("revokedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            Permissions = ["string"],

            LastUsedAt = null,
            RevokedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = 0,
            Environment = ItemEnvironment.Live,
            KeyPrefix = "keyPrefix",
            Name = "name",
            Key = "key",
            LastUsedAt = 0,
            Permissions = ["string"],
            RevokedAt = 0,
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(ItemEnvironment.Live)]
    [InlineData(ItemEnvironment.Test)]
    public void Validation_Works(ItemEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ItemEnvironment.Live)]
    [InlineData(ItemEnvironment.Test)]
    public void SerializationRoundtrip_Works(ItemEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
