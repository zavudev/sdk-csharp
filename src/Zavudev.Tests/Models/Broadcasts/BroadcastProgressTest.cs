using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastProgressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EstimatedCost = 0,
            ReservedAmount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBroadcastID = "broadcastId";
        long expectedDelivered = 0;
        long expectedFailed = 0;
        long expectedPending = 0;
        double expectedPercentComplete = 0;
        long expectedSending = 0;
        long expectedSkipped = 0;
        ApiEnum<string, BroadcastStatus> expectedStatus = BroadcastStatus.Draft;
        long expectedTotal = 0;
        double expectedActualCost = 0;
        DateTimeOffset expectedEstimatedCompletionAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        double expectedEstimatedCost = 0;
        double expectedReservedAmount = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBroadcastID, model.BroadcastID);
        Assert.Equal(expectedDelivered, model.Delivered);
        Assert.Equal(expectedFailed, model.Failed);
        Assert.Equal(expectedPending, model.Pending);
        Assert.Equal(expectedPercentComplete, model.PercentComplete);
        Assert.Equal(expectedSending, model.Sending);
        Assert.Equal(expectedSkipped, model.Skipped);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedActualCost, model.ActualCost);
        Assert.Equal(expectedEstimatedCompletionAt, model.EstimatedCompletionAt);
        Assert.Equal(expectedEstimatedCost, model.EstimatedCost);
        Assert.Equal(expectedReservedAmount, model.ReservedAmount);
        Assert.Equal(expectedStartedAt, model.StartedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EstimatedCost = 0,
            ReservedAmount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastProgress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EstimatedCost = 0,
            ReservedAmount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastProgress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBroadcastID = "broadcastId";
        long expectedDelivered = 0;
        long expectedFailed = 0;
        long expectedPending = 0;
        double expectedPercentComplete = 0;
        long expectedSending = 0;
        long expectedSkipped = 0;
        ApiEnum<string, BroadcastStatus> expectedStatus = BroadcastStatus.Draft;
        long expectedTotal = 0;
        double expectedActualCost = 0;
        DateTimeOffset expectedEstimatedCompletionAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        double expectedEstimatedCost = 0;
        double expectedReservedAmount = 0;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBroadcastID, deserialized.BroadcastID);
        Assert.Equal(expectedDelivered, deserialized.Delivered);
        Assert.Equal(expectedFailed, deserialized.Failed);
        Assert.Equal(expectedPending, deserialized.Pending);
        Assert.Equal(expectedPercentComplete, deserialized.PercentComplete);
        Assert.Equal(expectedSending, deserialized.Sending);
        Assert.Equal(expectedSkipped, deserialized.Skipped);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedActualCost, deserialized.ActualCost);
        Assert.Equal(expectedEstimatedCompletionAt, deserialized.EstimatedCompletionAt);
        Assert.Equal(expectedEstimatedCost, deserialized.EstimatedCost);
        Assert.Equal(expectedReservedAmount, deserialized.ReservedAmount);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EstimatedCost = 0,
            ReservedAmount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCost = 0,
            ReservedAmount = 0,
        };

        Assert.Null(model.EstimatedCompletionAt);
        Assert.False(model.RawData.ContainsKey("estimatedCompletionAt"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCost = 0,
            ReservedAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCost = 0,
            ReservedAmount = 0,

            // Null should be interpreted as omitted for these properties
            EstimatedCompletionAt = null,
            StartedAt = null,
        };

        Assert.Null(model.EstimatedCompletionAt);
        Assert.False(model.RawData.ContainsKey("estimatedCompletionAt"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCost = 0,
            ReservedAmount = 0,

            // Null should be interpreted as omitted for these properties
            EstimatedCompletionAt = null,
            StartedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ActualCost);
        Assert.False(model.RawData.ContainsKey("actualCost"));
        Assert.Null(model.EstimatedCost);
        Assert.False(model.RawData.ContainsKey("estimatedCost"));
        Assert.Null(model.ReservedAmount);
        Assert.False(model.RawData.ContainsKey("reservedAmount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActualCost = null,
            EstimatedCost = null,
            ReservedAmount = null,
        };

        Assert.Null(model.ActualCost);
        Assert.True(model.RawData.ContainsKey("actualCost"));
        Assert.Null(model.EstimatedCost);
        Assert.True(model.RawData.ContainsKey("estimatedCost"));
        Assert.Null(model.ReservedAmount);
        Assert.True(model.RawData.ContainsKey("reservedAmount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ActualCost = null,
            EstimatedCost = null,
            ReservedAmount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastProgress
        {
            BroadcastID = "broadcastId",
            Delivered = 0,
            Failed = 0,
            Pending = 0,
            PercentComplete = 0,
            Sending = 0,
            Skipped = 0,
            Status = BroadcastStatus.Draft,
            Total = 0,
            ActualCost = 0,
            EstimatedCompletionAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EstimatedCost = 0,
            ReservedAmount = 0,
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BroadcastProgress copied = new(model);

        Assert.Equal(model, copied);
    }
}
