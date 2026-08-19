using System;
using Zavudev.Models.Senders.Telegram;

namespace Zavudev.Tests.Models.Senders.Telegram;

public class TelegramConnectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TelegramConnectParams { SenderID = "senderId", BotToken = "botToken" };

        string expectedSenderID = "senderId";
        string expectedBotToken = "botToken";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedBotToken, parameters.BotToken);
    }

    [Fact]
    public void Url_Works()
    {
        TelegramConnectParams parameters = new() { SenderID = "senderId", BotToken = "botToken" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/telegram"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TelegramConnectParams { SenderID = "senderId", BotToken = "botToken" };

        TelegramConnectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
