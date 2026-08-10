using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.SubAccounts.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyListResponse, ApiKeyListResponseFromRaw>))]
public sealed record class ApiKeyListResponse : JsonModel
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

    public ApiKeyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyListResponse(ApiKeyListResponse apiKeyListResponse)
        : base(apiKeyListResponse) { }
#pragma warning restore CS8618

    public ApiKeyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyListResponseFromRaw.FromRawUnchecked"/>
    public static ApiKeyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyListResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class ApiKeyListResponseFromRaw : IFromRawJson<ApiKeyListResponse>
{
    /// <inheritdoc/>
    public ApiKeyListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKeyListResponse.FromRawUnchecked(rawData);
}

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

    public required double CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required ApiEnum<string, ItemEnvironment> Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ItemEnvironment>>("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    /// <summary>
    /// First characters of the key for identification.
    /// </summary>
    public required string KeyPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("keyPrefix");
        }
        init { this._rawData.Set("keyPrefix", value); }
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

    /// <summary>
    /// Full API key. Only returned on creation.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    public double? LastUsedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("lastUsedAt");
        }
        init { this._rawData.Set("lastUsedAt", value); }
    }

    public IReadOnlyList<string>? Permissions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("permissions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "permissions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public double? RevokedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("revokedAt");
        }
        init { this._rawData.Set("revokedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Environment.Validate();
        _ = this.KeyPrefix;
        _ = this.Name;
        _ = this.Key;
        _ = this.LastUsedAt;
        _ = this.Permissions;
        _ = this.RevokedAt;
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

[JsonConverter(typeof(ItemEnvironmentConverter))]
public enum ItemEnvironment
{
    Live,
    Test,
}

sealed class ItemEnvironmentConverter : JsonConverter<ItemEnvironment>
{
    public override ItemEnvironment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "live" => ItemEnvironment.Live,
            "test" => ItemEnvironment.Test,
            _ => (ItemEnvironment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemEnvironment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ItemEnvironment.Live => "live",
                ItemEnvironment.Test => "test",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
