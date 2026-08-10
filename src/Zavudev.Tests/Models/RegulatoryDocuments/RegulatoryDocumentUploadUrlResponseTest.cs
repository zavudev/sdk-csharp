using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentUploadUrlResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegulatoryDocumentUploadUrlResponse { UploadUrl = "https://example.com" };

        string expectedUploadUrl = "https://example.com";

        Assert.Equal(expectedUploadUrl, model.UploadUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegulatoryDocumentUploadUrlResponse { UploadUrl = "https://example.com" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentUploadUrlResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegulatoryDocumentUploadUrlResponse { UploadUrl = "https://example.com" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentUploadUrlResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUploadUrl = "https://example.com";

        Assert.Equal(expectedUploadUrl, deserialized.UploadUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegulatoryDocumentUploadUrlResponse { UploadUrl = "https://example.com" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegulatoryDocumentUploadUrlResponse { UploadUrl = "https://example.com" };

        RegulatoryDocumentUploadUrlResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
