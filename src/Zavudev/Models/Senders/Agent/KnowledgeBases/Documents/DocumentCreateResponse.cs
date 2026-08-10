using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentCreateResponse, DocumentCreateResponseFromRaw>))]
public sealed record class DocumentCreateResponse : JsonModel
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

    public DocumentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentCreateResponse(DocumentCreateResponse documentCreateResponse)
        : base(documentCreateResponse) { }
#pragma warning restore CS8618

    public DocumentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentCreateResponseFromRaw.FromRawUnchecked"/>
    public static DocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DocumentCreateResponse(AgentDocument document)
        : this()
    {
        this.Document = document;
    }
}

class DocumentCreateResponseFromRaw : IFromRawJson<DocumentCreateResponse>
{
    /// <inheritdoc/>
    public DocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentCreateResponse.FromRawUnchecked(rawData);
}
