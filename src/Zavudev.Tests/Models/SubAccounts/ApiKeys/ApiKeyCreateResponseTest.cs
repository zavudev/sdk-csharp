using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Tests.Models.SubAccounts.ApiKeys;

public class ApiKeyCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ApiKey = new()
            {
                ID = "id",
                Environment = ApiKeyEnvironment.Live,
                Key = "key",
                Name = "name",
            },
        };

        ApiKey expectedApiKey = new()
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        Assert.Equal(expectedApiKey, model.ApiKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ApiKey = new()
            {
                ID = "id",
                Environment = ApiKeyEnvironment.Live,
                Key = "key",
                Name = "name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ApiKey = new()
            {
                ID = "id",
                Environment = ApiKeyEnvironment.Live,
                Key = "key",
                Name = "name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiKey expectedApiKey = new()
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ApiKey = new()
            {
                ID = "id",
                Environment = ApiKeyEnvironment.Live,
                Key = "key",
                Name = "name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyCreateResponse
        {
            ApiKey = new()
            {
                ID = "id",
                Environment = ApiKeyEnvironment.Live,
                Key = "key",
                Name = "name",
            },
        };

        ApiKeyCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        string expectedID = "id";
        ApiEnum<string, ApiKeyEnvironment> expectedEnvironment = ApiKeyEnvironment.Live;
        string expectedKey = "key";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, ApiKeyEnvironment> expectedEnvironment = ApiKeyEnvironment.Live;
        string expectedKey = "key";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKey
        {
            ID = "id",
            Environment = ApiKeyEnvironment.Live,
            Key = "key",
            Name = "name",
        };

        ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiKeyEnvironmentTest : TestBase
{
    [Theory]
    [InlineData(ApiKeyEnvironment.Live)]
    [InlineData(ApiKeyEnvironment.Test)]
    public void Validation_Works(ApiKeyEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeyEnvironment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeyEnvironment.Live)]
    [InlineData(ApiKeyEnvironment.Test)]
    public void SerializationRoundtrip_Works(ApiKeyEnvironment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeyEnvironment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyEnvironment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeyEnvironment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
