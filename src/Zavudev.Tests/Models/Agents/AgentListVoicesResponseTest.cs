using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Agents;

namespace Zavudev.Tests.Models.Agents;

public class AgentListVoicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
            Total = 0,
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "aura-2-celeste-es",
                Language = "es",
                Name = "celeste",
            },
        ];
        List<string> expectedLanguages = ["string"];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListVoicesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListVoicesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "aura-2-celeste-es",
                Language = "es",
                Name = "celeste",
            },
        ];
        List<string> expectedLanguages = ["string"];
        long expectedTotal = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
        };

        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],

            // Null should be interpreted as omitted for these properties
            Total = null,
        };

        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],

            // Null should be interpreted as omitted for these properties
            Total = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentListVoicesResponse
        {
            Items =
            [
                new()
                {
                    ID = "aura-2-celeste-es",
                    Language = "es",
                    Name = "celeste",
                },
            ],
            Languages = ["string"],
            Total = 0,
        };

        AgentListVoicesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "aura-2-celeste-es",
            Language = "es",
            Name = "celeste",
        };

        string expectedID = "aura-2-celeste-es";
        string expectedLanguage = "es";
        string expectedName = "celeste";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "aura-2-celeste-es",
            Language = "es",
            Name = "celeste",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "aura-2-celeste-es",
            Language = "es",
            Name = "celeste",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "aura-2-celeste-es";
        string expectedLanguage = "es";
        string expectedName = "celeste";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "aura-2-celeste-es",
            Language = "es",
            Name = "celeste",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "aura-2-celeste-es",
            Language = "es",
            Name = "celeste",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
