using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Sender
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
        };

        string expectedID = "sender_12345";
        string expectedName = "Primary sender";
        string expectedPhoneNumber = "+13125551212";
        List<string> expectedChannels = ["sms", "voice"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmailAddress = "noreply@yourdomain.com";
        bool expectedEmailCatchAllEnabled = true;
        bool expectedEmailReceivingEnabled = true;
        bool expectedIsDefault = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        SenderWebhook expectedWebhook = new()
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };
        Whatsapp expectedWhatsapp = new()
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedEmailCatchAllEnabled, model.EmailCatchAllEnabled);
        Assert.Equal(expectedEmailReceivingEnabled, model.EmailReceivingEnabled);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebhook, model.Webhook);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Sender
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sender>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Sender
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Sender>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "sender_12345";
        string expectedName = "Primary sender";
        string expectedPhoneNumber = "+13125551212";
        List<string> expectedChannels = ["sms", "voice"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmailAddress = "noreply@yourdomain.com";
        bool expectedEmailCatchAllEnabled = true;
        bool expectedEmailReceivingEnabled = true;
        bool expectedIsDefault = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        SenderWebhook expectedWebhook = new()
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };
        Whatsapp expectedWhatsapp = new()
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedEmailCatchAllEnabled, deserialized.EmailCatchAllEnabled);
        Assert.Equal(expectedEmailReceivingEnabled, deserialized.EmailReceivingEnabled);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebhook, deserialized.Webhook);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Sender
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Sender
        {
            ID = "sender_12345",
            Name = "Primary sender",
            PhoneNumber = "+13125551212",
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.EmailCatchAllEnabled);
        Assert.False(model.RawData.ContainsKey("emailCatchAllEnabled"));
        Assert.Null(model.EmailReceivingEnabled);
        Assert.False(model.RawData.ContainsKey("emailReceivingEnabled"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Webhook);
        Assert.False(model.RawData.ContainsKey("webhook"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Sender
        {
            ID = "sender_12345",
            Name = "Primary sender",
            PhoneNumber = "+13125551212",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Sender
        {
            ID = "sender_12345",
            Name = "Primary sender",
            PhoneNumber = "+13125551212",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            CreatedAt = null,
            EmailAddress = null,
            EmailCatchAllEnabled = null,
            EmailReceivingEnabled = null,
            IsDefault = null,
            UpdatedAt = null,
            Webhook = null,
            Whatsapp = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.EmailAddress);
        Assert.False(model.RawData.ContainsKey("emailAddress"));
        Assert.Null(model.EmailCatchAllEnabled);
        Assert.False(model.RawData.ContainsKey("emailCatchAllEnabled"));
        Assert.Null(model.EmailReceivingEnabled);
        Assert.False(model.RawData.ContainsKey("emailReceivingEnabled"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("isDefault"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Webhook);
        Assert.False(model.RawData.ContainsKey("webhook"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Sender
        {
            ID = "sender_12345",
            Name = "Primary sender",
            PhoneNumber = "+13125551212",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            CreatedAt = null,
            EmailAddress = null,
            EmailCatchAllEnabled = null,
            EmailReceivingEnabled = null,
            IsDefault = null,
            UpdatedAt = null,
            Webhook = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Sender
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
        };

        Sender copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        string expectedDisplayPhoneNumber = "+14155551234";
        PaymentStatus expectedPaymentStatus = new()
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };
        string expectedPhoneNumberID = "phoneNumberId";

        Assert.Equal(expectedDisplayPhoneNumber, model.DisplayPhoneNumber);
        Assert.Equal(expectedPaymentStatus, model.PaymentStatus);
        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Whatsapp
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDisplayPhoneNumber = "+14155551234";
        PaymentStatus expectedPaymentStatus = new()
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };
        string expectedPhoneNumberID = "phoneNumberId";

        Assert.Equal(expectedDisplayPhoneNumber, deserialized.DisplayPhoneNumber);
        Assert.Equal(expectedPaymentStatus, deserialized.PaymentStatus);
        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Whatsapp
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Whatsapp { };

        Assert.Null(model.DisplayPhoneNumber);
        Assert.False(model.RawData.ContainsKey("displayPhoneNumber"));
        Assert.Null(model.PaymentStatus);
        Assert.False(model.RawData.ContainsKey("paymentStatus"));
        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phoneNumberId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Whatsapp { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Whatsapp
        {
            // Null should be interpreted as omitted for these properties
            DisplayPhoneNumber = null,
            PaymentStatus = null,
            PhoneNumberID = null,
        };

        Assert.Null(model.DisplayPhoneNumber);
        Assert.False(model.RawData.ContainsKey("displayPhoneNumber"));
        Assert.Null(model.PaymentStatus);
        Assert.False(model.RawData.ContainsKey("paymentStatus"));
        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phoneNumberId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Whatsapp
        {
            // Null should be interpreted as omitted for these properties
            DisplayPhoneNumber = null,
            PaymentStatus = null,
            PhoneNumberID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Whatsapp
        {
            DisplayPhoneNumber = "+14155551234",
            PaymentStatus = new()
            {
                CanSendTemplates = true,
                MethodStatus = "VALID",
                SetupStatus = "COMPLETE",
            },
            PhoneNumberID = "phoneNumberId",
        };

        Whatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentStatus
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };

        bool expectedCanSendTemplates = true;
        string expectedMethodStatus = "VALID";
        string expectedSetupStatus = "COMPLETE";

        Assert.Equal(expectedCanSendTemplates, model.CanSendTemplates);
        Assert.Equal(expectedMethodStatus, model.MethodStatus);
        Assert.Equal(expectedSetupStatus, model.SetupStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentStatus
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentStatus
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanSendTemplates = true;
        string expectedMethodStatus = "VALID";
        string expectedSetupStatus = "COMPLETE";

        Assert.Equal(expectedCanSendTemplates, deserialized.CanSendTemplates);
        Assert.Equal(expectedMethodStatus, deserialized.MethodStatus);
        Assert.Equal(expectedSetupStatus, deserialized.SetupStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentStatus
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaymentStatus { };

        Assert.Null(model.CanSendTemplates);
        Assert.False(model.RawData.ContainsKey("canSendTemplates"));
        Assert.Null(model.MethodStatus);
        Assert.False(model.RawData.ContainsKey("methodStatus"));
        Assert.Null(model.SetupStatus);
        Assert.False(model.RawData.ContainsKey("setupStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaymentStatus { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaymentStatus
        {
            // Null should be interpreted as omitted for these properties
            CanSendTemplates = null,
            MethodStatus = null,
            SetupStatus = null,
        };

        Assert.Null(model.CanSendTemplates);
        Assert.False(model.RawData.ContainsKey("canSendTemplates"));
        Assert.Null(model.MethodStatus);
        Assert.False(model.RawData.ContainsKey("methodStatus"));
        Assert.Null(model.SetupStatus);
        Assert.False(model.RawData.ContainsKey("setupStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaymentStatus
        {
            // Null should be interpreted as omitted for these properties
            CanSendTemplates = null,
            MethodStatus = null,
            SetupStatus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentStatus
        {
            CanSendTemplates = true,
            MethodStatus = "VALID",
            SetupStatus = "COMPLETE",
        };

        PaymentStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
