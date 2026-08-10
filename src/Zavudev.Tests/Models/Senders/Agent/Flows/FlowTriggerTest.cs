using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        ApiEnum<string, FlowTriggerType> expectedType = FlowTriggerType.Keyword;
        string expectedIntent = "intent";
        List<string> expectedKeywords = ["string"];

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedIntent, model.Intent);
        Assert.NotNull(model.Keywords);
        Assert.Equal(expectedKeywords.Count, model.Keywords.Count);
        for (int i = 0; i < expectedKeywords.Count; i++)
        {
            Assert.Equal(expectedKeywords[i], model.Keywords[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlowTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlowTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FlowTriggerType> expectedType = FlowTriggerType.Keyword;
        string expectedIntent = "intent";
        List<string> expectedKeywords = ["string"];

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedIntent, deserialized.Intent);
        Assert.NotNull(deserialized.Keywords);
        Assert.Equal(expectedKeywords.Count, deserialized.Keywords.Count);
        for (int i = 0; i < expectedKeywords.Count; i++)
        {
            Assert.Equal(expectedKeywords[i], deserialized.Keywords[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FlowTrigger { Type = FlowTriggerType.Keyword };

        Assert.Null(model.Intent);
        Assert.False(model.RawData.ContainsKey("intent"));
        Assert.Null(model.Keywords);
        Assert.False(model.RawData.ContainsKey("keywords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FlowTrigger { Type = FlowTriggerType.Keyword };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,

            // Null should be interpreted as omitted for these properties
            Intent = null,
            Keywords = null,
        };

        Assert.Null(model.Intent);
        Assert.False(model.RawData.ContainsKey("intent"));
        Assert.Null(model.Keywords);
        Assert.False(model.RawData.ContainsKey("keywords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,

            // Null should be interpreted as omitted for these properties
            Intent = null,
            Keywords = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FlowTrigger
        {
            Type = FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        FlowTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FlowTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(FlowTriggerType.Keyword)]
    [InlineData(FlowTriggerType.Intent)]
    [InlineData(FlowTriggerType.Always)]
    [InlineData(FlowTriggerType.Manual)]
    public void Validation_Works(FlowTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FlowTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FlowTriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FlowTriggerType.Keyword)]
    [InlineData(FlowTriggerType.Intent)]
    [InlineData(FlowTriggerType.Always)]
    [InlineData(FlowTriggerType.Manual)]
    public void SerializationRoundtrip_Works(FlowTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FlowTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FlowTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FlowTriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FlowTriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
