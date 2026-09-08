using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.AgentTemplates;

[JsonConverter(
    typeof(JsonModelConverter<AgentTemplateListResponse, AgentTemplateListResponseFromRaw>)
)]
public sealed record class AgentTemplateListResponse : JsonModel
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

    public AgentTemplateListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTemplateListResponse(AgentTemplateListResponse agentTemplateListResponse)
        : base(agentTemplateListResponse) { }
#pragma warning restore CS8618

    public AgentTemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentTemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentTemplateListResponseFromRaw.FromRawUnchecked"/>
    public static AgentTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentTemplateListResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class AgentTemplateListResponseFromRaw : IFromRawJson<AgentTemplateListResponse>
{
    /// <inheritdoc/>
    public AgentTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentTemplateListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Compact catalog entry for a factory agent.
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

    public required ApiEnum<string, ItemCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ItemCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    public required long ToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("toolCount");
        }
        init { this._rawData.Set("toolCount", value); }
    }

    /// <summary>
    /// Whether this agent answers phone calls.
    /// </summary>
    public required bool Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("voice");
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Category.Validate();
        _ = this.Name;
        _ = this.Summary;
        _ = this.ToolCount;
        _ = this.Voice;
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

[JsonConverter(typeof(ItemCategoryConverter))]
public enum ItemCategory
{
    Sales,
    Support,
    FrontDesk,
    Ops,
}

sealed class ItemCategoryConverter : JsonConverter<ItemCategory>
{
    public override ItemCategory Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sales" => ItemCategory.Sales,
            "support" => ItemCategory.Support,
            "frontDesk" => ItemCategory.FrontDesk,
            "ops" => ItemCategory.Ops,
            _ => (ItemCategory)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ItemCategory.Sales => "sales",
                ItemCategory.Support => "support",
                ItemCategory.FrontDesk => "frontDesk",
                ItemCategory.Ops => "ops",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
