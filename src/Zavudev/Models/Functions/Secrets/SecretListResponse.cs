using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions.Secrets;

[JsonConverter(typeof(JsonModelConverter<SecretListResponse, SecretListResponseFromRaw>))]
public sealed record class SecretListResponse : JsonModel
{
    public required IReadOnlyList<Secret> Secrets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Secret>>("secrets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Secret>>(
                "secrets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Secrets)
        {
            item.Validate();
        }
    }

    public SecretListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SecretListResponse(SecretListResponse secretListResponse)
        : base(secretListResponse) { }
#pragma warning restore CS8618

    public SecretListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SecretListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretListResponseFromRaw.FromRawUnchecked"/>
    public static SecretListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SecretListResponse(IReadOnlyList<Secret> secrets)
        : this()
    {
        this.Secrets = secrets;
    }
}

class SecretListResponseFromRaw : IFromRawJson<SecretListResponse>
{
    /// <inheritdoc/>
    public SecretListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SecretListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Secret, SecretFromRaw>))]
public sealed record class Secret : JsonModel
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

    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    public required string ValueLast4
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("valueLast4");
        }
        init { this._rawData.Set("valueLast4", value); }
    }

    public double? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    public bool? SyncedToAws
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("syncedToAws");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("syncedToAws", value);
        }
    }

    public double? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Key;
        _ = this.ValueLast4;
        _ = this.CreatedAt;
        _ = this.SyncedToAws;
        _ = this.UpdatedAt;
    }

    public Secret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Secret(Secret secret)
        : base(secret) { }
#pragma warning restore CS8618

    public Secret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Secret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SecretFromRaw.FromRawUnchecked"/>
    public static Secret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SecretFromRaw : IFromRawJson<Secret>
{
    /// <inheritdoc/>
    public Secret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Secret.FromRawUnchecked(rawData);
}
