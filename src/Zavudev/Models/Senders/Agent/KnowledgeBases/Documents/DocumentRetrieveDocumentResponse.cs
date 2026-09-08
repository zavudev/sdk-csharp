using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

[JsonConverter(
    typeof(JsonModelConverter<
        DocumentRetrieveDocumentResponse,
        DocumentRetrieveDocumentResponseFromRaw
    >)
)]
public sealed record class DocumentRetrieveDocumentResponse : JsonModel
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

    public DocumentRetrieveDocumentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentRetrieveDocumentResponse(
        DocumentRetrieveDocumentResponse documentRetrieveDocumentResponse
    )
        : base(documentRetrieveDocumentResponse) { }
#pragma warning restore CS8618

    public DocumentRetrieveDocumentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentRetrieveDocumentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentRetrieveDocumentResponseFromRaw.FromRawUnchecked"/>
    public static DocumentRetrieveDocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DocumentRetrieveDocumentResponse(AgentDocument document)
        : this()
    {
        this.Document = document;
    }
}

class DocumentRetrieveDocumentResponseFromRaw : IFromRawJson<DocumentRetrieveDocumentResponse>
{
    /// <inheritdoc/>
    public DocumentRetrieveDocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentRetrieveDocumentResponse.FromRawUnchecked(rawData);
}
