using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionDeployResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionDeployResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = DeploymentStatus.Pending,
                Version = 0,
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
        };

        Deployment expectedDeployment = new()
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        Assert.Equal(expectedDeployment, model.Deployment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionDeployResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = DeploymentStatus.Pending,
                Version = 0,
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDeployResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionDeployResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = DeploymentStatus.Pending,
                Version = 0,
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDeployResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Deployment expectedDeployment = new()
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        Assert.Equal(expectedDeployment, deserialized.Deployment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionDeployResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = DeploymentStatus.Pending,
                Version = 0,
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionDeployResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = DeploymentStatus.Pending,
                Version = 0,
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
        };

        FunctionDeployResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string expectedID = "fnd_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        ApiEnum<string, DeploymentStatus> expectedStatus = DeploymentStatus.Pending;
        long expectedVersion = 0;
        long expectedBundleBytes = 0;
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        long expectedSourceCodeBytes = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedBundleBytes, model.BundleBytes);
        Assert.Equal(expectedDeployedAt, model.DeployedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedSourceCodeBytes, model.SourceCodeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Deployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Deployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fnd_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        ApiEnum<string, DeploymentStatus> expectedStatus = DeploymentStatus.Pending;
        long expectedVersion = 0;
        long expectedBundleBytes = 0;
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        long expectedSourceCodeBytes = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedBundleBytes, deserialized.BundleBytes);
        Assert.Equal(expectedDeployedAt, deserialized.DeployedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedSourceCodeBytes, deserialized.SourceCodeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
        };

        Assert.Null(model.BundleBytes);
        Assert.False(model.RawData.ContainsKey("bundleBytes"));
        Assert.Null(model.DeployedAt);
        Assert.False(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.SourceCodeBytes);
        Assert.False(model.RawData.ContainsKey("sourceCodeBytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,

            BundleBytes = null,
            DeployedAt = null,
            ErrorMessage = null,
            SourceCodeBytes = null,
        };

        Assert.Null(model.BundleBytes);
        Assert.True(model.RawData.ContainsKey("bundleBytes"));
        Assert.Null(model.DeployedAt);
        Assert.True(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.SourceCodeBytes);
        Assert.True(model.RawData.ContainsKey("sourceCodeBytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,

            BundleBytes = null,
            DeployedAt = null,
            ErrorMessage = null,
            SourceCodeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Deployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = DeploymentStatus.Pending,
            Version = 0,
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        Deployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeploymentStatusTest : TestBase
{
    [Theory]
    [InlineData(DeploymentStatus.Pending)]
    [InlineData(DeploymentStatus.Bundling)]
    [InlineData(DeploymentStatus.Uploading)]
    [InlineData(DeploymentStatus.Publishing)]
    [InlineData(DeploymentStatus.Active)]
    [InlineData(DeploymentStatus.Failed)]
    [InlineData(DeploymentStatus.Superseded)]
    public void Validation_Works(DeploymentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeploymentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeploymentStatus.Pending)]
    [InlineData(DeploymentStatus.Bundling)]
    [InlineData(DeploymentStatus.Uploading)]
    [InlineData(DeploymentStatus.Publishing)]
    [InlineData(DeploymentStatus.Active)]
    [InlineData(DeploymentStatus.Failed)]
    [InlineData(DeploymentStatus.Superseded)]
    public void SerializationRoundtrip_Works(DeploymentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeploymentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeploymentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeploymentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeploymentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
