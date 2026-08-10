using System;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactMergeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactMergeParams
        {
            ContactID = "contactId",
            SourceContactID = "jx7xyz789",
        };

        string expectedContactID = "contactId";
        string expectedSourceContactID = "jx7xyz789";

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedSourceContactID, parameters.SourceContactID);
    }

    [Fact]
    public void Url_Works()
    {
        ContactMergeParams parameters = new()
        {
            ContactID = "contactId",
            SourceContactID = "jx7xyz789",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts/contactId/merge"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactMergeParams
        {
            ContactID = "contactId",
            SourceContactID = "jx7xyz789",
        };

        ContactMergeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
