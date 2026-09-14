using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders;

public class TelegramServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Connect_Works()
    {
        var response = await this.client.Senders.Telegram.Connect(
            "senderId",
            new() { BotToken = "botToken" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Disconnect_Works()
    {
        await this.client.Senders.Telegram.Disconnect(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
