using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(
    typeof(JsonModelConverter<KnowledgeBaseListPageResponse, KnowledgeBaseListPageResponseFromRaw>)
)]
public sealed record class KnowledgeBaseListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentKnowledgeBase> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentKnowledgeBase>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentKnowledgeBase>>(
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

    public KnowledgeBaseListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeBaseListPageResponse(
        KnowledgeBaseListPageResponse knowledgeBaseListPageResponse
    )
        : base(knowledgeBaseListPageResponse) { }
#pragma warning restore CS8618

    public KnowledgeBaseListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeBaseListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnowledgeBaseListPageResponseFromRaw.FromRawUnchecked"/>
    public static KnowledgeBaseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public KnowledgeBaseListPageResponse(IReadOnlyList<AgentKnowledgeBase> items)
        : this()
    {
        this.Items = items;
    }
}

class KnowledgeBaseListPageResponseFromRaw : IFromRawJson<KnowledgeBaseListPageResponse>
{
    /// <inheritdoc/>
    public KnowledgeBaseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KnowledgeBaseListPageResponse.FromRawUnchecked(rawData);
}
