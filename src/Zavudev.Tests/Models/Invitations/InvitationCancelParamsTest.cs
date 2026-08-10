using System;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationCancelParams { InvitationID = "invitationId" };

        string expectedInvitationID = "invitationId";

        Assert.Equal(expectedInvitationID, parameters.InvitationID);
    }

    [Fact]
    public void Url_Works()
    {
        InvitationCancelParams parameters = new() { InvitationID = "invitationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/invitations/invitationId/cancel"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationCancelParams { InvitationID = "invitationId" };

        InvitationCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
