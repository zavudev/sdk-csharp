using System;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactListParams
        {
            Cursor = "cursor",
            Limit = 100,
            PhoneNumber = "phoneNumber",
        };

        string expectedCursor = "cursor";
        long expectedLimit = 100;
        string expectedPhoneNumber = "phoneNumber";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phoneNumber"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            PhoneNumber = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phoneNumber"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 100,
            PhoneNumber = "phoneNumber",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/contacts?cursor=cursor&limit=100&phoneNumber=phoneNumber"
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
            Cursor = "cursor",
            Limit = 100,
            PhoneNumber = "phoneNumber",
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
