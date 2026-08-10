using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<FunctionUpdateResponse, FunctionUpdateResponseFromRaw>))]
public sealed record class FunctionUpdateResponse : JsonModel
{
    /// <summary>
    /// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
    /// to messaging events or HTTP requests.
    /// </summary>
    public required FunctionUpdateResponseFunction Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionUpdateResponseFunction>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
    }

    public FunctionUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateResponse(FunctionUpdateResponse functionUpdateResponse)
        : base(functionUpdateResponse) { }
#pragma warning restore CS8618

    public FunctionUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionUpdateResponse(FunctionUpdateResponseFunction function)
        : this()
    {
        this.Function = function;
    }
}

class FunctionUpdateResponseFromRaw : IFromRawJson<FunctionUpdateResponse>
{
    /// <inheritdoc/>
    public FunctionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
/// to messaging events or HTTP requests.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionUpdateResponseFunction,
        FunctionUpdateResponseFunctionFromRaw
    >)
)]
public sealed record class FunctionUpdateResponseFunction : JsonModel
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

    /// <summary>
    /// npm dependencies installed in the function bundle. Keys are package names,
    /// values are semver ranges.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Dependencies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("dependencies");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "dependencies",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether the function can be invoked over HTTPS via its public URL.
    /// </summary>
    public required bool HttpEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("httpEnabled");
        }
        init { this._rawData.Set("httpEnabled", value); }
    }

    /// <summary>
    /// Memory allocation in MB.
    /// </summary>
    public required long MemoryMB
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("memoryMb");
        }
        init { this._rawData.Set("memoryMb", value); }
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
    /// Runtime the function is deployed on.
    /// </summary>
    public required ApiEnum<string, FunctionUpdateResponseFunctionRuntime> Runtime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionUpdateResponseFunctionRuntime>
            >("runtime");
        }
        init { this._rawData.Set("runtime", value); }
    }

    /// <summary>
    /// URL-safe identifier, unique per project.
    /// </summary>
    public required string Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slug");
        }
        init { this._rawData.Set("slug", value); }
    }

    /// <summary>
    /// Lifecycle status of a Zavu Function.
    /// </summary>
    public required ApiEnum<string, FunctionUpdateResponseFunctionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionUpdateResponseFunctionStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Per-invocation timeout in seconds.
    /// </summary>
    public required long TimeoutSec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("timeoutSec");
        }
        init { this._rawData.Set("timeoutSec", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// ID of the deployment currently serving traffic.
    /// </summary>
    public string? ActiveDeploymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("activeDeploymentId");
        }
        init { this._rawData.Set("activeDeploymentId", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// HTTPS endpoint, present only while httpEnabled is true. Null otherwise, including
    /// for a function that was previously exposed — the stored URL stops serving
    /// the moment HTTP is turned off, so it is never returned.
    /// </summary>
    public string? PublicUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("publicUrl");
        }
        init { this._rawData.Set("publicUrl", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Dependencies;
        _ = this.HttpEnabled;
        _ = this.MemoryMB;
        _ = this.Name;
        this.Runtime.Validate();
        _ = this.Slug;
        this.Status.Validate();
        _ = this.TimeoutSec;
        _ = this.UpdatedAt;
        _ = this.ActiveDeploymentID;
        _ = this.Description;
        _ = this.PublicUrl;
    }

    public FunctionUpdateResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionUpdateResponseFunction(
        FunctionUpdateResponseFunction functionUpdateResponseFunction
    )
        : base(functionUpdateResponseFunction) { }
#pragma warning restore CS8618

    public FunctionUpdateResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionUpdateResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionUpdateResponseFunctionFromRaw.FromRawUnchecked"/>
    public static FunctionUpdateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionUpdateResponseFunctionFromRaw : IFromRawJson<FunctionUpdateResponseFunction>
{
    /// <inheritdoc/>
    public FunctionUpdateResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionUpdateResponseFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Runtime the function is deployed on.
/// </summary>
[JsonConverter(typeof(FunctionUpdateResponseFunctionRuntimeConverter))]
public enum FunctionUpdateResponseFunctionRuntime
{
    Nodejs24,
}

sealed class FunctionUpdateResponseFunctionRuntimeConverter
    : JsonConverter<FunctionUpdateResponseFunctionRuntime>
{
    public override FunctionUpdateResponseFunctionRuntime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nodejs24" => FunctionUpdateResponseFunctionRuntime.Nodejs24,
            _ => (FunctionUpdateResponseFunctionRuntime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateResponseFunctionRuntime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionUpdateResponseFunctionRuntime.Nodejs24 => "nodejs24",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Lifecycle status of a Zavu Function.
/// </summary>
[JsonConverter(typeof(FunctionUpdateResponseFunctionStatusConverter))]
public enum FunctionUpdateResponseFunctionStatus
{
    Draft,
    Bundling,
    Deploying,
    Active,
    Failed,
    Disabled,
}

sealed class FunctionUpdateResponseFunctionStatusConverter
    : JsonConverter<FunctionUpdateResponseFunctionStatus>
{
    public override FunctionUpdateResponseFunctionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => FunctionUpdateResponseFunctionStatus.Draft,
            "bundling" => FunctionUpdateResponseFunctionStatus.Bundling,
            "deploying" => FunctionUpdateResponseFunctionStatus.Deploying,
            "active" => FunctionUpdateResponseFunctionStatus.Active,
            "failed" => FunctionUpdateResponseFunctionStatus.Failed,
            "disabled" => FunctionUpdateResponseFunctionStatus.Disabled,
            _ => (FunctionUpdateResponseFunctionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionUpdateResponseFunctionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionUpdateResponseFunctionStatus.Draft => "draft",
                FunctionUpdateResponseFunctionStatus.Bundling => "bundling",
                FunctionUpdateResponseFunctionStatus.Deploying => "deploying",
                FunctionUpdateResponseFunctionStatus.Active => "active",
                FunctionUpdateResponseFunctionStatus.Failed => "failed",
                FunctionUpdateResponseFunctionStatus.Disabled => "disabled",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
