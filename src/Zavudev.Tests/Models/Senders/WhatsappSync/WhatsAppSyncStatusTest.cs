using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsAppSyncStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsAppSyncStatus
        {
            Contacts = new()
            {
                CanSync = true,
                Status = Status.NotRequested,
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            History = new()
            {
                CanSync = true,
                Status = WhatsAppSyncHistoryStatus.NotRequested,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            IsCoexistence = true,
            Status = WhatsAppSyncStatusStatus.PendingVerification,
        };

        WhatsAppSyncContacts expectedContacts = new()
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        WhatsAppSyncHistory expectedHistory = new()
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        bool expectedIsCoexistence = true;
        ApiEnum<string, WhatsAppSyncStatusStatus> expectedStatus =
            WhatsAppSyncStatusStatus.PendingVerification;

        Assert.Equal(expectedContacts, model.Contacts);
        Assert.Equal(expectedHistory, model.History);
        Assert.Equal(expectedIsCoexistence, model.IsCoexistence);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsAppSyncStatus
        {
            Contacts = new()
            {
                CanSync = true,
                Status = Status.NotRequested,
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            History = new()
            {
                CanSync = true,
                Status = WhatsAppSyncHistoryStatus.NotRequested,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            IsCoexistence = true,
            Status = WhatsAppSyncStatusStatus.PendingVerification,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsAppSyncStatus
        {
            Contacts = new()
            {
                CanSync = true,
                Status = Status.NotRequested,
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            History = new()
            {
                CanSync = true,
                Status = WhatsAppSyncHistoryStatus.NotRequested,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            IsCoexistence = true,
            Status = WhatsAppSyncStatusStatus.PendingVerification,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WhatsAppSyncContacts expectedContacts = new()
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        WhatsAppSyncHistory expectedHistory = new()
        {
            CanSync = true,
            Status = WhatsAppSyncHistoryStatus.NotRequested,
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        bool expectedIsCoexistence = true;
        ApiEnum<string, WhatsAppSyncStatusStatus> expectedStatus =
            WhatsAppSyncStatusStatus.PendingVerification;

        Assert.Equal(expectedContacts, deserialized.Contacts);
        Assert.Equal(expectedHistory, deserialized.History);
        Assert.Equal(expectedIsCoexistence, deserialized.IsCoexistence);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsAppSyncStatus
        {
            Contacts = new()
            {
                CanSync = true,
                Status = Status.NotRequested,
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            History = new()
            {
                CanSync = true,
                Status = WhatsAppSyncHistoryStatus.NotRequested,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            IsCoexistence = true,
            Status = WhatsAppSyncStatusStatus.PendingVerification,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsAppSyncStatus
        {
            Contacts = new()
            {
                CanSync = true,
                Status = Status.NotRequested,
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            History = new()
            {
                CanSync = true,
                Status = WhatsAppSyncHistoryStatus.NotRequested,
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            IsCoexistence = true,
            Status = WhatsAppSyncStatusStatus.PendingVerification,
        };

        WhatsAppSyncStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WhatsAppSyncStatusStatusTest : TestBase
{
    [Theory]
    [InlineData(WhatsAppSyncStatusStatus.PendingVerification)]
    [InlineData(WhatsAppSyncStatusStatus.PendingRegistration)]
    [InlineData(WhatsAppSyncStatusStatus.Active)]
    [InlineData(WhatsAppSyncStatusStatus.Disconnected)]
    [InlineData(WhatsAppSyncStatusStatus.Error)]
    public void Validation_Works(WhatsAppSyncStatusStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsAppSyncStatusStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncStatusStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WhatsAppSyncStatusStatus.PendingVerification)]
    [InlineData(WhatsAppSyncStatusStatus.PendingRegistration)]
    [InlineData(WhatsAppSyncStatusStatus.Active)]
    [InlineData(WhatsAppSyncStatusStatus.Disconnected)]
    [InlineData(WhatsAppSyncStatusStatus.Error)]
    public void SerializationRoundtrip_Works(WhatsAppSyncStatusStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WhatsAppSyncStatusStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncStatusStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncStatusStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WhatsAppSyncStatusStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
