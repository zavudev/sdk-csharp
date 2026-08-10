using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageResponse, MessageResponseFromRaw>))]
public sealed record class MessageResponse : JsonModel
{
    public required Message Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Message>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Message.Validate();
    }

    public MessageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageResponse(MessageResponse messageResponse)
        : base(messageResponse) { }
#pragma warning restore CS8618

    public MessageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageResponseFromRaw.FromRawUnchecked"/>
    public static MessageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageResponse(Message message)
        : this()
    {
        this.Message = message;
    }
}

class MessageResponseFromRaw : IFromRawJson<MessageResponse>
{
    /// <inheritdoc/>
    public MessageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageResponse.FromRawUnchecked(rawData);
}
