using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class InvitationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var invitation = await this.client.Invitations.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        invitation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var invitation = await this.client.Invitations.Retrieve(
            "invitationId",
            new(),
            TestContext.Current.CancellationToken
        );
        invitation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Invitations.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Invitations.Cancel(
            "invitationId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
