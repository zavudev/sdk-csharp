using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionRollbackDeploymentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
            RolledBackToVersion = 0,
        };

        FunctionRollbackDeploymentResponseDeployment expectedDeployment = new()
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };
        JsonElement expectedPreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedRolledBackToVersion = 0;

        Assert.Equal(expectedDeployment, model.Deployment);
        Assert.NotNull(model.PreviousDraft);
        Assert.True(JsonElement.DeepEquals(expectedPreviousDraft, model.PreviousDraft.Value));
        Assert.Equal(expectedRolledBackToVersion, model.RolledBackToVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
            RolledBackToVersion = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionRollbackDeploymentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
            RolledBackToVersion = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionRollbackDeploymentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FunctionRollbackDeploymentResponseDeployment expectedDeployment = new()
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };
        JsonElement expectedPreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}");
        long expectedRolledBackToVersion = 0;

        Assert.Equal(expectedDeployment, deserialized.Deployment);
        Assert.NotNull(deserialized.PreviousDraft);
        Assert.True(
            JsonElement.DeepEquals(expectedPreviousDraft, deserialized.PreviousDraft.Value)
        );
        Assert.Equal(expectedRolledBackToVersion, deserialized.RolledBackToVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
            RolledBackToVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.RolledBackToVersion);
        Assert.False(model.RawData.ContainsKey("rolledBackToVersion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            RolledBackToVersion = null,
        };

        Assert.Null(model.RolledBackToVersion);
        Assert.False(model.RawData.ContainsKey("rolledBackToVersion"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            RolledBackToVersion = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            RolledBackToVersion = 0,
        };

        Assert.Null(model.PreviousDraft);
        Assert.False(model.RawData.ContainsKey("previousDraft"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            RolledBackToVersion = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            RolledBackToVersion = 0,

            PreviousDraft = null,
        };

        Assert.Null(model.PreviousDraft);
        Assert.True(model.RawData.ContainsKey("previousDraft"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            RolledBackToVersion = 0,

            PreviousDraft = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionRollbackDeploymentResponse
        {
            Deployment = new()
            {
                ID = "fnd_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
                Version = 0,
                BuildLogs = "buildLogs",
                BundleBytes = 0,
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                SourceCodeBytes = 0,
            },
            PreviousDraft = JsonSerializer.Deserialize<JsonElement>("{}"),
            RolledBackToVersion = 0,
        };

        FunctionRollbackDeploymentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionRollbackDeploymentResponseDeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string expectedID = "fnd_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus> expectedStatus =
            FunctionRollbackDeploymentResponseDeploymentStatus.Pending;
        long expectedVersion = 0;
        string expectedBuildLogs = "buildLogs";
        long expectedBundleBytes = 0;
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        long expectedSourceCodeBytes = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedBuildLogs, model.BuildLogs);
        Assert.Equal(expectedBundleBytes, model.BundleBytes);
        Assert.Equal(expectedDeployedAt, model.DeployedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedSourceCodeBytes, model.SourceCodeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionRollbackDeploymentResponseDeployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionRollbackDeploymentResponseDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fnd_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus> expectedStatus =
            FunctionRollbackDeploymentResponseDeploymentStatus.Pending;
        long expectedVersion = 0;
        string expectedBuildLogs = "buildLogs";
        long expectedBundleBytes = 0;
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        long expectedSourceCodeBytes = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedBuildLogs, deserialized.BuildLogs);
        Assert.Equal(expectedBundleBytes, deserialized.BundleBytes);
        Assert.Equal(expectedDeployedAt, deserialized.DeployedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedSourceCodeBytes, deserialized.SourceCodeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
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
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
        };

        Assert.Null(model.BuildLogs);
        Assert.False(model.RawData.ContainsKey("buildLogs"));
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
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,

            BuildLogs = null,
            BundleBytes = null,
            DeployedAt = null,
            ErrorMessage = null,
            SourceCodeBytes = null,
        };

        Assert.Null(model.BuildLogs);
        Assert.True(model.RawData.ContainsKey("buildLogs"));
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
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,

            BuildLogs = null,
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
        var model = new FunctionRollbackDeploymentResponseDeployment
        {
            ID = "fnd_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Status = FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            Version = 0,
            BuildLogs = "buildLogs",
            BundleBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            SourceCodeBytes = 0,
        };

        FunctionRollbackDeploymentResponseDeployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionRollbackDeploymentResponseDeploymentStatusTest : TestBase
{
    [Theory]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Pending)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Bundling)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Uploading)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Publishing)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Active)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Failed)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Superseded)]
    public void Validation_Works(FunctionRollbackDeploymentResponseDeploymentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Pending)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Bundling)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Uploading)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Publishing)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Active)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Failed)]
    [InlineData(FunctionRollbackDeploymentResponseDeploymentStatus.Superseded)]
    public void SerializationRoundtrip_Works(
        FunctionRollbackDeploymentResponseDeploymentStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
