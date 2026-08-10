using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.RegulatoryDocuments;

[JsonConverter(
    typeof(JsonModelConverter<
        RegulatoryDocumentRetrieveResponse,
        RegulatoryDocumentRetrieveResponseFromRaw
    >)
)]
public sealed record class RegulatoryDocumentRetrieveResponse : JsonModel
{
    /// <summary>
    /// A regulatory document for phone number requirements.
    /// </summary>
    public required RegulatoryDocument Document
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RegulatoryDocument>("document");
        }
        init { this._rawData.Set("document", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Document.Validate();
    }

    public RegulatoryDocumentRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocumentRetrieveResponse(
        RegulatoryDocumentRetrieveResponse regulatoryDocumentRetrieveResponse
    )
        : base(regulatoryDocumentRetrieveResponse) { }
#pragma warning restore CS8618

    public RegulatoryDocumentRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryDocumentRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryDocumentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RegulatoryDocumentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RegulatoryDocumentRetrieveResponse(RegulatoryDocument document)
        : this()
    {
        this.Document = document;
    }
}

class RegulatoryDocumentRetrieveResponseFromRaw : IFromRawJson<RegulatoryDocumentRetrieveResponse>
{
    /// <inheritdoc/>
    public RegulatoryDocumentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegulatoryDocumentRetrieveResponse.FromRawUnchecked(rawData);
}
