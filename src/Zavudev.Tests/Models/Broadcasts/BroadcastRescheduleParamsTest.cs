using System;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastRescheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastRescheduleParams
        {
            BroadcastID = "broadcastId",
            ScheduledAt = DateTimeOffset.Parse("2024-01-15T14:00:00Z"),
        };

        string expectedBroadcastID = "broadcastId";
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2024-01-15T14:00:00Z");

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedScheduledAt, parameters.ScheduledAt);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastRescheduleParams parameters = new()
        {
            BroadcastID = "broadcastId",
            ScheduledAt = DateTimeOffset.Parse("2024-01-15T14:00:00Z"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId/schedule"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastRescheduleParams
        {
            BroadcastID = "broadcastId",
            ScheduledAt = DateTimeOffset.Parse("2024-01-15T14:00:00Z"),
        };

        BroadcastRescheduleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
