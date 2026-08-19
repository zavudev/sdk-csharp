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
    typeof(JsonModelConverter<
        FunctionRollbackDeploymentResponse,
        FunctionRollbackDeploymentResponseFromRaw
    >)
)]
public sealed record class FunctionRollbackDeploymentResponse : JsonModel
{
    public required FunctionRollbackDeploymentResponseDeployment Deployment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionRollbackDeploymentResponseDeployment>(
                "deployment"
            );
        }
        init { this._rawData.Set("deployment", value); }
    }

    /// <summary>
    /// The draft that was replaced, so a UI can offer to restore it.
    /// </summary>
    public JsonElement? PreviousDraft
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("previousDraft");
        }
        init { this._rawData.Set("previousDraft", value); }
    }

    public long? RolledBackToVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("rolledBackToVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rolledBackToVersion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Deployment.Validate();
        _ = this.PreviousDraft;
        _ = this.RolledBackToVersion;
    }

    public FunctionRollbackDeploymentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionRollbackDeploymentResponse(
        FunctionRollbackDeploymentResponse functionRollbackDeploymentResponse
    )
        : base(functionRollbackDeploymentResponse) { }
#pragma warning restore CS8618

    public FunctionRollbackDeploymentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionRollbackDeploymentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionRollbackDeploymentResponseFromRaw.FromRawUnchecked"/>
    public static FunctionRollbackDeploymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionRollbackDeploymentResponse(
        FunctionRollbackDeploymentResponseDeployment deployment
    )
        : this()
    {
        this.Deployment = deployment;
    }
}

class FunctionRollbackDeploymentResponseFromRaw : IFromRawJson<FunctionRollbackDeploymentResponse>
{
    /// <inheritdoc/>
    public FunctionRollbackDeploymentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionRollbackDeploymentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FunctionRollbackDeploymentResponseDeployment,
        FunctionRollbackDeploymentResponseDeploymentFromRaw
    >)
)]
public sealed record class FunctionRollbackDeploymentResponseDeployment : JsonModel
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
    public required ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionRollbackDeploymentResponseDeploymentStatus>
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

    public FunctionRollbackDeploymentResponseDeployment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionRollbackDeploymentResponseDeployment(
        FunctionRollbackDeploymentResponseDeployment functionRollbackDeploymentResponseDeployment
    )
        : base(functionRollbackDeploymentResponseDeployment) { }
#pragma warning restore CS8618

    public FunctionRollbackDeploymentResponseDeployment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionRollbackDeploymentResponseDeployment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionRollbackDeploymentResponseDeploymentFromRaw.FromRawUnchecked"/>
    public static FunctionRollbackDeploymentResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionRollbackDeploymentResponseDeploymentFromRaw
    : IFromRawJson<FunctionRollbackDeploymentResponseDeployment>
{
    /// <inheritdoc/>
    public FunctionRollbackDeploymentResponseDeployment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionRollbackDeploymentResponseDeployment.FromRawUnchecked(rawData);
}

/// <summary>
/// Stage of a function deployment.
/// </summary>
[JsonConverter(typeof(FunctionRollbackDeploymentResponseDeploymentStatusConverter))]
public enum FunctionRollbackDeploymentResponseDeploymentStatus
{
    Pending,
    Bundling,
    Uploading,
    Publishing,
    Active,
    Failed,
    Superseded,
}

sealed class FunctionRollbackDeploymentResponseDeploymentStatusConverter
    : JsonConverter<FunctionRollbackDeploymentResponseDeploymentStatus>
{
    public override FunctionRollbackDeploymentResponseDeploymentStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => FunctionRollbackDeploymentResponseDeploymentStatus.Pending,
            "bundling" => FunctionRollbackDeploymentResponseDeploymentStatus.Bundling,
            "uploading" => FunctionRollbackDeploymentResponseDeploymentStatus.Uploading,
            "publishing" => FunctionRollbackDeploymentResponseDeploymentStatus.Publishing,
            "active" => FunctionRollbackDeploymentResponseDeploymentStatus.Active,
            "failed" => FunctionRollbackDeploymentResponseDeploymentStatus.Failed,
            "superseded" => FunctionRollbackDeploymentResponseDeploymentStatus.Superseded,
            _ => (FunctionRollbackDeploymentResponseDeploymentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionRollbackDeploymentResponseDeploymentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionRollbackDeploymentResponseDeploymentStatus.Pending => "pending",
                FunctionRollbackDeploymentResponseDeploymentStatus.Bundling => "bundling",
                FunctionRollbackDeploymentResponseDeploymentStatus.Uploading => "uploading",
                FunctionRollbackDeploymentResponseDeploymentStatus.Publishing => "publishing",
                FunctionRollbackDeploymentResponseDeploymentStatus.Active => "active",
                FunctionRollbackDeploymentResponseDeploymentStatus.Failed => "failed",
                FunctionRollbackDeploymentResponseDeploymentStatus.Superseded => "superseded",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
