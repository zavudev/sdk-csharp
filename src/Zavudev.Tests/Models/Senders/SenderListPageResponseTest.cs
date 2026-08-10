using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Sender> expectedItems =
        [
            new()
            {
                ID = "sender_12345",
                Name = "Primary sender",
                PhoneNumber = "+13125551212",
                Channels = ["sms", "voice"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EmailAddress = "noreply@yourdomain.com",
                EmailCatchAllEnabled = true,
                EmailReceivingEnabled = true,
                IsDefault = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Webhook = new()
                {
                    Active = true,
                    Events = [WebhookEvent.MessageQueued],
                    SignatureVersion = SignatureVersion.V2,
                    Url = "https://api.example.com/webhooks/zavu",
                    Secret = "whsec_abc123...",
                },
                Whatsapp = new()
                {
                    DisplayPhoneNumber = "+14155551234",
                    PaymentStatus = new()
                    {
                        CanSendTemplates = true,
                        MethodStatus = "VALID",
                        SetupStatus = "COMPLETE",
                    },
                    PhoneNumberID = "phoneNumberId",
                },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Sender> expectedItems =
        [
            new()
            {
                ID = "sender_12345",
                Name = "Primary sender",
                PhoneNumber = "+13125551212",
                Channels = ["sms", "voice"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EmailAddress = "noreply@yourdomain.com",
                EmailCatchAllEnabled = true,
                EmailReceivingEnabled = true,
                IsDefault = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Webhook = new()
                {
                    Active = true,
                    Events = [WebhookEvent.MessageQueued],
                    SignatureVersion = SignatureVersion.V2,
                    Url = "https://api.example.com/webhooks/zavu",
                    Secret = "whsec_abc123...",
                },
                Whatsapp = new()
                {
                    DisplayPhoneNumber = "+14155551234",
                    PaymentStatus = new()
                    {
                        CanSendTemplates = true,
                        MethodStatus = "VALID",
                        SetupStatus = "COMPLETE",
                    },
                    PhoneNumberID = "phoneNumberId",
                },
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "sender_12345",
                    Name = "Primary sender",
                    PhoneNumber = "+13125551212",
                    Channels = ["sms", "voice"],
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EmailAddress = "noreply@yourdomain.com",
                    EmailCatchAllEnabled = true,
                    EmailReceivingEnabled = true,
                    IsDefault = true,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Webhook = new()
                    {
                        Active = true,
                        Events = [WebhookEvent.MessageQueued],
                        SignatureVersion = SignatureVersion.V2,
                        Url = "https://api.example.com/webhooks/zavu",
                        Secret = "whsec_abc123...",
                    },
                    Whatsapp = new()
                    {
                        DisplayPhoneNumber = "+14155551234",
                        PaymentStatus = new()
                        {
                            CanSendTemplates = true,
                            MethodStatus = "VALID",
                            SetupStatus = "COMPLETE",
                        },
                        PhoneNumberID = "phoneNumberId",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        SenderListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
