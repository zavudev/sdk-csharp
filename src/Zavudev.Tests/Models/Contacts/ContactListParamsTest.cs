using System;
using System.Collections.Generic;
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
            Search = "search",
            Tag = ["string"],
        };

        string expectedCursor = "cursor";
        long expectedLimit = 100;
        string expectedPhoneNumber = "phoneNumber";
        string expectedSearch = "search";
        List<string> expectedTag = ["string"];

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.NotNull(parameters.Tag);
        Assert.Equal(expectedTag.Count, parameters.Tag.Count);
        for (int i = 0; i < expectedTag.Count; i++)
        {
            Assert.Equal(expectedTag[i], parameters.Tag[i]);
        }
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
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
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
            Search = null,
            Tag = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Tag);
        Assert.False(parameters.RawQueryData.ContainsKey("tag"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 100,
            PhoneNumber = "phoneNumber",
            Search = "search",
            Tag = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/contacts?cursor=cursor&limit=100&phoneNumber=phoneNumber&search=search&tag=string"
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
            Search = "search",
            Tag = ["string"],
        };

        ContactListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
