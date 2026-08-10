using System;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Tests.Models.Broadcasts.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams
        {
            BroadcastID = "broadcastId",
            Cursor = "cursor",
            Limit = 100,
            Status = BroadcastContactStatus.Pending,
        };

        string expectedBroadcastID = "broadcastId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;
        ApiEnum<string, BroadcastContactStatus> expectedStatus = BroadcastContactStatus.Pending;

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactListParams { BroadcastID = "broadcastId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactListParams
        {
            BroadcastID = "broadcastId",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Cursor = "cursor",
            Limit = 100,
            Status = BroadcastContactStatus.Pending,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/broadcasts/broadcastId/contacts?cursor=cursor&limit=100&status=pending"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactListParams
        {
            BroadcastID = "broadcastId",
            Cursor = "cursor",
            Limit = 100,
            Status = BroadcastContactStatus.Pending,
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
