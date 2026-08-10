using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderCreateParams
        {
            Name = "name",
            EmailAddress = "noreply@yourdomain.com",
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            PhoneNumber = "phoneNumber",
            SetAsDefault = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = WebhookSignatureVersion.V2,
            WebhookUrl = "https://example.com",
        };

        string expectedName = "name";
        string expectedEmailAddress = "noreply@yourdomain.com";
        string expectedEmailDomainID = "emailDomainId";
        string expectedEmailFromName = "emailFromName";
        bool expectedEmailReceivingEnabled = true;
        bool expectedEnableSmsOneway = true;
        bool expectedEnableVoice = true;
        string expectedPhoneNumber = "phoneNumber";
        bool expectedSetAsDefault = true;
        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents = [WebhookEvent.MessageQueued];
        ApiEnum<string, WebhookSignatureVersion> expectedWebhookSignatureVersion =
            WebhookSignatureVersion.V2;
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedEmailAddress, parameters.EmailAddress);
        Assert.Equal(expectedEmailDomainID, parameters.EmailDomainID);
        Assert.Equal(expectedEmailFromName, parameters.EmailFromName);
        Assert.Equal(expectedEmailReceivingEnabled, parameters.EmailReceivingEnabled);
        Assert.Equal(expectedEnableSmsOneway, parameters.EnableSmsOneway);
        Assert.Equal(expectedEnableVoice, parameters.EnableVoice);
        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedSetAsDefault, parameters.SetAsDefault);
        Assert.NotNull(parameters.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, parameters.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], parameters.WebhookEvents[i]);
        }
        Assert.Equal(expectedWebhookSignatureVersion, parameters.WebhookSignatureVersion);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderCreateParams { Name = "name" };

        Assert.Null(parameters.EmailAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("emailAddress"));
        Assert.Null(parameters.EmailDomainID);
        Assert.False(parameters.RawBodyData.ContainsKey("emailDomainId"));
        Assert.Null(parameters.EmailFromName);
        Assert.False(parameters.RawBodyData.ContainsKey("emailFromName"));
        Assert.Null(parameters.EmailReceivingEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("emailReceivingEnabled"));
        Assert.Null(parameters.EnableSmsOneway);
        Assert.False(parameters.RawBodyData.ContainsKey("enableSmsOneway"));
        Assert.Null(parameters.EnableVoice);
        Assert.False(parameters.RawBodyData.ContainsKey("enableVoice"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.SetAsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("setAsDefault"));
        Assert.Null(parameters.WebhookEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookEvents"));
        Assert.Null(parameters.WebhookSignatureVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSignatureVersion"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderCreateParams
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            EmailAddress = null,
            EmailDomainID = null,
            EmailFromName = null,
            EmailReceivingEnabled = null,
            EnableSmsOneway = null,
            EnableVoice = null,
            PhoneNumber = null,
            SetAsDefault = null,
            WebhookEvents = null,
            WebhookSignatureVersion = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.EmailAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("emailAddress"));
        Assert.Null(parameters.EmailDomainID);
        Assert.False(parameters.RawBodyData.ContainsKey("emailDomainId"));
        Assert.Null(parameters.EmailFromName);
        Assert.False(parameters.RawBodyData.ContainsKey("emailFromName"));
        Assert.Null(parameters.EmailReceivingEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("emailReceivingEnabled"));
        Assert.Null(parameters.EnableSmsOneway);
        Assert.False(parameters.RawBodyData.ContainsKey("enableSmsOneway"));
        Assert.Null(parameters.EnableVoice);
        Assert.False(parameters.RawBodyData.ContainsKey("enableVoice"));
        Assert.Null(parameters.PhoneNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumber"));
        Assert.Null(parameters.SetAsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("setAsDefault"));
        Assert.Null(parameters.WebhookEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookEvents"));
        Assert.Null(parameters.WebhookSignatureVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSignatureVersion"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderCreateParams parameters = new() { Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderCreateParams
        {
            Name = "name",
            EmailAddress = "noreply@yourdomain.com",
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            PhoneNumber = "phoneNumber",
            SetAsDefault = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = WebhookSignatureVersion.V2,
            WebhookUrl = "https://example.com",
        };

        SenderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookSignatureVersionTest : TestBase
{
    [Theory]
    [InlineData(WebhookSignatureVersion.V1)]
    [InlineData(WebhookSignatureVersion.V1V2)]
    [InlineData(WebhookSignatureVersion.V2)]
    public void Validation_Works(WebhookSignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookSignatureVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookSignatureVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookSignatureVersion.V1)]
    [InlineData(WebhookSignatureVersion.V1V2)]
    [InlineData(WebhookSignatureVersion.V2)]
    public void SerializationRoundtrip_Works(WebhookSignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookSignatureVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookSignatureVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookSignatureVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookSignatureVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
