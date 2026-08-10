using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolParameters
        {
            Properties = new Dictionary<string, PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Type.Object,
        };

        Dictionary<string, PropertiesItem> expectedProperties = new()
        {
            {
                "foo",
                new() { Description = "description", Type = "type" }
            },
        };
        List<string> expectedRequired = ["string"];
        ApiEnum<string, Type> expectedType = Type.Object;

        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Properties[item.Key]);
        }
        Assert.Equal(expectedRequired.Count, model.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], model.Required[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolParameters
        {
            Properties = new Dictionary<string, PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Type.Object,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolParameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolParameters
        {
            Properties = new Dictionary<string, PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Type.Object,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolParameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, PropertiesItem> expectedProperties = new()
        {
            {
                "foo",
                new() { Description = "description", Type = "type" }
            },
        };
        List<string> expectedRequired = ["string"];
        ApiEnum<string, Type> expectedType = Type.Object;

        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Properties[item.Key]);
        }
        Assert.Equal(expectedRequired.Count, deserialized.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], deserialized.Required[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolParameters
        {
            Properties = new Dictionary<string, PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Type.Object,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolParameters
        {
            Properties = new Dictionary<string, PropertiesItem>()
            {
                {
                    "foo",
                    new() { Description = "description", Type = "type" }
                },
            },
            Required = ["string"],
            Type = Type.Object,
        };

        ToolParameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PropertiesItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PropertiesItem { Description = "description", Type = "type" };

        string expectedDescription = "description";
        string expectedType = "type";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PropertiesItem { Description = "description", Type = "type" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PropertiesItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PropertiesItem { Description = "description", Type = "type" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PropertiesItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedType = "type";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PropertiesItem { Description = "description", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PropertiesItem { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PropertiesItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PropertiesItem
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Type = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PropertiesItem
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PropertiesItem { Description = "description", Type = "type" };

        PropertiesItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Object)]
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
    [InlineData(Type.Object)]
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
