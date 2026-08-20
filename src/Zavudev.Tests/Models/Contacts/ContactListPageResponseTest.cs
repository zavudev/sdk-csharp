using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Contact> expectedItems =
        [
            new()
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Contact> expectedItems =
        [
            new()
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
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        ContactListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
