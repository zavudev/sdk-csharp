using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.AgentTemplates;

namespace Zavudev.Tests.Models.AgentTemplates;

public class AgentTemplateRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentTemplateRetrieveResponse
        {
            Template = new()
            {
                ID = "fermi",
                Category = Category.Sales,
                DefaultSlug = "fermi",
                Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
                Files = [new() { Content = "content", Path = "index.ts" }],
                Name = "name",
                RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
                Summary = "summary",
                Voice = true,
            },
        };

        Template expectedTemplate = new()
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        Assert.Equal(expectedTemplate, model.Template);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentTemplateRetrieveResponse
        {
            Template = new()
            {
                ID = "fermi",
                Category = Category.Sales,
                DefaultSlug = "fermi",
                Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
                Files = [new() { Content = "content", Path = "index.ts" }],
                Name = "name",
                RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
                Summary = "summary",
                Voice = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTemplateRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentTemplateRetrieveResponse
        {
            Template = new()
            {
                ID = "fermi",
                Category = Category.Sales,
                DefaultSlug = "fermi",
                Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
                Files = [new() { Content = "content", Path = "index.ts" }],
                Name = "name",
                RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
                Summary = "summary",
                Voice = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTemplateRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Template expectedTemplate = new()
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentTemplateRetrieveResponse
        {
            Template = new()
            {
                ID = "fermi",
                Category = Category.Sales,
                DefaultSlug = "fermi",
                Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
                Files = [new() { Content = "content", Path = "index.ts" }],
                Name = "name",
                RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
                Summary = "summary",
                Voice = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentTemplateRetrieveResponse
        {
            Template = new()
            {
                ID = "fermi",
                Category = Category.Sales,
                DefaultSlug = "fermi",
                Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
                Files = [new() { Content = "content", Path = "index.ts" }],
                Name = "name",
                RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
                Summary = "summary",
                Voice = true,
            },
        };

        AgentTemplateRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        string expectedID = "fermi";
        ApiEnum<string, Category> expectedCategory = Category.Sales;
        string expectedDefaultSlug = "fermi";
        Dictionary<string, string> expectedDependencies = new() { { "foo", "string" } };
        List<File> expectedFiles = [new() { Content = "content", Path = "index.ts" }];
        string expectedName = "name";
        List<RequiredSecret> expectedRequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }];
        string expectedSummary = "summary";
        bool expectedVoice = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedDefaultSlug, model.DefaultSlug);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(model.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Dependencies[item.Key]);
        }
        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRequiredSecrets.Count, model.RequiredSecrets.Count);
        for (int i = 0; i < expectedRequiredSecrets.Count; i++)
        {
            Assert.Equal(expectedRequiredSecrets[i], model.RequiredSecrets[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Template
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Template
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "fermi";
        ApiEnum<string, Category> expectedCategory = Category.Sales;
        string expectedDefaultSlug = "fermi";
        Dictionary<string, string> expectedDependencies = new() { { "foo", "string" } };
        List<File> expectedFiles = [new() { Content = "content", Path = "index.ts" }];
        string expectedName = "name";
        List<RequiredSecret> expectedRequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }];
        string expectedSummary = "summary";
        bool expectedVoice = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedDefaultSlug, deserialized.DefaultSlug);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(deserialized.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Dependencies[item.Key]);
        }
        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRequiredSecrets.Count, deserialized.RequiredSecrets.Count);
        for (int i = 0; i < expectedRequiredSecrets.Count; i++)
        {
            Assert.Equal(expectedRequiredSecrets[i], deserialized.RequiredSecrets[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Template
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Template
        {
            ID = "fermi",
            Category = Category.Sales,
            DefaultSlug = "fermi",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
            Files = [new() { Content = "content", Path = "index.ts" }],
            Name = "name",
            RequiredSecrets = [new() { Hint = "hint", Key = "SENDER_ID" }],
            Summary = "summary",
            Voice = true,
        };

        Template copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Sales)]
    [InlineData(Category.Support)]
    [InlineData(Category.FrontDesk)]
    [InlineData(Category.Ops)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Sales)]
    [InlineData(Category.Support)]
    [InlineData(Category.FrontDesk)]
    [InlineData(Category.Ops)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File { Content = "content", Path = "index.ts" };

        string expectedContent = "content";
        string expectedPath = "index.ts";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File { Content = "content", Path = "index.ts" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File { Content = "content", Path = "index.ts" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedPath = "index.ts";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File { Content = "content", Path = "index.ts" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File { Content = "content", Path = "index.ts" };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequiredSecretTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequiredSecret { Hint = "hint", Key = "SENDER_ID" };

        string expectedHint = "hint";
        string expectedKey = "SENDER_ID";

        Assert.Equal(expectedHint, model.Hint);
        Assert.Equal(expectedKey, model.Key);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequiredSecret { Hint = "hint", Key = "SENDER_ID" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequiredSecret>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequiredSecret { Hint = "hint", Key = "SENDER_ID" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequiredSecret>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedHint = "hint";
        string expectedKey = "SENDER_ID";

        Assert.Equal(expectedHint, deserialized.Hint);
        Assert.Equal(expectedKey, deserialized.Key);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequiredSecret { Hint = "hint", Key = "SENDER_ID" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequiredSecret { Hint = "hint", Key = "SENDER_ID" };

        RequiredSecret copied = new(model);

        Assert.Equal(model, copied);
    }
}
