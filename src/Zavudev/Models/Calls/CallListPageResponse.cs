using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallListPageResponse, CallListPageResponseFromRaw>))]
public sealed record class CallListPageResponse : JsonModel
{
    public required IReadOnlyList<CallListResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CallListResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CallListResponse>>(
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

    public CallListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallListPageResponse(CallListPageResponse callListPageResponse)
        : base(callListPageResponse) { }
#pragma warning restore CS8618

    public CallListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallListPageResponseFromRaw.FromRawUnchecked"/>
    public static CallListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CallListPageResponse(IReadOnlyList<CallListResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class CallListPageResponseFromRaw : IFromRawJson<CallListPageResponse>
{
    /// <inheritdoc/>
    public CallListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallListPageResponse.FromRawUnchecked(rawData);
}
