using System;
using System.Collections.Generic;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderUpdateProfileParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderUpdateProfileParams
        {
            SenderID = "senderId",
            About = "Succulent specialists!",
            Address = "address",
            Description = "We specialize in providing high-quality succulents.",
            Email = "contact@example.com",
            Vertical = WhatsappBusinessProfileVertical.Retail,
            Websites = ["https://www.example.com"],
        };

        string expectedSenderID = "senderId";
        string expectedAbout = "Succulent specialists!";
        string expectedAddress = "address";
        string expectedDescription = "We specialize in providing high-quality succulents.";
        string expectedEmail = "contact@example.com";
        ApiEnum<string, WhatsappBusinessProfileVertical> expectedVertical =
            WhatsappBusinessProfileVertical.Retail;
        List<string> expectedWebsites = ["https://www.example.com"];

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedAbout, parameters.About);
        Assert.Equal(expectedAddress, parameters.Address);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedVertical, parameters.Vertical);
        Assert.NotNull(parameters.Websites);
        Assert.Equal(expectedWebsites.Count, parameters.Websites.Count);
        for (int i = 0; i < expectedWebsites.Count; i++)
        {
            Assert.Equal(expectedWebsites[i], parameters.Websites[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderUpdateProfileParams { SenderID = "senderId" };

        Assert.Null(parameters.About);
        Assert.False(parameters.RawBodyData.ContainsKey("about"));
        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Vertical);
        Assert.False(parameters.RawBodyData.ContainsKey("vertical"));
        Assert.Null(parameters.Websites);
        Assert.False(parameters.RawBodyData.ContainsKey("websites"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderUpdateProfileParams
        {
            SenderID = "senderId",

            // Null should be interpreted as omitted for these properties
            About = null,
            Address = null,
            Description = null,
            Email = null,
            Vertical = null,
            Websites = null,
        };

        Assert.Null(parameters.About);
        Assert.False(parameters.RawBodyData.ContainsKey("about"));
        Assert.Null(parameters.Address);
        Assert.False(parameters.RawBodyData.ContainsKey("address"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Vertical);
        Assert.False(parameters.RawBodyData.ContainsKey("vertical"));
        Assert.Null(parameters.Websites);
        Assert.False(parameters.RawBodyData.ContainsKey("websites"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderUpdateProfileParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/profile"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderUpdateProfileParams
        {
            SenderID = "senderId",
            About = "Succulent specialists!",
            Address = "address",
            Description = "We specialize in providing high-quality succulents.",
            Email = "contact@example.com",
            Vertical = WhatsappBusinessProfileVertical.Retail,
            Websites = ["https://www.example.com"],
        };

        SenderUpdateProfileParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
