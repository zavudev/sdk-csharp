using System;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsappSyncRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WhatsappSyncRetrieveParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        WhatsappSyncRetrieveParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/whatsapp-sync"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WhatsappSyncRetrieveParams { SenderID = "senderId" };

        WhatsappSyncRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
