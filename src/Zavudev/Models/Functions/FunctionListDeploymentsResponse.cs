using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListDeploymentsResponse,
        FunctionListDeploymentsResponseFromRaw
    >)
)]
public sealed record class FunctionListDeploymentsResponse : JsonModel
{
    public required IReadOnlyList<FunctionListDeploymentsResponseDeployment> Deployments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FunctionListDeploymentsResponseDeployment>
            >("deployments");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FunctionListDeploymentsResponseDeployment>>(
                "deployments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Deployments)
        {
            item.Validate();
        }
    }

    public FunctionListDeploymentsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListDeploymentsResponse(
        FunctionListDeploymentsResponse functionListDeploymentsResponse
    )
        : base(functionListDeploymentsResponse) { }
#pragma warning restore CS8618

    public FunctionListDeploymentsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListDeploymentsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListDeploymentsResponseFromRaw.FromRawUnchecked"/>
    public static FunctionListDeploymentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionListDeploymentsResponse(
        IReadOnlyList<FunctionListDeploymentsResponseDeployment> deployments
    )
        : this()
    {
        this.Deployments = deployments;
    }
}

class FunctionListDeploymentsResponseFromRaw : IFromRawJson<FunctionListDeploymentsResponse>
{
    /// <inheritdoc/>
    public FunctionListDeploymentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListDeploymentsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionListDeploymentsResponseDeployment,
        FunctionListDeploymentsResponseDeploymentFromRaw
    >)
)]
public sealed record class FunctionListDeploymentsResponseDeployment : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public long? BundleSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bundleSizeBytes");
        }
        init { this._rawData.Set("bundleSizeBytes", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
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

    public DateTimeOffset? DeployedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("deployedAt");
        }
        init { this._rawData.Set("deployedAt", value); }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isActive", value);
        }
    }

    /// <summary>
    /// Stage of a function deployment.
    /// </summary>
    public ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FunctionListDeploymentsResponseDeploymentStatus>
            >("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public long? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BundleSizeBytes;
        _ = this.CreatedAt;
        _ = this.DeployedAt;
        _ = this.ErrorMessage;
        _ = this.IsActive;
        this.Status?.Validate();
        _ = this.Version;
    }

    public FunctionListDeploymentsResponseDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionListDeploymentsResponseDeployment(
        FunctionListDeploymentsResponseDeployment functionListDeploymentsResponseDeployment
    )
        : base(functionListDeploymentsResponseDeployment) { }
#pragma warning restore CS8618

    public FunctionListDeploymentsResponseDeployment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionListDeploymentsResponseDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionListDeploymentsResponseDeploymentFromRaw.FromRawUnchecked"/>
    public static FunctionListDeploymentsResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionListDeploymentsResponseDeploymentFromRaw
    : IFromRawJson<FunctionListDeploymentsResponseDeployment>
{
    /// <inheritdoc/>
    public FunctionListDeploymentsResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionListDeploymentsResponseDeployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Stage of a function deployment.
/// </summary>
[JsonConverter(typeof(FunctionListDeploymentsResponseDeploymentStatusConverter))]
public enum FunctionListDeploymentsResponseDeploymentStatus
{
    Pending,
    Bundling,
    Uploading,
    Publishing,
    Active,
    Failed,
    Superseded,
}

sealed class FunctionListDeploymentsResponseDeploymentStatusConverter
    : JsonConverter<FunctionListDeploymentsResponseDeploymentStatus>
{
    public override FunctionListDeploymentsResponseDeploymentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => FunctionListDeploymentsResponseDeploymentStatus.Pending,
            "bundling" => FunctionListDeploymentsResponseDeploymentStatus.Bundling,
            "uploading" => FunctionListDeploymentsResponseDeploymentStatus.Uploading,
            "publishing" => FunctionListDeploymentsResponseDeploymentStatus.Publishing,
            "active" => FunctionListDeploymentsResponseDeploymentStatus.Active,
            "failed" => FunctionListDeploymentsResponseDeploymentStatus.Failed,
            "superseded" => FunctionListDeploymentsResponseDeploymentStatus.Superseded,
            _ => (FunctionListDeploymentsResponseDeploymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionListDeploymentsResponseDeploymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionListDeploymentsResponseDeploymentStatus.Pending => "pending",
                FunctionListDeploymentsResponseDeploymentStatus.Bundling => "bundling",
                FunctionListDeploymentsResponseDeploymentStatus.Uploading => "uploading",
                FunctionListDeploymentsResponseDeploymentStatus.Publishing => "publishing",
                FunctionListDeploymentsResponseDeploymentStatus.Active => "active",
                FunctionListDeploymentsResponseDeploymentStatus.Failed => "failed",
                FunctionListDeploymentsResponseDeploymentStatus.Superseded => "superseded",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
