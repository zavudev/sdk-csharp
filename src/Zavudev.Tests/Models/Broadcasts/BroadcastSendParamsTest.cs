using System;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastSendParams
        {
            BroadcastID = "broadcastId",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBroadcastID = "broadcastId";
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedScheduledAt, parameters.ScheduledAt);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastSendParams { BroadcastID = "broadcastId" };

        Assert.Null(parameters.ScheduledAt);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduledAt"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastSendParams
        {
            BroadcastID = "broadcastId",

            // Null should be interpreted as omitted for these properties
            ScheduledAt = null,
        };

        Assert.Null(parameters.ScheduledAt);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduledAt"));
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastSendParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId/send"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastSendParams
        {
            BroadcastID = "broadcastId",
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BroadcastSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
