using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateResponse
        {
            Function = new()
            {
                ID = "fn_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
                HttpEnabled = true,
                MemoryMB = 256,
                Name = "Order Bot",
                Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
                Slug = "order-bot",
                Status = FunctionUpdateResponseFunctionStatus.Draft,
                TimeoutSec = 10,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActiveDeploymentID = "activeDeploymentId",
                Description = "description",
                PublicUrl = "https://example.com",
            },
        };

        FunctionUpdateResponseFunction expectedFunction = new()
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        Assert.Equal(expectedFunction, model.Function);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionUpdateResponse
        {
            Function = new()
            {
                ID = "fn_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
                HttpEnabled = true,
                MemoryMB = 256,
                Name = "Order Bot",
                Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
                Slug = "order-bot",
                Status = FunctionUpdateResponseFunctionStatus.Draft,
                TimeoutSec = 10,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActiveDeploymentID = "activeDeploymentId",
                Description = "description",
                PublicUrl = "https://example.com",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateResponse
        {
            Function = new()
            {
                ID = "fn_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
                HttpEnabled = true,
                MemoryMB = 256,
                Name = "Order Bot",
                Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
                Slug = "order-bot",
                Status = FunctionUpdateResponseFunctionStatus.Draft,
                TimeoutSec = 10,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActiveDeploymentID = "activeDeploymentId",
                Description = "description",
                PublicUrl = "https://example.com",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionUpdateResponseFunction expectedFunction = new()
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        Assert.Equal(expectedFunction, deserialized.Function);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionUpdateResponse
        {
            Function = new()
            {
                ID = "fn_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
                HttpEnabled = true,
                MemoryMB = 256,
                Name = "Order Bot",
                Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
                Slug = "order-bot",
                Status = FunctionUpdateResponseFunctionStatus.Draft,
                TimeoutSec = 10,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActiveDeploymentID = "activeDeploymentId",
                Description = "description",
                PublicUrl = "https://example.com",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateResponse
        {
            Function = new()
            {
                ID = "fn_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
                HttpEnabled = true,
                MemoryMB = 256,
                Name = "Order Bot",
                Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
                Slug = "order-bot",
                Status = FunctionUpdateResponseFunctionStatus.Draft,
                TimeoutSec = 10,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActiveDeploymentID = "activeDeploymentId",
                Description = "description",
                PublicUrl = "https://example.com",
            },
        };

        FunctionUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateResponseFunctionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        string expectedID = "fn_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedDependencies = new() { { "openai", "^4.20.0" } };
        bool expectedHttpEnabled = true;
        long expectedMemoryMB = 256;
        string expectedName = "Order Bot";
        ApiEnum<string, FunctionUpdateResponseFunctionRuntime> expectedRuntime =
            FunctionUpdateResponseFunctionRuntime.Nodejs24;
        string expectedSlug = "order-bot";
        ApiEnum<string, FunctionUpdateResponseFunctionStatus> expectedStatus =
            FunctionUpdateResponseFunctionStatus.Draft;
        long expectedTimeoutSec = 10;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedActiveDeploymentID = "activeDeploymentId";
        string expectedDescription = "description";
        string expectedPublicUrl = "https://example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(model.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Dependencies[item.Key]);
        }
        Assert.Equal(expectedHttpEnabled, model.HttpEnabled);
        Assert.Equal(expectedMemoryMB, model.MemoryMB);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRuntime, model.Runtime);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimeoutSec, model.TimeoutSec);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedActiveDeploymentID, model.ActiveDeploymentID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedPublicUrl, model.PublicUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateResponseFunction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionUpdateResponseFunction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fn_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedDependencies = new() { { "openai", "^4.20.0" } };
        bool expectedHttpEnabled = true;
        long expectedMemoryMB = 256;
        string expectedName = "Order Bot";
        ApiEnum<string, FunctionUpdateResponseFunctionRuntime> expectedRuntime =
            FunctionUpdateResponseFunctionRuntime.Nodejs24;
        string expectedSlug = "order-bot";
        ApiEnum<string, FunctionUpdateResponseFunctionStatus> expectedStatus =
            FunctionUpdateResponseFunctionStatus.Draft;
        long expectedTimeoutSec = 10;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedActiveDeploymentID = "activeDeploymentId";
        string expectedDescription = "description";
        string expectedPublicUrl = "https://example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(deserialized.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Dependencies[item.Key]);
        }
        Assert.Equal(expectedHttpEnabled, deserialized.HttpEnabled);
        Assert.Equal(expectedMemoryMB, deserialized.MemoryMB);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRuntime, deserialized.Runtime);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimeoutSec, deserialized.TimeoutSec);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedActiveDeploymentID, deserialized.ActiveDeploymentID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedPublicUrl, deserialized.PublicUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActiveDeploymentID);
        Assert.False(model.RawData.ContainsKey("activeDeploymentId"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.PublicUrl);
        Assert.False(model.RawData.ContainsKey("publicUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveDeploymentID = null,
            Description = null,
            PublicUrl = null,
        };

        Assert.Null(model.ActiveDeploymentID);
        Assert.True(model.RawData.ContainsKey("activeDeploymentId"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.PublicUrl);
        Assert.True(model.RawData.ContainsKey("publicUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActiveDeploymentID = null,
            Description = null,
            PublicUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionUpdateResponseFunction
        {
            ID = "fn_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            HttpEnabled = true,
            MemoryMB = 256,
            Name = "Order Bot",
            Runtime = FunctionUpdateResponseFunctionRuntime.Nodejs24,
            Slug = "order-bot",
            Status = FunctionUpdateResponseFunctionStatus.Draft,
            TimeoutSec = 10,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActiveDeploymentID = "activeDeploymentId",
            Description = "description",
            PublicUrl = "https://example.com",
        };

        FunctionUpdateResponseFunction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionUpdateResponseFunctionRuntimeTest : TestBase
{
    [Theory]
    [InlineData(FunctionUpdateResponseFunctionRuntime.Nodejs24)]
    public void Validation_Works(FunctionUpdateResponseFunctionRuntime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateResponseFunctionRuntime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionRuntime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionUpdateResponseFunctionRuntime.Nodejs24)]
    public void SerializationRoundtrip_Works(FunctionUpdateResponseFunctionRuntime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateResponseFunctionRuntime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionRuntime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionRuntime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionRuntime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FunctionUpdateResponseFunctionStatusTest : TestBase
{
    [Theory]
    [InlineData(FunctionUpdateResponseFunctionStatus.Draft)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Bundling)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Deploying)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Active)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Failed)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Disabled)]
    public void Validation_Works(FunctionUpdateResponseFunctionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateResponseFunctionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionUpdateResponseFunctionStatus.Draft)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Bundling)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Deploying)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Active)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Failed)]
    [InlineData(FunctionUpdateResponseFunctionStatus.Disabled)]
    public void SerializationRoundtrip_Works(FunctionUpdateResponseFunctionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionUpdateResponseFunctionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionUpdateResponseFunctionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
