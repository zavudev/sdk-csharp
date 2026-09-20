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
            PhoneNumber = "phoneNumber",
            Type = PhoneNumberType.Local,
        };

        string expectedCountryCode = "xx";
        string expectedPhoneNumber = "phoneNumber";
        ApiEnum<string, PhoneNumberType> expectedType = PhoneNumberType.Local;

        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberRequirementsParams { };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("countryCode"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhoneNumberRequirementsParams
        {
            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            PhoneNumber = null,
            Type = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawQueryData.ContainsKey("countryCode"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawQueryData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberRequirementsParams parameters = new()
        {
            CountryCode = "xx",
            PhoneNumber = "phoneNumber",
            Type = PhoneNumberType.Local,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/phone-numbers/requirements?countryCode=xx&phoneNumber=phoneNumber&type=local"
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
            PhoneNumber = "phoneNumber",
            Type = PhoneNumberType.Local,
        };

        PhoneNumberRequirementsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
