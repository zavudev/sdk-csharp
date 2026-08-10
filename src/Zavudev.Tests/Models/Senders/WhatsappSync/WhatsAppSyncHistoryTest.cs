using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsAppSyncHistoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedCanSync = true;
        ApiEnum<string, WhatsAppSyncHistoryStatus> expectedStatus =
            WhatsAppSyncHistoryStatus.NotRequested;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanSync, model.CanSync);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedRequestedAt, model.RequestedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncHistory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncHistory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanSync = true;
        ApiEnum<string, WhatsAppSyncHistoryStatus> expectedStatus =
            WhatsAppSyncHistoryStatus.NotRequested;
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanSync, deserialized.CanSync);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedRequestedAt, deserialized.RequestedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
        };

        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.RequestedAt);
        Assert.False(model.RawData.ContainsKey("requestedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,

            CompletedAt = null,
            RequestedAt = null,
        };

        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.RequestedAt);
        Assert.True(model.RawData.ContainsKey("requestedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,

            CompletedAt = null,
            RequestedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsAppSyncHistory
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        WhatsAppSyncHistory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsAppSyncHistoryStatusTest : TestBase
{
    [Theory]
    [InlineData(WhatsAppSyncHistoryStatus.NotRequested)]
    [InlineData(WhatsAppSyncHistoryStatus.Pending)]
    [InlineData(WhatsAppSyncHistoryStatus.Syncing)]
    [InlineData(WhatsAppSyncHistoryStatus.Completed)]
    [InlineData(WhatsAppSyncHistoryStatus.Rejected)]
    public void Validation_Works(WhatsAppSyncHistoryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsAppSyncHistoryStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncHistoryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WhatsAppSyncHistoryStatus.NotRequested)]
    [InlineData(WhatsAppSyncHistoryStatus.Pending)]
    [InlineData(WhatsAppSyncHistoryStatus.Syncing)]
    [InlineData(WhatsAppSyncHistoryStatus.Completed)]
    [InlineData(WhatsAppSyncHistoryStatus.Rejected)]
    public void SerializationRoundtrip_Works(WhatsAppSyncHistoryStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsAppSyncHistoryStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncHistoryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncHistoryStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncHistoryStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
