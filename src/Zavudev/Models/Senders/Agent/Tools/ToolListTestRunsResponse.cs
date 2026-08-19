using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(
    typeof(JsonModelConverter<ToolListTestRunsResponse, ToolListTestRunsResponseFromRaw>)
)]
public sealed record class ToolListTestRunsResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public ToolListTestRunsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolListTestRunsResponse(ToolListTestRunsResponse toolListTestRunsResponse)
        : base(toolListTestRunsResponse) { }
#pragma warning restore CS8618

    public ToolListTestRunsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolListTestRunsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolListTestRunsResponseFromRaw.FromRawUnchecked"/>
    public static ToolListTestRunsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolListTestRunsResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class ToolListTestRunsResponseFromRaw : IFromRawJson<ToolListTestRunsResponse>
{
    /// <inheritdoc/>
    public ToolListTestRunsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolListTestRunsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One run of a tool triggered from the test endpoint. Recorded so a test is verifiable
/// after the fact rather than only visible in the response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required long DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("durationMs");
        }
        init { this._rawData.Set("durationMs", value); }
    }

    /// <summary>
    /// Whether the tool returned without error. A tool that answered with a non-2xx
    /// status is a failed run, not an error of this endpoint.
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public required string ToolID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("toolId");
        }
        init { this._rawData.Set("toolId", value); }
    }

    /// <summary>
    /// Why the run failed, when it did.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// The parameters the tool was called with.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Params
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("params");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The tool's response body, truncated.
    /// </summary>
    public string? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response");
        }
        init { this._rawData.Set("response", value); }
    }

    /// <summary>
    /// HTTP status the tool's webhook returned. Absent for tools that do not go over HTTP.
    /// </summary>
    public long? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusCode");
        }
        init { this._rawData.Set("statusCode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DurationMs;
        _ = this.Success;
        _ = this.ToolID;
        _ = this.Error;
        _ = this.Params;
        _ = this.Response;
        _ = this.StatusCode;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
