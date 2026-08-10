using System;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberSearchAvailableParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberSearchAvailableParams
        {
            CountryCode = "xx",
            Capabilities = "voice,sms",
            Contains = "contains",
            Limit = 50,
            Type = PhoneNumberType.Local,
        };

        string expectedCountryCode = "xx";
        string expectedCapabilities = "voice,sms";
        string expectedContains = "contains";
        long expectedLimit = 50;
        ApiEnum<string, PhoneNumberType> expectedType = PhoneNumberType.Local;

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedCapabilities, parameters.Capabilities);
        Assert.Equal(expectedContains, parameters.Contains);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberSearchAvailableParams { CountryCode = "xx" };

        Assert.Null(parameters.Capabilities);
        Assert.False(parameters.RawQueryData.ContainsKey("capabilities"));
        Assert.Null(parameters.Contains);
        Assert.False(parameters.RawQueryData.ContainsKey("contains"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhoneNumberSearchAvailableParams
        {
            CountryCode = "xx",

            // Null should be interpreted as omitted for these properties
            Capabilities = null,
            Contains = null,
            Limit = null,
            Type = null,
        };

        Assert.Null(parameters.Capabilities);
        Assert.False(parameters.RawQueryData.ContainsKey("capabilities"));
        Assert.Null(parameters.Contains);
        Assert.False(parameters.RawQueryData.ContainsKey("contains"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberSearchAvailableParams parameters = new()
        {
            CountryCode = "xx",
            Capabilities = "voice,sms",
            Contains = "contains",
            Limit = 50,
            Type = PhoneNumberType.Local,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/phone-numbers/available?countryCode=xx&capabilities=voice%2csms&contains=contains&limit=50&type=local"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberSearchAvailableParams
        {
            CountryCode = "xx",
            Capabilities = "voice,sms",
            Contains = "contains",
            Limit = 50,
            Type = PhoneNumberType.Local,
        };

        PhoneNumberSearchAvailableParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
