using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class WhatsappBusinessProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            About = "Succulent specialists!",
            Address = "1 Hacker Way, Menlo Park, CA 94025",
            Description =
                "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
            Email = "contact@example.com",
            ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
            Vertical = WhatsappBusinessProfileVertical.Undefined,
            Websites = ["https://www.example.com/"],
        };

        string expectedAbout = "Succulent specialists!";
        string expectedAddress = "1 Hacker Way, Menlo Park, CA 94025";
        string expectedDescription =
            "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.";
        string expectedEmail = "contact@example.com";
        string expectedProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...";
        ApiEnum<string, WhatsappBusinessProfileVertical> expectedVertical =
            WhatsappBusinessProfileVertical.Undefined;
        List<string> expectedWebsites = ["https://www.example.com/"];

        Assert.Equal(expectedAbout, model.About);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedProfilePictureUrl, model.ProfilePictureUrl);
        Assert.Equal(expectedVertical, model.Vertical);
        Assert.NotNull(model.Websites);
        Assert.Equal(expectedWebsites.Count, model.Websites.Count);
        for (int i = 0; i < expectedWebsites.Count; i++)
        {
            Assert.Equal(expectedWebsites[i], model.Websites[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            About = "Succulent specialists!",
            Address = "1 Hacker Way, Menlo Park, CA 94025",
            Description =
                "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
            Email = "contact@example.com",
            ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
            Vertical = WhatsappBusinessProfileVertical.Undefined,
            Websites = ["https://www.example.com/"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            About = "Succulent specialists!",
            Address = "1 Hacker Way, Menlo Park, CA 94025",
            Description =
                "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
            Email = "contact@example.com",
            ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
            Vertical = WhatsappBusinessProfileVertical.Undefined,
            Websites = ["https://www.example.com/"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAbout = "Succulent specialists!";
        string expectedAddress = "1 Hacker Way, Menlo Park, CA 94025";
        string expectedDescription =
            "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.";
        string expectedEmail = "contact@example.com";
        string expectedProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...";
        ApiEnum<string, WhatsappBusinessProfileVertical> expectedVertical =
            WhatsappBusinessProfileVertical.Undefined;
        List<string> expectedWebsites = ["https://www.example.com/"];

        Assert.Equal(expectedAbout, deserialized.About);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedProfilePictureUrl, deserialized.ProfilePictureUrl);
        Assert.Equal(expectedVertical, deserialized.Vertical);
        Assert.NotNull(deserialized.Websites);
        Assert.Equal(expectedWebsites.Count, deserialized.Websites.Count);
        for (int i = 0; i < expectedWebsites.Count; i++)
        {
            Assert.Equal(expectedWebsites[i], deserialized.Websites[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            About = "Succulent specialists!",
            Address = "1 Hacker Way, Menlo Park, CA 94025",
            Description =
                "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
            Email = "contact@example.com",
            ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
            Vertical = WhatsappBusinessProfileVertical.Undefined,
            Websites = ["https://www.example.com/"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsappBusinessProfile { };

        Assert.Null(model.About);
        Assert.False(model.RawData.ContainsKey("about"));
        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ProfilePictureUrl);
        Assert.False(model.RawData.ContainsKey("profilePictureUrl"));
        Assert.Null(model.Vertical);
        Assert.False(model.RawData.ContainsKey("vertical"));
        Assert.Null(model.Websites);
        Assert.False(model.RawData.ContainsKey("websites"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsappBusinessProfile { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            // Null should be interpreted as omitted for these properties
            About = null,
            Address = null,
            Description = null,
            Email = null,
            ProfilePictureUrl = null,
            Vertical = null,
            Websites = null,
        };

        Assert.Null(model.About);
        Assert.False(model.RawData.ContainsKey("about"));
        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ProfilePictureUrl);
        Assert.False(model.RawData.ContainsKey("profilePictureUrl"));
        Assert.Null(model.Vertical);
        Assert.False(model.RawData.ContainsKey("vertical"));
        Assert.Null(model.Websites);
        Assert.False(model.RawData.ContainsKey("websites"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            // Null should be interpreted as omitted for these properties
            About = null,
            Address = null,
            Description = null,
            Email = null,
            ProfilePictureUrl = null,
            Vertical = null,
            Websites = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappBusinessProfile
        {
            About = "Succulent specialists!",
            Address = "1 Hacker Way, Menlo Park, CA 94025",
            Description =
                "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
            Email = "contact@example.com",
            ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
            Vertical = WhatsappBusinessProfileVertical.Undefined,
            Websites = ["https://www.example.com/"],
        };

        WhatsappBusinessProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}
