using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegulatoryDocument
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

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RegulatoryDocumentDocumentType> expectedDocumentType =
            RegulatoryDocumentDocumentType.Passport;
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        long expectedFileSize = 0;
        string expectedMimeType = "mimeType";
        string expectedRejectionReason = "rejectionReason";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDocumentType, model.DocumentType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedRejectionReason, model.RejectionReason);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegulatoryDocument
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocument>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegulatoryDocument
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryDocument>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, RegulatoryDocumentDocumentType> expectedDocumentType =
            RegulatoryDocumentDocumentType.Passport;
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        long expectedFileSize = 0;
        string expectedMimeType = "mimeType";
        string expectedRejectionReason = "rejectionReason";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDocumentType, deserialized.DocumentType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedRejectionReason, deserialized.RejectionReason);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegulatoryDocument
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            RejectionReason = "rejectionReason",
        };

        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("fileSize"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            RejectionReason = "rejectionReason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            RejectionReason = "rejectionReason",

            // Null should be interpreted as omitted for these properties
            FileSize = null,
            MimeType = null,
            UpdatedAt = null,
        };

        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("fileSize"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            RejectionReason = "rejectionReason",

            // Null should be interpreted as omitted for these properties
            FileSize = null,
            MimeType = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.RejectionReason);
        Assert.False(model.RawData.ContainsKey("rejectionReason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            RejectionReason = null,
        };

        Assert.Null(model.RejectionReason);
        Assert.True(model.RawData.ContainsKey("rejectionReason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RegulatoryDocument
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DocumentType = RegulatoryDocumentDocumentType.Passport,
            Name = "name",
            Status = Status.Pending,
            FileSize = 0,
            MimeType = "mimeType",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            RejectionReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegulatoryDocument
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

        RegulatoryDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RegulatoryDocumentDocumentTypeTest : TestBase
{
    [Theory]
    [InlineData(RegulatoryDocumentDocumentType.Passport)]
    [InlineData(RegulatoryDocumentDocumentType.NationalID)]
    [InlineData(RegulatoryDocumentDocumentType.DriversLicense)]
    [InlineData(RegulatoryDocumentDocumentType.UtilityBill)]
    [InlineData(RegulatoryDocumentDocumentType.TaxID)]
    [InlineData(RegulatoryDocumentDocumentType.BusinessRegistration)]
    [InlineData(RegulatoryDocumentDocumentType.ProofOfAddress)]
    [InlineData(RegulatoryDocumentDocumentType.Other)]
    public void Validation_Works(RegulatoryDocumentDocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegulatoryDocumentDocumentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegulatoryDocumentDocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RegulatoryDocumentDocumentType.Passport)]
    [InlineData(RegulatoryDocumentDocumentType.NationalID)]
    [InlineData(RegulatoryDocumentDocumentType.DriversLicense)]
    [InlineData(RegulatoryDocumentDocumentType.UtilityBill)]
    [InlineData(RegulatoryDocumentDocumentType.TaxID)]
    [InlineData(RegulatoryDocumentDocumentType.BusinessRegistration)]
    [InlineData(RegulatoryDocumentDocumentType.ProofOfAddress)]
    [InlineData(RegulatoryDocumentDocumentType.Other)]
    public void SerializationRoundtrip_Works(RegulatoryDocumentDocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegulatoryDocumentDocumentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RegulatoryDocumentDocumentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegulatoryDocumentDocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RegulatoryDocumentDocumentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Uploaded)]
    [InlineData(Status.Verified)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Uploaded)]
    [InlineData(Status.Verified)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
