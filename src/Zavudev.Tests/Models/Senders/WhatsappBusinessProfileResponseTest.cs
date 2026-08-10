using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class WhatsappBusinessProfileResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappBusinessProfileResponse
        {
            Profile = new()
            {
                About = "Succulent specialists!",
                Address = "1 Hacker Way, Menlo Park, CA 94025",
                Description =
                    "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
                Email = "contact@example.com",
                ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
                Vertical = WhatsappBusinessProfileVertical.Undefined,
                Websites = ["https://www.example.com/"],
            },
        };

        WhatsappBusinessProfile expectedProfile = new()
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

        Assert.Equal(expectedProfile, model.Profile);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappBusinessProfileResponse
        {
            Profile = new()
            {
                About = "Succulent specialists!",
                Address = "1 Hacker Way, Menlo Park, CA 94025",
                Description =
                    "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
                Email = "contact@example.com",
                ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
                Vertical = WhatsappBusinessProfileVertical.Undefined,
                Websites = ["https://www.example.com/"],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessProfileResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappBusinessProfileResponse
        {
            Profile = new()
            {
                About = "Succulent specialists!",
                Address = "1 Hacker Way, Menlo Park, CA 94025",
                Description =
                    "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
                Email = "contact@example.com",
                ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
                Vertical = WhatsappBusinessProfileVertical.Undefined,
                Websites = ["https://www.example.com/"],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappBusinessProfileResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WhatsappBusinessProfile expectedProfile = new()
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

        Assert.Equal(expectedProfile, deserialized.Profile);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappBusinessProfileResponse
        {
            Profile = new()
            {
                About = "Succulent specialists!",
                Address = "1 Hacker Way, Menlo Park, CA 94025",
                Description =
                    "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
                Email = "contact@example.com",
                ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
                Vertical = WhatsappBusinessProfileVertical.Undefined,
                Websites = ["https://www.example.com/"],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappBusinessProfileResponse
        {
            Profile = new()
            {
                About = "Succulent specialists!",
                Address = "1 Hacker Way, Menlo Park, CA 94025",
                Description =
                    "At Lucky Shrub, we specialize in providing a diverse range of high-quality succulents.",
                Email = "contact@example.com",
                ProfilePictureUrl = "https://pps.whatsapp.net/v/t61.24...",
                Vertical = WhatsappBusinessProfileVertical.Undefined,
                Websites = ["https://www.example.com/"],
            },
        };

        WhatsappBusinessProfileResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
