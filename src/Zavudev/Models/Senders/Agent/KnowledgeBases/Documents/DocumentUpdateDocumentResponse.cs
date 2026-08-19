using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

[JsonConverter(
    typeof(JsonModelConverter<
        DocumentUpdateDocumentResponse,
        DocumentUpdateDocumentResponseFromRaw
    >)
)]
public sealed record class DocumentUpdateDocumentResponse : JsonModel
{
    public required AgentDocument Document
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentDocument>("document");
        }
        init { this._rawData.Set("document", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Document.Validate();
    }

    public DocumentUpdateDocumentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentUpdateDocumentResponse(
        DocumentUpdateDocumentResponse documentUpdateDocumentResponse
    )
        : base(documentUpdateDocumentResponse) { }
#pragma warning restore CS8618

    public DocumentUpdateDocumentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentUpdateDocumentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentUpdateDocumentResponseFromRaw.FromRawUnchecked"/>
    public static DocumentUpdateDocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DocumentUpdateDocumentResponse(AgentDocument document)
        : this()
    {
        this.Document = document;
    }
}

class DocumentUpdateDocumentResponseFromRaw : IFromRawJson<DocumentUpdateDocumentResponse>
{
    /// <inheritdoc/>
    public DocumentUpdateDocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentUpdateDocumentResponse.FromRawUnchecked(rawData);
}
