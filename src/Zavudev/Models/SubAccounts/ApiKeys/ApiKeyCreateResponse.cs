using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.SubAccounts.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyCreateResponse, ApiKeyCreateResponseFromRaw>))]
public sealed record class ApiKeyCreateResponse : JsonModel
{
    public required ApiKey ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiKey>("apiKey");
        }
        init { this._rawData.Set("apiKey", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ApiKey.Validate();
    }

    public ApiKeyCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyCreateResponse(ApiKeyCreateResponse apiKeyCreateResponse)
        : base(apiKeyCreateResponse) { }
#pragma warning restore CS8618

    public ApiKeyCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyCreateResponseFromRaw.FromRawUnchecked"/>
    public static ApiKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyCreateResponse(ApiKey apiKey)
        : this()
    {
        this.ApiKey = apiKey;
    }
}

class ApiKeyCreateResponseFromRaw : IFromRawJson<ApiKeyCreateResponse>
{
    /// <inheritdoc/>
    public ApiKeyCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
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

    public required ApiEnum<string, ApiKeyEnvironment> Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ApiKeyEnvironment>>("environment");
        }
        init { this._rawData.Set("environment", value); }
    }

    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Environment.Validate();
        _ = this.Key;
        _ = this.Name;
    }

    public ApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ApiKeyEnvironmentConverter))]
public enum ApiKeyEnvironment
{
    Live,
    Test,
}

sealed class ApiKeyEnvironmentConverter : JsonConverter<ApiKeyEnvironment>
{
    public override ApiKeyEnvironment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "live" => ApiKeyEnvironment.Live,
            "test" => ApiKeyEnvironment.Test,
            _ => (ApiKeyEnvironment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiKeyEnvironment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ApiKeyEnvironment.Live => "live",
                ApiKeyEnvironment.Test => "test",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
