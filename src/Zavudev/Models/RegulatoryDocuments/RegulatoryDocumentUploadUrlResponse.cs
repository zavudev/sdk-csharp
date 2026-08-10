using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.RegulatoryDocuments;

[JsonConverter(
    typeof(JsonModelConverter<
        RegulatoryDocumentUploadUrlResponse,
        RegulatoryDocumentUploadUrlResponseFromRaw
    >)
)]
public sealed record class RegulatoryDocumentUploadUrlResponse : JsonModel
{
    /// <summary>
    /// Pre-signed URL for uploading the file.
    /// </summary>
    public required string UploadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("uploadUrl");
        }
        init { this._rawData.Set("uploadUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UploadUrl;
    }

    public RegulatoryDocumentUploadUrlResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocumentUploadUrlResponse(
        RegulatoryDocumentUploadUrlResponse regulatoryDocumentUploadUrlResponse
    )
        : base(regulatoryDocumentUploadUrlResponse) { }
#pragma warning restore CS8618

    public RegulatoryDocumentUploadUrlResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryDocumentUploadUrlResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryDocumentUploadUrlResponseFromRaw.FromRawUnchecked"/>
    public static RegulatoryDocumentUploadUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RegulatoryDocumentUploadUrlResponse(string uploadUrl)
        : this()
    {
        this.UploadUrl = uploadUrl;
    }
}

class RegulatoryDocumentUploadUrlResponseFromRaw : IFromRawJson<RegulatoryDocumentUploadUrlResponse>
{
    /// <inheritdoc/>
    public RegulatoryDocumentUploadUrlResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegulatoryDocumentUploadUrlResponse.FromRawUnchecked(rawData);
}
