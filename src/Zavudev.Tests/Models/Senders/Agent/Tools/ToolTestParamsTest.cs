using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolTestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ToolTestParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            TestParams = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedSenderID = "senderId";
        string expectedToolID = "toolId";
        Dictionary<string, JsonElement> expectedTestParams = new()
        {
            { "order_id", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedToolID, parameters.ToolID);
        Assert.Equal(expectedTestParams.Count, parameters.TestParams.Count);
        foreach (var item in expectedTestParams)
        {
            Assert.True(parameters.TestParams.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.TestParams[item.Key]));
        }
    }

    [Fact]
    public void Url_Works()
    {
        ToolTestParams parameters = new()
        {
            SenderID = "senderId",
            ToolID = "toolId",
            TestParams = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/tools/toolId/test"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ToolTestParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            TestParams = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ToolTestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
