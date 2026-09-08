using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageSendParams
        {
            To = "+56912345678",
            Attachments =
            [
                new()
                {
                    Filename = "invoice.pdf",
                    Content = "content",
                    ContentID = "logo",
                    ContentType = "application/pdf",
                    Path = "https://example.com",
                },
            ],
            Channel = MessageChannel.Auto,
            Content = new()
            {
                Buttons = [new() { ID = "id", Title = "title" }],
                Contacts = [new() { Name = "name", Phones = ["string"] }],
                CtaDisplayText = "See Dates",
                CtaHeaderMediaUrl = "https://example.com",
                CtaHeaderText = "ctaHeaderText",
                CtaHeaderType = CtaHeaderType.Text,
                CtaUrl = "https://example.com/schedule",
                Emoji = "emoji",
                Filename = "invoice.pdf",
                FooterText = "Dates subject to change.",
                Latitude = 0,
                ListButton = "listButton",
                LocationAddress = "locationAddress",
                LocationName = "locationName",
                Longitude = 0,
                MediaID = "mediaId",
                MediaUrl = "https://example.com/image.jpg",
                MimeType = "image/jpeg",
                ReactToMessageID = "reactToMessageId",
                Referral = new()
                {
                    Body = "body",
                    CtwaClid = "ARIzZm9vYmFyY3R3YWNsaWQ",
                    Headline = "headline",
                    ImageUrl = "https://example.com",
                    MediaType = MediaType.Image,
                    SourceID = "120210000000000000",
                    SourceType = SourceType.Ad,
                    SourceUrl = "https://example.com",
                    ThumbnailUrl = "https://example.com",
                    VideoUrl = "https://example.com",
                },
                ReplyToFrom = "replyToFrom",
                ReplyToMessageID = "replyToMessageId",
                ReplyToMessageType = "replyToMessageType",
                ReplyToProviderMessageID = "replyToProviderMessageId",
                ReplyToText = "replyToText",
                Sections =
                [
                    new()
                    {
                        Rows =
                        [
                            new()
                            {
                                ID = "id",
                                Title = "title",
                                Description = "description",
                            },
                        ],
                        Title = "title",
                    },
                ],
                TemplateButtonVariables = new Dictionary<string, string>()
                {
                    { "0", "abc-report-token" },
                },
                TemplateHeaderVariables = new Dictionary<string, string>()
                {
                    { "1", "Jorge y Laura" },
                },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>()
                {
                    { "1", "John" },
                    { "2", "ORD-12345" },
                },
            },
            FallbackEnabled = true,
            HtmlBody = "htmlBody",
            IdempotencyKey = "msg_01HZY4ZP7VQY2J3BRW7Z6G0QGE",
            MessageType = MessageType.Text,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReplyTo = "support@example.com",
            Subject = "Your order confirmation",
            Text = "Your verification code is 123456",
            VoiceLanguage = "es-ES",
            ZavuSender = "sender_12345",
        };

        string expectedTo = "+56912345678";
        List<Attachment> expectedAttachments =
        [
            new()
            {
                Filename = "invoice.pdf",
                Content = "content",
                ContentID = "logo",
                ContentType = "application/pdf",
                Path = "https://example.com",
            },
        ];
        ApiEnum<string, MessageChannel> expectedChannel = MessageChannel.Auto;
        MessageContent expectedContent = new()
        {
            Buttons = [new() { ID = "id", Title = "title" }],
            Contacts = [new() { Name = "name", Phones = ["string"] }],
            CtaDisplayText = "See Dates",
            CtaHeaderMediaUrl = "https://example.com",
            CtaHeaderText = "ctaHeaderText",
            CtaHeaderType = CtaHeaderType.Text,
            CtaUrl = "https://example.com/schedule",
            Emoji = "emoji",
            Filename = "invoice.pdf",
            FooterText = "Dates subject to change.",
            Latitude = 0,
            ListButton = "listButton",
            LocationAddress = "locationAddress",
            LocationName = "locationName",
            Longitude = 0,
            MediaID = "mediaId",
            MediaUrl = "https://example.com/image.jpg",
            MimeType = "image/jpeg",
            ReactToMessageID = "reactToMessageId",
            Referral = new()
            {
                Body = "body",
                CtwaClid = "ARIzZm9vYmFyY3R3YWNsaWQ",
                Headline = "headline",
                ImageUrl = "https://example.com",
                MediaType = MediaType.Image,
                SourceID = "120210000000000000",
                SourceType = SourceType.Ad,
                SourceUrl = "https://example.com",
                ThumbnailUrl = "https://example.com",
                VideoUrl = "https://example.com",
            },
            ReplyToFrom = "replyToFrom",
            ReplyToMessageID = "replyToMessageId",
            ReplyToMessageType = "replyToMessageType",
            ReplyToProviderMessageID = "replyToProviderMessageId",
            ReplyToText = "replyToText",
            Sections =
            [
                new()
                {
                    Rows =
                    [
                        new()
                        {
                            ID = "id",
                            Title = "title",
                            Description = "description",
                        },
                    ],
                    Title = "title",
                },
            ],
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };
        bool expectedFallbackEnabled = true;
        string expectedHtmlBody = "htmlBody";
        string expectedIdempotencyKey = "msg_01HZY4ZP7VQY2J3BRW7Z6G0QGE";
        ApiEnum<string, MessageType> expectedMessageType = MessageType.Text;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedReplyTo = "support@example.com";
        string expectedSubject = "Your order confirmation";
        string expectedText = "Your verification code is 123456";
        string expectedVoiceLanguage = "es-ES";
        string expectedZavuSender = "sender_12345";

        Assert.Equal(expectedTo, parameters.To);
        Assert.NotNull(parameters.Attachments);
        Assert.Equal(expectedAttachments.Count, parameters.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], parameters.Attachments[i]);
        }
        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedFallbackEnabled, parameters.FallbackEnabled);
        Assert.Equal(expectedHtmlBody, parameters.HtmlBody);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedMessageType, parameters.MessageType);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedReplyTo, parameters.ReplyTo);
        Assert.Equal(expectedSubject, parameters.Subject);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedVoiceLanguage, parameters.VoiceLanguage);
        Assert.Equal(expectedZavuSender, parameters.ZavuSender);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageSendParams { To = "+56912345678" };

        Assert.Null(parameters.Attachments);
        Assert.False(parameters.RawBodyData.ContainsKey("attachments"));
        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawBodyData.ContainsKey("channel"));
        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.FallbackEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("fallbackEnabled"));
        Assert.Null(parameters.HtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("htmlBody"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotencyKey"));
        Assert.Null(parameters.MessageType);
        Assert.False(parameters.RawBodyData.ContainsKey("messageType"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReplyTo);
        Assert.False(parameters.RawBodyData.ContainsKey("replyTo"));
        Assert.Null(parameters.Subject);
        Assert.False(parameters.RawBodyData.ContainsKey("subject"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.VoiceLanguage);
        Assert.False(parameters.RawBodyData.ContainsKey("voiceLanguage"));
        Assert.Null(parameters.ZavuSender);
        Assert.False(parameters.RawHeaderData.ContainsKey("Zavu-Sender"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageSendParams
        {
            To = "+56912345678",

            // Null should be interpreted as omitted for these properties
            Attachments = null,
            Channel = null,
            Content = null,
            FallbackEnabled = null,
            HtmlBody = null,
            IdempotencyKey = null,
            MessageType = null,
            Metadata = null,
            ReplyTo = null,
            Subject = null,
            Text = null,
            VoiceLanguage = null,
            ZavuSender = null,
        };

        Assert.Null(parameters.Attachments);
        Assert.False(parameters.RawBodyData.ContainsKey("attachments"));
        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawBodyData.ContainsKey("channel"));
        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.FallbackEnabled);
        Assert.False(parameters.RawBodyData.ContainsKey("fallbackEnabled"));
        Assert.Null(parameters.HtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("htmlBody"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawBodyData.ContainsKey("idempotencyKey"));
        Assert.Null(parameters.MessageType);
        Assert.False(parameters.RawBodyData.ContainsKey("messageType"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.ReplyTo);
        Assert.False(parameters.RawBodyData.ContainsKey("replyTo"));
        Assert.Null(parameters.Subject);
        Assert.False(parameters.RawBodyData.ContainsKey("subject"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.VoiceLanguage);
        Assert.False(parameters.RawBodyData.ContainsKey("voiceLanguage"));
        Assert.Null(parameters.ZavuSender);
        Assert.False(parameters.RawHeaderData.ContainsKey("Zavu-Sender"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageSendParams parameters = new() { To = "+56912345678" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/messages"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageSendParams parameters = new() { To = "+56912345678", ZavuSender = "sender_12345" };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sender_12345"], requestMessage.Headers.GetValues("Zavu-Sender"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageSendParams
        {
            To = "+56912345678",
            Attachments =
            [
                new()
                {
                    Filename = "invoice.pdf",
                    Content = "content",
                    ContentID = "logo",
                    ContentType = "application/pdf",
                    Path = "https://example.com",
                },
            ],
            Channel = MessageChannel.Auto,
            Content = new()
            {
                Buttons = [new() { ID = "id", Title = "title" }],
                Contacts = [new() { Name = "name", Phones = ["string"] }],
                CtaDisplayText = "See Dates",
                CtaHeaderMediaUrl = "https://example.com",
                CtaHeaderText = "ctaHeaderText",
                CtaHeaderType = CtaHeaderType.Text,
                CtaUrl = "https://example.com/schedule",
                Emoji = "emoji",
                Filename = "invoice.pdf",
                FooterText = "Dates subject to change.",
                Latitude = 0,
                ListButton = "listButton",
                LocationAddress = "locationAddress",
                LocationName = "locationName",
                Longitude = 0,
                MediaID = "mediaId",
                MediaUrl = "https://example.com/image.jpg",
                MimeType = "image/jpeg",
                ReactToMessageID = "reactToMessageId",
                Referral = new()
                {
                    Body = "body",
                    CtwaClid = "ARIzZm9vYmFyY3R3YWNsaWQ",
                    Headline = "headline",
                    ImageUrl = "https://example.com",
                    MediaType = MediaType.Image,
                    SourceID = "120210000000000000",
                    SourceType = SourceType.Ad,
                    SourceUrl = "https://example.com",
                    ThumbnailUrl = "https://example.com",
                    VideoUrl = "https://example.com",
                },
                ReplyToFrom = "replyToFrom",
                ReplyToMessageID = "replyToMessageId",
                ReplyToMessageType = "replyToMessageType",
                ReplyToProviderMessageID = "replyToProviderMessageId",
                ReplyToText = "replyToText",
                Sections =
                [
                    new()
                    {
                        Rows =
                        [
                            new()
                            {
                                ID = "id",
                                Title = "title",
                                Description = "description",
                            },
                        ],
                        Title = "title",
                    },
                ],
                TemplateButtonVariables = new Dictionary<string, string>()
                {
                    { "0", "abc-report-token" },
                },
                TemplateHeaderVariables = new Dictionary<string, string>()
                {
                    { "1", "Jorge y Laura" },
                },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>()
                {
                    { "1", "John" },
                    { "2", "ORD-12345" },
                },
            },
            FallbackEnabled = true,
            HtmlBody = "htmlBody",
            IdempotencyKey = "msg_01HZY4ZP7VQY2J3BRW7Z6G0QGE",
            MessageType = MessageType.Text,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ReplyTo = "support@example.com",
            Subject = "Your order confirmation",
            Text = "Your verification code is 123456",
            VoiceLanguage = "es-ES",
            ZavuSender = "sender_12345",
        };

        MessageSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",
            Content = "content",
            ContentID = "logo",
            ContentType = "application/pdf",
            Path = "https://example.com",
        };

        string expectedFilename = "invoice.pdf";
        string expectedContent = "content";
        string expectedContentID = "logo";
        string expectedContentType = "application/pdf";
        string expectedPath = "https://example.com";

        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedContentID, model.ContentID);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",
            Content = "content",
            ContentID = "logo",
            ContentType = "application/pdf",
            Path = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",
            Content = "content",
            ContentID = "logo",
            ContentType = "application/pdf",
            Path = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFilename = "invoice.pdf";
        string expectedContent = "content";
        string expectedContentID = "logo";
        string expectedContentType = "application/pdf";
        string expectedPath = "https://example.com";

        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedContentID, deserialized.ContentID);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",
            Content = "content",
            ContentID = "logo",
            ContentType = "application/pdf",
            Path = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attachment { Filename = "invoice.pdf" };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.ContentID);
        Assert.False(model.RawData.ContainsKey("content_id"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attachment { Filename = "invoice.pdf" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",

            // Null should be interpreted as omitted for these properties
            Content = null,
            ContentID = null,
            ContentType = null,
            Path = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.ContentID);
        Assert.False(model.RawData.ContainsKey("content_id"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",

            // Null should be interpreted as omitted for these properties
            Content = null,
            ContentID = null,
            ContentType = null,
            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attachment
        {
            Filename = "invoice.pdf",
            Content = "content",
            ContentID = "logo",
            ContentType = "application/pdf",
            Path = "https://example.com",
        };

        Attachment copied = new(model);

        Assert.Equal(model, copied);
    }
}
