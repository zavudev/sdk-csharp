using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Executions;

/// <summary>
/// Fetch full details for one execution — including `errorMessage`, `errorCode`,
/// and `responseText`. Use this to debug failures surfaced by the list endpoint.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExecutionRetrieveParams : ParamsBase
{
    public required string SenderID { get; init; }

    public string? ExecutionID { get; init; }

    public ExecutionRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionRetrieveParams(ExecutionRetrieveParams executionRetrieveParams)
        : base(executionRetrieveParams)
    {
        this.SenderID = executionRetrieveParams.SenderID;
        this.ExecutionID = executionRetrieveParams.ExecutionID;
    }
#pragma warning restore CS8618

    public ExecutionRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string senderID,
        string executionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SenderID = senderID;
        this.ExecutionID = executionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExecutionRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string senderID,
        string executionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            senderID,
            executionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SenderID"] = JsonSerializer.SerializeToElement(this.SenderID),
                    ["ExecutionID"] = JsonSerializer.SerializeToElement(this.ExecutionID),
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

    public virtual bool Equals(ExecutionRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.SenderID.Equals(other.SenderID)
            && (this.ExecutionID?.Equals(other.ExecutionID) ?? other.ExecutionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/senders/{0}/agent/executions/{1}",
                    this.SenderID,
                    this.ExecutionID
                )
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
