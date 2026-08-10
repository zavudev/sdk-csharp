using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegulatoryDocumentRetrieveResponse
        {
            Document = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentType = RegulatoryDocumentDocumentType.Passport,
                Name = "name",
                Status = Status.Pending,
                FileSize = 0,
                MimeType = "mimeType",
                RejectionReason = "rejectionReason",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        RegulatoryDocument expectedDocument = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            RejectionReason = "rejectionReason",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedDocument, model.Document);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegulatoryDocumentRetrieveResponse
        {
            Document = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentType = RegulatoryDocumentDocumentType.Passport,
                Name = "name",
                Status = Status.Pending,
                FileSize = 0,
                MimeType = "mimeType",
                RejectionReason = "rejectionReason",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegulatoryDocumentRetrieveResponse
        {
            Document = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentType = RegulatoryDocumentDocumentType.Passport,
                Name = "name",
                Status = Status.Pending,
                FileSize = 0,
                MimeType = "mimeType",
                RejectionReason = "rejectionReason",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RegulatoryDocument expectedDocument = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            RejectionReason = "rejectionReason",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedDocument, deserialized.Document);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegulatoryDocumentRetrieveResponse
        {
            Document = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentType = RegulatoryDocumentDocumentType.Passport,
                Name = "name",
                Status = Status.Pending,
                FileSize = 0,
                MimeType = "mimeType",
                RejectionReason = "rejectionReason",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegulatoryDocumentRetrieveResponse
        {
            Document = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DocumentType = RegulatoryDocumentDocumentType.Passport,
                Name = "name",
                Status = Status.Pending,
                FileSize = 0,
                MimeType = "mimeType",
                RejectionReason = "rejectionReason",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        RegulatoryDocumentRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
