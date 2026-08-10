using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using ApiKeys = Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Tests.Models.SubAccounts.ApiKeys;

public class ApiKeyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ApiKeys::ApiKeyCreateParams
        {
            ID = "id",
            Name = "Production Key",
            Environment = ApiKeys::Environment.Live,
            Permissions = ["string"],
        };

        string expectedID = "id";
        string expectedName = "Production Key";
        ApiEnum<string, ApiKeys::Environment> expectedEnvironment = ApiKeys::Environment.Live;
        List<string> expectedPermissions = ["string"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedEnvironment, parameters.Environment);
        Assert.NotNull(parameters.Permissions);
        Assert.Equal(expectedPermissions.Count, parameters.Permissions.Count);
        for (int i = 0; i < expectedPermissions.Count; i++)
        {
            Assert.Equal(expectedPermissions[i], parameters.Permissions[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ApiKeys::ApiKeyCreateParams { ID = "id", Name = "Production Key" };

        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawBodyData.ContainsKey("environment"));
        Assert.Null(parameters.Permissions);
        Assert.False(parameters.RawBodyData.ContainsKey("permissions"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ApiKeys::ApiKeyCreateParams
        {
            ID = "id",
            Name = "Production Key",

            // Null should be interpreted as omitted for these properties
            Environment = null,
            Permissions = null,
        };

        Assert.Null(parameters.Environment);
        Assert.False(parameters.RawBodyData.ContainsKey("environment"));
        Assert.Null(parameters.Permissions);
        Assert.False(parameters.RawBodyData.ContainsKey("permissions"));
    }

    [Fact]
    public void Url_Works()
    {
        ApiKeys::ApiKeyCreateParams parameters = new() { ID = "id", Name = "Production Key" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/sub-accounts/id/api-keys"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ApiKeys::ApiKeyCreateParams
        {
            ID = "id",
            Name = "Production Key",
            Environment = ApiKeys::Environment.Live,
            Permissions = ["string"],
        };

        ApiKeys::ApiKeyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnvironmentTest : TestBase
{
    [Theory]
    [InlineData(ApiKeys::Environment.Live)]
    [InlineData(ApiKeys::Environment.Test)]
    public void Validation_Works(ApiKeys::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::Environment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeys::Environment.Live)]
    [InlineData(ApiKeys::Environment.Test)]
    public void SerializationRoundtrip_Works(ApiKeys::Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::Environment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
