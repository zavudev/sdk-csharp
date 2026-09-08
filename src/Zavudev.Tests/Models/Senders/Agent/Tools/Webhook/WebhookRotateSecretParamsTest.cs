using System;
using Zavudev.Models.Senders.Agent.Tools.Webhook;

namespace Zavudev.Tests.Models.Senders.Agent.Tools.Webhook;

public class WebhookRotateSecretParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookRotateSecretParams { SenderID = "senderId", ToolID = "toolId" };

        string expectedSenderID = "senderId";
        string expectedToolID = "toolId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedToolID, parameters.ToolID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookRotateSecretParams parameters = new() { SenderID = "senderId", ToolID = "toolId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/tools/toolId/webhook/secret"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookRotateSecretParams { SenderID = "senderId", ToolID = "toolId" };

        WebhookRotateSecretParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
