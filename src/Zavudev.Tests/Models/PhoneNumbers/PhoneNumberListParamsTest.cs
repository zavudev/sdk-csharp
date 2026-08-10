using System;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberListParams
        {
            Cursor = "cursor",
            Limit = 100,
            Status = PhoneNumberStatus.Active,
        };

        string expectedCursor = "cursor";
        long expectedLimit = 100;
        ApiEnum<string, PhoneNumberStatus> expectedStatus = PhoneNumberStatus.Active;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberListParams { };

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
        var parameters = new PhoneNumberListParams
        {
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
        PhoneNumberListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 100,
            Status = PhoneNumberStatus.Active,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/phone-numbers?cursor=cursor&limit=100&status=active"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberListParams
        {
            Cursor = "cursor",
            Limit = 100,
            Status = PhoneNumberStatus.Active,
        };

        PhoneNumberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
