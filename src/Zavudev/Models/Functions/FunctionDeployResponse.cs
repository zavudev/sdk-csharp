using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<FunctionDeployResponse, FunctionDeployResponseFromRaw>))]
public sealed record class FunctionDeployResponse : JsonModel
{
    public required Deployment Deployment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Deployment>("deployment");
        }
        init { this._rawData.Set("deployment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Deployment.Validate();
    }

    public FunctionDeployResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionDeployResponse(FunctionDeployResponse functionDeployResponse)
        : base(functionDeployResponse) { }
#pragma warning restore CS8618

    public FunctionDeployResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionDeployResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionDeployResponseFromRaw.FromRawUnchecked"/>
    public static FunctionDeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionDeployResponse(Deployment deployment)
        : this()
    {
        this.Deployment = deployment;
    }
}

class FunctionDeployResponseFromRaw : IFromRawJson<FunctionDeployResponse>
{
    /// <inheritdoc/>
    public FunctionDeployResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionDeployResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Deployment, DeploymentFromRaw>))]
public sealed record class Deployment : JsonModel
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
    public required ApiEnum<string, DeploymentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DeploymentStatus>>("status");
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
    /// What the build printed: dependency installation, the bundler's output, and
    /// the compiler's message when it failed. Returned when fetching a single deployment,
    /// omitted from the list. Read this first when a deploy fails — `errorMessage`
    /// is often the outer wrapper's summary, and the line that names the broken
    /// import or the syntax error is here.
    /// </summary>
    public string? BuildLogs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("buildLogs");
        }
        init { this._rawData.Set("buildLogs", value); }
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
        _ = this.BuildLogs;
        _ = this.BundleBytes;
        _ = this.DeployedAt;
        _ = this.ErrorMessage;
        _ = this.SourceCodeBytes;
    }

    public Deployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Deployment(Deployment deployment)
        : base(deployment) { }
#pragma warning restore CS8618

    public Deployment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Deployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeploymentFromRaw.FromRawUnchecked"/>
    public static Deployment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeploymentFromRaw : IFromRawJson<Deployment>
{
    /// <inheritdoc/>
    public Deployment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Deployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Stage of a function deployment.
/// </summary>
[JsonConverter(typeof(DeploymentStatusConverter))]
public enum DeploymentStatus
{
    Pending,
    Bundling,
    Uploading,
    Publishing,
    Active,
    Failed,
    Superseded,
}

sealed class DeploymentStatusConverter : JsonConverter<DeploymentStatus>
{
    public override DeploymentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => DeploymentStatus.Pending,
            "bundling" => DeploymentStatus.Bundling,
            "uploading" => DeploymentStatus.Uploading,
            "publishing" => DeploymentStatus.Publishing,
            "active" => DeploymentStatus.Active,
            "failed" => DeploymentStatus.Failed,
            "superseded" => DeploymentStatus.Superseded,
            _ => (DeploymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeploymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DeploymentStatus.Pending => "pending",
                DeploymentStatus.Bundling => "bundling",
                DeploymentStatus.Uploading => "uploading",
                DeploymentStatus.Publishing => "publishing",
                DeploymentStatus.Active => "active",
                DeploymentStatus.Failed => "failed",
                DeploymentStatus.Superseded => "superseded",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
