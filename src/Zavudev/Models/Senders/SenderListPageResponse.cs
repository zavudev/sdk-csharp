using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(typeof(JsonModelConverter<SenderListPageResponse, SenderListPageResponseFromRaw>))]
public sealed record class SenderListPageResponse : JsonModel
{
    public required IReadOnlyList<Sender> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Sender>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Sender>>(
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

    public SenderListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderListPageResponse(SenderListPageResponse senderListPageResponse)
        : base(senderListPageResponse) { }
#pragma warning restore CS8618

    public SenderListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderListPageResponseFromRaw.FromRawUnchecked"/>
    public static SenderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SenderListPageResponse(IReadOnlyList<Sender> items)
        : this()
    {
        this.Items = items;
    }
}

class SenderListPageResponseFromRaw : IFromRawJson<SenderListPageResponse>
{
    /// <inheritdoc/>
    public SenderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SenderListPageResponse.FromRawUnchecked(rawData);
}
