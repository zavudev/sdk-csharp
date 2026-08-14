using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "jd7x2k3m4n5p6q7r8s9t0";
        ApiEnum<string, MessageChannel> expectedChannel = MessageChannel.Auto;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageType> expectedMessageType = MessageType.Text;
        ApiEnum<string, MessageStatus> expectedStatus = MessageStatus.Queued;
        string expectedTo = "+56912345678";
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
        string expectedConversationID = "js723987cyghwqxxaxcf590qd18axd95";
        double expectedCost = 0;
        double expectedCostProvider = 0;
        double expectedCostTotal = 0;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedFrom = "+13125551212";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedProviderMessageID = "providerMessageId";
        string expectedSenderID = "sender_12345";
        string expectedText = "text";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMessageType, model.MessageType);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedConversationID, model.ConversationID);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCostProvider, model.CostProvider);
        Assert.Equal(expectedCostTotal, model.CostTotal);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedFrom, model.From);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedProviderMessageID, model.ProviderMessageID);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Message>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "jd7x2k3m4n5p6q7r8s9t0";
        ApiEnum<string, MessageChannel> expectedChannel = MessageChannel.Auto;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageType> expectedMessageType = MessageType.Text;
        ApiEnum<string, MessageStatus> expectedStatus = MessageStatus.Queued;
        string expectedTo = "+56912345678";
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
        string expectedConversationID = "js723987cyghwqxxaxcf590qd18axd95";
        double expectedCost = 0;
        double expectedCostProvider = 0;
        double expectedCostTotal = 0;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedFrom = "+13125551212";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedProviderMessageID = "providerMessageId";
        string expectedSenderID = "sender_12345";
        string expectedText = "text";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMessageType, deserialized.MessageType);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedConversationID, deserialized.ConversationID);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCostProvider, deserialized.CostProvider);
        Assert.Equal(expectedCostTotal, deserialized.CostTotal);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedProviderMessageID, deserialized.ProviderMessageID);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ProviderMessageID);
        Assert.False(model.RawData.ContainsKey("providerMessageId"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",

            // Null should be interpreted as omitted for these properties
            Content = null,
            ConversationID = null,
            From = null,
            Metadata = null,
            ProviderMessageID = null,
            SenderID = null,
            Text = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.ConversationID);
        Assert.False(model.RawData.ContainsKey("conversationId"));
        Assert.Null(model.From);
        Assert.False(model.RawData.ContainsKey("from"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.ProviderMessageID);
        Assert.False(model.RawData.ContainsKey("providerMessageId"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",

            // Null should be interpreted as omitted for these properties
            Content = null,
            ConversationID = null,
            From = null,
            Metadata = null,
            ProviderMessageID = null,
            SenderID = null,
            Text = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CostProvider);
        Assert.False(model.RawData.ContainsKey("costProvider"));
        Assert.Null(model.CostTotal);
        Assert.False(model.RawData.ContainsKey("costTotal"));
        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Cost = null,
            CostProvider = null,
            CostTotal = null,
            ErrorCode = null,
            ErrorMessage = null,
        };

        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
        Assert.Null(model.CostProvider);
        Assert.True(model.RawData.ContainsKey("costProvider"));
        Assert.Null(model.CostTotal);
        Assert.True(model.RawData.ContainsKey("costTotal"));
        Assert.Null(model.ErrorCode);
        Assert.True(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("errorMessage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Cost = null,
            CostProvider = null,
            CostTotal = null,
            ErrorCode = null,
            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Message
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            Channel = MessageChannel.Auto,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = MessageType.Text,
            Status = MessageStatus.Queued,
            To = "+56912345678",
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
            ConversationID = "js723987cyghwqxxaxcf590qd18axd95",
            Cost = 0,
            CostProvider = 0,
            CostTotal = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            From = "+13125551212",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ProviderMessageID = "providerMessageId",
            SenderID = "sender_12345",
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Message copied = new(model);

        Assert.Equal(model, copied);
    }
}
