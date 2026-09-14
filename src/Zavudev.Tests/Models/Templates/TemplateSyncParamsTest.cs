using System;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateSyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateSyncParams { SenderID = "sender_12345" };

        string expectedSenderID = "sender_12345";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateSyncParams { };

        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateSyncParams
        {
            // Null should be interpreted as omitted for these properties
            SenderID = null,
        };

        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateSyncParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/templates/sync"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateSyncParams { SenderID = "sender_12345" };

        TemplateSyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
