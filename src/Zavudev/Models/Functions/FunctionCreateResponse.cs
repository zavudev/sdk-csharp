using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<FunctionCreateResponse, FunctionCreateResponseFromRaw>))]
public sealed record class FunctionCreateResponse : JsonModel
{
    /// <summary>
    /// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
    /// to messaging events or HTTP requests.
    /// </summary>
    public required Function Function
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Function>("function");
        }
        init { this._rawData.Set("function", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Function.Validate();
    }

    public FunctionCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCreateResponse(FunctionCreateResponse functionCreateResponse)
        : base(functionCreateResponse) { }
#pragma warning restore CS8618

    public FunctionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCreateResponseFromRaw.FromRawUnchecked"/>
    public static FunctionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionCreateResponse(Function function)
        : this()
    {
        this.Function = function;
    }
}

class FunctionCreateResponseFromRaw : IFromRawJson<FunctionCreateResponse>
{
    /// <inheritdoc/>
    public FunctionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A Zavu Function — user-supplied TypeScript that runs in Zavu Cloud and reacts
/// to messaging events or HTTP requests.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Function, FunctionFromRaw>))]
public sealed record class Function : JsonModel
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
    public required ApiEnum<string, FunctionRuntime> Runtime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, FunctionRuntime>>("runtime");
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
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
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

    public Function() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Function(Function function)
        : base(function) { }
#pragma warning restore CS8618

    public Function(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Function(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionFromRaw.FromRawUnchecked"/>
    public static Function FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionFromRaw : IFromRawJson<Function>
{
    /// <inheritdoc/>
    public Function FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Function.FromRawUnchecked(rawData);
}

/// <summary>
/// Runtime the function is deployed on.
/// </summary>
[JsonConverter(typeof(FunctionRuntimeConverter))]
public enum FunctionRuntime
{
    Nodejs24,
}

sealed class FunctionRuntimeConverter : JsonConverter<FunctionRuntime>
{
    public override FunctionRuntime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nodejs24" => FunctionRuntime.Nodejs24,
            _ => (FunctionRuntime)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionRuntime value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FunctionRuntime.Nodejs24 => "nodejs24",
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
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Bundling,
    Deploying,
    Active,
    Failed,
    Disabled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => Status.Draft,
            "bundling" => Status.Bundling,
            "deploying" => Status.Deploying,
            "active" => Status.Active,
            "failed" => Status.Failed,
            "disabled" => Status.Disabled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Bundling => "bundling",
                Status.Deploying => "deploying",
                Status.Active => "active",
                Status.Failed => "failed",
                Status.Disabled => "disabled",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
