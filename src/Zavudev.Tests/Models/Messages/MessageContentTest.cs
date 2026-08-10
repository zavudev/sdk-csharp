using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageContent
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

        List<Button> expectedButtons = [new() { ID = "id", Title = "title" }];
        List<Contact> expectedContacts = [new() { Name = "name", Phones = ["string"] }];
        string expectedCtaDisplayText = "See Dates";
        string expectedCtaHeaderMediaUrl = "https://example.com";
        string expectedCtaHeaderText = "ctaHeaderText";
        ApiEnum<string, CtaHeaderType> expectedCtaHeaderType = CtaHeaderType.Text;
        string expectedCtaUrl = "https://example.com/schedule";
        string expectedEmoji = "emoji";
        string expectedFilename = "invoice.pdf";
        string expectedFooterText = "Dates subject to change.";
        double expectedLatitude = 0;
        string expectedListButton = "listButton";
        string expectedLocationAddress = "locationAddress";
        string expectedLocationName = "locationName";
        double expectedLongitude = 0;
        string expectedMediaID = "mediaId";
        string expectedMediaUrl = "https://example.com/image.jpg";
        string expectedMimeType = "image/jpeg";
        string expectedReactToMessageID = "reactToMessageId";
        string expectedReplyToFrom = "replyToFrom";
        string expectedReplyToMessageID = "replyToMessageId";
        string expectedReplyToMessageType = "replyToMessageType";
        string expectedReplyToProviderMessageID = "replyToProviderMessageId";
        string expectedReplyToText = "replyToText";
        List<Section> expectedSections =
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
        ];
        Dictionary<string, string> expectedTemplateButtonVariables = new()
        {
            { "0", "abc-report-token" },
        };
        Dictionary<string, string> expectedTemplateHeaderVariables = new()
        {
            { "1", "Jorge y Laura" },
        };
        string expectedTemplateID = "templateId";
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "1", "John" },
            { "2", "ORD-12345" },
        };

        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.NotNull(model.Contacts);
        Assert.Equal(expectedContacts.Count, model.Contacts.Count);
        for (int i = 0; i < expectedContacts.Count; i++)
        {
            Assert.Equal(expectedContacts[i], model.Contacts[i]);
        }
        Assert.Equal(expectedCtaDisplayText, model.CtaDisplayText);
        Assert.Equal(expectedCtaHeaderMediaUrl, model.CtaHeaderMediaUrl);
        Assert.Equal(expectedCtaHeaderText, model.CtaHeaderText);
        Assert.Equal(expectedCtaHeaderType, model.CtaHeaderType);
        Assert.Equal(expectedCtaUrl, model.CtaUrl);
        Assert.Equal(expectedEmoji, model.Emoji);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedFooterText, model.FooterText);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedListButton, model.ListButton);
        Assert.Equal(expectedLocationAddress, model.LocationAddress);
        Assert.Equal(expectedLocationName, model.LocationName);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedMediaID, model.MediaID);
        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedReactToMessageID, model.ReactToMessageID);
        Assert.Equal(expectedReplyToFrom, model.ReplyToFrom);
        Assert.Equal(expectedReplyToMessageID, model.ReplyToMessageID);
        Assert.Equal(expectedReplyToMessageType, model.ReplyToMessageType);
        Assert.Equal(expectedReplyToProviderMessageID, model.ReplyToProviderMessageID);
        Assert.Equal(expectedReplyToText, model.ReplyToText);
        Assert.NotNull(model.Sections);
        Assert.Equal(expectedSections.Count, model.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], model.Sections[i]);
        }
        Assert.NotNull(model.TemplateButtonVariables);
        Assert.Equal(expectedTemplateButtonVariables.Count, model.TemplateButtonVariables.Count);
        foreach (var item in expectedTemplateButtonVariables)
        {
            Assert.True(model.TemplateButtonVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateButtonVariables[item.Key]);
        }
        Assert.NotNull(model.TemplateHeaderVariables);
        Assert.Equal(expectedTemplateHeaderVariables.Count, model.TemplateHeaderVariables.Count);
        foreach (var item in expectedTemplateHeaderVariables)
        {
            Assert.True(model.TemplateHeaderVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateHeaderVariables[item.Key]);
        }
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.NotNull(model.TemplateVariables);
        Assert.Equal(expectedTemplateVariables.Count, model.TemplateVariables.Count);
        foreach (var item in expectedTemplateVariables)
        {
            Assert.True(model.TemplateVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateVariables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageContent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageContent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Button> expectedButtons = [new() { ID = "id", Title = "title" }];
        List<Contact> expectedContacts = [new() { Name = "name", Phones = ["string"] }];
        string expectedCtaDisplayText = "See Dates";
        string expectedCtaHeaderMediaUrl = "https://example.com";
        string expectedCtaHeaderText = "ctaHeaderText";
        ApiEnum<string, CtaHeaderType> expectedCtaHeaderType = CtaHeaderType.Text;
        string expectedCtaUrl = "https://example.com/schedule";
        string expectedEmoji = "emoji";
        string expectedFilename = "invoice.pdf";
        string expectedFooterText = "Dates subject to change.";
        double expectedLatitude = 0;
        string expectedListButton = "listButton";
        string expectedLocationAddress = "locationAddress";
        string expectedLocationName = "locationName";
        double expectedLongitude = 0;
        string expectedMediaID = "mediaId";
        string expectedMediaUrl = "https://example.com/image.jpg";
        string expectedMimeType = "image/jpeg";
        string expectedReactToMessageID = "reactToMessageId";
        string expectedReplyToFrom = "replyToFrom";
        string expectedReplyToMessageID = "replyToMessageId";
        string expectedReplyToMessageType = "replyToMessageType";
        string expectedReplyToProviderMessageID = "replyToProviderMessageId";
        string expectedReplyToText = "replyToText";
        List<Section> expectedSections =
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
        ];
        Dictionary<string, string> expectedTemplateButtonVariables = new()
        {
            { "0", "abc-report-token" },
        };
        Dictionary<string, string> expectedTemplateHeaderVariables = new()
        {
            { "1", "Jorge y Laura" },
        };
        string expectedTemplateID = "templateId";
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "1", "John" },
            { "2", "ORD-12345" },
        };

        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.NotNull(deserialized.Contacts);
        Assert.Equal(expectedContacts.Count, deserialized.Contacts.Count);
        for (int i = 0; i < expectedContacts.Count; i++)
        {
            Assert.Equal(expectedContacts[i], deserialized.Contacts[i]);
        }
        Assert.Equal(expectedCtaDisplayText, deserialized.CtaDisplayText);
        Assert.Equal(expectedCtaHeaderMediaUrl, deserialized.CtaHeaderMediaUrl);
        Assert.Equal(expectedCtaHeaderText, deserialized.CtaHeaderText);
        Assert.Equal(expectedCtaHeaderType, deserialized.CtaHeaderType);
        Assert.Equal(expectedCtaUrl, deserialized.CtaUrl);
        Assert.Equal(expectedEmoji, deserialized.Emoji);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedFooterText, deserialized.FooterText);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedListButton, deserialized.ListButton);
        Assert.Equal(expectedLocationAddress, deserialized.LocationAddress);
        Assert.Equal(expectedLocationName, deserialized.LocationName);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedMediaID, deserialized.MediaID);
        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedReactToMessageID, deserialized.ReactToMessageID);
        Assert.Equal(expectedReplyToFrom, deserialized.ReplyToFrom);
        Assert.Equal(expectedReplyToMessageID, deserialized.ReplyToMessageID);
        Assert.Equal(expectedReplyToMessageType, deserialized.ReplyToMessageType);
        Assert.Equal(expectedReplyToProviderMessageID, deserialized.ReplyToProviderMessageID);
        Assert.Equal(expectedReplyToText, deserialized.ReplyToText);
        Assert.NotNull(deserialized.Sections);
        Assert.Equal(expectedSections.Count, deserialized.Sections.Count);
        for (int i = 0; i < expectedSections.Count; i++)
        {
            Assert.Equal(expectedSections[i], deserialized.Sections[i]);
        }
        Assert.NotNull(deserialized.TemplateButtonVariables);
        Assert.Equal(
            expectedTemplateButtonVariables.Count,
            deserialized.TemplateButtonVariables.Count
        );
        foreach (var item in expectedTemplateButtonVariables)
        {
            Assert.True(deserialized.TemplateButtonVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateButtonVariables[item.Key]);
        }
        Assert.NotNull(deserialized.TemplateHeaderVariables);
        Assert.Equal(
            expectedTemplateHeaderVariables.Count,
            deserialized.TemplateHeaderVariables.Count
        );
        foreach (var item in expectedTemplateHeaderVariables)
        {
            Assert.True(deserialized.TemplateHeaderVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateHeaderVariables[item.Key]);
        }
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.NotNull(deserialized.TemplateVariables);
        Assert.Equal(expectedTemplateVariables.Count, deserialized.TemplateVariables.Count);
        foreach (var item in expectedTemplateVariables)
        {
            Assert.True(deserialized.TemplateVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateVariables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageContent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageContent { };

        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Contacts);
        Assert.False(model.RawData.ContainsKey("contacts"));
        Assert.Null(model.CtaDisplayText);
        Assert.False(model.RawData.ContainsKey("ctaDisplayText"));
        Assert.Null(model.CtaHeaderMediaUrl);
        Assert.False(model.RawData.ContainsKey("ctaHeaderMediaUrl"));
        Assert.Null(model.CtaHeaderText);
        Assert.False(model.RawData.ContainsKey("ctaHeaderText"));
        Assert.Null(model.CtaHeaderType);
        Assert.False(model.RawData.ContainsKey("ctaHeaderType"));
        Assert.Null(model.CtaUrl);
        Assert.False(model.RawData.ContainsKey("ctaUrl"));
        Assert.Null(model.Emoji);
        Assert.False(model.RawData.ContainsKey("emoji"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.FooterText);
        Assert.False(model.RawData.ContainsKey("footerText"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.ListButton);
        Assert.False(model.RawData.ContainsKey("listButton"));
        Assert.Null(model.LocationAddress);
        Assert.False(model.RawData.ContainsKey("locationAddress"));
        Assert.Null(model.LocationName);
        Assert.False(model.RawData.ContainsKey("locationName"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.ReactToMessageID);
        Assert.False(model.RawData.ContainsKey("reactToMessageId"));
        Assert.Null(model.ReplyToFrom);
        Assert.False(model.RawData.ContainsKey("replyToFrom"));
        Assert.Null(model.ReplyToMessageID);
        Assert.False(model.RawData.ContainsKey("replyToMessageId"));
        Assert.Null(model.ReplyToMessageType);
        Assert.False(model.RawData.ContainsKey("replyToMessageType"));
        Assert.Null(model.ReplyToProviderMessageID);
        Assert.False(model.RawData.ContainsKey("replyToProviderMessageId"));
        Assert.Null(model.ReplyToText);
        Assert.False(model.RawData.ContainsKey("replyToText"));
        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageContent
        {
            // Null should be interpreted as omitted for these properties
            Buttons = null,
            Contacts = null,
            CtaDisplayText = null,
            CtaHeaderMediaUrl = null,
            CtaHeaderText = null,
            CtaHeaderType = null,
            CtaUrl = null,
            Emoji = null,
            Filename = null,
            FooterText = null,
            Latitude = null,
            ListButton = null,
            LocationAddress = null,
            LocationName = null,
            Longitude = null,
            MediaID = null,
            MediaUrl = null,
            MimeType = null,
            ReactToMessageID = null,
            ReplyToFrom = null,
            ReplyToMessageID = null,
            ReplyToMessageType = null,
            ReplyToProviderMessageID = null,
            ReplyToText = null,
            Sections = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateID = null,
            TemplateVariables = null,
        };

        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.Contacts);
        Assert.False(model.RawData.ContainsKey("contacts"));
        Assert.Null(model.CtaDisplayText);
        Assert.False(model.RawData.ContainsKey("ctaDisplayText"));
        Assert.Null(model.CtaHeaderMediaUrl);
        Assert.False(model.RawData.ContainsKey("ctaHeaderMediaUrl"));
        Assert.Null(model.CtaHeaderText);
        Assert.False(model.RawData.ContainsKey("ctaHeaderText"));
        Assert.Null(model.CtaHeaderType);
        Assert.False(model.RawData.ContainsKey("ctaHeaderType"));
        Assert.Null(model.CtaUrl);
        Assert.False(model.RawData.ContainsKey("ctaUrl"));
        Assert.Null(model.Emoji);
        Assert.False(model.RawData.ContainsKey("emoji"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.FooterText);
        Assert.False(model.RawData.ContainsKey("footerText"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.ListButton);
        Assert.False(model.RawData.ContainsKey("listButton"));
        Assert.Null(model.LocationAddress);
        Assert.False(model.RawData.ContainsKey("locationAddress"));
        Assert.Null(model.LocationName);
        Assert.False(model.RawData.ContainsKey("locationName"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.ReactToMessageID);
        Assert.False(model.RawData.ContainsKey("reactToMessageId"));
        Assert.Null(model.ReplyToFrom);
        Assert.False(model.RawData.ContainsKey("replyToFrom"));
        Assert.Null(model.ReplyToMessageID);
        Assert.False(model.RawData.ContainsKey("replyToMessageId"));
        Assert.Null(model.ReplyToMessageType);
        Assert.False(model.RawData.ContainsKey("replyToMessageType"));
        Assert.Null(model.ReplyToProviderMessageID);
        Assert.False(model.RawData.ContainsKey("replyToProviderMessageId"));
        Assert.Null(model.ReplyToText);
        Assert.False(model.RawData.ContainsKey("replyToText"));
        Assert.Null(model.Sections);
        Assert.False(model.RawData.ContainsKey("sections"));
        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageContent
        {
            // Null should be interpreted as omitted for these properties
            Buttons = null,
            Contacts = null,
            CtaDisplayText = null,
            CtaHeaderMediaUrl = null,
            CtaHeaderText = null,
            CtaHeaderType = null,
            CtaUrl = null,
            Emoji = null,
            Filename = null,
            FooterText = null,
            Latitude = null,
            ListButton = null,
            LocationAddress = null,
            LocationName = null,
            Longitude = null,
            MediaID = null,
            MediaUrl = null,
            MimeType = null,
            ReactToMessageID = null,
            ReplyToFrom = null,
            ReplyToMessageID = null,
            ReplyToMessageType = null,
            ReplyToProviderMessageID = null,
            ReplyToText = null,
            Sections = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateID = null,
            TemplateVariables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageContent
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

        MessageContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Button { ID = "id", Title = "title" };

        string expectedID = "id";
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Button { ID = "id", Title = "title" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Button>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Button { ID = "id", Title = "title" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Button>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Button { ID = "id", Title = "title" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Button { ID = "id", Title = "title" };

        Button copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contact { Name = "name", Phones = ["string"] };

        string expectedName = "name";
        List<string> expectedPhones = ["string"];

        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Phones);
        Assert.Equal(expectedPhones.Count, model.Phones.Count);
        for (int i = 0; i < expectedPhones.Count; i++)
        {
            Assert.Equal(expectedPhones[i], model.Phones[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contact { Name = "name", Phones = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contact { Name = "name", Phones = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        List<string> expectedPhones = ["string"];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Phones);
        Assert.Equal(expectedPhones.Count, deserialized.Phones.Count);
        for (int i = 0; i < expectedPhones.Count; i++)
        {
            Assert.Equal(expectedPhones[i], deserialized.Phones[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contact { Name = "name", Phones = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phones);
        Assert.False(model.RawData.ContainsKey("phones"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contact
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Phones = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phones);
        Assert.False(model.RawData.ContainsKey("phones"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Phones = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contact { Name = "name", Phones = ["string"] };

        Contact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CtaHeaderTypeTest : TestBase
{
    [Theory]
    [InlineData(CtaHeaderType.Text)]
    [InlineData(CtaHeaderType.Image)]
    [InlineData(CtaHeaderType.Video)]
    [InlineData(CtaHeaderType.Document)]
    public void Validation_Works(CtaHeaderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CtaHeaderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CtaHeaderType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CtaHeaderType.Text)]
    [InlineData(CtaHeaderType.Image)]
    [InlineData(CtaHeaderType.Video)]
    [InlineData(CtaHeaderType.Document)]
    public void SerializationRoundtrip_Works(CtaHeaderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CtaHeaderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CtaHeaderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CtaHeaderType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CtaHeaderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Section
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
        };

        List<Row> expectedRows =
        [
            new()
            {
                ID = "id",
                Title = "title",
                Description = "description",
            },
        ];
        string expectedTitle = "title";

        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], model.Rows[i]);
        }
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Section
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Section>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Section
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Section>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Row> expectedRows =
        [
            new()
            {
                ID = "id",
                Title = "title",
                Description = "description",
            },
        ];
        string expectedTitle = "title";

        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i], deserialized.Rows[i]);
        }
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Section
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Section
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
        };

        Section copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RowTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",
            Description = "description",
        };

        string expectedID = "id";
        string expectedTitle = "title";
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedTitle = "title";
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Row { ID = "id", Title = "title" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Row { ID = "id", Title = "title" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Row
        {
            ID = "id",
            Title = "title",
            Description = "description",
        };

        Row copied = new(model);

        Assert.Equal(model, copied);
    }
}
