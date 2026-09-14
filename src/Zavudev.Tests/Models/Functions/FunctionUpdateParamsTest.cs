using System;
using System.Collections.Generic;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            FunctionID = "functionId",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
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
            SourceCode = "sourceCode",
        };

        string expectedFunctionID = "functionId";
        Dictionary<string, string> expectedDependencies = new() { { "foo", "string" } };
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
        string expectedSourceCode = "sourceCode";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.NotNull(parameters.Dependencies);
        Assert.Equal(expectedDependencies.Count, parameters.Dependencies.Count);
        foreach (var item in expectedDependencies)
        {
            Assert.True(parameters.Dependencies.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Dependencies[item.Key]);
        }
        Assert.Equal(expectedEntrypoint, parameters.Entrypoint);
        Assert.NotNull(parameters.Files);
        Assert.Equal(expectedFiles.Count, parameters.Files.Count);
        foreach (var item in expectedFiles)
        {
            Assert.True(parameters.Files.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Files[item.Key]);
        }
        Assert.Equal(expectedHttpEnabled, parameters.HttpEnabled);
        Assert.Equal(expectedSourceCode, parameters.SourceCode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionUpdateParams { FunctionID = "functionId" };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Entrypoint);
        Assert.False(parameters.RawBodyData.ContainsKey("entrypoint"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.HttpEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("httpEnabled"));
        Assert.Null(parameters.SourceCode);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceCode"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            FunctionID = "functionId",

            // Null should be interpreted as omitted for these properties
            Dependencies = null,
            Entrypoint = null,
            Files = null,
            HttpEnabled = null,
            SourceCode = null,
        };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
        Assert.Null(parameters.Entrypoint);
        Assert.False(parameters.RawBodyData.ContainsKey("entrypoint"));
        Assert.Null(parameters.Files);
        Assert.False(parameters.RawBodyData.ContainsKey("files"));
        Assert.Null(parameters.HttpEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("httpEnabled"));
        Assert.Null(parameters.SourceCode);
        Assert.False(parameters.RawBodyData.ContainsKey("sourceCode"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionUpdateParams parameters = new() { FunctionID = "functionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions/functionId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionUpdateParams
        {
            FunctionID = "functionId",
            Dependencies = new Dictionary<string, string>() { { "foo", "string" } },
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
            SourceCode = "sourceCode",
        };

        FunctionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
