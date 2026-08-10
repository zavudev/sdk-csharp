using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Tests.Models.Senders.WhatsappSync;

public class WhatsAppSyncContactsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedCanSync = true;
        ApiEnum<string, Status> expectedStatus = Status.NotRequested;
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanSync, model.CanSync);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedRequestedAt, model.RequestedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncContacts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WhatsAppSyncContacts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanSync = true;
        ApiEnum<string, Status> expectedStatus = Status.NotRequested;
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCanSync, deserialized.CanSync);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedRequestedAt, deserialized.RequestedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WhatsAppSyncContacts { CanSync = true, Status = Status.NotRequested };

        Assert.Null(model.RequestedAt);
        Assert.False(model.RawData.ContainsKey("requestedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WhatsAppSyncContacts { CanSync = true, Status = Status.NotRequested };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,

            RequestedAt = null,
        };

        Assert.Null(model.RequestedAt);
        Assert.True(model.RawData.ContainsKey("requestedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,

            RequestedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WhatsAppSyncContacts
        {
            CanSync = true,
            Status = Status.NotRequested,
            RequestedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        WhatsAppSyncContacts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.NotRequested)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Syncing)]
    [InlineData(Status.Completed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.NotRequested)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Syncing)]
    [InlineData(Status.Completed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
