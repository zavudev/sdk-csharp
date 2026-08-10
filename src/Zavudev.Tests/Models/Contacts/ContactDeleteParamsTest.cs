using System;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactDeleteParams { ContactID = "contactId" };

        string expectedContactID = "contactId";

        Assert.Equal(expectedContactID, parameters.ContactID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactDeleteParams parameters = new() { ContactID = "contactId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts/contactId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactDeleteParams { ContactID = "contactId" };

        ContactDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
