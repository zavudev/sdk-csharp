using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts;

namespace Zavudev.Tests.Models.Contacts;

public class ContactCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactCreateParams
        {
            Channels =
            [
                new()
                {
                    ChannelValue = ChannelChannel.Sms,
                    Identifier = "+14155551234",
                    CountryCode = "US",
                    IsPrimary = true,
                    Label = "work",
                },
            ],
            DisplayName = "John Doe",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        List<Channel> expectedChannels =
        [
            new()
            {
                ChannelValue = ChannelChannel.Sms,
                Identifier = "+14155551234",
                CountryCode = "US",
                IsPrimary = true,
                Label = "work",
            },
        ];
        string expectedDisplayName = "John Doe";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedChannels.Count, parameters.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], parameters.Channels[i]);
        }
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
        var parameters = new ContactCreateParams
        {
            Channels =
            [
                new()
                {
                    ChannelValue = ChannelChannel.Sms,
                    Identifier = "+14155551234",
                    CountryCode = "US",
                    IsPrimary = true,
                    Label = "work",
                },
            ],
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContactCreateParams
        {
            Channels =
            [
                new()
                {
                    ChannelValue = ChannelChannel.Sms,
                    Identifier = "+14155551234",
                    CountryCode = "US",
                    IsPrimary = true,
                    Label = "work",
                },
            ],

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Metadata = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ContactCreateParams parameters = new()
        {
            Channels =
            [
                new()
                {
                    ChannelValue = ChannelChannel.Sms,
                    Identifier = "+14155551234",
                    CountryCode = "US",
                    IsPrimary = true,
                    Label = "work",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/contacts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactCreateParams
        {
            Channels =
            [
                new()
                {
                    ChannelValue = ChannelChannel.Sms,
                    Identifier = "+14155551234",
                    CountryCode = "US",
                    IsPrimary = true,
                    Label = "work",
                },
            ],
            DisplayName = "John Doe",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        ContactCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        ApiEnum<string, ChannelChannel> expectedChannelValue = ChannelChannel.Sms;
        string expectedIdentifier = "+14155551234";
        string expectedCountryCode = "US";
        bool expectedIsPrimary = true;
        string expectedLabel = "work";

        Assert.Equal(expectedChannelValue, model.ChannelValue);
        Assert.Equal(expectedIdentifier, model.Identifier);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedIsPrimary, model.IsPrimary);
        Assert.Equal(expectedLabel, model.Label);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channel>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ChannelChannel> expectedChannelValue = ChannelChannel.Sms;
        string expectedIdentifier = "+14155551234";
        string expectedCountryCode = "US";
        bool expectedIsPrimary = true;
        string expectedLabel = "work";

        Assert.Equal(expectedChannelValue, deserialized.ChannelValue);
        Assert.Equal(expectedIdentifier, deserialized.Identifier);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedIsPrimary, deserialized.IsPrimary);
        Assert.Equal(expectedLabel, deserialized.Label);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Channel { ChannelValue = ChannelChannel.Sms, Identifier = "+14155551234" };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.IsPrimary);
        Assert.False(model.RawData.ContainsKey("isPrimary"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Channel { ChannelValue = ChannelChannel.Sms, Identifier = "+14155551234" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            IsPrimary = null,
            Label = null,
        };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("countryCode"));
        Assert.Null(model.IsPrimary);
        Assert.False(model.RawData.ContainsKey("isPrimary"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",

            // Null should be interpreted as omitted for these properties
            CountryCode = null,
            IsPrimary = null,
            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Channel
        {
            ChannelValue = ChannelChannel.Sms,
            Identifier = "+14155551234",
            CountryCode = "US",
            IsPrimary = true,
            Label = "work",
        };

        Channel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChannelChannelTest : TestBase
{
    [Theory]
    [InlineData(ChannelChannel.Sms)]
    [InlineData(ChannelChannel.Whatsapp)]
    [InlineData(ChannelChannel.Email)]
    [InlineData(ChannelChannel.Telegram)]
    [InlineData(ChannelChannel.Instagram)]
    [InlineData(ChannelChannel.Messenger)]
    [InlineData(ChannelChannel.Voice)]
    public void Validation_Works(ChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChannelChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChannelChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChannelChannel.Sms)]
    [InlineData(ChannelChannel.Whatsapp)]
    [InlineData(ChannelChannel.Email)]
    [InlineData(ChannelChannel.Telegram)]
    [InlineData(ChannelChannel.Instagram)]
    [InlineData(ChannelChannel.Messenger)]
    [InlineData(ChannelChannel.Voice)]
    public void SerializationRoundtrip_Works(ChannelChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChannelChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChannelChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChannelChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChannelChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
