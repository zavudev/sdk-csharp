using System.Threading.Tasks;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Services;

public class ContactServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var contact = await this.client.Contacts.Create(
            new()
            {
                Channels =
                [
                    new()
                    {
                        ChannelValue = ChannelChannel.Sms,
                        Identifier = "+14155551234",
                        CountryCode = "US",
                        IsPrimary = true,
                        Label = "work",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        contact.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var contact = await this.client.Contacts.Retrieve(
            "contactId",
            new(),
            TestContext.Current.CancellationToken
        );
        contact.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var contact = await this.client.Contacts.Update(
            "contactId",
            new(),
            TestContext.Current.CancellationToken
        );
        contact.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Contacts.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Contacts.Delete(
            "contactId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DismissMergeSuggestion_Works()
    {
        await this.client.Contacts.DismissMergeSuggestion(
            "contactId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Merge_Works()
    {
        var contact = await this.client.Contacts.Merge(
            "contactId",
            new() { SourceContactID = "jx7xyz789" },
            TestContext.Current.CancellationToken
        );
        contact.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveByPhone_Works()
    {
        var contact = await this.client.Contacts.RetrieveByPhone(
            "phoneNumber",
            new(),
            TestContext.Current.CancellationToken
        );
        contact.Validate();
    }
}
