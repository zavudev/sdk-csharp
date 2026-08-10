using System;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddressDeleteParams { AddressID = "addressId" };

        string expectedAddressID = "addressId";

        Assert.Equal(expectedAddressID, parameters.AddressID);
    }

    [Fact]
    public void Url_Works()
    {
        AddressDeleteParams parameters = new() { AddressID = "addressId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/addresses/addressId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddressDeleteParams { AddressID = "addressId" };

        AddressDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
