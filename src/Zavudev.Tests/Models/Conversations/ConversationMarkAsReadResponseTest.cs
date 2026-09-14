using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Conversations;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationMarkAsReadResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponse
        {
            Conversation = new()
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
                    Direction =
                        ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        ConversationMarkAsReadResponseConversation expectedConversation = new()
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        Assert.Equal(expectedConversation, model.Conversation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponse
        {
            Conversation = new()
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
                    Direction =
                        ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationMarkAsReadResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMarkAsReadResponse
        {
            Conversation = new()
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
                    Direction =
                        ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationMarkAsReadResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ConversationMarkAsReadResponseConversation expectedConversation = new()
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        Assert.Equal(expectedConversation, deserialized.Conversation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationMarkAsReadResponse
        {
            Conversation = new()
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
                    Direction =
                        ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationMarkAsReadResponse
        {
            Conversation = new()
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
                    Direction =
                        ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        ConversationMarkAsReadResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationMarkAsReadResponseConversationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        string expectedID = "js723987cyghwqxxaxcf590qd18axd95";
        List<string> expectedChannels = ["whatsapp", "sms"];
        string expectedContactIdentifier = "+56912345678";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ConversationMarkAsReadResponseConversationLastMessage expectedLastMessage = new()
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };
        long expectedMessageCount = 0;
        long expectedUnreadCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedContactID = "contactId";
        string expectedEmail = "email";
        ConversationMarkAsReadResponseConversationGroup expectedGroup = new()
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };
        string expectedSenderID = "senderId";
        ConversationMarkAsReadResponseConversationWhatsapp expectedWhatsapp = new()
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedContactIdentifier, model.ContactIdentifier);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLastMessage, model.LastMessage);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedUnreadCount, model.UnreadCount);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedContactID, model.ContactID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "js723987cyghwqxxaxcf590qd18axd95";
        List<string> expectedChannels = ["whatsapp", "sms"];
        string expectedContactIdentifier = "+56912345678";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ConversationMarkAsReadResponseConversationLastMessage expectedLastMessage = new()
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };
        long expectedMessageCount = 0;
        long expectedUnreadCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedContactID = "contactId";
        string expectedEmail = "email";
        ConversationMarkAsReadResponseConversationGroup expectedGroup = new()
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };
        string expectedSenderID = "senderId";
        ConversationMarkAsReadResponseConversationWhatsapp expectedWhatsapp = new()
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedContactIdentifier, deserialized.ContactIdentifier);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLastMessage, deserialized.LastMessage);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedUnreadCount, deserialized.UnreadCount);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedContactID, deserialized.ContactID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
                Text = "text",
            },
            MessageCount = 0,
            UnreadCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contactId"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
                Text = "text",
            },
            MessageCount = 0,
            UnreadCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
                Text = "text",
            },
            MessageCount = 0,
            UnreadCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ContactID = null,
            Email = null,
            Group = null,
            SenderID = null,
            Whatsapp = null,
        };

        Assert.Null(model.ContactID);
        Assert.False(model.RawData.ContainsKey("contactId"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Group);
        Assert.False(model.RawData.ContainsKey("group"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
                Text = "text",
            },
            MessageCount = 0,
            UnreadCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ContactID = null,
            Email = null,
            Group = null,
            SenderID = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationMarkAsReadResponseConversation
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
                Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
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
        };

        ConversationMarkAsReadResponseConversation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationMarkAsReadResponseConversationLastMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationLastMessage
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };

        string expectedID = "id";
        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageChannel> expectedChannel = MessageChannel.Auto;
        ApiEnum<
            string,
            ConversationMarkAsReadResponseConversationLastMessageDirection
        > expectedDirection =
            ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound;
        string expectedText = "text";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAt, model.At);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationLastMessage
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationLastMessage>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationLastMessage
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationLastMessage>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, MessageChannel> expectedChannel = MessageChannel.Auto;
        ApiEnum<
            string,
            ConversationMarkAsReadResponseConversationLastMessageDirection
        > expectedDirection =
            ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound;
        string expectedText = "text";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAt, deserialized.At);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationLastMessage
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationLastMessage
        {
            ID = "id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Channel = MessageChannel.Auto,
            Direction = ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound,
            Text = "text",
        };

        ConversationMarkAsReadResponseConversationLastMessage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationMarkAsReadResponseConversationLastMessageDirectionTest : TestBase
{
    [Theory]
    [InlineData(ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound)]
    [InlineData(ConversationMarkAsReadResponseConversationLastMessageDirection.Outbound)]
    public void Validation_Works(
        ConversationMarkAsReadResponseConversationLastMessageDirection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConversationMarkAsReadResponseConversationLastMessageDirection.Inbound)]
    [InlineData(ConversationMarkAsReadResponseConversationLastMessageDirection.Outbound)]
    public void SerializationRoundtrip_Works(
        ConversationMarkAsReadResponseConversationLastMessageDirection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConversationMarkAsReadResponseConversationLastMessageDirection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConversationMarkAsReadResponseConversationGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };

        string expectedID = "id";
        long expectedParticipantCount = 0;
        string expectedSubject = "subject";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedParticipantCount, model.ParticipantCount);
        Assert.Equal(expectedSubject, model.Subject);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationGroup>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationGroup>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedParticipantCount = 0;
        string expectedSubject = "subject";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedParticipantCount, deserialized.ParticipantCount);
        Assert.Equal(expectedSubject, deserialized.Subject);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup { ID = "id" };

        Assert.Null(model.ParticipantCount);
        Assert.False(model.RawData.ContainsKey("participantCount"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ParticipantCount = null,
            Subject = null,
        };

        Assert.Null(model.ParticipantCount);
        Assert.False(model.RawData.ContainsKey("participantCount"));
        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            ParticipantCount = null,
            Subject = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationGroup
        {
            ID = "id",
            ParticipantCount = 0,
            Subject = "subject",
        };

        ConversationMarkAsReadResponseConversationGroup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConversationMarkAsReadResponseConversationWhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        string expectedBsuid = "bsuid";
        string expectedUsername = "username";

        Assert.Equal(expectedBsuid, model.Bsuid);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationWhatsapp>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConversationMarkAsReadResponseConversationWhatsapp>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedBsuid = "bsuid";
        string expectedUsername = "username";

        Assert.Equal(expectedBsuid, deserialized.Bsuid);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp { };

        Assert.Null(model.Bsuid);
        Assert.False(model.RawData.ContainsKey("bsuid"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            // Null should be interpreted as omitted for these properties
            Bsuid = null,
            Username = null,
        };

        Assert.Null(model.Bsuid);
        Assert.False(model.RawData.ContainsKey("bsuid"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            // Null should be interpreted as omitted for these properties
            Bsuid = null,
            Username = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConversationMarkAsReadResponseConversationWhatsapp
        {
            Bsuid = "bsuid",
            Username = "username",
        };

        ConversationMarkAsReadResponseConversationWhatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}
