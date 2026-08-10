using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<RegulatoryDocument> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocumentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RegulatoryDocument> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegulatoryDocumentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        RegulatoryDocumentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
