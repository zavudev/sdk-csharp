using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Telegram;

[JsonConverter(typeof(JsonModelConverter<TelegramConnectResponse, TelegramConnectResponseFromRaw>))]
public sealed record class TelegramConnectResponse : JsonModel
{
    public required TelegramConnectResponseTelegram Telegram
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TelegramConnectResponseTelegram>("telegram");
        }
        init { this._rawData.Set("telegram", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Telegram.Validate();
    }

    public TelegramConnectResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelegramConnectResponse(TelegramConnectResponse telegramConnectResponse)
        : base(telegramConnectResponse) { }
#pragma warning restore CS8618

    public TelegramConnectResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TelegramConnectResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TelegramConnectResponseFromRaw.FromRawUnchecked"/>
    public static TelegramConnectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TelegramConnectResponse(TelegramConnectResponseTelegram telegram)
        : this()
    {
        this.Telegram = telegram;
    }
}

class TelegramConnectResponseFromRaw : IFromRawJson<TelegramConnectResponse>
{
    /// <inheritdoc/>
    public TelegramConnectResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TelegramConnectResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TelegramConnectResponseTelegram,
        TelegramConnectResponseTelegramFromRaw
    >)
)]
public sealed record class TelegramConnectResponseTelegram : JsonModel
{
    public required bool Connected
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("connected");
        }
        init { this._rawData.Set("connected", value); }
    }

    public string? BotID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("botId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("botId", value);
        }
    }

    public string? BotUsername
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("botUsername");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("botUsername", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Connected;
        _ = this.BotID;
        _ = this.BotUsername;
    }

    public TelegramConnectResponseTelegram() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelegramConnectResponseTelegram(
        TelegramConnectResponseTelegram telegramConnectResponseTelegram
    )
        : base(telegramConnectResponseTelegram) { }
#pragma warning restore CS8618

    public TelegramConnectResponseTelegram(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TelegramConnectResponseTelegram(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TelegramConnectResponseTelegramFromRaw.FromRawUnchecked"/>
    public static TelegramConnectResponseTelegram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TelegramConnectResponseTelegram(bool connected)
        : this()
    {
        this.Connected = connected;
    }
}

class TelegramConnectResponseTelegramFromRaw : IFromRawJson<TelegramConnectResponseTelegram>
{
    /// <inheritdoc/>
    public TelegramConnectResponseTelegram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TelegramConnectResponseTelegram.FromRawUnchecked(rawData);
}
