using System;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberRetrieveParams { PhoneNumberID = "phoneNumberId" };

        string expectedPhoneNumberID = "phoneNumberId";

        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberRetrieveParams parameters = new() { PhoneNumberID = "phoneNumberId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/phone-numbers/phoneNumberId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberRetrieveParams { PhoneNumberID = "phoneNumberId" };

        PhoneNumberRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
