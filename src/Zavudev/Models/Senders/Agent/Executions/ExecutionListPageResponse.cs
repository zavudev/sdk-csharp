using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Executions;

[JsonConverter(
    typeof(JsonModelConverter<ExecutionListPageResponse, ExecutionListPageResponseFromRaw>)
)]
public sealed record class ExecutionListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentExecution> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentExecution>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentExecution>>(
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

    public ExecutionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionListPageResponse(ExecutionListPageResponse executionListPageResponse)
        : base(executionListPageResponse) { }
#pragma warning restore CS8618

    public ExecutionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExecutionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionListPageResponse(IReadOnlyList<AgentExecution> items)
        : this()
    {
        this.Items = items;
    }
}

class ExecutionListPageResponseFromRaw : IFromRawJson<ExecutionListPageResponse>
{
    /// <inheritdoc/>
    public ExecutionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionListPageResponse.FromRawUnchecked(rawData);
}
