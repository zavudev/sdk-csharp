using System.Threading.Tasks;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Tests.Services.Contacts;

public class ChannelServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var channel = await this.client.Contacts.Channels.Update(
            "channelId",
            new() { ContactID = "contactId" },
            TestContext.Current.CancellationToken
        );
        channel.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Contacts.Channels.Add(
            "contactId",
            new() { Channel = Channel.Email, Identifier = "john.work@company.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Contacts.Channels.Remove(
            "channelId",
            new() { ContactID = "contactId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SetPrimary_Works()
    {
        var response = await this.client.Contacts.Channels.SetPrimary(
            "channelId",
            new() { ContactID = "contactId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
