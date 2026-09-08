using System;
using Zavudev.Models.Senders.Telegram;

namespace Zavudev.Tests.Models.Senders.Telegram;

public class TelegramDisconnectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TelegramDisconnectParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        TelegramDisconnectParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/telegram"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TelegramDisconnectParams { SenderID = "senderId" };

        TelegramDisconnectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
