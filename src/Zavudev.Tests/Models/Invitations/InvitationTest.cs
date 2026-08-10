using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invitation
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

        string expectedID = "inv_abc123";
        string expectedToken = "token";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, InvitationStatus> expectedStatus = InvitationStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://dashboard.zavu.dev/invite/abc123xyz";
        string expectedClientEmail = "clientEmail";
        string expectedClientName = "clientName";
        string expectedClientPhone = "clientPhone";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ConnectedAccount expectedConnectedAccount = new()
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };
        ApiEnum<string, InvitationConnectionType> expectedConnectionType =
            InvitationConnectionType.WhatsappWaba;
        DateTimeOffset expectedFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failureReason";
        string expectedPhoneNumberID = "phoneNumberId";
        string expectedSenderID = "senderId";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedClientName, model.ClientName);
        Assert.Equal(expectedClientPhone, model.ClientPhone);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedConnectedAccount, model.ConnectedAccount);
        Assert.Equal(expectedConnectionType, model.ConnectionType);
        Assert.Equal(expectedFailedAt, model.FailedAt);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedViewedAt, model.ViewedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invitation
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invitation
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "inv_abc123";
        string expectedToken = "token";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, InvitationStatus> expectedStatus = InvitationStatus.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://dashboard.zavu.dev/invite/abc123xyz";
        string expectedClientEmail = "clientEmail";
        string expectedClientName = "clientName";
        string expectedClientPhone = "clientPhone";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ConnectedAccount expectedConnectedAccount = new()
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };
        ApiEnum<string, InvitationConnectionType> expectedConnectionType =
            InvitationConnectionType.WhatsappWaba;
        DateTimeOffset expectedFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failureReason";
        string expectedPhoneNumberID = "phoneNumberId";
        string expectedSenderID = "senderId";
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedClientName, deserialized.ClientName);
        Assert.Equal(expectedClientPhone, deserialized.ClientPhone);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedConnectedAccount, deserialized.ConnectedAccount);
        Assert.Equal(expectedConnectionType, deserialized.ConnectionType);
        Assert.Equal(expectedFailedAt, deserialized.FailedAt);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedViewedAt, deserialized.ViewedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invitation
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invitation
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
            FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
            PhoneNumberID = "phoneNumberId",
            SenderID = "senderId",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ConnectionType);
        Assert.False(model.RawData.ContainsKey("connectionType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invitation
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
            FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
            PhoneNumberID = "phoneNumberId",
            SenderID = "senderId",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invitation
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
            FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
            PhoneNumberID = "phoneNumberId",
            SenderID = "senderId",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ConnectionType = null,
        };

        Assert.Null(model.ConnectionType);
        Assert.False(model.RawData.ContainsKey("connectionType"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invitation
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
            FailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
            PhoneNumberID = "phoneNumberId",
            SenderID = "senderId",
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ViewedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ConnectionType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invitation
        {
            ID = "inv_abc123",
            Token = "token",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = InvitationStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://dashboard.zavu.dev/invite/abc123xyz",
            ConnectionType = InvitationConnectionType.WhatsappWaba,
        };

        Assert.Null(model.ClientEmail);
        Assert.False(model.RawData.ContainsKey("clientEmail"));
        Assert.Null(model.ClientName);
        Assert.False(model.RawData.ContainsKey("clientName"));
        Assert.Null(model.ClientPhone);
        Assert.False(model.RawData.ContainsKey("clientPhone"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.ConnectedAccount);
        Assert.False(model.RawData.ContainsKey("connectedAccount"));
        Assert.Null(model.FailedAt);
        Assert.False(model.RawData.ContainsKey("failedAt"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.PhoneNumberID);
        Assert.False(model.RawData.ContainsKey("phoneNumberId"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.ViewedAt);
        Assert.False(model.RawData.ContainsKey("viewedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invitation
        {
            ID = "inv_abc123",
            Token = "token",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = InvitationStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://dashboard.zavu.dev/invite/abc123xyz",
            ConnectionType = InvitationConnectionType.WhatsappWaba,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Invitation
        {
            ID = "inv_abc123",
            Token = "token",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = InvitationStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://dashboard.zavu.dev/invite/abc123xyz",
            ConnectionType = InvitationConnectionType.WhatsappWaba,

            ClientEmail = null,
            ClientName = null,
            ClientPhone = null,
            CompletedAt = null,
            ConnectedAccount = null,
            FailedAt = null,
            FailureReason = null,
            PhoneNumberID = null,
            SenderID = null,
            StartedAt = null,
            ViewedAt = null,
        };

        Assert.Null(model.ClientEmail);
        Assert.True(model.RawData.ContainsKey("clientEmail"));
        Assert.Null(model.ClientName);
        Assert.True(model.RawData.ContainsKey("clientName"));
        Assert.Null(model.ClientPhone);
        Assert.True(model.RawData.ContainsKey("clientPhone"));
        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completedAt"));
        Assert.Null(model.ConnectedAccount);
        Assert.True(model.RawData.ContainsKey("connectedAccount"));
        Assert.Null(model.FailedAt);
        Assert.True(model.RawData.ContainsKey("failedAt"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.PhoneNumberID);
        Assert.True(model.RawData.ContainsKey("phoneNumberId"));
        Assert.Null(model.SenderID);
        Assert.True(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
        Assert.Null(model.ViewedAt);
        Assert.True(model.RawData.ContainsKey("viewedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invitation
        {
            ID = "inv_abc123",
            Token = "token",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = InvitationStatus.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://dashboard.zavu.dev/invite/abc123xyz",
            ConnectionType = InvitationConnectionType.WhatsappWaba,

            ClientEmail = null,
            ClientName = null,
            ClientPhone = null,
            CompletedAt = null,
            ConnectedAccount = null,
            FailedAt = null,
            FailureReason = null,
            PhoneNumberID = null,
            SenderID = null,
            StartedAt = null,
            ViewedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invitation
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

        Invitation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvitationStatusTest : TestBase
{
    [Theory]
    [InlineData(InvitationStatus.Pending)]
    [InlineData(InvitationStatus.InProgress)]
    [InlineData(InvitationStatus.Completed)]
    [InlineData(InvitationStatus.Expired)]
    [InlineData(InvitationStatus.Cancelled)]
    [InlineData(InvitationStatus.Failed)]
    public void Validation_Works(InvitationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationStatus.Pending)]
    [InlineData(InvitationStatus.InProgress)]
    [InlineData(InvitationStatus.Completed)]
    [InlineData(InvitationStatus.Expired)]
    [InlineData(InvitationStatus.Cancelled)]
    [InlineData(InvitationStatus.Failed)]
    public void SerializationRoundtrip_Works(InvitationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConnectedAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };

        string expectedID = "id";
        ApiEnum<string, Channel> expectedChannel = Channel.Whatsapp;
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectedAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConnectedAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Channel> expectedChannel = Channel.Whatsapp;
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConnectedAccount { ID = "id", Channel = Channel.Whatsapp };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConnectedAccount { ID = "id", Channel = Channel.Whatsapp };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,

            Name = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,

            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConnectedAccount
        {
            ID = "id",
            Channel = Channel.Whatsapp,
            Name = "name",
        };

        ConnectedAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Messenger)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Messenger)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvitationConnectionTypeTest : TestBase
{
    [Theory]
    [InlineData(InvitationConnectionType.WhatsappWaba)]
    [InlineData(InvitationConnectionType.Messenger)]
    public void Validation_Works(InvitationConnectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationConnectionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationConnectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InvitationConnectionType.WhatsappWaba)]
    [InlineData(InvitationConnectionType.Messenger)]
    public void SerializationRoundtrip_Works(InvitationConnectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InvitationConnectionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationConnectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InvitationConnectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InvitationConnectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
