using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Broadcast
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

        string expectedID = "brd_abc123";
        ApiEnum<string, BroadcastChannel> expectedChannel = BroadcastChannel.Smart;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BroadcastMessageType> expectedMessageType = BroadcastMessageType.Text;
        string expectedName = "name";
        ApiEnum<string, BroadcastStatus> expectedStatus = BroadcastStatus.Draft;
        long expectedTotalContacts = 0;
        double expectedActualCost = 0;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        long expectedDeliveredCount = 0;
        string expectedEmailSubject = "emailSubject";
        double expectedEstimatedCost = 0;
        long expectedFailedCount = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        long expectedPendingCount = 0;
        double expectedReservedAmount = 0;
        long expectedReviewAttempts = 0;
        ReviewResult expectedReviewResult = new()
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";
        long expectedSendingCount = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedText = "text";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMessageType, model.MessageType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotalContacts, model.TotalContacts);
        Assert.Equal(expectedActualCost, model.ActualCost);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedDeliveredCount, model.DeliveredCount);
        Assert.Equal(expectedEmailSubject, model.EmailSubject);
        Assert.Equal(expectedEstimatedCost, model.EstimatedCost);
        Assert.Equal(expectedFailedCount, model.FailedCount);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPendingCount, model.PendingCount);
        Assert.Equal(expectedReservedAmount, model.ReservedAmount);
        Assert.Equal(expectedReviewAttempts, model.ReviewAttempts);
        Assert.Equal(expectedReviewResult, model.ReviewResult);
        Assert.Equal(expectedScheduledAt, model.ScheduledAt);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedSendingCount, model.SendingCount);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Broadcast
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Broadcast>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Broadcast
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Broadcast>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "brd_abc123";
        ApiEnum<string, BroadcastChannel> expectedChannel = BroadcastChannel.Smart;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BroadcastMessageType> expectedMessageType = BroadcastMessageType.Text;
        string expectedName = "name";
        ApiEnum<string, BroadcastStatus> expectedStatus = BroadcastStatus.Draft;
        long expectedTotalContacts = 0;
        double expectedActualCost = 0;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        long expectedDeliveredCount = 0;
        string expectedEmailSubject = "emailSubject";
        double expectedEstimatedCost = 0;
        long expectedFailedCount = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        long expectedPendingCount = 0;
        double expectedReservedAmount = 0;
        long expectedReviewAttempts = 0;
        ReviewResult expectedReviewResult = new()
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };
        DateTimeOffset expectedScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";
        long expectedSendingCount = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedText = "text";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMessageType, deserialized.MessageType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotalContacts, deserialized.TotalContacts);
        Assert.Equal(expectedActualCost, deserialized.ActualCost);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedDeliveredCount, deserialized.DeliveredCount);
        Assert.Equal(expectedEmailSubject, deserialized.EmailSubject);
        Assert.Equal(expectedEstimatedCost, deserialized.EstimatedCost);
        Assert.Equal(expectedFailedCount, deserialized.FailedCount);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPendingCount, deserialized.PendingCount);
        Assert.Equal(expectedReservedAmount, deserialized.ReservedAmount);
        Assert.Equal(expectedReviewAttempts, deserialized.ReviewAttempts);
        Assert.Equal(expectedReviewResult, deserialized.ReviewResult);
        Assert.Equal(expectedScheduledAt, deserialized.ScheduledAt);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedSendingCount, deserialized.SendingCount);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Broadcast
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
            ActualCost = 0,
            EstimatedCost = 0,
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
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.DeliveredCount);
        Assert.False(model.RawData.ContainsKey("deliveredCount"));
        Assert.Null(model.EmailSubject);
        Assert.False(model.RawData.ContainsKey("emailSubject"));
        Assert.Null(model.FailedCount);
        Assert.False(model.RawData.ContainsKey("failedCount"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PendingCount);
        Assert.False(model.RawData.ContainsKey("pendingCount"));
        Assert.Null(model.ScheduledAt);
        Assert.False(model.RawData.ContainsKey("scheduledAt"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.SendingCount);
        Assert.False(model.RawData.ContainsKey("sendingCount"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
            ActualCost = 0,
            EstimatedCost = 0,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
            ActualCost = 0,
            EstimatedCost = 0,
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

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
            Content = null,
            DeliveredCount = null,
            EmailSubject = null,
            FailedCount = null,
            Metadata = null,
            PendingCount = null,
            ScheduledAt = null,
            SenderID = null,
            SendingCount = null,
            StartedAt = null,
            Text = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.DeliveredCount);
        Assert.False(model.RawData.ContainsKey("deliveredCount"));
        Assert.Null(model.EmailSubject);
        Assert.False(model.RawData.ContainsKey("emailSubject"));
        Assert.Null(model.FailedCount);
        Assert.False(model.RawData.ContainsKey("failedCount"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PendingCount);
        Assert.False(model.RawData.ContainsKey("pendingCount"));
        Assert.Null(model.ScheduledAt);
        Assert.False(model.RawData.ContainsKey("scheduledAt"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.SendingCount);
        Assert.False(model.RawData.ContainsKey("sendingCount"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
            ActualCost = 0,
            EstimatedCost = 0,
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

            // Null should be interpreted as omitted for these properties
            CompletedAt = null,
            Content = null,
            DeliveredCount = null,
            EmailSubject = null,
            FailedCount = null,
            Metadata = null,
            PendingCount = null,
            ScheduledAt = null,
            SenderID = null,
            SendingCount = null,
            StartedAt = null,
            Text = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
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
            FailedCount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PendingCount = 0,
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            SendingCount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActualCost);
        Assert.False(model.RawData.ContainsKey("actualCost"));
        Assert.Null(model.EstimatedCost);
        Assert.False(model.RawData.ContainsKey("estimatedCost"));
        Assert.Null(model.ReservedAmount);
        Assert.False(model.RawData.ContainsKey("reservedAmount"));
        Assert.Null(model.ReviewAttempts);
        Assert.False(model.RawData.ContainsKey("reviewAttempts"));
        Assert.Null(model.ReviewResult);
        Assert.False(model.RawData.ContainsKey("reviewResult"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
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
            FailedCount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PendingCount = 0,
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            SendingCount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
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
            FailedCount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PendingCount = 0,
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            SendingCount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActualCost = null,
            EstimatedCost = null,
            ReservedAmount = null,
            ReviewAttempts = null,
            ReviewResult = null,
        };

        Assert.Null(model.ActualCost);
        Assert.True(model.RawData.ContainsKey("actualCost"));
        Assert.Null(model.EstimatedCost);
        Assert.True(model.RawData.ContainsKey("estimatedCost"));
        Assert.Null(model.ReservedAmount);
        Assert.True(model.RawData.ContainsKey("reservedAmount"));
        Assert.Null(model.ReviewAttempts);
        Assert.True(model.RawData.ContainsKey("reviewAttempts"));
        Assert.Null(model.ReviewResult);
        Assert.True(model.RawData.ContainsKey("reviewResult"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Broadcast
        {
            ID = "brd_abc123",
            Channel = BroadcastChannel.Smart,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MessageType = BroadcastMessageType.Text,
            Name = "name",
            Status = BroadcastStatus.Draft,
            TotalContacts = 0,
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
            FailedCount = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PendingCount = 0,
            ScheduledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            SendingCount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Text = "text",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActualCost = null,
            EstimatedCost = null,
            ReservedAmount = null,
            ReviewAttempts = null,
            ReviewResult = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Broadcast
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

        Broadcast copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReviewResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        List<string> expectedCategories = ["string"];
        List<string> expectedFlaggedContent = ["string"];
        string expectedReasoning = "reasoning";
        DateTimeOffset expectedReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedScore = 0;

        Assert.NotNull(model.Categories);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.NotNull(model.FlaggedContent);
        Assert.Equal(expectedFlaggedContent.Count, model.FlaggedContent.Count);
        for (int i = 0; i < expectedFlaggedContent.Count; i++)
        {
            Assert.Equal(expectedFlaggedContent[i], model.FlaggedContent[i]);
        }
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.Equal(expectedReviewedAt, model.ReviewedAt);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCategories = ["string"];
        List<string> expectedFlaggedContent = ["string"];
        string expectedReasoning = "reasoning";
        DateTimeOffset expectedReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedScore = 0;

        Assert.NotNull(deserialized.Categories);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.NotNull(deserialized.FlaggedContent);
        Assert.Equal(expectedFlaggedContent.Count, deserialized.FlaggedContent.Count);
        for (int i = 0; i < expectedFlaggedContent.Count; i++)
        {
            Assert.Equal(expectedFlaggedContent[i], deserialized.FlaggedContent[i]);
        }
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.Equal(expectedReviewedAt, deserialized.ReviewedAt);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReviewResult { FlaggedContent = ["string"] };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.ReviewedAt);
        Assert.False(model.RawData.ContainsKey("reviewedAt"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReviewResult { FlaggedContent = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReviewResult
        {
            FlaggedContent = ["string"],

            // Null should be interpreted as omitted for these properties
            Categories = null,
            Reasoning = null,
            ReviewedAt = null,
            Score = null,
        };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.ReviewedAt);
        Assert.False(model.RawData.ContainsKey("reviewedAt"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReviewResult
        {
            FlaggedContent = ["string"],

            // Null should be interpreted as omitted for these properties
            Categories = null,
            Reasoning = null,
            ReviewedAt = null,
            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        Assert.Null(model.FlaggedContent);
        Assert.False(model.RawData.ContainsKey("flaggedContent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,

            FlaggedContent = null,
        };

        Assert.Null(model.FlaggedContent);
        Assert.True(model.RawData.ContainsKey("flaggedContent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,

            FlaggedContent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReviewResult
        {
            Categories = ["string"],
            FlaggedContent = ["string"],
            Reasoning = "reasoning",
            ReviewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Score = 0,
        };

        ReviewResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
