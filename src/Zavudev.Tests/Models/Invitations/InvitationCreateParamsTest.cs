using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Invitations;

namespace Zavudev.Tests.Models.Invitations;

public class InvitationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvitationCreateParams
        {
            AllowedPhoneCountries = ["US", "MX"],
            ClientEmail = "contact@acme.com",
            ClientName = "Acme Corp",
            ClientPhone = "+14155551234",
            ConnectionType = ConnectionType.WhatsappWaba,
            ExpiresInDays = 1,
            PhoneNumberID = "pn_abc123",
        };

        List<string> expectedAllowedPhoneCountries = ["US", "MX"];
        string expectedClientEmail = "contact@acme.com";
        string expectedClientName = "Acme Corp";
        string expectedClientPhone = "+14155551234";
        ApiEnum<string, ConnectionType> expectedConnectionType = ConnectionType.WhatsappWaba;
        long expectedExpiresInDays = 1;
        string expectedPhoneNumberID = "pn_abc123";

        Assert.NotNull(parameters.AllowedPhoneCountries);
        Assert.Equal(expectedAllowedPhoneCountries.Count, parameters.AllowedPhoneCountries.Count);
        for (int i = 0; i < expectedAllowedPhoneCountries.Count; i++)
        {
            Assert.Equal(expectedAllowedPhoneCountries[i], parameters.AllowedPhoneCountries[i]);
        }
        Assert.Equal(expectedClientEmail, parameters.ClientEmail);
        Assert.Equal(expectedClientName, parameters.ClientName);
        Assert.Equal(expectedClientPhone, parameters.ClientPhone);
        Assert.Equal(expectedConnectionType, parameters.ConnectionType);
        Assert.Equal(expectedExpiresInDays, parameters.ExpiresInDays);
        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvitationCreateParams { };

        Assert.Null(parameters.AllowedPhoneCountries);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedPhoneCountries"));
        Assert.Null(parameters.ClientEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("clientEmail"));
        Assert.Null(parameters.ClientName);
        Assert.False(parameters.RawBodyData.ContainsKey("clientName"));
        Assert.Null(parameters.ClientPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("clientPhone"));
        Assert.Null(parameters.ConnectionType);
        Assert.False(parameters.RawBodyData.ContainsKey("connectionType"));
        Assert.Null(parameters.ExpiresInDays);
        Assert.False(parameters.RawBodyData.ContainsKey("expiresInDays"));
        Assert.Null(parameters.PhoneNumberID);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumberId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvitationCreateParams
        {
            // Null should be interpreted as omitted for these properties
            AllowedPhoneCountries = null,
            ClientEmail = null,
            ClientName = null,
            ClientPhone = null,
            ConnectionType = null,
            ExpiresInDays = null,
            PhoneNumberID = null,
        };

        Assert.Null(parameters.AllowedPhoneCountries);
        Assert.False(parameters.RawBodyData.ContainsKey("allowedPhoneCountries"));
        Assert.Null(parameters.ClientEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("clientEmail"));
        Assert.Null(parameters.ClientName);
        Assert.False(parameters.RawBodyData.ContainsKey("clientName"));
        Assert.Null(parameters.ClientPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("clientPhone"));
        Assert.Null(parameters.ConnectionType);
        Assert.False(parameters.RawBodyData.ContainsKey("connectionType"));
        Assert.Null(parameters.ExpiresInDays);
        Assert.False(parameters.RawBodyData.ContainsKey("expiresInDays"));
        Assert.Null(parameters.PhoneNumberID);
        Assert.False(parameters.RawBodyData.ContainsKey("phoneNumberId"));
    }

    [Fact]
    public void Url_Works()
    {
        InvitationCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/invitations"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvitationCreateParams
        {
            AllowedPhoneCountries = ["US", "MX"],
            ClientEmail = "contact@acme.com",
            ClientName = "Acme Corp",
            ClientPhone = "+14155551234",
            ConnectionType = ConnectionType.WhatsappWaba,
            ExpiresInDays = 1,
            PhoneNumberID = "pn_abc123",
        };

        InvitationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConnectionTypeTest : TestBase
{
    [Theory]
    [InlineData(ConnectionType.WhatsappWaba)]
    [InlineData(ConnectionType.Messenger)]
    public void Validation_Works(ConnectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConnectionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConnectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConnectionType.WhatsappWaba)]
    [InlineData(ConnectionType.Messenger)]
    public void SerializationRoundtrip_Works(ConnectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConnectionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConnectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConnectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConnectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
