using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Invitation> expectedItems =
        [
            new()
            {
                ID = "inv_abc123",
                Token = "token",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = InvitationStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                ClientEmail = "clientEmail",
                ClientName = "clientName",
                ClientPhone = "clientPhone",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ConnectedAccount = new()
                {
                    ID = "id",
                    Channel = Channel.Whatsapp,
                    Name = "name",
                },
                ConnectionType = InvitationConnectionType.WhatsappWaba,
                FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failureReason",
                PhoneNumberID = "phoneNumberId",
                SenderID = "senderId",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Invitation> expectedItems =
        [
            new()
            {
                ID = "inv_abc123",
                Token = "token",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = InvitationStatus.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                ClientEmail = "clientEmail",
                ClientName = "clientName",
                ClientPhone = "clientPhone",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ConnectedAccount = new()
                {
                    ID = "id",
                    Channel = Channel.Whatsapp,
                    Name = "name",
                },
                ConnectionType = InvitationConnectionType.WhatsappWaba,
                FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failureReason",
                PhoneNumberID = "phoneNumberId",
                SenderID = "senderId",
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvitationListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "inv_abc123",
                    Token = "token",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = InvitationStatus.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://dashboard.zavu.dev/invite/abc123xyz",
                    ClientEmail = "clientEmail",
                    ClientName = "clientName",
                    ClientPhone = "clientPhone",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ConnectedAccount = new()
                    {
                        ID = "id",
                        Channel = Channel.Whatsapp,
                        Name = "name",
                    },
                    ConnectionType = InvitationConnectionType.WhatsappWaba,
                    FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                    PhoneNumberID = "phoneNumberId",
                    SenderID = "senderId",
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextCursor = "nextCursor",
        };

        InvitationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
