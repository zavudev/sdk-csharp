using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RegulatoryDocumentCreateParams
        {
            DocumentType = DocumentType.Passport,
            FileSize = 102400,
            MimeType = "image/jpeg",
            Name = "Passport Scan",
            StorageID = "kg2abc123...",
        };

        ApiEnum<string, DocumentType> expectedDocumentType = DocumentType.Passport;
        long expectedFileSize = 102400;
        string expectedMimeType = "image/jpeg";
        string expectedName = "Passport Scan";
        string expectedStorageID = "kg2abc123...";

        Assert.Equal(expectedDocumentType, parameters.DocumentType);
        Assert.Equal(expectedFileSize, parameters.FileSize);
        Assert.Equal(expectedMimeType, parameters.MimeType);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStorageID, parameters.StorageID);
    }

    [Fact]
    public void Url_Works()
    {
        RegulatoryDocumentCreateParams parameters = new()
        {
            DocumentType = DocumentType.Passport,
            FileSize = 102400,
            MimeType = "image/jpeg",
            Name = "Passport Scan",
            StorageID = "kg2abc123...",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/documents"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RegulatoryDocumentCreateParams
        {
            DocumentType = DocumentType.Passport,
            FileSize = 102400,
            MimeType = "image/jpeg",
            Name = "Passport Scan",
            StorageID = "kg2abc123...",
        };

        RegulatoryDocumentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DocumentTypeTest : TestBase
{
    [Theory]
    [InlineData(DocumentType.Passport)]
    [InlineData(DocumentType.NationalID)]
    [InlineData(DocumentType.DriversLicense)]
    [InlineData(DocumentType.UtilityBill)]
    [InlineData(DocumentType.TaxID)]
    [InlineData(DocumentType.BusinessRegistration)]
    [InlineData(DocumentType.ProofOfAddress)]
    [InlineData(DocumentType.Other)]
    public void Validation_Works(DocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DocumentType.Passport)]
    [InlineData(DocumentType.NationalID)]
    [InlineData(DocumentType.DriversLicense)]
    [InlineData(DocumentType.UtilityBill)]
    [InlineData(DocumentType.TaxID)]
    [InlineData(DocumentType.BusinessRegistration)]
    [InlineData(DocumentType.ProofOfAddress)]
    [InlineData(DocumentType.Other)]
    public void SerializationRoundtrip_Works(DocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
