using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Urls;

namespace Zavudev.Tests.Models.Urls;

public class UrlSubmitForVerificationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlSubmitForVerificationResponse
        {
            Url = new()
            {
                ID = "url_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "example.com",
                Status = VerifiedUrlStatus.Pending,
                Url = "https://example.com/page",
                ApprovalType = ApprovalType.Manual,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        VerifiedUrl expectedUrl = new()
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlSubmitForVerificationResponse
        {
            Url = new()
            {
                ID = "url_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "example.com",
                Status = VerifiedUrlStatus.Pending,
                Url = "https://example.com/page",
                ApprovalType = ApprovalType.Manual,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlSubmitForVerificationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlSubmitForVerificationResponse
        {
            Url = new()
            {
                ID = "url_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "example.com",
                Status = VerifiedUrlStatus.Pending,
                Url = "https://example.com/page",
                ApprovalType = ApprovalType.Manual,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlSubmitForVerificationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        VerifiedUrl expectedUrl = new()
        {
            ID = "url_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Domain = "example.com",
            Status = VerifiedUrlStatus.Pending,
            Url = "https://example.com/page",
            ApprovalType = ApprovalType.Manual,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlSubmitForVerificationResponse
        {
            Url = new()
            {
                ID = "url_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "example.com",
                Status = VerifiedUrlStatus.Pending,
                Url = "https://example.com/page",
                ApprovalType = ApprovalType.Manual,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlSubmitForVerificationResponse
        {
            Url = new()
            {
                ID = "url_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Domain = "example.com",
                Status = VerifiedUrlStatus.Pending,
                Url = "https://example.com/page",
                ApprovalType = ApprovalType.Manual,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        UrlSubmitForVerificationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
