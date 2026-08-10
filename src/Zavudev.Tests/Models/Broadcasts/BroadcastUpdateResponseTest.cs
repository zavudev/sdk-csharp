using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastUpdateResponse
        {
            Broadcast = new()
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
        };

        Broadcast expectedBroadcast = new()
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
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
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
        };

        Assert.Equal(expectedBroadcast, model.Broadcast);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BroadcastUpdateResponse
        {
            Broadcast = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastUpdateResponse
        {
            Broadcast = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Broadcast expectedBroadcast = new()
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
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
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
        };

        Assert.Equal(expectedBroadcast, deserialized.Broadcast);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BroadcastUpdateResponse
        {
            Broadcast = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastUpdateResponse
        {
            Broadcast = new()
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
        };

        BroadcastUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
