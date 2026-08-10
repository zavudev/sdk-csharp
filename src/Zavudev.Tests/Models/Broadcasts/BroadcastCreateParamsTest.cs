using System;
using System.Collections.Generic;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = BroadcastChannel.Sms,
            Name = "Black Friday Sale",
            Content = new()
            {
                Filename = "filename",
                MediaID = "mediaId",
                MediaUrl = "mediaUrl",
                MimeType = "mimeType",
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
            },
            EmailHtmlBody = "emailHtmlBody",
            EmailSubject = "emailSubject",
            IdempotencyKey = "idempotencyKey",
            MessageType = BroadcastMessageType.Text,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            Text = "Hi {{name}}, check out our Black Friday deals! Use code FRIDAY20 for 20% off.",
        };

        ApiEnum<string, BroadcastChannel> expectedChannel = BroadcastChannel.Sms;
        string expectedName = "Black Friday Sale";
        BroadcastContent expectedContent = new()
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string expectedEmailHtmlBody = "emailHtmlBody";
        string expectedEmailSubject = "emailSubject";
        string expectedIdempotencyKey = "idempotencyKey";
        ApiEnum<string, BroadcastMessageType> expectedMessageType = BroadcastMessageType.Text;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";
        string expectedText =
            "Hi {{name}}, check out our Black Friday deals! Use code FRIDAY20 for 20% off.";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedEmailHtmlBody, parameters.EmailHtmlBody);
        Assert.Equal(expectedEmailSubject, parameters.EmailSubject);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedMessageType, parameters.MessageType);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedScheduledAt, parameters.ScheduledAt);
        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = BroadcastChannel.Sms,
            Name = "Black Friday Sale",
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.EmailHtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("emailHtmlBody"));
        Assert.Null(parameters.EmailSubject);
        Assert.False(parameters.RawBodyData.ContainsKey("emailSubject"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotencyKey"));
        Assert.Null(parameters.MessageType);
        Assert.False(parameters.RawBodyData.ContainsKey("messageType"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ScheduledAt);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduledAt"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = BroadcastChannel.Sms,
            Name = "Black Friday Sale",

            // Null should be interpreted as omitted for these properties
            Content = null,
            EmailHtmlBody = null,
            EmailSubject = null,
            IdempotencyKey = null,
            MessageType = null,
            Metadata = null,
            ScheduledAt = null,
            SenderID = null,
            Text = null,
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.EmailHtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("emailHtmlBody"));
        Assert.Null(parameters.EmailSubject);
        Assert.False(parameters.RawBodyData.ContainsKey("emailSubject"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotencyKey"));
        Assert.Null(parameters.MessageType);
        Assert.False(parameters.RawBodyData.ContainsKey("messageType"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ScheduledAt);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduledAt"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastCreateParams parameters = new()
        {
            Channel = BroadcastChannel.Sms,
            Name = "Black Friday Sale",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/broadcasts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = BroadcastChannel.Sms,
            Name = "Black Friday Sale",
            Content = new()
            {
                Filename = "filename",
                MediaID = "mediaId",
                MediaUrl = "mediaUrl",
                MimeType = "mimeType",
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
            },
            EmailHtmlBody = "emailHtmlBody",
            EmailSubject = "emailSubject",
            IdempotencyKey = "idempotencyKey",
            MessageType = BroadcastMessageType.Text,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            Text = "Hi {{name}}, check out our Black Friday deals! Use code FRIDAY20 for 20% off.",
        };

        BroadcastCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
