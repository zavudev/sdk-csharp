using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListPageResponse, MessageListPageResponseFromRaw>))]
public sealed record class MessageListPageResponse : JsonModel
{
    public required IReadOnlyList<Message> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Message>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Message>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public MessageListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListPageResponse(MessageListPageResponse messageListPageResponse)
        : base(messageListPageResponse) { }
#pragma warning restore CS8618

    public MessageListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageListPageResponseFromRaw.FromRawUnchecked"/>
    public static MessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageListPageResponse(IReadOnlyList<Message> items)
        : this()
    {
        this.Items = items;
    }
}

class MessageListPageResponseFromRaw : IFromRawJson<MessageListPageResponse>
{
    /// <inheritdoc/>
    public MessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageListPageResponse.FromRawUnchecked(rawData);
}
