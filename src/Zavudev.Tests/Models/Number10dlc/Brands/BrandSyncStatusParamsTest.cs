using System;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandSyncStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandSyncStatusParams { BrandID = "brandId" };

        string expectedBrandID = "brandId";

        Assert.Equal(expectedBrandID, parameters.BrandID);
    }

    [Fact]
    public void Url_Works()
    {
        BrandSyncStatusParams parameters = new() { BrandID = "brandId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/brands/brandId/sync"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandSyncStatusParams { BrandID = "brandId" };

        BrandSyncStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
