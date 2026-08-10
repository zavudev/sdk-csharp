using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Broadcasts;

public class ContactServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Broadcasts.Contacts.List(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Broadcasts.Contacts.Add(
            "broadcastId",
            new()
            {
                Contacts =
                [
                    new()
                    {
                        Recipient = "+14155551234",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "0", "abc-report-token" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "1", "Jorge y Laura" },
                        },
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "name", "John" },
                            { "order_id", "ORD-001" },
                        },
                    },
                    new()
                    {
                        Recipient = "+14155555678",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "0", "abc-report-token" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "1", "Jorge y Laura" },
                        },
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "name", "Jane" },
                            { "order_id", "ORD-002" },
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Broadcasts.Contacts.Remove(
            "contactId",
            new() { BroadcastID = "broadcastId" },
            TestContext.Current.CancellationToken
        );
    }
}
