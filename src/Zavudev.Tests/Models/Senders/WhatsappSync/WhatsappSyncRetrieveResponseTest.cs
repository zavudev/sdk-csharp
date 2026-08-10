using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsappSyncRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsappSyncRetrieveResponse
        {
            Sync = new()
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
            },
        };

        WhatsAppSyncStatus expectedSync = new()
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

        Assert.Equal(expectedSync, model.Sync);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsappSyncRetrieveResponse
        {
            Sync = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappSyncRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsappSyncRetrieveResponse
        {
            Sync = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsappSyncRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WhatsAppSyncStatus expectedSync = new()
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

        Assert.Equal(expectedSync, deserialized.Sync);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsappSyncRetrieveResponse
        {
            Sync = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsappSyncRetrieveResponse
        {
            Sync = new()
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
            },
        };

        WhatsappSyncRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
