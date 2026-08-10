using System;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Tests.Models.Broadcasts.Contacts;

public class ContactRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRemoveParams
        {
            BroadcastID = "broadcastId",
            ContactID = "contactId",
        };

        string expectedBroadcastID = "broadcastId";
        string expectedContactID = "contactId";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedContactID, parameters.ContactID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRemoveParams parameters = new()
        {
            BroadcastID = "broadcastId",
            ContactID = "contactId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId/contacts/contactId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRemoveParams
        {
            BroadcastID = "broadcastId",
            ContactID = "contactId",
        };

        ContactRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
