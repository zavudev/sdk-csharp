using System;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactRetrieveByPhoneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactRetrieveByPhoneParams { PhoneNumber = "phoneNumber" };

        string expectedPhoneNumber = "phoneNumber";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        ContactRetrieveByPhoneParams parameters = new() { PhoneNumber = "phoneNumber" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts/phone/phoneNumber"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactRetrieveByPhoneParams { PhoneNumber = "phoneNumber" };

        ContactRetrieveByPhoneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
