using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Messages;

namespace Zavudev.Models.Conversations;

[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListMessagesPageResponse,
        ConversationListMessagesPageResponseFromRaw
    >)
)]
public sealed record class ConversationListMessagesPageResponse : JsonModel
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

    public ConversationListMessagesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListMessagesPageResponse(
        ConversationListMessagesPageResponse conversationListMessagesPageResponse
    )
        : base(conversationListMessagesPageResponse) { }
#pragma warning restore CS8618

    public ConversationListMessagesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListMessagesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListMessagesPageResponseFromRaw.FromRawUnchecked"/>
    public static ConversationListMessagesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversationListMessagesPageResponse(IReadOnlyList<Message> items)
        : this()
    {
        this.Items = items;
    }
}

class ConversationListMessagesPageResponseFromRaw
    : IFromRawJson<ConversationListMessagesPageResponse>
{
    /// <inheritdoc/>
    public ConversationListMessagesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListMessagesPageResponse.FromRawUnchecked(rawData);
}
