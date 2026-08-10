using System;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ToolListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Enabled = true,
            Limit = 100,
        };

        string expectedSenderID = "senderId";
        string expectedCursor = "cursor";
        bool expectedEnabled = true;
        long expectedLimit = 100;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ToolListParams { SenderID = "senderId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawQueryData.ContainsKey("enabled"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ToolListParams
        {
            SenderID = "senderId",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Enabled = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawQueryData.ContainsKey("enabled"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ToolListParams parameters = new()
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Enabled = true,
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/tools?cursor=cursor&enabled=true&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ToolListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Enabled = true,
            Limit = 100,
        };

        ToolListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
