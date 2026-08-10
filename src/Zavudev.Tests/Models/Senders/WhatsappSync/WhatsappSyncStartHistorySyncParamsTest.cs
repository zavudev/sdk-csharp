using System;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsappSyncStartHistorySyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WhatsappSyncStartHistorySyncParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        WhatsappSyncStartHistorySyncParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/whatsapp-sync/history"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WhatsappSyncStartHistorySyncParams { SenderID = "senderId" };

        WhatsappSyncStartHistorySyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
