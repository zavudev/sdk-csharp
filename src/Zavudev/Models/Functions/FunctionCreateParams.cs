using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions;

/// <summary>
/// Create a new Zavu Function. The function starts in `draft` status. A dedicated
/// API key is auto-provisioned and injected as the `ZAVU_API_KEY` secret so the function
/// can call back into the Zavu API without manual setup.
///
/// <para>Provide `sourceCode` to seed the draft. Call `POST /v1/functions/{functionId}/deploy`
/// afterwards to publish.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// URL-safe identifier (lowercase, digits, hyphens). Must be unique per project.
    /// </summary>
    public required string Slug
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("slug");
        }
        init { this._rawBodyData.Set("slug", value); }
    }

    /// <summary>
    /// npm dependencies. Keys are package names, values are semver ranges.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Dependencies
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>(
                "dependencies"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "dependencies",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Which file in `files` is the entry point. Defaults to `index.ts`.
    /// </summary>
    public string? Entrypoint
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("entrypoint");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entrypoint", value);
        }
    }

    /// <summary>
    /// The project's source files, keyed by path relative to the project root (e.g.
    /// `index.ts`, `lib/orders.ts`). Imports between them are resolved when the
    /// function is built, so a function can be split across as many files as it needs.
    ///
    /// <para>Paths must be relative and use forward slashes; `..`, `node_modules/`
    /// and `package.json` are rejected. npm packages are not uploaded here — declare
    /// them under `dependencies` and Zavu installs them. Limits: 200 files and 900,000
    /// bytes for the whole tree.</para>
    /// </summary>
    public IReadOnlyDictionary<string, string>? Files
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("files");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "files",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to expose a public HTTPS URL for this function.
    /// </summary>
    public bool? HttpEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("httpEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("httpEnabled", value);
        }
    }

    public ApiEnum<long, MemoryMB>? MemoryMB
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<long, MemoryMB>>("memoryMb");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("memoryMb", value);
        }
    }

    /// <summary>
    /// Runtime the function is deployed on.
    /// </summary>
    public ApiEnum<string, Runtime>? Runtime
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Runtime>>("runtime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("runtime", value);
        }
    }

    /// <summary>
    /// Shortcut for a single-file function: exactly equivalent to sending `files`
    /// with one entry named after `entrypoint` (`index.ts` by default). Fully supported
    /// — use whichever fits. If both are sent, `files` wins.
    /// </summary>
    public string? SourceCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sourceCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sourceCode", value);
        }
    }

    /// <summary>
    /// Per-invocation timeout in seconds. Event and cron invocations are asynchronous,
    /// so a long timeout only bounds cost; a tool called during a live conversation
    /// holds up the reply, and a function exposed over HTTP is additionally bounded
    /// by the platform's HTTP response limit.
    /// </summary>
    public long? TimeoutSec
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("timeoutSec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("timeoutSec", value);
        }
    }

    public FunctionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCreateParams(FunctionCreateParams functionCreateParams)
        : base(functionCreateParams)
    {
        this._rawBodyData = new(functionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FunctionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FunctionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FunctionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/functions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(MemoryMBConverter))]
public enum MemoryMB
{
    V128,
    V256,
    V512,
    V1024,
}

sealed class MemoryMBConverter : JsonConverter<MemoryMB>
{
    public override MemoryMB Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            128L => MemoryMB.V128,
            256L => MemoryMB.V256,
            512L => MemoryMB.V512,
            1024L => MemoryMB.V1024,
            _ => (MemoryMB)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, MemoryMB value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MemoryMB.V128 => 128L,
                MemoryMB.V256 => 256L,
                MemoryMB.V512 => 512L,
                MemoryMB.V1024 => 1024L,
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Runtime the function is deployed on.
/// </summary>
[JsonConverter(typeof(RuntimeConverter))]
public enum Runtime
{
    Nodejs24,
}

sealed class RuntimeConverter : JsonConverter<Runtime>
{
    public override Runtime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "nodejs24" => Runtime.Nodejs24,
            _ => (Runtime)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Runtime value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Runtime.Nodejs24 => "nodejs24",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
