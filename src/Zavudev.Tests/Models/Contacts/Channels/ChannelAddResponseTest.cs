using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Contacts;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Tests.Models.Contacts.Channels;

public class ChannelAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelAddResponse
        {
            Channel = new()
            {
                ID = "id",
                Channel = ContactChannelChannel.Sms,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Identifier = "+14155551234",
                IsPrimary = true,
                Verified = true,
                CountryCode = "US",
                Label = "work",
                LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Metrics = new()
                {
                    AvgDeliveryTimeMs = 0,
                    FailureCount = 0,
                    LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SuccessCount = 0,
                    TotalAttempts = 0,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        ContactChannel expectedChannel = new()
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,
            CountryCode = "US",
            Label = "work",
            LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Metrics = new()
            {
                AvgDeliveryTimeMs = 0,
                FailureCount = 0,
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SuccessCount = 0,
                TotalAttempts = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedChannel, model.Channel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelAddResponse
        {
            Channel = new()
            {
                ID = "id",
                Channel = ContactChannelChannel.Sms,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Identifier = "+14155551234",
                IsPrimary = true,
                Verified = true,
                CountryCode = "US",
                Label = "work",
                LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Metrics = new()
                {
                    AvgDeliveryTimeMs = 0,
                    FailureCount = 0,
                    LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SuccessCount = 0,
                    TotalAttempts = 0,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelAddResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelAddResponse
        {
            Channel = new()
            {
                ID = "id",
                Channel = ContactChannelChannel.Sms,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Identifier = "+14155551234",
                IsPrimary = true,
                Verified = true,
                CountryCode = "US",
                Label = "work",
                LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Metrics = new()
                {
                    AvgDeliveryTimeMs = 0,
                    FailureCount = 0,
                    LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SuccessCount = 0,
                    TotalAttempts = 0,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelAddResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContactChannel expectedChannel = new()
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,
            CountryCode = "US",
            Label = "work",
            LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Metrics = new()
            {
                AvgDeliveryTimeMs = 0,
                FailureCount = 0,
                LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SuccessCount = 0,
                TotalAttempts = 0,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedChannel, deserialized.Channel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelAddResponse
        {
            Channel = new()
            {
                ID = "id",
                Channel = ContactChannelChannel.Sms,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Identifier = "+14155551234",
                IsPrimary = true,
                Verified = true,
                CountryCode = "US",
                Label = "work",
                LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Metrics = new()
                {
                    AvgDeliveryTimeMs = 0,
                    FailureCount = 0,
                    LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SuccessCount = 0,
                    TotalAttempts = 0,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChannelAddResponse
        {
            Channel = new()
            {
                ID = "id",
                Channel = ContactChannelChannel.Sms,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Identifier = "+14155551234",
                IsPrimary = true,
                Verified = true,
                CountryCode = "US",
                Label = "work",
                LastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Metrics = new()
                {
                    AvgDeliveryTimeMs = 0,
                    FailureCount = 0,
                    LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SuccessCount = 0,
                    TotalAttempts = 0,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        ChannelAddResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
