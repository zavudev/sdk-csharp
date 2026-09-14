using System;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallRetrieveParams { CallID = "callId" };

        string expectedCallID = "callId";

        Assert.Equal(expectedCallID, parameters.CallID);
    }

    [Fact]
    public void Url_Works()
    {
        CallRetrieveParams parameters = new() { CallID = "callId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/calls/callId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallRetrieveParams { CallID = "callId" };

        CallRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
