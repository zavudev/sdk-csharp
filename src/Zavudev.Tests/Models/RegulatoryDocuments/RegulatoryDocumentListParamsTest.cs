using System;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RegulatoryDocumentListParams { Cursor = "cursor", Limit = 100 };

        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RegulatoryDocumentListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RegulatoryDocumentListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        RegulatoryDocumentListParams parameters = new() { Cursor = "cursor", Limit = 100 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/documents?cursor=cursor&limit=100"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RegulatoryDocumentListParams { Cursor = "cursor", Limit = 100 };

        RegulatoryDocumentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
