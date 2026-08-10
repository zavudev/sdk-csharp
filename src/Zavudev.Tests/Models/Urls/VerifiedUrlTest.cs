using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Urls;

namespace Zavudev.Tests.Models.Urls;

public class VerifiedUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "url_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDomain = "example.com";
        ApiEnum<string, VerifiedUrlStatus> expectedStatus = VerifiedUrlStatus.Pending;
        string expectedUrl = "https://example.com/page";
        ApiEnum<string, ApprovalType> expectedApprovalType = ApprovalType.Manual;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedApprovalType, model.ApprovalType);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifiedUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifiedUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "url_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDomain = "example.com";
        ApiEnum<string, VerifiedUrlStatus> expectedStatus = VerifiedUrlStatus.Pending;
        string expectedUrl = "https://example.com/page";
        ApiEnum<string, ApprovalType> expectedApprovalType = ApprovalType.Manual;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedApprovalType, deserialized.ApprovalType);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
        };

        Assert.Null(model.ApprovalType);
        Assert.False(model.RawData.ContainsKey("approvalType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",

            // Null should be interpreted as omitted for these properties
            ApprovalType = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ApprovalType);
        Assert.False(model.RawData.ContainsKey("approvalType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",

            // Null should be interpreted as omitted for these properties
            ApprovalType = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifiedUrl
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        VerifiedUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifiedUrlStatusTest : TestBase
{
    [Theory]
    [InlineData(VerifiedUrlStatus.Pending)]
    [InlineData(VerifiedUrlStatus.Approved)]
    [InlineData(VerifiedUrlStatus.Rejected)]
    [InlineData(VerifiedUrlStatus.Escalated)]
    [InlineData(VerifiedUrlStatus.Malicious)]
    public void Validation_Works(VerifiedUrlStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifiedUrlStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifiedUrlStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifiedUrlStatus.Pending)]
    [InlineData(VerifiedUrlStatus.Approved)]
    [InlineData(VerifiedUrlStatus.Rejected)]
    [InlineData(VerifiedUrlStatus.Escalated)]
    [InlineData(VerifiedUrlStatus.Malicious)]
    public void SerializationRoundtrip_Works(VerifiedUrlStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifiedUrlStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifiedUrlStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifiedUrlStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifiedUrlStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ApprovalTypeTest : TestBase
{
    [Theory]
    [InlineData(ApprovalType.Manual)]
    [InlineData(ApprovalType.AutoWebRisk)]
    public void Validation_Works(ApprovalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApprovalType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApprovalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApprovalType.Manual)]
    [InlineData(ApprovalType.AutoWebRisk)]
    public void SerializationRoundtrip_Works(ApprovalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApprovalType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApprovalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApprovalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApprovalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
