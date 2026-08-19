using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Telegram;

namespace Zavudev.Tests.Models.Senders.Telegram;

public class TelegramConnectResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TelegramConnectResponse
        {
            Telegram = new()
            {
                Connected = true,
                BotID = "botId",
                BotUsername = "botUsername",
            },
        };

        TelegramConnectResponseTelegram expectedTelegram = new()
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        Assert.Equal(expectedTelegram, model.Telegram);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TelegramConnectResponse
        {
            Telegram = new()
            {
                Connected = true,
                BotID = "botId",
                BotUsername = "botUsername",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConnectResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TelegramConnectResponse
        {
            Telegram = new()
            {
                Connected = true,
                BotID = "botId",
                BotUsername = "botUsername",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConnectResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TelegramConnectResponseTelegram expectedTelegram = new()
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        Assert.Equal(expectedTelegram, deserialized.Telegram);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TelegramConnectResponse
        {
            Telegram = new()
            {
                Connected = true,
                BotID = "botId",
                BotUsername = "botUsername",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TelegramConnectResponse
        {
            Telegram = new()
            {
                Connected = true,
                BotID = "botId",
                BotUsername = "botUsername",
            },
        };

        TelegramConnectResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TelegramConnectResponseTelegramTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        bool expectedConnected = true;
        string expectedBotID = "botId";
        string expectedBotUsername = "botUsername";

        Assert.Equal(expectedConnected, model.Connected);
        Assert.Equal(expectedBotID, model.BotID);
        Assert.Equal(expectedBotUsername, model.BotUsername);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConnectResponseTelegram>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TelegramConnectResponseTelegram>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedConnected = true;
        string expectedBotID = "botId";
        string expectedBotUsername = "botUsername";

        Assert.Equal(expectedConnected, deserialized.Connected);
        Assert.Equal(expectedBotID, deserialized.BotID);
        Assert.Equal(expectedBotUsername, deserialized.BotUsername);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TelegramConnectResponseTelegram { Connected = true };

        Assert.Null(model.BotID);
        Assert.False(model.RawData.ContainsKey("botId"));
        Assert.Null(model.BotUsername);
        Assert.False(model.RawData.ContainsKey("botUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TelegramConnectResponseTelegram { Connected = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,

            // Null should be interpreted as omitted for these properties
            BotID = null,
            BotUsername = null,
        };

        Assert.Null(model.BotID);
        Assert.False(model.RawData.ContainsKey("botId"));
        Assert.Null(model.BotUsername);
        Assert.False(model.RawData.ContainsKey("botUsername"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,

            // Null should be interpreted as omitted for these properties
            BotID = null,
            BotUsername = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TelegramConnectResponseTelegram
        {
            Connected = true,
            BotID = "botId",
            BotUsername = "botUsername",
        };

        TelegramConnectResponseTelegram copied = new(model);

        Assert.Equal(model, copied);
    }
}
