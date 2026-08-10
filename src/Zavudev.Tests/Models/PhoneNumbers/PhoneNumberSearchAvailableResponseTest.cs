using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberSearchAvailableResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberSearchAvailableResponse
        {
            Items =
            [
                new()
                {
                    Capabilities = new()
                    {
                        Mms = true,
                        Sms = true,
                        Voice = true,
                    },
                    PhoneNumber = "+15551234567",
                    Pricing = new()
                    {
                        IsFreeEligible = true,
                        MonthlyPrice = 0,
                        UpfrontPrice = 0,
                    },
                    FriendlyName = "(555) 123-4567",
                    Locality = "San Francisco",
                    Region = "CA",
                },
            ],
        };

        List<AvailablePhoneNumber> expectedItems =
        [
            new()
            {
                Capabilities = new()
                {
                    Mms = true,
                    Sms = true,
                    Voice = true,
                },
                PhoneNumber = "+15551234567",
                Pricing = new()
                {
                    IsFreeEligible = true,
                    MonthlyPrice = 0,
                    UpfrontPrice = 0,
                },
                FriendlyName = "(555) 123-4567",
                Locality = "San Francisco",
                Region = "CA",
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberSearchAvailableResponse
        {
            Items =
            [
                new()
                {
                    Capabilities = new()
                    {
                        Mms = true,
                        Sms = true,
                        Voice = true,
                    },
                    PhoneNumber = "+15551234567",
                    Pricing = new()
                    {
                        IsFreeEligible = true,
                        MonthlyPrice = 0,
                        UpfrontPrice = 0,
                    },
                    FriendlyName = "(555) 123-4567",
                    Locality = "San Francisco",
                    Region = "CA",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberSearchAvailableResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberSearchAvailableResponse
        {
            Items =
            [
                new()
                {
                    Capabilities = new()
                    {
                        Mms = true,
                        Sms = true,
                        Voice = true,
                    },
                    PhoneNumber = "+15551234567",
                    Pricing = new()
                    {
                        IsFreeEligible = true,
                        MonthlyPrice = 0,
                        UpfrontPrice = 0,
                    },
                    FriendlyName = "(555) 123-4567",
                    Locality = "San Francisco",
                    Region = "CA",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberSearchAvailableResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AvailablePhoneNumber> expectedItems =
        [
            new()
            {
                Capabilities = new()
                {
                    Mms = true,
                    Sms = true,
                    Voice = true,
                },
                PhoneNumber = "+15551234567",
                Pricing = new()
                {
                    IsFreeEligible = true,
                    MonthlyPrice = 0,
                    UpfrontPrice = 0,
                },
                FriendlyName = "(555) 123-4567",
                Locality = "San Francisco",
                Region = "CA",
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberSearchAvailableResponse
        {
            Items =
            [
                new()
                {
                    Capabilities = new()
                    {
                        Mms = true,
                        Sms = true,
                        Voice = true,
                    },
                    PhoneNumber = "+15551234567",
                    Pricing = new()
                    {
                        IsFreeEligible = true,
                        MonthlyPrice = 0,
                        UpfrontPrice = 0,
                    },
                    FriendlyName = "(555) 123-4567",
                    Locality = "San Francisco",
                    Region = "CA",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberSearchAvailableResponse
        {
            Items =
            [
                new()
                {
                    Capabilities = new()
                    {
                        Mms = true,
                        Sms = true,
                        Voice = true,
                    },
                    PhoneNumber = "+15551234567",
                    Pricing = new()
                    {
                        IsFreeEligible = true,
                        MonthlyPrice = 0,
                        UpfrontPrice = 0,
                    },
                    FriendlyName = "(555) 123-4567",
                    Locality = "San Francisco",
                    Region = "CA",
                },
            ],
        };

        PhoneNumberSearchAvailableResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
