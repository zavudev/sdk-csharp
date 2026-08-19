using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.AgentTemplates;

namespace Zavudev.Tests.Models.AgentTemplates;

public class AgentTemplateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentTemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "fermi",
                    Category = ItemCategory.Sales,
                    Name = "name",
                    Summary = "summary",
                    ToolCount = 0,
                    Voice = true,
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "fermi",
                Category = ItemCategory.Sales,
                Name = "name",
                Summary = "summary",
                ToolCount = 0,
                Voice = true,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentTemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "fermi",
                    Category = ItemCategory.Sales,
                    Name = "name",
                    Summary = "summary",
                    ToolCount = 0,
                    Voice = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTemplateListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentTemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "fermi",
                    Category = ItemCategory.Sales,
                    Name = "name",
                    Summary = "summary",
                    ToolCount = 0,
                    Voice = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTemplateListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "fermi",
                Category = ItemCategory.Sales,
                Name = "name",
                Summary = "summary",
                ToolCount = 0,
                Voice = true,
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentTemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "fermi",
                    Category = ItemCategory.Sales,
                    Name = "name",
                    Summary = "summary",
                    ToolCount = 0,
                    Voice = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentTemplateListResponse
        {
            Items =
            [
                new()
                {
                    ID = "fermi",
                    Category = ItemCategory.Sales,
                    Name = "name",
                    Summary = "summary",
                    ToolCount = 0,
                    Voice = true,
                },
            ],
        };

        AgentTemplateListResponse copied = new(model);

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
            ID = "fermi",
            Category = ItemCategory.Sales,
            Name = "name",
            Summary = "summary",
            ToolCount = 0,
            Voice = true,
        };

        string expectedID = "fermi";
        ApiEnum<string, ItemCategory> expectedCategory = ItemCategory.Sales;
        string expectedName = "name";
        string expectedSummary = "summary";
        long expectedToolCount = 0;
        bool expectedVoice = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedToolCount, model.ToolCount);
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "fermi",
            Category = ItemCategory.Sales,
            Name = "name",
            Summary = "summary",
            ToolCount = 0,
            Voice = true,
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
            ID = "fermi",
            Category = ItemCategory.Sales,
            Name = "name",
            Summary = "summary",
            ToolCount = 0,
            Voice = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "fermi";
        ApiEnum<string, ItemCategory> expectedCategory = ItemCategory.Sales;
        string expectedName = "name";
        string expectedSummary = "summary";
        long expectedToolCount = 0;
        bool expectedVoice = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.Equal(expectedToolCount, deserialized.ToolCount);
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "fermi",
            Category = ItemCategory.Sales,
            Name = "name",
            Summary = "summary",
            ToolCount = 0,
            Voice = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "fermi",
            Category = ItemCategory.Sales,
            Name = "name",
            Summary = "summary",
            ToolCount = 0,
            Voice = true,
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemCategoryTest : TestBase
{
    [Theory]
    [InlineData(ItemCategory.Sales)]
    [InlineData(ItemCategory.Support)]
    [InlineData(ItemCategory.FrontDesk)]
    [InlineData(ItemCategory.Ops)]
    public void Validation_Works(ItemCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ItemCategory.Sales)]
    [InlineData(ItemCategory.Support)]
    [InlineData(ItemCategory.FrontDesk)]
    [InlineData(ItemCategory.Ops)]
    public void SerializationRoundtrip_Works(ItemCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
