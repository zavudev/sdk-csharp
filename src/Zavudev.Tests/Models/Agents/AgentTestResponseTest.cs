using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Agents;

namespace Zavudev.Tests.Models.Agents;

public class AgentTestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
            ExecutedToolCalls =
            [
                new()
                {
                    Name = "name",
                    Ok = true,
                    Error = "error",
                },
            ],
        };

        string expectedError = "error";
        long expectedInputTokens = 0;
        long expectedKnowledgeChunksUsed = 0;
        long expectedLatencyMs = 0;
        long expectedOutputTokens = 0;
        bool expectedSuccess = true;
        string expectedText = "text";
        List<string> expectedWarnings = ["string"];
        List<ExecutedToolCall> expectedExecutedToolCalls =
        [
            new()
            {
                Name = "name",
                Ok = true,
                Error = "error",
            },
        ];

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedInputTokens, model.InputTokens);
        Assert.Equal(expectedKnowledgeChunksUsed, model.KnowledgeChunksUsed);
        Assert.Equal(expectedLatencyMs, model.LatencyMs);
        Assert.Equal(expectedOutputTokens, model.OutputTokens);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedWarnings.Count, model.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], model.Warnings[i]);
        }
        Assert.NotNull(model.ExecutedToolCalls);
        Assert.Equal(expectedExecutedToolCalls.Count, model.ExecutedToolCalls.Count);
        for (int i = 0; i < expectedExecutedToolCalls.Count; i++)
        {
            Assert.Equal(expectedExecutedToolCalls[i], model.ExecutedToolCalls[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
            ExecutedToolCalls =
            [
                new()
                {
                    Name = "name",
                    Ok = true,
                    Error = "error",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
            ExecutedToolCalls =
            [
                new()
                {
                    Name = "name",
                    Ok = true,
                    Error = "error",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentTestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedInputTokens = 0;
        long expectedKnowledgeChunksUsed = 0;
        long expectedLatencyMs = 0;
        long expectedOutputTokens = 0;
        bool expectedSuccess = true;
        string expectedText = "text";
        List<string> expectedWarnings = ["string"];
        List<ExecutedToolCall> expectedExecutedToolCalls =
        [
            new()
            {
                Name = "name",
                Ok = true,
                Error = "error",
            },
        ];

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedInputTokens, deserialized.InputTokens);
        Assert.Equal(expectedKnowledgeChunksUsed, deserialized.KnowledgeChunksUsed);
        Assert.Equal(expectedLatencyMs, deserialized.LatencyMs);
        Assert.Equal(expectedOutputTokens, deserialized.OutputTokens);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedWarnings.Count, deserialized.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], deserialized.Warnings[i]);
        }
        Assert.NotNull(deserialized.ExecutedToolCalls);
        Assert.Equal(expectedExecutedToolCalls.Count, deserialized.ExecutedToolCalls.Count);
        for (int i = 0; i < expectedExecutedToolCalls.Count; i++)
        {
            Assert.Equal(expectedExecutedToolCalls[i], deserialized.ExecutedToolCalls[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
            ExecutedToolCalls =
            [
                new()
                {
                    Name = "name",
                    Ok = true,
                    Error = "error",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
        };

        Assert.Null(model.ExecutedToolCalls);
        Assert.False(model.RawData.ContainsKey("executedToolCalls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],

            // Null should be interpreted as omitted for these properties
            ExecutedToolCalls = null,
        };

        Assert.Null(model.ExecutedToolCalls);
        Assert.False(model.RawData.ContainsKey("executedToolCalls"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],

            // Null should be interpreted as omitted for these properties
            ExecutedToolCalls = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentTestResponse
        {
            Error = "error",
            InputTokens = 0,
            KnowledgeChunksUsed = 0,
            LatencyMs = 0,
            OutputTokens = 0,
            Success = true,
            Text = "text",
            Warnings = ["string"],
            ExecutedToolCalls =
            [
                new()
                {
                    Name = "name",
                    Ok = true,
                    Error = "error",
                },
            ],
        };

        AgentTestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExecutedToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,
            Error = "error",
        };

        string expectedName = "name";
        bool expectedOk = true;
        string expectedError = "error";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOk, model.Ok);
        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,
            Error = "error",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutedToolCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,
            Error = "error",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExecutedToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        bool expectedOk = true;
        string expectedError = "error";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOk, deserialized.Ok);
        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,
            Error = "error",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExecutedToolCall { Name = "name", Ok = true };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExecutedToolCall { Name = "name", Ok = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,

            Error = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,

            Error = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExecutedToolCall
        {
            Name = "name",
            Ok = true,
            Error = "error",
        };

        ExecutedToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}
