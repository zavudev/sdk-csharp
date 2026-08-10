using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.RegulatoryDocuments;

[JsonConverter(
    typeof(JsonModelConverter<
        RegulatoryDocumentListPageResponse,
        RegulatoryDocumentListPageResponseFromRaw
    >)
)]
public sealed record class RegulatoryDocumentListPageResponse : JsonModel
{
    public required IReadOnlyList<RegulatoryDocument> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RegulatoryDocument>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RegulatoryDocument>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public RegulatoryDocumentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocumentListPageResponse(
        RegulatoryDocumentListPageResponse regulatoryDocumentListPageResponse
    )
        : base(regulatoryDocumentListPageResponse) { }
#pragma warning restore CS8618

    public RegulatoryDocumentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryDocumentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryDocumentListPageResponseFromRaw.FromRawUnchecked"/>
    public static RegulatoryDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RegulatoryDocumentListPageResponse(IReadOnlyList<RegulatoryDocument> items)
        : this()
    {
        this.Items = items;
    }
}

class RegulatoryDocumentListPageResponseFromRaw : IFromRawJson<RegulatoryDocumentListPageResponse>
{
    /// <inheritdoc/>
    public RegulatoryDocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegulatoryDocumentListPageResponse.FromRawUnchecked(rawData);
}
