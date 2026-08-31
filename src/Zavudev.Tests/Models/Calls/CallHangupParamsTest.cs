using System;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallHangupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallHangupParams { CallID = "callId" };

        string expectedCallID = "callId";

        Assert.Equal(expectedCallID, parameters.CallID);
    }

    [Fact]
    public void Url_Works()
    {
        CallHangupParams parameters = new() { CallID = "callId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/calls/callId/hangup"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallHangupParams { CallID = "callId" };

        CallHangupParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
