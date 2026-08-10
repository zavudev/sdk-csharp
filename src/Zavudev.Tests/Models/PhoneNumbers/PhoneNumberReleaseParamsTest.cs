using System;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberReleaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberReleaseParams { PhoneNumberID = "phoneNumberId" };

        string expectedPhoneNumberID = "phoneNumberId";

        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberReleaseParams parameters = new() { PhoneNumberID = "phoneNumberId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/phone-numbers/phoneNumberId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberReleaseParams { PhoneNumberID = "phoneNumberId" };

        PhoneNumberReleaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
