using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.RegulatoryDocuments;

[JsonConverter(
    typeof(JsonModelConverter<
        RegulatoryDocumentCreateResponse,
        RegulatoryDocumentCreateResponseFromRaw
    >)
)]
public sealed record class RegulatoryDocumentCreateResponse : JsonModel
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

    public RegulatoryDocumentCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocumentCreateResponse(
        RegulatoryDocumentCreateResponse regulatoryDocumentCreateResponse
    )
        : base(regulatoryDocumentCreateResponse) { }
#pragma warning restore CS8618

    public RegulatoryDocumentCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryDocumentCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryDocumentCreateResponseFromRaw.FromRawUnchecked"/>
    public static RegulatoryDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RegulatoryDocumentCreateResponse(RegulatoryDocument document)
        : this()
    {
        this.Document = document;
    }
}

class RegulatoryDocumentCreateResponseFromRaw : IFromRawJson<RegulatoryDocumentCreateResponse>
{
    /// <inheritdoc/>
    public RegulatoryDocumentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegulatoryDocumentCreateResponse.FromRawUnchecked(rawData);
}
