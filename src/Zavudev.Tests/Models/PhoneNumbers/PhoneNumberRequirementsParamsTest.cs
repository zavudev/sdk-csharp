using System;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberRequirementsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberRequirementsParams
        {
            CountryCode = "xx",
            Type = PhoneNumberType.Local,
        };

        string expectedCountryCode = "xx";
        ApiEnum<string, PhoneNumberType> expectedType = PhoneNumberType.Local;

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberRequirementsParams { CountryCode = "xx" };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhoneNumberRequirementsParams
        {
            CountryCode = "xx",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberRequirementsParams parameters = new()
        {
            CountryCode = "xx",
            Type = PhoneNumberType.Local,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/phone-numbers/requirements?countryCode=xx&type=local"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberRequirementsParams
        {
            CountryCode = "xx",
            Type = PhoneNumberType.Local,
        };

        PhoneNumberRequirementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
