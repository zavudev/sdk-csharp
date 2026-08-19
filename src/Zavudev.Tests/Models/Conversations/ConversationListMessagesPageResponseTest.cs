using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Conversations;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationListMessagesPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Message> expectedItems =
        [
            new()
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
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListMessagesPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Message> expectedItems =
        [
            new()
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
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListMessagesPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        ConversationListMessagesPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
