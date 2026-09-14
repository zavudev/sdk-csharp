using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListEventTypesResponse,
        FunctionListEventTypesResponseFromRaw
    >)
)]
public sealed record class FunctionListEventTypesResponse : JsonModel
{
    public required IReadOnlyList<string> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Events;
    }

    public FunctionListEventTypesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListEventTypesResponse(
        FunctionListEventTypesResponse functionListEventTypesResponse
    )
        : base(functionListEventTypesResponse) { }
#pragma warning restore CS8618

    public FunctionListEventTypesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListEventTypesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListEventTypesResponseFromRaw.FromRawUnchecked"/>
    public static FunctionListEventTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionListEventTypesResponse(IReadOnlyList<string> events)
        : this()
    {
        this.Events = events;
    }
}

class FunctionListEventTypesResponseFromRaw : IFromRawJson<FunctionListEventTypesResponse>
{
    /// <inheritdoc/>
    public FunctionListEventTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListEventTypesResponse.FromRawUnchecked(rawData);
}
