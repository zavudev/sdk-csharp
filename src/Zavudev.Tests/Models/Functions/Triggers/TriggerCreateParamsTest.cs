using System;
using System.Collections.Generic;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Tests.Models.Functions.Triggers;

public class TriggerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TriggerCreateParams
        {
            FunctionID = "functionId",
            EventTypes = ["message.inbound"],
            SenderIds = [null],
            Cron = "0 9 * * 1-5",
        };

        string expectedFunctionID = "functionId";
        List<string> expectedEventTypes = ["message.inbound"];
        List<string?> expectedSenderIds = [null];
        string expectedCron = "0 9 * * 1-5";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
        Assert.Equal(expectedSenderIds.Count, parameters.SenderIds.Count);
        for (int i = 0; i < expectedSenderIds.Count; i++)
        {
            Assert.Equal(expectedSenderIds[i], parameters.SenderIds[i]);
        }
        Assert.Equal(expectedCron, parameters.Cron);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TriggerCreateParams
        {
            FunctionID = "functionId",
            EventTypes = ["message.inbound"],
            SenderIds = [null],
        };

        Assert.Null(parameters.Cron);
        Assert.False(parameters.RawBodyData.ContainsKey("cron"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TriggerCreateParams
        {
            FunctionID = "functionId",
            EventTypes = ["message.inbound"],
            SenderIds = [null],

            // Null should be interpreted as omitted for these properties
            Cron = null,
        };

        Assert.Null(parameters.Cron);
        Assert.False(parameters.RawBodyData.ContainsKey("cron"));
    }

    [Fact]
    public void Url_Works()
    {
        TriggerCreateParams parameters = new()
        {
            FunctionID = "functionId",
            EventTypes = ["message.inbound"],
            SenderIds = [null],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/triggers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TriggerCreateParams
        {
            FunctionID = "functionId",
            EventTypes = ["message.inbound"],
            SenderIds = [null],
            Cron = "0 9 * * 1-5",
        };

        TriggerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
