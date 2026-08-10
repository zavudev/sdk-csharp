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
    typeof(JsonModelConverter<FunctionRetrieveResponse, FunctionRetrieveResponseFromRaw>)
)]
public sealed record class FunctionRetrieveResponse : JsonModel
{
    /// <summary>
    /// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
    /// to messaging events or HTTP requests.
    /// </summary>
    public required FunctionRetrieveResponseFunction Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FunctionRetrieveResponseFunction>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
    }

    public FunctionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionRetrieveResponse(FunctionRetrieveResponse functionRetrieveResponse)
        : base(functionRetrieveResponse) { }
#pragma warning restore CS8618

    public FunctionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FunctionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionRetrieveResponse(FunctionRetrieveResponseFunction function)
        : this()
    {
        this.Function = function;
    }
}

class FunctionRetrieveResponseFromRaw : IFromRawJson<FunctionRetrieveResponse>
{
    /// <inheritdoc/>
    public FunctionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
/// to messaging events or HTTP requests.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FunctionRetrieveResponseFunction,
        FunctionRetrieveResponseFunctionFromRaw
    >)
)]
public sealed record class FunctionRetrieveResponseFunction : JsonModel
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
    public required ApiEnum<string, FunctionRetrieveResponseFunctionRuntime> Runtime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionRetrieveResponseFunctionRuntime>
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
    public required ApiEnum<string, FunctionRetrieveResponseFunctionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FunctionRetrieveResponseFunctionStatus>
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

    public FunctionRetrieveResponseFunction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionRetrieveResponseFunction(
        FunctionRetrieveResponseFunction functionRetrieveResponseFunction
    )
        : base(functionRetrieveResponseFunction) { }
#pragma warning restore CS8618

    public FunctionRetrieveResponseFunction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionRetrieveResponseFunction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionRetrieveResponseFunctionFromRaw.FromRawUnchecked"/>
    public static FunctionRetrieveResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionRetrieveResponseFunctionFromRaw : IFromRawJson<FunctionRetrieveResponseFunction>
{
    /// <inheritdoc/>
    public FunctionRetrieveResponseFunction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionRetrieveResponseFunction.FromRawUnchecked(rawData);
}

/// <summary>
/// Runtime the function is deployed on.
/// </summary>
[JsonConverter(typeof(FunctionRetrieveResponseFunctionRuntimeConverter))]
public enum FunctionRetrieveResponseFunctionRuntime
{
    Nodejs24,
}

sealed class FunctionRetrieveResponseFunctionRuntimeConverter
    : JsonConverter<FunctionRetrieveResponseFunctionRuntime>
{
    public override FunctionRetrieveResponseFunctionRuntime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nodejs24" => FunctionRetrieveResponseFunctionRuntime.Nodejs24,
            _ => (FunctionRetrieveResponseFunctionRuntime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionRetrieveResponseFunctionRuntime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionRetrieveResponseFunctionRuntime.Nodejs24 => "nodejs24",
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
[JsonConverter(typeof(FunctionRetrieveResponseFunctionStatusConverter))]
public enum FunctionRetrieveResponseFunctionStatus
{
    Draft,
    Bundling,
    Deploying,
    Active,
    Failed,
    Disabled,
}

sealed class FunctionRetrieveResponseFunctionStatusConverter
    : JsonConverter<FunctionRetrieveResponseFunctionStatus>
{
    public override FunctionRetrieveResponseFunctionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => FunctionRetrieveResponseFunctionStatus.Draft,
            "bundling" => FunctionRetrieveResponseFunctionStatus.Bundling,
            "deploying" => FunctionRetrieveResponseFunctionStatus.Deploying,
            "active" => FunctionRetrieveResponseFunctionStatus.Active,
            "failed" => FunctionRetrieveResponseFunctionStatus.Failed,
            "disabled" => FunctionRetrieveResponseFunctionStatus.Disabled,
            _ => (FunctionRetrieveResponseFunctionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionRetrieveResponseFunctionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionRetrieveResponseFunctionStatus.Draft => "draft",
                FunctionRetrieveResponseFunctionStatus.Bundling => "bundling",
                FunctionRetrieveResponseFunctionStatus.Deploying => "deploying",
                FunctionRetrieveResponseFunctionStatus.Active => "active",
                FunctionRetrieveResponseFunctionStatus.Failed => "failed",
                FunctionRetrieveResponseFunctionStatus.Disabled => "disabled",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
