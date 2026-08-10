using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(typeof(JsonModelConverter<AgentDocument, AgentDocumentFromRaw>))]
public sealed record class AgentDocument : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Number of chunks created from this document.
    /// </summary>
    public required long ChunkCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("chunkCount");
        }
        init { this._rawData.Set("chunkCount", value); }
    }

    /// <summary>
    /// Length of the document content in characters.
    /// </summary>
    public required long ContentLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("contentLength");
        }
        init { this._rawData.Set("contentLength", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Whether the document has been processed for RAG.
    /// </summary>
    public required bool IsProcessed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isProcessed");
        }
        init { this._rawData.Set("isProcessed", value); }
    }

    public required string KnowledgeBaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("knowledgeBaseId");
        }
        init { this._rawData.Set("knowledgeBaseId", value); }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChunkCount;
        _ = this.ContentLength;
        _ = this.CreatedAt;
        _ = this.IsProcessed;
        _ = this.KnowledgeBaseID;
        _ = this.Title;
        _ = this.UpdatedAt;
    }

    public AgentDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDocument(AgentDocument agentDocument)
        : base(agentDocument) { }
#pragma warning restore CS8618

    public AgentDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDocumentFromRaw.FromRawUnchecked"/>
    public static AgentDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDocumentFromRaw : IFromRawJson<AgentDocument>
{
    /// <inheritdoc/>
    public AgentDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentDocument.FromRawUnchecked(rawData);
}
