using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class WhatsappBusinessProfileVerticalTest : TestBase
{
    [Theory]
    [InlineData(WhatsappBusinessProfileVertical.Undefined)]
    [InlineData(WhatsappBusinessProfileVertical.Other)]
    [InlineData(WhatsappBusinessProfileVertical.Auto)]
    [InlineData(WhatsappBusinessProfileVertical.Beauty)]
    [InlineData(WhatsappBusinessProfileVertical.Apparel)]
    [InlineData(WhatsappBusinessProfileVertical.Edu)]
    [InlineData(WhatsappBusinessProfileVertical.Entertain)]
    [InlineData(WhatsappBusinessProfileVertical.EventPlan)]
    [InlineData(WhatsappBusinessProfileVertical.Finance)]
    [InlineData(WhatsappBusinessProfileVertical.Grocery)]
    [InlineData(WhatsappBusinessProfileVertical.Govt)]
    [InlineData(WhatsappBusinessProfileVertical.Hotel)]
    [InlineData(WhatsappBusinessProfileVertical.Health)]
    [InlineData(WhatsappBusinessProfileVertical.Nonprofit)]
    [InlineData(WhatsappBusinessProfileVertical.ProfServices)]
    [InlineData(WhatsappBusinessProfileVertical.Retail)]
    [InlineData(WhatsappBusinessProfileVertical.Travel)]
    [InlineData(WhatsappBusinessProfileVertical.Restaurant)]
    [InlineData(WhatsappBusinessProfileVertical.NotABiz)]
    public void Validation_Works(WhatsappBusinessProfileVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsappBusinessProfileVertical> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsappBusinessProfileVertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WhatsappBusinessProfileVertical.Undefined)]
    [InlineData(WhatsappBusinessProfileVertical.Other)]
    [InlineData(WhatsappBusinessProfileVertical.Auto)]
    [InlineData(WhatsappBusinessProfileVertical.Beauty)]
    [InlineData(WhatsappBusinessProfileVertical.Apparel)]
    [InlineData(WhatsappBusinessProfileVertical.Edu)]
    [InlineData(WhatsappBusinessProfileVertical.Entertain)]
    [InlineData(WhatsappBusinessProfileVertical.EventPlan)]
    [InlineData(WhatsappBusinessProfileVertical.Finance)]
    [InlineData(WhatsappBusinessProfileVertical.Grocery)]
    [InlineData(WhatsappBusinessProfileVertical.Govt)]
    [InlineData(WhatsappBusinessProfileVertical.Hotel)]
    [InlineData(WhatsappBusinessProfileVertical.Health)]
    [InlineData(WhatsappBusinessProfileVertical.Nonprofit)]
    [InlineData(WhatsappBusinessProfileVertical.ProfServices)]
    [InlineData(WhatsappBusinessProfileVertical.Retail)]
    [InlineData(WhatsappBusinessProfileVertical.Travel)]
    [InlineData(WhatsappBusinessProfileVertical.Restaurant)]
    [InlineData(WhatsappBusinessProfileVertical.NotABiz)]
    public void SerializationRoundtrip_Works(WhatsappBusinessProfileVertical rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsappBusinessProfileVertical> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WhatsappBusinessProfileVertical>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsappBusinessProfileVertical>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WhatsappBusinessProfileVertical>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
