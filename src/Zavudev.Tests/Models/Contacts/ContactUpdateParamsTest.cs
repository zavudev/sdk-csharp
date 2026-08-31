using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            DefaultChannel = DefaultChannel.Sms,
            DisplayName = "John Doe",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedContactID = "contactId";
        ApiEnum<string, DefaultChannel> expectedDefaultChannel = DefaultChannel.Sms;
        string expectedDisplayName = "John Doe";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedDefaultChannel, parameters.DefaultChannel);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            DefaultChannel = DefaultChannel.Sms,
            DisplayName = "John Doe",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            DefaultChannel = DefaultChannel.Sms,
            DisplayName = "John Doe",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.DefaultChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultChannel"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            DefaultChannel = null,
            DisplayName = null,
        };

        Assert.Null(parameters.DefaultChannel);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultChannel"));
        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("displayName"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactUpdateParams parameters = new() { ContactID = "contactId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts/contactId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactUpdateParams
        {
            ContactID = "contactId",
            DefaultChannel = DefaultChannel.Sms,
            DisplayName = "John Doe",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ContactUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DefaultChannelTest : TestBase
{
    [Theory]
    [InlineData(DefaultChannel.Sms)]
    [InlineData(DefaultChannel.Whatsapp)]
    [InlineData(DefaultChannel.Telegram)]
    [InlineData(DefaultChannel.Email)]
    [InlineData(DefaultChannel.Instagram)]
    [InlineData(DefaultChannel.Messenger)]
    [InlineData(DefaultChannel.Voice)]
    public void Validation_Works(DefaultChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DefaultChannel.Sms)]
    [InlineData(DefaultChannel.Whatsapp)]
    [InlineData(DefaultChannel.Telegram)]
    [InlineData(DefaultChannel.Email)]
    [InlineData(DefaultChannel.Instagram)]
    [InlineData(DefaultChannel.Messenger)]
    [InlineData(DefaultChannel.Voice)]
    public void SerializationRoundtrip_Works(DefaultChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DefaultChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DefaultChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
