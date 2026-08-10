using System;
using System.Collections.Generic;
using System.Text.Json;
using Flows = Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Flows::FlowUpdateParams
        {
            SenderID = "senderId",
            FlowID = "flowId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Priority = 0,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["string"],
            },
        };

        string expectedSenderID = "senderId";
        string expectedFlowID = "flowId";
        string expectedDescription = "description";
        bool expectedEnabled = true;
        string expectedName = "name";
        long expectedPriority = 0;
        List<Flows::FlowStep> expectedSteps =
        [
            new()
            {
                ID = "id",
                Config = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Type = Flows::Type.Message,
                NextStepID = "nextStepId",
            },
        ];
        Flows::FlowTrigger expectedTrigger = new()
        {
            Type = Flows::FlowTriggerType.Keyword,
            Intent = "intent",
            Keywords = ["string"],
        };

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedFlowID, parameters.FlowID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPriority, parameters.Priority);
        Assert.NotNull(parameters.Steps);
        Assert.Equal(expectedSteps.Count, parameters.Steps.Count);
        for (int i = 0; i < expectedSteps.Count; i++)
        {
            Assert.Equal(expectedSteps[i], parameters.Steps[i]);
        }
        Assert.Equal(expectedTrigger, parameters.Trigger);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Flows::FlowUpdateParams { SenderID = "senderId", FlowID = "flowId" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Steps);
        Assert.False(parameters.RawBodyData.ContainsKey("steps"));
        Assert.Null(parameters.Trigger);
        Assert.False(parameters.RawBodyData.ContainsKey("trigger"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Flows::FlowUpdateParams
        {
            SenderID = "senderId",
            FlowID = "flowId",

            // Null should be interpreted as omitted for these properties
            Description = null,
            Enabled = null,
            Name = null,
            Priority = null,
            Steps = null,
            Trigger = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.Steps);
        Assert.False(parameters.RawBodyData.ContainsKey("steps"));
        Assert.Null(parameters.Trigger);
        Assert.False(parameters.RawBodyData.ContainsKey("trigger"));
    }

    [Fact]
    public void Url_Works()
    {
        Flows::FlowUpdateParams parameters = new() { SenderID = "senderId", FlowID = "flowId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/flows/flowId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Flows::FlowUpdateParams
        {
            SenderID = "senderId",
            FlowID = "flowId",
            Description = "description",
            Enabled = true,
            Name = "name",
            Priority = 0,
            Steps =
            [
                new()
                {
                    ID = "id",
                    Config = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = Flows::Type.Message,
                    NextStepID = "nextStepId",
                },
            ],
            Trigger = new()
            {
                Type = Flows::FlowTriggerType.Keyword,
                Intent = "intent",
                Keywords = ["string"],
            },
        };

        Flows::FlowUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
