using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderUpdateProfileResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderUpdateProfileResponse
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
            Success = true,
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
        bool expectedSuccess = true;

        Assert.Equal(expectedProfile, model.Profile);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderUpdateProfileResponse
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
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderUpdateProfileResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderUpdateProfileResponse
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
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderUpdateProfileResponse>(
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
        bool expectedSuccess = true;

        Assert.Equal(expectedProfile, deserialized.Profile);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderUpdateProfileResponse
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
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderUpdateProfileResponse
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
            Success = true,
        };

        SenderUpdateProfileResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
