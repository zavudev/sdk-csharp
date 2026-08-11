using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

[JsonConverter(
    typeof(JsonModelConverter<FunctionGetDeploymentResponse, FunctionGetDeploymentResponseFromRaw>)
)]
public sealed record class FunctionGetDeploymentResponse : JsonModel
{
    public required FunctionGetDeploymentResponseDeployment Deployment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionGetDeploymentResponseDeployment>(
                "deployment"
            );
        }
        init { this._rawData.Set("deployment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Deployment.Validate();
    }

    public FunctionGetDeploymentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetDeploymentResponse(
        FunctionGetDeploymentResponse functionGetDeploymentResponse
    )
        : base(functionGetDeploymentResponse) { }
#pragma warning restore CS8618

    public FunctionGetDeploymentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetDeploymentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionGetDeploymentResponseFromRaw.FromRawUnchecked"/>
    public static FunctionGetDeploymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionGetDeploymentResponse(FunctionGetDeploymentResponseDeployment deployment)
        : this()
    {
        this.Deployment = deployment;
    }
}

class FunctionGetDeploymentResponseFromRaw : IFromRawJson<FunctionGetDeploymentResponse>
{
    /// <inheritdoc/>
    public FunctionGetDeploymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionGetDeploymentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionGetDeploymentResponseDeployment,
        FunctionGetDeploymentResponseDeploymentFromRaw
    >)
)]
public sealed record class FunctionGetDeploymentResponseDeployment : JsonModel
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

    public required string FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionId");
        }
        init { this._rawData.Set("functionId", value); }
    }

    /// <summary>
    /// Stage of a function deployment.
    /// </summary>
    public required ApiEnum<string, FunctionGetDeploymentResponseDeploymentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionGetDeploymentResponseDeploymentStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Monotonically increasing deployment version, starting at 1.
    /// </summary>
    public required long Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// Size of the built bundle in bytes. Null until the build finishes.
    /// </summary>
    public long? BundleBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bundleBytes");
        }
        init { this._rawData.Set("bundleBytes", value); }
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

    /// <summary>
    /// Failure reason when status is 'failed'.
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    /// <summary>
    /// Total size of the deployed source tree in bytes.
    /// </summary>
    public long? SourceCodeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sourceCodeBytes");
        }
        init { this._rawData.Set("sourceCodeBytes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FunctionID;
        this.Status.Validate();
        _ = this.Version;
        _ = this.BundleBytes;
        _ = this.DeployedAt;
        _ = this.ErrorMessage;
        _ = this.SourceCodeBytes;
    }

    public FunctionGetDeploymentResponseDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionGetDeploymentResponseDeployment(
        FunctionGetDeploymentResponseDeployment functionGetDeploymentResponseDeployment
    )
        : base(functionGetDeploymentResponseDeployment) { }
#pragma warning restore CS8618

    public FunctionGetDeploymentResponseDeployment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionGetDeploymentResponseDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionGetDeploymentResponseDeploymentFromRaw.FromRawUnchecked"/>
    public static FunctionGetDeploymentResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionGetDeploymentResponseDeploymentFromRaw
    : IFromRawJson<FunctionGetDeploymentResponseDeployment>
{
    /// <inheritdoc/>
    public FunctionGetDeploymentResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionGetDeploymentResponseDeployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Stage of a function deployment.
/// </summary>
[JsonConverter(typeof(FunctionGetDeploymentResponseDeploymentStatusConverter))]
public enum FunctionGetDeploymentResponseDeploymentStatus
{
    Pending,
    Bundling,
    Uploading,
    Publishing,
    Active,
    Failed,
    Superseded,
}

sealed class FunctionGetDeploymentResponseDeploymentStatusConverter
    : JsonConverter<FunctionGetDeploymentResponseDeploymentStatus>
{
    public override FunctionGetDeploymentResponseDeploymentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => FunctionGetDeploymentResponseDeploymentStatus.Pending,
            "bundling" => FunctionGetDeploymentResponseDeploymentStatus.Bundling,
            "uploading" => FunctionGetDeploymentResponseDeploymentStatus.Uploading,
            "publishing" => FunctionGetDeploymentResponseDeploymentStatus.Publishing,
            "active" => FunctionGetDeploymentResponseDeploymentStatus.Active,
            "failed" => FunctionGetDeploymentResponseDeploymentStatus.Failed,
            "superseded" => FunctionGetDeploymentResponseDeploymentStatus.Superseded,
            _ => (FunctionGetDeploymentResponseDeploymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionGetDeploymentResponseDeploymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionGetDeploymentResponseDeploymentStatus.Pending => "pending",
                FunctionGetDeploymentResponseDeploymentStatus.Bundling => "bundling",
                FunctionGetDeploymentResponseDeploymentStatus.Uploading => "uploading",
                FunctionGetDeploymentResponseDeploymentStatus.Publishing => "publishing",
                FunctionGetDeploymentResponseDeploymentStatus.Active => "active",
                FunctionGetDeploymentResponseDeploymentStatus.Failed => "failed",
                FunctionGetDeploymentResponseDeploymentStatus.Superseded => "superseded",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
