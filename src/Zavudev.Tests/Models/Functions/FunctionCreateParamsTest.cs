using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionCreateParams
        {
            Name = "Order Bot",
            Slug = "order-bot",
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            Description = "Replies to order status questions on WhatsApp.",
            Entrypoint = "index.ts",
            Files = new Dictionary<string, string>()
            {
                {
                    "index.ts",
                    "import { formatOrder } from './lib/orders';\n\nexport default async function handler(event) {\n  return { statusCode: 200, body: formatOrder(event) };\n}\n"
                },
                {
                    "lib/orders.ts",
                    "export function formatOrder(event) {\n  return JSON.stringify(event);\n}\n"
                },
            },
            HttpEnabled = true,
            MemoryMB = MemoryMB.V128,
            Runtime = Runtime.Nodejs24,
            SourceCode =
                "import { defineFunction } from '@zavudev/functions';\n\nexport default defineFunction(async (event, ctx) => {\n  ctx.log('received', event.type);\n});\n",
            TimeoutSec = 1,
        };

        string expectedName = "Order Bot";
        string expectedSlug = "order-bot";
        Dictionary<string, string> expectedDependencies = new() { { "openai", "^4.20.0" } };
        string expectedDescription = "Replies to order status questions on WhatsApp.";
        string expectedEntrypoint = "index.ts";
        Dictionary<string, string> expectedFiles = new()
        {
            {
                "index.ts",
                "import { formatOrder } from './lib/orders';\n\nexport default async function handler(event) {\n  return { statusCode: 200, body: formatOrder(event) };\n}\n"
            },
            {
                "lib/orders.ts",
                "export function formatOrder(event) {\n  return JSON.stringify(event);\n}\n"
            },
        };
        bool expectedHttpEnabled = true;
        ApiEnum<long, MemoryMB> expectedMemoryMB = MemoryMB.V128;
        ApiEnum<string, Runtime> expectedRuntime = Runtime.Nodejs24;
        string expectedSourceCode =
            "import { defineFunction } from '@zavudev/functions';\n\nexport default defineFunction(async (event, ctx) => {\n  ctx.log('received', event.type);\n});\n";
        long expectedTimeoutSec = 1;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSlug, parameters.Slug);
        Assert.NotNull(parameters.Dependencies);
        Assert.Equal(expectedDependencies.Count, parameters.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(parameters.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Dependencies[item.Key]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEntrypoint, parameters.Entrypoint);
        Assert.NotNull(parameters.Files);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        foreach (var item in expectedFiles)
        {
            Assert.True(parameters.Files.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Files[item.Key]);
        }
        Assert.Equal(expectedHttpEnabled, parameters.HttpEnabled);
        Assert.Equal(expectedMemoryMB, parameters.MemoryMB);
        Assert.Equal(expectedRuntime, parameters.Runtime);
        Assert.Equal(expectedSourceCode, parameters.SourceCode);
        Assert.Equal(expectedTimeoutSec, parameters.TimeoutSec);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionCreateParams { Name = "Order Bot", Slug = "order-bot" };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Entrypoint);
        Assert.False(parameters.RawBodyData.ContainsKey("entrypoint"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.HttpEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("httpEnabled"));
        Assert.Null(parameters.MemoryMB);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryMb"));
        Assert.Null(parameters.Runtime);
        Assert.False(parameters.RawBodyData.ContainsKey("runtime"));
        Assert.Null(parameters.SourceCode);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceCode"));
        Assert.Null(parameters.TimeoutSec);
        Assert.False(parameters.RawBodyData.ContainsKey("timeoutSec"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionCreateParams
        {
            Name = "Order Bot",
            Slug = "order-bot",

            // Null should be interpreted as omitted for these properties
            Dependencies = null,
            Description = null,
            Entrypoint = null,
            Files = null,
            HttpEnabled = null,
            MemoryMB = null,
            Runtime = null,
            SourceCode = null,
            TimeoutSec = null,
        };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Entrypoint);
        Assert.False(parameters.RawBodyData.ContainsKey("entrypoint"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.HttpEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("httpEnabled"));
        Assert.Null(parameters.MemoryMB);
        Assert.False(parameters.RawBodyData.ContainsKey("memoryMb"));
        Assert.Null(parameters.Runtime);
        Assert.False(parameters.RawBodyData.ContainsKey("runtime"));
        Assert.Null(parameters.SourceCode);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceCode"));
        Assert.Null(parameters.TimeoutSec);
        Assert.False(parameters.RawBodyData.ContainsKey("timeoutSec"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionCreateParams parameters = new() { Name = "Order Bot", Slug = "order-bot" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionCreateParams
        {
            Name = "Order Bot",
            Slug = "order-bot",
            Dependencies = new Dictionary<string, string>() { { "openai", "^4.20.0" } },
            Description = "Replies to order status questions on WhatsApp.",
            Entrypoint = "index.ts",
            Files = new Dictionary<string, string>()
            {
                {
                    "index.ts",
                    "import { formatOrder } from './lib/orders';\n\nexport default async function handler(event) {\n  return { statusCode: 200, body: formatOrder(event) };\n}\n"
                },
                {
                    "lib/orders.ts",
                    "export function formatOrder(event) {\n  return JSON.stringify(event);\n}\n"
                },
            },
            HttpEnabled = true,
            MemoryMB = MemoryMB.V128,
            Runtime = Runtime.Nodejs24,
            SourceCode =
                "import { defineFunction } from '@zavudev/functions';\n\nexport default defineFunction(async (event, ctx) => {\n  ctx.log('received', event.type);\n});\n",
            TimeoutSec = 1,
        };

        FunctionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MemoryMBTest : TestBase
{
    [Theory]
    [InlineData(MemoryMB.V128)]
    [InlineData(MemoryMB.V256)]
    [InlineData(MemoryMB.V512)]
    [InlineData(MemoryMB.V1024)]
    public void Validation_Works(MemoryMB rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, MemoryMB> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, MemoryMB>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MemoryMB.V128)]
    [InlineData(MemoryMB.V256)]
    [InlineData(MemoryMB.V512)]
    [InlineData(MemoryMB.V1024)]
    public void SerializationRoundtrip_Works(MemoryMB rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<long, MemoryMB> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, MemoryMB>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<long, MemoryMB>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<long, MemoryMB>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RuntimeTest : TestBase
{
    [Theory]
    [InlineData(Runtime.Nodejs24)]
    public void Validation_Works(Runtime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Runtime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Runtime.Nodejs24)]
    public void SerializationRoundtrip_Works(Runtime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Runtime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Runtime>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
