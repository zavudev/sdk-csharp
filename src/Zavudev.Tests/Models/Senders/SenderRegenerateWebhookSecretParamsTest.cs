using System;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderRegenerateWebhookSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderRegenerateWebhookSecretParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        SenderRegenerateWebhookSecretParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/webhook/secret"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderRegenerateWebhookSecretParams { SenderID = "senderId" };

        SenderRegenerateWebhookSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
