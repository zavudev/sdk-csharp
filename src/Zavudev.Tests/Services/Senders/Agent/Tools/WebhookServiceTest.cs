using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders.Agent.Tools;

public class WebhookServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RotateSecret_Works()
    {
        var webhookSecretResponse = await this.client.Senders.Agent.Tools.Webhook.RotateSecret(
            "toolId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        webhookSecretResponse.Validate();
    }
}
