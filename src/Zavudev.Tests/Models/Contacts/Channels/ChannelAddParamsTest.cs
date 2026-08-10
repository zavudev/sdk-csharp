using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Tests.Models.Contacts.Channels;

public class ChannelAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChannelAddParams
        {
            ContactID = "contactId",
            Channel = Channel.Email,
            Identifier = "john.work@company.com",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        string expectedContactID = "contactId";
        ApiEnum<string, Channel> expectedChannel = Channel.Email;
        string expectedIdentifier = "john.work@company.com";
        string expectedCountryCode = "US";
        bool expectedIsPrimary = true;
        string expectedLabel = "work";

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedIdentifier, parameters.Identifier);
        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedIsPrimary, parameters.IsPrimary);
        Assert.Equal(expectedLabel, parameters.Label);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChannelAddParams
        {
            ContactID = "contactId",
            Channel = Channel.Email,
            Identifier = "john.work@company.com",
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("countryCode"));
        Assert.Null(parameters.IsPrimary);
        Assert.False(parameters.RawBodyData.ContainsKey("isPrimary"));
        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChannelAddParams
        {
            ContactID = "contactId",
            Channel = Channel.Email,
            Identifier = "john.work@company.com",

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            IsPrimary = null,
            Label = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("countryCode"));
        Assert.Null(parameters.IsPrimary);
        Assert.False(parameters.RawBodyData.ContainsKey("isPrimary"));
        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
    }

    [Fact]
    public void Url_Works()
    {
        ChannelAddParams parameters = new()
        {
            ContactID = "contactId",
            Channel = Channel.Email,
            Identifier = "john.work@company.com",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts/contactId/channels"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChannelAddParams
        {
            ContactID = "contactId",
            Channel = Channel.Email,
            Identifier = "john.work@company.com",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        ChannelAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Instagram)]
    [InlineData(Channel.Messenger)]
    [InlineData(Channel.Voice)]
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
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Instagram)]
    [InlineData(Channel.Messenger)]
    [InlineData(Channel.Voice)]
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
