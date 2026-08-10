using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class SenderUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            EmailAddress = "noreply@yourdomain.com",
            EmailCatchAllEnabled = true,
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            Name = "name",
            SetAsDefault = true,
            WebhookActive = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = SenderUpdateParamsWebhookSignatureVersion.V2,
            WebhookUrl = "https://example.com",
        };

        string expectedSenderID = "senderId";
        string expectedEmailAddress = "noreply@yourdomain.com";
        bool expectedEmailCatchAllEnabled = true;
        string expectedEmailDomainID = "emailDomainId";
        string expectedEmailFromName = "emailFromName";
        bool expectedEmailReceivingEnabled = true;
        bool expectedEnableSmsOneway = true;
        bool expectedEnableVoice = true;
        string expectedName = "name";
        bool expectedSetAsDefault = true;
        bool expectedWebhookActive = true;
        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents = [WebhookEvent.MessageQueued];
        ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion> expectedWebhookSignatureVersion =
            SenderUpdateParamsWebhookSignatureVersion.V2;
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedEmailAddress, parameters.EmailAddress);
        Assert.Equal(expectedEmailCatchAllEnabled, parameters.EmailCatchAllEnabled);
        Assert.Equal(expectedEmailDomainID, parameters.EmailDomainID);
        Assert.Equal(expectedEmailFromName, parameters.EmailFromName);
        Assert.Equal(expectedEmailReceivingEnabled, parameters.EmailReceivingEnabled);
        Assert.Equal(expectedEnableSmsOneway, parameters.EnableSmsOneway);
        Assert.Equal(expectedEnableVoice, parameters.EnableVoice);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSetAsDefault, parameters.SetAsDefault);
        Assert.Equal(expectedWebhookActive, parameters.WebhookActive);
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
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            WebhookUrl = "https://example.com",
        };

        Assert.Null(parameters.EmailAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("emailAddress"));
        Assert.Null(parameters.EmailCatchAllEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("emailCatchAllEnabled"));
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
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SetAsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("setAsDefault"));
        Assert.Null(parameters.WebhookActive);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookActive"));
        Assert.Null(parameters.WebhookEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookEvents"));
        Assert.Null(parameters.WebhookSignatureVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSignatureVersion"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            WebhookUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            EmailAddress = null,
            EmailCatchAllEnabled = null,
            EmailDomainID = null,
            EmailFromName = null,
            EmailReceivingEnabled = null,
            EnableSmsOneway = null,
            EnableVoice = null,
            Name = null,
            SetAsDefault = null,
            WebhookActive = null,
            WebhookEvents = null,
            WebhookSignatureVersion = null,
        };

        Assert.Null(parameters.EmailAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("emailAddress"));
        Assert.Null(parameters.EmailCatchAllEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("emailCatchAllEnabled"));
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
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.SetAsDefault);
        Assert.False(parameters.RawBodyData.ContainsKey("setAsDefault"));
        Assert.Null(parameters.WebhookActive);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookActive"));
        Assert.Null(parameters.WebhookEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookEvents"));
        Assert.Null(parameters.WebhookSignatureVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookSignatureVersion"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            EmailAddress = "noreply@yourdomain.com",
            EmailCatchAllEnabled = true,
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            Name = "name",
            SetAsDefault = true,
            WebhookActive = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = SenderUpdateParamsWebhookSignatureVersion.V2,
        };

        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            EmailAddress = "noreply@yourdomain.com",
            EmailCatchAllEnabled = true,
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            Name = "name",
            SetAsDefault = true,
            WebhookActive = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = SenderUpdateParamsWebhookSignatureVersion.V2,

            WebhookUrl = null,
        };

        Assert.Null(parameters.WebhookUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void Url_Works()
    {
        SenderUpdateParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderUpdateParams
        {
            SenderID = "senderId",
            EmailAddress = "noreply@yourdomain.com",
            EmailCatchAllEnabled = true,
            EmailDomainID = "emailDomainId",
            EmailFromName = "emailFromName",
            EmailReceivingEnabled = true,
            EnableSmsOneway = true,
            EnableVoice = true,
            Name = "name",
            SetAsDefault = true,
            WebhookActive = true,
            WebhookEvents = [WebhookEvent.MessageQueued],
            WebhookSignatureVersion = SenderUpdateParamsWebhookSignatureVersion.V2,
            WebhookUrl = "https://example.com",
        };

        SenderUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SenderUpdateParamsWebhookSignatureVersionTest : TestBase
{
    [Theory]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V1)]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V1V2)]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V2)]
    public void Validation_Works(SenderUpdateParamsWebhookSignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V1)]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V1V2)]
    [InlineData(SenderUpdateParamsWebhookSignatureVersion.V2)]
    public void SerializationRoundtrip_Works(SenderUpdateParamsWebhookSignatureVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
