using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

[JsonConverter(
    typeof(JsonModelConverter<DocumentListPageResponse, DocumentListPageResponseFromRaw>)
)]
public sealed record class DocumentListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentDocument> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentDocument>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentDocument>>(
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

    public DocumentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentListPageResponse(DocumentListPageResponse documentListPageResponse)
        : base(documentListPageResponse) { }
#pragma warning restore CS8618

    public DocumentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentListPageResponseFromRaw.FromRawUnchecked"/>
    public static DocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DocumentListPageResponse(IReadOnlyList<AgentDocument> items)
        : this()
    {
        this.Items = items;
    }
}

class DocumentListPageResponseFromRaw : IFromRawJson<DocumentListPageResponse>
{
    /// <inheritdoc/>
    public DocumentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DocumentListPageResponse.FromRawUnchecked(rawData);
}
