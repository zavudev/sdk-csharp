using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Functions;

/// <summary>
/// Fetch invocation logs for a function. Logs are paginated via `nextToken`. Pass
/// `startTime` / `endTime` (Unix epoch milliseconds) to bound the window, or `filterPattern`
/// to filter messages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FunctionTailLogsParams : ParamsBase
{
    public string? FunctionID { get; init; }

    /// <summary>
    /// End of the log window in Unix epoch milliseconds.
    /// </summary>
    public long? EndTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("endTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("endTime", value);
        }
    }

    public string? FilterPattern
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("filterPattern");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("filterPattern", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public string? NextToken
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("nextToken");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("nextToken", value);
        }
    }

    /// <summary>
    /// Start of the log window in Unix epoch milliseconds.
    /// </summary>
    public long? StartTime
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("startTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("startTime", value);
        }
    }

    public FunctionTailLogsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionTailLogsParams(FunctionTailLogsParams functionTailLogsParams)
        : base(functionTailLogsParams)
    {
        this.FunctionID = functionTailLogsParams.FunctionID;
    }
#pragma warning restore CS8618

    public FunctionTailLogsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionTailLogsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string functionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.FunctionID = functionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FunctionTailLogsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string functionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            functionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FunctionID"] = JsonSerializer.SerializeToElement(this.FunctionID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FunctionTailLogsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FunctionID?.Equals(other.FunctionID) ?? other.FunctionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/functions/{0}/logs", this.FunctionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
