using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class WebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookEvent.MessageQueued)]
    [InlineData(WebhookEvent.MessageSent)]
    [InlineData(WebhookEvent.MessageDelivered)]
    [InlineData(WebhookEvent.MessageRead)]
    [InlineData(WebhookEvent.MessageStatus)]
    [InlineData(WebhookEvent.MessageFailed)]
    [InlineData(WebhookEvent.MessageInbound)]
    [InlineData(WebhookEvent.MessageUnsupported)]
    [InlineData(WebhookEvent.BroadcastStatusChanged)]
    [InlineData(WebhookEvent.ConversationNew)]
    [InlineData(WebhookEvent.TemplateStatusChanged)]
    [InlineData(WebhookEvent.InvitationStatusChanged)]
    [InlineData(WebhookEvent.CallInitiated)]
    [InlineData(WebhookEvent.CallAnswered)]
    [InlineData(WebhookEvent.CallCompleted)]
    [InlineData(WebhookEvent.CallFailed)]
    [InlineData(WebhookEvent.DomainVerified)]
    [InlineData(WebhookEvent.DomainFailed)]
    public void Validation_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEvent.MessageQueued)]
    [InlineData(WebhookEvent.MessageSent)]
    [InlineData(WebhookEvent.MessageDelivered)]
    [InlineData(WebhookEvent.MessageRead)]
    [InlineData(WebhookEvent.MessageStatus)]
    [InlineData(WebhookEvent.MessageFailed)]
    [InlineData(WebhookEvent.MessageInbound)]
    [InlineData(WebhookEvent.MessageUnsupported)]
    [InlineData(WebhookEvent.BroadcastStatusChanged)]
    [InlineData(WebhookEvent.ConversationNew)]
    [InlineData(WebhookEvent.TemplateStatusChanged)]
    [InlineData(WebhookEvent.InvitationStatusChanged)]
    [InlineData(WebhookEvent.CallInitiated)]
    [InlineData(WebhookEvent.CallAnswered)]
    [InlineData(WebhookEvent.CallCompleted)]
    [InlineData(WebhookEvent.CallFailed)]
    [InlineData(WebhookEvent.DomainVerified)]
    [InlineData(WebhookEvent.DomainFailed)]
    public void SerializationRoundtrip_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
