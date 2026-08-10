using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvitationCreateResponse
        {
            Invitation = new()
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
        };

        Invitation expectedInvitation = new()
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
        };

        Assert.Equal(expectedInvitation, model.Invitation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvitationCreateResponse
        {
            Invitation = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvitationCreateResponse
        {
            Invitation = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InvitationCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Invitation expectedInvitation = new()
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
        };

        Assert.Equal(expectedInvitation, deserialized.Invitation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvitationCreateResponse
        {
            Invitation = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InvitationCreateResponse
        {
            Invitation = new()
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
        };

        InvitationCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
