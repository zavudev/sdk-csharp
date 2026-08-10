using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Broadcast> expectedItems =
        [
            new()
            {
                ID = "brd_abc123",
                Channel = BroadcastChannel.Smart,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MessageType = BroadcastMessageType.Text,
                Name = "name",
                Status = BroadcastStatus.Draft,
                TotalContacts = 0,
                ActualCost = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Content = new()
                {
                    Filename = "filename",
                    MediaID = "mediaId",
                    MediaUrl = "mediaUrl",
                    MimeType = "mimeType",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateID = "templateId",
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
                DeliveredCount = 0,
                EmailSubject = "emailSubject",
                EstimatedCost = 0,
                FailedCount = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PendingCount = 0,
                ReservedAmount = 0,
                ReviewAttempts = 0,
                ReviewResult = new()
                {
                    Categories = ["string"],
                    FlaggedContent = ["string"],
                    Reasoning = "reasoning",
                    ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Score = 0,
                },
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SenderID = "senderId",
                SendingCount = 0,
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Broadcast> expectedItems =
        [
            new()
            {
                ID = "brd_abc123",
                Channel = BroadcastChannel.Smart,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                MessageType = BroadcastMessageType.Text,
                Name = "name",
                Status = BroadcastStatus.Draft,
                TotalContacts = 0,
                ActualCost = 0,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Content = new()
                {
                    Filename = "filename",
                    MediaID = "mediaId",
                    MediaUrl = "mediaUrl",
                    MimeType = "mimeType",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateID = "templateId",
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
                DeliveredCount = 0,
                EmailSubject = "emailSubject",
                EstimatedCost = 0,
                FailedCount = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PendingCount = 0,
                ReservedAmount = 0,
                ReviewAttempts = 0,
                ReviewResult = new()
                {
                    Categories = ["string"],
                    FlaggedContent = ["string"],
                    Reasoning = "reasoning",
                    ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Score = 0,
                },
                ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SenderID = "senderId",
                SendingCount = 0,
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BroadcastListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "brd_abc123",
                    Channel = BroadcastChannel.Smart,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    MessageType = BroadcastMessageType.Text,
                    Name = "name",
                    Status = BroadcastStatus.Draft,
                    TotalContacts = 0,
                    ActualCost = 0,
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Content = new()
                    {
                        Filename = "filename",
                        MediaID = "mediaId",
                        MediaUrl = "mediaUrl",
                        MimeType = "mimeType",
                        TemplateButtonVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateHeaderVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                        TemplateID = "templateId",
                        TemplateVariables = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
                    },
                    DeliveredCount = 0,
                    EmailSubject = "emailSubject",
                    EstimatedCost = 0,
                    FailedCount = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PendingCount = 0,
                    ReservedAmount = 0,
                    ReviewAttempts = 0,
                    ReviewResult = new()
                    {
                        Categories = ["string"],
                        FlaggedContent = ["string"],
                        Reasoning = "reasoning",
                        ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Score = 0,
                    },
                    ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                    SendingCount = 0,
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Text = "text",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        BroadcastListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
