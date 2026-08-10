using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class RequirementFieldTypeTest : TestBase
{
    [Theory]
    [InlineData(RequirementFieldType.Textual)]
    [InlineData(RequirementFieldType.Address)]
    [InlineData(RequirementFieldType.Document)]
    [InlineData(RequirementFieldType.Action)]
    public void Validation_Works(RequirementFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RequirementFieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RequirementFieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RequirementFieldType.Textual)]
    [InlineData(RequirementFieldType.Address)]
    [InlineData(RequirementFieldType.Document)]
    [InlineData(RequirementFieldType.Action)]
    public void SerializationRoundtrip_Works(RequirementFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RequirementFieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RequirementFieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RequirementFieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RequirementFieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
