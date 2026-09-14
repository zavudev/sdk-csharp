using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionListDeploymentsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionListDeploymentsResponse
        {
            Deployments =
            [
                new()
                {
                    ID = "id",
                    BundleSizeBytes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    IsActive = true,
                    Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                    Version = 0,
                },
            ],
        };

        List<FunctionListDeploymentsResponseDeployment> expectedDeployments =
        [
            new()
            {
                ID = "id",
                BundleSizeBytes = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                IsActive = true,
                Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                Version = 0,
            },
        ];

        Assert.Equal(expectedDeployments.Count, model.Deployments.Count);
        for (int i = 0; i < expectedDeployments.Count; i++)
        {
            Assert.Equal(expectedDeployments[i], model.Deployments[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionListDeploymentsResponse
        {
            Deployments =
            [
                new()
                {
                    ID = "id",
                    BundleSizeBytes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    IsActive = true,
                    Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                    Version = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListDeploymentsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionListDeploymentsResponse
        {
            Deployments =
            [
                new()
                {
                    ID = "id",
                    BundleSizeBytes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    IsActive = true,
                    Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                    Version = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListDeploymentsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FunctionListDeploymentsResponseDeployment> expectedDeployments =
        [
            new()
            {
                ID = "id",
                BundleSizeBytes = 0,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                IsActive = true,
                Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                Version = 0,
            },
        ];

        Assert.Equal(expectedDeployments.Count, deserialized.Deployments.Count);
        for (int i = 0; i < expectedDeployments.Count; i++)
        {
            Assert.Equal(expectedDeployments[i], deserialized.Deployments[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionListDeploymentsResponse
        {
            Deployments =
            [
                new()
                {
                    ID = "id",
                    BundleSizeBytes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    IsActive = true,
                    Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                    Version = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionListDeploymentsResponse
        {
            Deployments =
            [
                new()
                {
                    ID = "id",
                    BundleSizeBytes = 0,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    IsActive = true,
                    Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
                    Version = 0,
                },
            ],
        };

        FunctionListDeploymentsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionListDeploymentsResponseDeploymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            BundleSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        string expectedID = "id";
        long expectedBundleSizeBytes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        bool expectedIsActive = true;
        ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus> expectedStatus =
            FunctionListDeploymentsResponseDeploymentStatus.Pending;
        long expectedVersion = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBundleSizeBytes, model.BundleSizeBytes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeployedAt, model.DeployedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            BundleSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListDeploymentsResponseDeployment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            BundleSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListDeploymentsResponseDeployment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedBundleSizeBytes = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        bool expectedIsActive = true;
        ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus> expectedStatus =
            FunctionListDeploymentsResponseDeploymentStatus.Pending;
        long expectedVersion = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBundleSizeBytes, deserialized.BundleSizeBytes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeployedAt, deserialized.DeployedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            BundleSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            BundleSizeBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            BundleSizeBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            BundleSizeBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsActive = null,
            Status = null,
            Version = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("isActive"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            BundleSizeBytes = 0,
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            IsActive = null,
            Status = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        Assert.Null(model.BundleSizeBytes);
        Assert.False(model.RawData.ContainsKey("bundleSizeBytes"));
        Assert.Null(model.DeployedAt);
        Assert.False(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,

            BundleSizeBytes = null,
            DeployedAt = null,
            ErrorMessage = null,
        };

        Assert.Null(model.BundleSizeBytes);
        Assert.True(model.RawData.ContainsKey("bundleSizeBytes"));
        Assert.Null(model.DeployedAt);
        Assert.True(model.RawData.ContainsKey("deployedAt"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("errorMessage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,

            BundleSizeBytes = null,
            DeployedAt = null,
            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionListDeploymentsResponseDeployment
        {
            ID = "id",
            BundleSizeBytes = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeployedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            IsActive = true,
            Status = FunctionListDeploymentsResponseDeploymentStatus.Pending,
            Version = 0,
        };

        FunctionListDeploymentsResponseDeployment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionListDeploymentsResponseDeploymentStatusTest : TestBase
{
    [Theory]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Pending)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Bundling)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Uploading)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Publishing)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Active)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Failed)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Superseded)]
    public void Validation_Works(FunctionListDeploymentsResponseDeploymentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Pending)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Bundling)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Uploading)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Publishing)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Active)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Failed)]
    [InlineData(FunctionListDeploymentsResponseDeploymentStatus.Superseded)]
    public void SerializationRoundtrip_Works(
        FunctionListDeploymentsResponseDeploymentStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
