using System;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationRetrieveParams { InvitationID = "invitationId" };

        string expectedInvitationID = "invitationId";

        Assert.Equal(expectedInvitationID, parameters.InvitationID);
    }

    [Fact]
    public void Url_Works()
    {
        InvitationRetrieveParams parameters = new() { InvitationID = "invitationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/invitations/invitationId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationRetrieveParams { InvitationID = "invitationId" };

        InvitationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
