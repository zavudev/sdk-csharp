using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<MessageShowTypingResponse, MessageShowTypingResponseFromRaw>)
)]
public sealed record class MessageShowTypingResponse : JsonModel
{
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
    }

    public MessageShowTypingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageShowTypingResponse(MessageShowTypingResponse messageShowTypingResponse)
        : base(messageShowTypingResponse) { }
#pragma warning restore CS8618

    public MessageShowTypingResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageShowTypingResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageShowTypingResponseFromRaw.FromRawUnchecked"/>
    public static MessageShowTypingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageShowTypingResponse(bool success)
        : this()
    {
        this.Success = success;
    }
}

class MessageShowTypingResponseFromRaw : IFromRawJson<MessageShowTypingResponse>
{
    /// <inheritdoc/>
    public MessageShowTypingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageShowTypingResponse.FromRawUnchecked(rawData);
}
