using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders;

public class WhatsappSyncServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var whatsappSync = await this.client.Senders.WhatsappSync.Retrieve(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        whatsappSync.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task StartContactsSync_Works()
    {
        var response = await this.client.Senders.WhatsappSync.StartContactsSync(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task StartHistorySync_Works()
    {
        var response = await this.client.Senders.WhatsappSync.StartHistorySync(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
