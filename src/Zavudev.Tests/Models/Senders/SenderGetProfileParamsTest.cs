using System;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderGetProfileParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderGetProfileParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        SenderGetProfileParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/profile"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderGetProfileParams { SenderID = "senderId" };

        SenderGetProfileParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
