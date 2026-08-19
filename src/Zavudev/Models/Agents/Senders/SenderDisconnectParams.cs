using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Agents.Senders;

/// <summary>
/// Stop the agent answering on this sender. The agent's primary sender is part of
/// the agent itself and cannot be disconnected here.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SenderDisconnectParams : ParamsBase
{
    public required string AgentID { get; init; }

    public string? SenderID { get; init; }

    public SenderDisconnectParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderDisconnectParams(SenderDisconnectParams senderDisconnectParams)
        : base(senderDisconnectParams)
    {
        this.AgentID = senderDisconnectParams.AgentID;
        this.SenderID = senderDisconnectParams.SenderID;
    }
#pragma warning restore CS8618

    public SenderDisconnectParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderDisconnectParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string agentID,
        string senderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AgentID = agentID;
        this.SenderID = senderID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SenderDisconnectParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string agentID,
        string senderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            agentID,
            senderID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AgentID"] = JsonSerializer.SerializeToElement(this.AgentID),
                    ["SenderID"] = JsonSerializer.SerializeToElement(this.SenderID),
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

    public virtual bool Equals(SenderDisconnectParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.AgentID.Equals(other.AgentID)
            && (this.SenderID?.Equals(other.SenderID) ?? other.SenderID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/agents/{0}/senders/{1}", this.AgentID, this.SenderID)
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
