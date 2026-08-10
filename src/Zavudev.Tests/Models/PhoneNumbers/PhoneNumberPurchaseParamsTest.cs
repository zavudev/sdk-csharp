using System;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberPurchaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",
            Name = "Primary Line",
        };

        string expectedPhoneNumber = "+15551234567";
        string expectedName = "Primary Line";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberPurchaseParams { PhoneNumber = "+15551234567" };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberPurchaseParams parameters = new() { PhoneNumber = "+15551234567" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/phone-numbers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",
            Name = "Primary Line",
        };

        PhoneNumberPurchaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
