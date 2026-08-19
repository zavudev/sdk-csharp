using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Functions.Triggers;

/// <summary>
/// Subscribe a function to one or more event types, optionally scoped to specific
/// senders. Provide eventTypes and senderIds (use null in senderIds for all senders);
/// a trigger is created for each event type and sender combination.
///
/// <para>The special event type `cron` runs the function on a schedule instead of
/// a messaging event: include a `cron` field with a 5-field UTC cron expression
/// (minimum granularity one minute). A cron trigger ignores the sender axis, and
/// a function may hold several cron triggers with different expressions. The function
/// receives an event with `type: "cron"` and `data.cron`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TriggerCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FunctionID { get; init; }

    /// <summary>
    /// Event types to subscribe to.
    /// </summary>
    public required IReadOnlyList<string> EventTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("eventTypes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "eventTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Senders to scope the triggers to. Use null for all senders.
    /// </summary>
    public required IReadOnlyList<string?> SenderIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string?>>("senderIds");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string?>>(
                "senderIds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Required when eventTypes includes `cron`: a 5-field cron expression (minute
    /// hour day-of-month month day-of-week), evaluated in UTC.
    /// </summary>
    public string? Cron
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("cron");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("cron", value);
        }
    }

    public TriggerCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TriggerCreateParams(TriggerCreateParams triggerCreateParams)
        : base(triggerCreateParams)
    {
        this.FunctionID = triggerCreateParams.FunctionID;

        this._rawBodyData = new(triggerCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TriggerCreateParams(
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
    TriggerCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string functionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FunctionID = functionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TriggerCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string functionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TriggerCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FunctionID?.Equals(other.FunctionID) ?? other.FunctionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/functions/{0}/triggers", this.FunctionID)
        )
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
