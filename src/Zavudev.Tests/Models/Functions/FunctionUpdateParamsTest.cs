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
            HttpEnabled = true,
            SourceCode = "sourceCode",
        };

        string expectedFunctionID = "functionId";
        Dictionary<string, string> expectedDependencies = new() { { "foo", "string" } };
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
        Assert.Equal(expectedHttpEnabled, parameters.HttpEnabled);
        Assert.Equal(expectedSourceCode, parameters.SourceCode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionUpdateParams { FunctionID = "functionId" };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
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
            HttpEnabled = null,
            SourceCode = null,
        };

        Assert.Null(parameters.Dependencies);
        Assert.False(parameters.RawBodyData.ContainsKey("dependencies"));
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
            HttpEnabled = true,
            SourceCode = "sourceCode",
        };

        FunctionUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
