using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            ProfileName = "John Doe",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<string> expectedAvailableChannels = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedVerified = true;
        List<ContactChannel> expectedChannels =
        [
            new()
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
        ];
        string expectedCountryCode = "CL";
        ApiEnum<string, ContactDefaultChannel> expectedDefaultChannel = ContactDefaultChannel.Sms;
        string expectedDisplayName = "John Doe";
        string expectedPhoneNumber = "+56912345678";
        string expectedPrimaryEmail = "john@example.com";
        string expectedPrimaryPhone = "+56912345678";
        string expectedProfileName = "John Doe";
        string expectedSuggestedMergeWith = "suggestedMergeWith";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAvailableChannels.Count, model.AvailableChannels.Count);
        for (int i = 0; i < expectedAvailableChannels.Count; i++)
        {
            Assert.Equal(expectedAvailableChannels[i], model.AvailableChannels[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedVerified, model.Verified);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedDefaultChannel, model.DefaultChannel);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPrimaryEmail, model.PrimaryEmail);
        Assert.Equal(expectedPrimaryPhone, model.PrimaryPhone);
        Assert.Equal(expectedProfileName, model.ProfileName);
        Assert.Equal(expectedSuggestedMergeWith, model.SuggestedMergeWith);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            ProfileName = "John Doe",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            ProfileName = "John Doe",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAvailableChannels = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedVerified = true;
        List<ContactChannel> expectedChannels =
        [
            new()
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
        ];
        string expectedCountryCode = "CL";
        ApiEnum<string, ContactDefaultChannel> expectedDefaultChannel = ContactDefaultChannel.Sms;
        string expectedDisplayName = "John Doe";
        string expectedPhoneNumber = "+56912345678";
        string expectedPrimaryEmail = "john@example.com";
        string expectedPrimaryPhone = "+56912345678";
        string expectedProfileName = "John Doe";
        string expectedSuggestedMergeWith = "suggestedMergeWith";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAvailableChannels.Count, deserialized.AvailableChannels.Count);
        for (int i = 0; i < expectedAvailableChannels.Count; i++)
        {
            Assert.Equal(expectedAvailableChannels[i], deserialized.AvailableChannels[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedVerified, deserialized.Verified);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedDefaultChannel, deserialized.DefaultChannel);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPrimaryEmail, deserialized.PrimaryEmail);
        Assert.Equal(expectedPrimaryPhone, deserialized.PrimaryPhone);
        Assert.Equal(expectedProfileName, deserialized.ProfileName);
        Assert.Equal(expectedSuggestedMergeWith, deserialized.SuggestedMergeWith);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            ProfileName = "John Doe",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            ProfileName = "John Doe",
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("defaultChannel"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PrimaryEmail);
        Assert.False(model.RawData.ContainsKey("primaryEmail"));
        Assert.Null(model.PrimaryPhone);
        Assert.False(model.RawData.ContainsKey("primaryPhone"));
        Assert.Null(model.SuggestedMergeWith);
        Assert.False(model.RawData.ContainsKey("suggestedMergeWith"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            ProfileName = "John Doe",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            ProfileName = "John Doe",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            CountryCode = null,
            DefaultChannel = null,
            DisplayName = null,
            PhoneNumber = null,
            PrimaryEmail = null,
            PrimaryPhone = null,
            SuggestedMergeWith = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.DefaultChannel);
        Assert.False(model.RawData.ContainsKey("defaultChannel"));
        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("displayName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.PrimaryEmail);
        Assert.False(model.RawData.ContainsKey("primaryEmail"));
        Assert.Null(model.PrimaryPhone);
        Assert.False(model.RawData.ContainsKey("primaryPhone"));
        Assert.Null(model.SuggestedMergeWith);
        Assert.False(model.RawData.ContainsKey("suggestedMergeWith"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            ProfileName = "John Doe",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            CountryCode = null,
            DefaultChannel = null,
            DisplayName = null,
            PhoneNumber = null,
            PrimaryEmail = null,
            PrimaryPhone = null,
            SuggestedMergeWith = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProfileName);
        Assert.False(model.RawData.ContainsKey("profileName"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ProfileName = null,
        };

        Assert.Null(model.ProfileName);
        Assert.True(model.RawData.ContainsKey("profileName"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ProfileName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contact
        {
            ID = "id",
            AvailableChannels = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
            Channels =
            [
                new()
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
            ],
            CountryCode = "CL",
            DefaultChannel = ContactDefaultChannel.Sms,
            DisplayName = "John Doe",
            PhoneNumber = "+56912345678",
            PrimaryEmail = "john@example.com",
            PrimaryPhone = "+56912345678",
            ProfileName = "John Doe",
            SuggestedMergeWith = "suggestedMergeWith",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Contact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContactDefaultChannelTest : TestBase
{
    [Theory]
    [InlineData(ContactDefaultChannel.Sms)]
    [InlineData(ContactDefaultChannel.Whatsapp)]
    [InlineData(ContactDefaultChannel.Telegram)]
    [InlineData(ContactDefaultChannel.Email)]
    [InlineData(ContactDefaultChannel.Instagram)]
    [InlineData(ContactDefaultChannel.Messenger)]
    [InlineData(ContactDefaultChannel.Voice)]
    public void Validation_Works(ContactDefaultChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContactDefaultChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContactDefaultChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContactDefaultChannel.Sms)]
    [InlineData(ContactDefaultChannel.Whatsapp)]
    [InlineData(ContactDefaultChannel.Telegram)]
    [InlineData(ContactDefaultChannel.Email)]
    [InlineData(ContactDefaultChannel.Instagram)]
    [InlineData(ContactDefaultChannel.Messenger)]
    [InlineData(ContactDefaultChannel.Voice)]
    public void SerializationRoundtrip_Works(ContactDefaultChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContactDefaultChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContactDefaultChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContactDefaultChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContactDefaultChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
