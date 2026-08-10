using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(
    typeof(JsonModelConverter<KnowledgeBaseUpdateResponse, KnowledgeBaseUpdateResponseFromRaw>)
)]
public sealed record class KnowledgeBaseUpdateResponse : JsonModel
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

    public KnowledgeBaseUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KnowledgeBaseUpdateResponse(KnowledgeBaseUpdateResponse knowledgeBaseUpdateResponse)
        : base(knowledgeBaseUpdateResponse) { }
#pragma warning restore CS8618

    public KnowledgeBaseUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KnowledgeBaseUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KnowledgeBaseUpdateResponseFromRaw.FromRawUnchecked"/>
    public static KnowledgeBaseUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public KnowledgeBaseUpdateResponse(AgentKnowledgeBase knowledgeBase)
        : this()
    {
        this.KnowledgeBase = knowledgeBase;
    }
}

class KnowledgeBaseUpdateResponseFromRaw : IFromRawJson<KnowledgeBaseUpdateResponse>
{
    /// <inheritdoc/>
    public KnowledgeBaseUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KnowledgeBaseUpdateResponse.FromRawUnchecked(rawData);
}
