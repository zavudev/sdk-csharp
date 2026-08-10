using System;
using System.Collections.Generic;
using System.Text.Json;
using Flows = Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Flows::FlowCreateParams
        {
            SenderID = "senderId",
            Name = "Lead Capture",
            Steps =
            [
                new()
                {
                    ID = "welcome",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "text", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "ask_name",
                },
                new()
                {
                    ID = "ask_name",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "variable", JsonSerializer.SerializeToElement("bar") },
                        { "prompt", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Collect,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["info", "pricing", "demo"],
            },
            Description = "Capture lead information",
            Enabled = true,
            Priority = 0,
        };

        string expectedSenderID = "senderId";
        string expectedName = "Lead Capture";
        List<Flows::FlowStep> expectedSteps =
        [
            new()
            {
                ID = "welcome",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "text", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Flows::Type.Message,
                NextStepID = "ask_name",
            },
            new()
            {
                ID = "ask_name",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "variable", JsonSerializer.SerializeToElement("bar") },
                    { "prompt", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Flows::Type.Collect,
                NextStepID = "nextStepId",
            },
        ];
        Flows::FlowTrigger expectedTrigger = new()
        {
            Type = Flows::FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["info", "pricing", "demo"],
        };
        string expectedDescription = "Capture lead information";
        bool expectedEnabled = true;
        long expectedPriority = 0;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSteps.Count, parameters.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], parameters.Steps[i]);
        }
        Assert.Equal(expectedTrigger, parameters.Trigger);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedPriority, parameters.Priority);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Flows::FlowCreateParams
        {
            SenderID = "senderId",
            Name = "Lead Capture",
            Steps =
            [
                new()
                {
                    ID = "welcome",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "text", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "ask_name",
                },
                new()
                {
                    ID = "ask_name",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "variable", JsonSerializer.SerializeToElement("bar") },
                        { "prompt", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Collect,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["info", "pricing", "demo"],
            },
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Flows::FlowCreateParams
        {
            SenderID = "senderId",
            Name = "Lead Capture",
            Steps =
            [
                new()
                {
                    ID = "welcome",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "text", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "ask_name",
                },
                new()
                {
                    ID = "ask_name",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "variable", JsonSerializer.SerializeToElement("bar") },
                        { "prompt", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Collect,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["info", "pricing", "demo"],
            },

            // Null should be interpreted as omitted for these properties
            Description = null,
            Enabled = null,
            Priority = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
    }

    [Fact]
    public void Url_Works()
    {
        Flows::FlowCreateParams parameters = new()
        {
            SenderID = "senderId",
            Name = "Lead Capture",
            Steps =
            [
                new()
                {
                    ID = "welcome",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "text", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "ask_name",
                },
                new()
                {
                    ID = "ask_name",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "variable", JsonSerializer.SerializeToElement("bar") },
                        { "prompt", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Collect,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["info", "pricing", "demo"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/agent/flows"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Flows::FlowCreateParams
        {
            SenderID = "senderId",
            Name = "Lead Capture",
            Steps =
            [
                new()
                {
                    ID = "welcome",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "text", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "ask_name",
                },
                new()
                {
                    ID = "ask_name",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "variable", JsonSerializer.SerializeToElement("bar") },
                        { "prompt", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Collect,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["info", "pricing", "demo"],
            },
            Description = "Capture lead information",
            Enabled = true,
            Priority = 0,
        };

        Flows::FlowCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
