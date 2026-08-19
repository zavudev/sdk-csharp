using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Agents;

namespace Zavudev.Tests.Models.Agents;

public class AgentTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentTestParams
        {
            AgentID = "agentId",
            Message = "Where is order ORD-12345?",
            ExecuteTools = true,
            History = [new() { Content = "content", Role = Role.User }],
            UseKnowledgeBase = true,
        };

        string expectedAgentID = "agentId";
        string expectedMessage = "Where is order ORD-12345?";
        bool expectedExecuteTools = true;
        List<History> expectedHistory = [new() { Content = "content", Role = Role.User }];
        bool expectedUseKnowledgeBase = true;

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedMessage, parameters.Message);
        Assert.Equal(expectedExecuteTools, parameters.ExecuteTools);
        Assert.NotNull(parameters.History);
        Assert.Equal(expectedHistory.Count, parameters.History.Count);
        for (int i = 0; i < expectedHistory.Count; i++)
        {
            Assert.Equal(expectedHistory[i], parameters.History[i]);
        }
        Assert.Equal(expectedUseKnowledgeBase, parameters.UseKnowledgeBase);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentTestParams
        {
            AgentID = "agentId",
            Message = "Where is order ORD-12345?",
        };

        Assert.Null(parameters.ExecuteTools);
        Assert.False(parameters.RawBodyData.ContainsKey("executeTools"));
        Assert.Null(parameters.History);
        Assert.False(parameters.RawBodyData.ContainsKey("history"));
        Assert.Null(parameters.UseKnowledgeBase);
        Assert.False(parameters.RawBodyData.ContainsKey("useKnowledgeBase"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentTestParams
        {
            AgentID = "agentId",
            Message = "Where is order ORD-12345?",

            // Null should be interpreted as omitted for these properties
            ExecuteTools = null,
            History = null,
            UseKnowledgeBase = null,
        };

        Assert.Null(parameters.ExecuteTools);
        Assert.False(parameters.RawBodyData.ContainsKey("executeTools"));
        Assert.Null(parameters.History);
        Assert.False(parameters.RawBodyData.ContainsKey("history"));
        Assert.Null(parameters.UseKnowledgeBase);
        Assert.False(parameters.RawBodyData.ContainsKey("useKnowledgeBase"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentTestParams parameters = new()
        {
            AgentID = "agentId",
            Message = "Where is order ORD-12345?",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/agents/agentId/test"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentTestParams
        {
            AgentID = "agentId",
            Message = "Where is order ORD-12345?",
            ExecuteTools = true,
            History = [new() { Content = "content", Role = Role.User }],
            UseKnowledgeBase = true,
        };

        AgentTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class HistoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new History { Content = "content", Role = Role.User };

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new History { Content = "content", Role = Role.User };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new History { Content = "content", Role = Role.User };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<History>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new History { Content = "content", Role = Role.User };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new History { Content = "content", Role = Role.User };

        History copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
