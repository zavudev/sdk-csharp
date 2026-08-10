using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderWebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };

        bool expectedActive = true;
        List<ApiEnum<string, WebhookEvent>> expectedEvents = [WebhookEvent.MessageQueued];
        ApiEnum<string, SignatureVersion> expectedSignatureVersion = SignatureVersion.V2;
        string expectedUrl = "https://api.example.com/webhooks/zavu";
        string expectedSecret = "whsec_abc123...";

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
        Assert.Equal(expectedSignatureVersion, model.SignatureVersion);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedSecret, model.Secret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderWebhook>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SenderWebhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        List<ApiEnum<string, WebhookEvent>> expectedEvents = [WebhookEvent.MessageQueued];
        ApiEnum<string, SignatureVersion> expectedSignatureVersion = SignatureVersion.V2;
        string expectedUrl = "https://api.example.com/webhooks/zavu";
        string expectedSecret = "whsec_abc123...";

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
        Assert.Equal(expectedSignatureVersion, deserialized.SignatureVersion);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedSecret, deserialized.Secret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
        };

        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",

            // Null should be interpreted as omitted for these properties
            Secret = null,
        };

        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",

            // Null should be interpreted as omitted for these properties
            Secret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SenderWebhook
        {
            Active = true,
            Events = [WebhookEvent.MessageQueued],
            SignatureVersion = SignatureVersion.V2,
            Url = "https://api.example.com/webhooks/zavu",
            Secret = "whsec_abc123...",
        };

        SenderWebhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SignatureVersionTest : TestBase
{
    [Theory]
    [InlineData(SignatureVersion.V1)]
    [InlineData(SignatureVersion.V1V2)]
    [InlineData(SignatureVersion.V2)]
    public void Validation_Works(SignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SignatureVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SignatureVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SignatureVersion.V1)]
    [InlineData(SignatureVersion.V1V2)]
    [InlineData(SignatureVersion.V2)]
    public void SerializationRoundtrip_Works(SignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SignatureVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SignatureVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SignatureVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SignatureVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
