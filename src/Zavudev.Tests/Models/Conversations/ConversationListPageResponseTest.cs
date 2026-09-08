using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Conversations;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
            NextCursor = "nextCursor",
        };

        List<ConversationListResponse> expectedItems =
        [
            new()
            {
                ID = "js723987cyghwqxxaxcf590qd18axd95",
                Channels = ["whatsapp", "sms"],
                ContactIdentifier = "+56912345678",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastMessage = new()
                {
                    ID = "id",
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Channel = MessageChannel.Auto,
                    Direction = ConversationListResponseLastMessageDirection.Inbound,
                    Text = "text",
                },
                MessageCount = 0,
                UnreadCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ContactID = "contactId",
                Email = "email",
                Group = new()
                {
                    ID = "id",
                    ParticipantCount = 0,
                    Subject = "subject",
                },
                SenderID = "senderId",
                Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
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
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ConversationListResponse> expectedItems =
        [
            new()
            {
                ID = "js723987cyghwqxxaxcf590qd18axd95",
                Channels = ["whatsapp", "sms"],
                ContactIdentifier = "+56912345678",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastMessage = new()
                {
                    ID = "id",
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Channel = MessageChannel.Auto,
                    Direction = ConversationListResponseLastMessageDirection.Inbound,
                    Text = "text",
                },
                MessageCount = 0,
                UnreadCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ContactID = "contactId",
                Email = "email",
                Group = new()
                {
                    ID = "id",
                    ParticipantCount = 0,
                    Subject = "subject",
                },
                SenderID = "senderId",
                Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
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
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
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
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "js723987cyghwqxxaxcf590qd18axd95",
                    Channels = ["whatsapp", "sms"],
                    ContactIdentifier = "+56912345678",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    LastMessage = new()
                    {
                        ID = "id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Channel = MessageChannel.Auto,
                        Direction = ConversationListResponseLastMessageDirection.Inbound,
                        Text = "text",
                    },
                    MessageCount = 0,
                    UnreadCount = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ContactID = "contactId",
                    Email = "email",
                    Group = new()
                    {
                        ID = "id",
                        ParticipantCount = 0,
                        Subject = "subject",
                    },
                    SenderID = "senderId",
                    Whatsapp = new() { Bsuid = "bsuid", Username = "username" },
                },
            ],
            NextCursor = "nextCursor",
        };

        ConversationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
