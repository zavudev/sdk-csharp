using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowStepTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
            NextStepID = "nextStepId",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Type> expectedType = Type.Message;
        string expectedNextStepID = "nextStepId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfig.Count, model.Config.Count);
        foreach (var item in expectedConfig)
        {
            Assert.True(model.Config.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Config[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedNextStepID, model.NextStepID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
            NextStepID = "nextStepId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlowStep>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
            NextStepID = "nextStepId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FlowStep>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedConfig = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Type> expectedType = Type.Message;
        string expectedNextStepID = "nextStepId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfig.Count, deserialized.Config.Count);
        foreach (var item in expectedConfig)
        {
            Assert.True(deserialized.Config.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Config[item.Key]));
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedNextStepID, deserialized.NextStepID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
            NextStepID = "nextStepId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
        };

        Assert.Null(model.NextStepID);
        Assert.False(model.RawData.ContainsKey("nextStepId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,

            NextStepID = null,
        };

        Assert.Null(model.NextStepID);
        Assert.True(model.RawData.ContainsKey("nextStepId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,

            NextStepID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FlowStep
        {
            ID = "id",
            Config = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.Message,
            NextStepID = "nextStepId",
        };

        FlowStep copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Message)]
    [InlineData(Type.Collect)]
    [InlineData(Type.Condition)]
    [InlineData(Type.Tool)]
    [InlineData(Type.Llm)]
    [InlineData(Type.Transfer)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Message)]
    [InlineData(Type.Collect)]
    [InlineData(Type.Condition)]
    [InlineData(Type.Tool)]
    [InlineData(Type.Llm)]
    [InlineData(Type.Transfer)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
