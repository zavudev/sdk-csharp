using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class WhatsappCategoryTest : TestBase
{
    [Theory]
    [InlineData(WhatsappCategory.Utility)]
    [InlineData(WhatsappCategory.Marketing)]
    [InlineData(WhatsappCategory.Authentication)]
    public void Validation_Works(WhatsappCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsappCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsappCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WhatsappCategory.Utility)]
    [InlineData(WhatsappCategory.Marketing)]
    [InlineData(WhatsappCategory.Authentication)]
    public void SerializationRoundtrip_Works(WhatsappCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsappCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsappCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsappCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsappCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
