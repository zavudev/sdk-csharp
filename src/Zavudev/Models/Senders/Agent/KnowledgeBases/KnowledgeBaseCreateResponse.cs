using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(
    typeof(JsonModelConverter<KnowledgeBaseCreateResponse, KnowledgeBaseCreateResponseFromRaw>)
)]
public sealed record class KnowledgeBaseCreateResponse : JsonModel
{
    public required AgentKnowledgeBase KnowledgeBase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentKnowledgeBase>("knowledgeBase");
        }
        init { this._rawData.Set("knowledgeBase", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.KnowledgeBase.Validate();
    }

    public KnowledgeBaseCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeBaseCreateResponse(KnowledgeBaseCreateResponse knowledgeBaseCreateResponse)
        : base(knowledgeBaseCreateResponse) { }
#pragma warning restore CS8618

    public KnowledgeBaseCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeBaseCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnowledgeBaseCreateResponseFromRaw.FromRawUnchecked"/>
    public static KnowledgeBaseCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public KnowledgeBaseCreateResponse(AgentKnowledgeBase knowledgeBase)
        : this()
    {
        this.KnowledgeBase = knowledgeBase;
    }
}

class KnowledgeBaseCreateResponseFromRaw : IFromRawJson<KnowledgeBaseCreateResponse>
{
    /// <inheritdoc/>
    public KnowledgeBaseCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KnowledgeBaseCreateResponse.FromRawUnchecked(rawData);
}
