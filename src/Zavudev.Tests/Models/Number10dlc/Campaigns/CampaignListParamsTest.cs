using System;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignListParams
        {
            BrandID = "brandId",
            Cursor = "cursor",
            Limit = 100,
        };

        string expectedBrandID = "brandId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignListParams { };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brandId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignListParams
        {
            // Null should be interpreted as omitted for these properties
            BrandID = null,
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.BrandID);
        Assert.False(parameters.RawQueryData.ContainsKey("brandId"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignListParams parameters = new()
        {
            BrandID = "brandId",
            Cursor = "cursor",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/10dlc/campaigns?brandId=brandId&cursor=cursor&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignListParams
        {
            BrandID = "brandId",
            Cursor = "cursor",
            Limit = 100,
        };

        CampaignListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
