using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderUploadProfilePictureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderUploadProfilePictureParams
        {
            SenderID = "senderId",
            ImageUrl = "https://example.com/profile.jpg",
            MimeType = MimeType.ImageJpeg,
        };

        string expectedSenderID = "senderId";
        string expectedImageUrl = "https://example.com/profile.jpg";
        ApiEnum<string, MimeType> expectedMimeType = MimeType.ImageJpeg;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedImageUrl, parameters.ImageUrl);
        Assert.Equal(expectedMimeType, parameters.MimeType);
    }

    [Fact]
    public void Url_Works()
    {
        SenderUploadProfilePictureParams parameters = new()
        {
            SenderID = "senderId",
            ImageUrl = "https://example.com/profile.jpg",
            MimeType = MimeType.ImageJpeg,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/profile/picture"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderUploadProfilePictureParams
        {
            SenderID = "senderId",
            ImageUrl = "https://example.com/profile.jpg",
            MimeType = MimeType.ImageJpeg,
        };

        SenderUploadProfilePictureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MimeTypeTest : TestBase
{
    [Theory]
    [InlineData(MimeType.ImageJpeg)]
    [InlineData(MimeType.ImagePng)]
    public void Validation_Works(MimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MimeType.ImageJpeg)]
    [InlineData(MimeType.ImagePng)]
    public void SerializationRoundtrip_Works(MimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
