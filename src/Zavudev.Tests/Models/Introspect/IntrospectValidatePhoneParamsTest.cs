using System;
using Zavudev.Models.Introspect;

namespace Zavudev.Tests.Models.Introspect;

public class IntrospectValidatePhoneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrospectValidatePhoneParams { PhoneNumber = "+56912345678" };

        string expectedPhoneNumber = "+56912345678";

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
    }

    [Fact]
    public void Url_Works()
    {
        IntrospectValidatePhoneParams parameters = new() { PhoneNumber = "+56912345678" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/introspect/phone"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrospectValidatePhoneParams { PhoneNumber = "+56912345678" };

        IntrospectValidatePhoneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
