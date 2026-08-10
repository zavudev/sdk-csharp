using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(
    typeof(JsonModelConverter<SubAccountListPageResponse, SubAccountListPageResponseFromRaw>)
)]
public sealed record class SubAccountListPageResponse : JsonModel
{
    public required IReadOnlyList<SubAccount> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubAccount>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubAccount>>(
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

    public SubAccountListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccountListPageResponse(SubAccountListPageResponse subAccountListPageResponse)
        : base(subAccountListPageResponse) { }
#pragma warning restore CS8618

    public SubAccountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountListPageResponseFromRaw.FromRawUnchecked"/>
    public static SubAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubAccountListPageResponse(IReadOnlyList<SubAccount> items)
        : this()
    {
        this.Items = items;
    }
}

class SubAccountListPageResponseFromRaw : IFromRawJson<SubAccountListPageResponse>
{
    /// <inheritdoc/>
    public SubAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubAccountListPageResponse.FromRawUnchecked(rawData);
}
