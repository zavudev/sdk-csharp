using System;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Tests.Models.Contacts.Channels;

public class ChannelRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChannelRemoveParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
        };

        string expectedContactID = "contactId";
        string expectedChannelID = "channelId";

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedChannelID, parameters.ChannelID);
    }

    [Fact]
    public void Url_Works()
    {
        ChannelRemoveParams parameters = new() { ContactID = "contactId", ChannelID = "channelId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/contacts/contactId/channels/channelId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChannelRemoveParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
        };

        ChannelRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
