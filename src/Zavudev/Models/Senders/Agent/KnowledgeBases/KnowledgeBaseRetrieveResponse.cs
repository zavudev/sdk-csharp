using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(
    typeof(JsonModelConverter<KnowledgeBaseRetrieveResponse, KnowledgeBaseRetrieveResponseFromRaw>)
)]
public sealed record class KnowledgeBaseRetrieveResponse : JsonModel
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

    public KnowledgeBaseRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeBaseRetrieveResponse(
        KnowledgeBaseRetrieveResponse knowledgeBaseRetrieveResponse
    )
        : base(knowledgeBaseRetrieveResponse) { }
#pragma warning restore CS8618

    public KnowledgeBaseRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeBaseRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnowledgeBaseRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static KnowledgeBaseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public KnowledgeBaseRetrieveResponse(AgentKnowledgeBase knowledgeBase)
        : this()
    {
        this.KnowledgeBase = knowledgeBase;
    }
}

class KnowledgeBaseRetrieveResponseFromRaw : IFromRawJson<KnowledgeBaseRetrieveResponse>
{
    /// <inheritdoc/>
    public KnowledgeBaseRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KnowledgeBaseRetrieveResponse.FromRawUnchecked(rawData);
}
