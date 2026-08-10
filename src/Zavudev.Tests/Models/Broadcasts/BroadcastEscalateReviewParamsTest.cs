using System;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastEscalateReviewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastEscalateReviewParams { BroadcastID = "broadcastId" };

        string expectedBroadcastID = "broadcastId";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastEscalateReviewParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId/escalate"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastEscalateReviewParams { BroadcastID = "broadcastId" };

        BroadcastEscalateReviewParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
