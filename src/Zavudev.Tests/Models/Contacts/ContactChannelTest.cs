using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactChannel
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

        string expectedID = "id";
        ApiEnum<string, ContactChannelChannel> expectedChannel = ContactChannelChannel.Sms;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdentifier = "+14155551234";
        bool expectedIsPrimary = true;
        bool expectedVerified = true;
        string expectedCountryCode = "US";
        string expectedLabel = "work";
        DateTimeOffset expectedLastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Metrics expectedMetrics = new()
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedIdentifier, model.Identifier);
        Assert.Equal(expectedIsPrimary, model.IsPrimary);
        Assert.Equal(expectedVerified, model.Verified);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedLastInboundAt, model.LastInboundAt);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMetrics, model.Metrics);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactChannel
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactChannel
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, ContactChannelChannel> expectedChannel = ContactChannelChannel.Sms;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedIdentifier = "+14155551234";
        bool expectedIsPrimary = true;
        bool expectedVerified = true;
        string expectedCountryCode = "US";
        string expectedLabel = "work";
        DateTimeOffset expectedLastInboundAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Metrics expectedMetrics = new()
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedIdentifier, deserialized.Identifier);
        Assert.Equal(expectedIsPrimary, deserialized.IsPrimary);
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedLastInboundAt, deserialized.LastInboundAt);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMetrics, deserialized.Metrics);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactChannel
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactChannel
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.LastInboundAt);
        Assert.False(model.RawData.ContainsKey("lastInboundAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactChannel
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactChannel
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Label = null,
            LastInboundAt = null,
            Metadata = null,
            Metrics = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.LastInboundAt);
        Assert.False(model.RawData.ContainsKey("lastInboundAt"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Metrics);
        Assert.False(model.RawData.ContainsKey("metrics"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactChannel
        {
            ID = "id",
            Channel = ContactChannelChannel.Sms,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Identifier = "+14155551234",
            IsPrimary = true,
            Verified = true,

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            Label = null,
            LastInboundAt = null,
            Metadata = null,
            Metrics = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactChannel
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

        ContactChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactChannelChannelTest : TestBase
{
    [Theory]
    [InlineData(ContactChannelChannel.Sms)]
    [InlineData(ContactChannelChannel.Whatsapp)]
    [InlineData(ContactChannelChannel.Email)]
    [InlineData(ContactChannelChannel.Telegram)]
    [InlineData(ContactChannelChannel.Instagram)]
    [InlineData(ContactChannelChannel.Messenger)]
    [InlineData(ContactChannelChannel.Voice)]
    public void Validation_Works(ContactChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContactChannelChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContactChannelChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContactChannelChannel.Sms)]
    [InlineData(ContactChannelChannel.Whatsapp)]
    [InlineData(ContactChannelChannel.Email)]
    [InlineData(ContactChannelChannel.Telegram)]
    [InlineData(ContactChannelChannel.Instagram)]
    [InlineData(ContactChannelChannel.Messenger)]
    [InlineData(ContactChannelChannel.Voice)]
    public void SerializationRoundtrip_Works(ContactChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContactChannelChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContactChannelChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContactChannelChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContactChannelChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metrics
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };

        double expectedAvgDeliveryTimeMs = 0;
        long expectedFailureCount = 0;
        DateTimeOffset expectedLastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedSuccessCount = 0;
        long expectedTotalAttempts = 0;

        Assert.Equal(expectedAvgDeliveryTimeMs, model.AvgDeliveryTimeMs);
        Assert.Equal(expectedFailureCount, model.FailureCount);
        Assert.Equal(expectedLastSuccessAt, model.LastSuccessAt);
        Assert.Equal(expectedSuccessCount, model.SuccessCount);
        Assert.Equal(expectedTotalAttempts, model.TotalAttempts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metrics
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metrics
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAvgDeliveryTimeMs = 0;
        long expectedFailureCount = 0;
        DateTimeOffset expectedLastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedSuccessCount = 0;
        long expectedTotalAttempts = 0;

        Assert.Equal(expectedAvgDeliveryTimeMs, deserialized.AvgDeliveryTimeMs);
        Assert.Equal(expectedFailureCount, deserialized.FailureCount);
        Assert.Equal(expectedLastSuccessAt, deserialized.LastSuccessAt);
        Assert.Equal(expectedSuccessCount, deserialized.SuccessCount);
        Assert.Equal(expectedTotalAttempts, deserialized.TotalAttempts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metrics
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metrics { };

        Assert.Null(model.AvgDeliveryTimeMs);
        Assert.False(model.RawData.ContainsKey("avgDeliveryTimeMs"));
        Assert.Null(model.FailureCount);
        Assert.False(model.RawData.ContainsKey("failureCount"));
        Assert.Null(model.LastSuccessAt);
        Assert.False(model.RawData.ContainsKey("lastSuccessAt"));
        Assert.Null(model.SuccessCount);
        Assert.False(model.RawData.ContainsKey("successCount"));
        Assert.Null(model.TotalAttempts);
        Assert.False(model.RawData.ContainsKey("totalAttempts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metrics { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Metrics
        {
            // Null should be interpreted as omitted for these properties
            AvgDeliveryTimeMs = null,
            FailureCount = null,
            LastSuccessAt = null,
            SuccessCount = null,
            TotalAttempts = null,
        };

        Assert.Null(model.AvgDeliveryTimeMs);
        Assert.False(model.RawData.ContainsKey("avgDeliveryTimeMs"));
        Assert.Null(model.FailureCount);
        Assert.False(model.RawData.ContainsKey("failureCount"));
        Assert.Null(model.LastSuccessAt);
        Assert.False(model.RawData.ContainsKey("lastSuccessAt"));
        Assert.Null(model.SuccessCount);
        Assert.False(model.RawData.ContainsKey("successCount"));
        Assert.Null(model.TotalAttempts);
        Assert.False(model.RawData.ContainsKey("totalAttempts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metrics
        {
            // Null should be interpreted as omitted for these properties
            AvgDeliveryTimeMs = null,
            FailureCount = null,
            LastSuccessAt = null,
            SuccessCount = null,
            TotalAttempts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metrics
        {
            AvgDeliveryTimeMs = 0,
            FailureCount = 0,
            LastSuccessAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SuccessCount = 0,
            TotalAttempts = 0,
        };

        Metrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
