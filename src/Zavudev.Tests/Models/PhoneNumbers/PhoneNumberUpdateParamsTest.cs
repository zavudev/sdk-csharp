using System;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberUpdateParams
        {
            PhoneNumberID = "phoneNumberId",
            Name = "Support Line",
            SenderID = "senderId",
        };

        string expectedPhoneNumberID = "phoneNumberId";
        string expectedName = "Support Line";
        string expectedSenderID = "senderId";

        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberUpdateParams { PhoneNumberID = "phoneNumberId" };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PhoneNumberUpdateParams
        {
            PhoneNumberID = "phoneNumberId",

            Name = null,
            SenderID = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SenderID);
        Assert.True(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberUpdateParams parameters = new() { PhoneNumberID = "phoneNumberId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/phone-numbers/phoneNumberId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberUpdateParams
        {
            PhoneNumberID = "phoneNumberId",
            Name = "Support Line",
            SenderID = "senderId",
        };

        PhoneNumberUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
