using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Agents;

/// <summary>
/// Run the agent's prompt, model and knowledge base against a message and return
/// the reply instead of delivering it. Writes nothing and charges nothing, so it
/// is safe to call repeatedly while iterating on a prompt.
///
/// <para>Note that a dry run never **executes** tools — running them would cause
/// real side effects. Live conversations on every channel do call them. When the
/// agent has enabled tools, that gap is reported in `warnings` rather than silently
/// producing an answer that looks like a tool call happened.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentTestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AgentID { get; init; }

    /// <summary>
    /// What to say to the agent.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("message");
        }
        init { this._rawBodyData.Set("message", value); }
    }

    /// <summary>
    /// Run the tools the agent calls instead of reporting the choice and stopping.
    ///
    /// <para>Off by default because a tool handler talks to the outside world: a
    /// rehearsal that charges a card is not a rehearsal. Turn it on to exercise the
    /// loop that actually matters — the model picks a tool, the handler answers,
    /// the model replies with the result — without sending a message to anyone.
    /// What ran comes back in `executedToolCalls`.</para>
    /// </summary>
    public bool? ExecuteTools
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("executeTools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("executeTools", value);
        }
    }

    /// <summary>
    /// Prior turns, oldest first, to exercise multi-turn behaviour without persisting
    /// a thread. Trimmed to the agent's context window.
    /// </summary>
    public IReadOnlyList<History>? History
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<History>>("history");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<History>?>(
                "history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set false to skip retrieval and isolate prompt behaviour from the knowledge base.
    /// </summary>
    public bool? UseKnowledgeBase
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("useKnowledgeBase");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("useKnowledgeBase", value);
        }
    }

    public AgentTestParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTestParams(AgentTestParams agentTestParams)
        : base(agentTestParams)
    {
        this.AgentID = agentTestParams.AgentID;

        this._rawBodyData = new(agentTestParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentTestParams(
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
    AgentTestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string agentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AgentID = agentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentTestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string agentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            agentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["AgentID"] = JsonSerializer.SerializeToElement(this.AgentID),
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

    public virtual bool Equals(AgentTestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AgentID?.Equals(other.AgentID) ?? other.AgentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/agents/{0}/test", this.AgentID)
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

[JsonConverter(typeof(JsonModelConverter<History, HistoryFromRaw>))]
public sealed record class History : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required ApiEnum<string, Role> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Role.Validate();
    }

    public History() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public History(History history)
        : base(history) { }
#pragma warning restore CS8618

    public History(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    History(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HistoryFromRaw.FromRawUnchecked"/>
    public static History FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HistoryFromRaw : IFromRawJson<History>
{
    /// <inheritdoc/>
    public History FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        History.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    User,
    Assistant,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Role.User,
            "assistant" => Role.Assistant,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.User => "user",
                Role.Assistant => "assistant",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
