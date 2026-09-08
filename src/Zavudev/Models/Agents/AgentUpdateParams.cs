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
using Agent = Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents;

/// <summary>
/// Update an agent
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AgentID { get; init; }

    public string? ApiKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("apiKey", value);
        }
    }

    public long? ContextWindowMessages
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("contextWindowMessages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contextWindowMessages", value);
        }
    }

    public bool? Enabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    public bool? IncludeContactMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeContactMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeContactMetadata", value);
        }
    }

    public long? MaxTokens
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxTokens");
        }
        init { this._rawBodyData.Set("maxTokens", value); }
    }

    public string? Model
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("model", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// LLM provider for the AI agent.
    /// </summary>
    public ApiEnum<string, Agent::AgentProvider>? Provider
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Agent::AgentProvider>>(
                "provider"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("provider", value);
        }
    }

    public string? SystemPrompt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("systemPrompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("systemPrompt", value);
        }
    }

    public double? Temperature
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("temperature");
        }
        init { this._rawBodyData.Set("temperature", value); }
    }

    public IReadOnlyList<string>? TriggerOnChannels
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("triggerOnChannels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "triggerOnChannels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? TriggerOnMessageTypes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "triggerOnMessageTypes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "triggerOnMessageTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Voice Agent configuration. Patch this object to enable voice, change the greeting,
    /// or adjust call limits. Requires the Voice Agents feature to be enabled for
    /// your team.
    /// </summary>
    public AgentUpdateParamsVoice? Voice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AgentUpdateParamsVoice>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("voice", value);
        }
    }

    public AgentUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentUpdateParams(AgentUpdateParams agentUpdateParams)
        : base(agentUpdateParams)
    {
        this.AgentID = agentUpdateParams.AgentID;

        this._rawBodyData = new(agentUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentUpdateParams(
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
    AgentUpdateParams(
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
    public static AgentUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(AgentUpdateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/agents/{0}", this.AgentID)
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

/// <summary>
/// Voice Agent configuration. Patch this object to enable voice, change the greeting,
/// or adjust call limits. Requires the Voice Agents feature to be enabled for your team.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentUpdateParamsVoice, AgentUpdateParamsVoiceFromRaw>))]
public sealed record class AgentUpdateParamsVoice : JsonModel
{
    /// <summary>
    /// Whether the agent handles voice calls. When false, the sender's number is
    /// not answered by the voice agent and outbound calls are rejected.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// Opening line the agent speaks when the call connects. If omitted, the agent
    /// waits for the caller to speak first.
    /// </summary>
    public string? Greeting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("greeting");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("greeting", value);
        }
    }

    /// <summary>
    /// Greeting per language, keyed by language code. Used when the caller's language
    /// differs from the one `greeting` is written in.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Greetings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("greetings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "greetings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether the caller can interrupt the agent while it is speaking (barge-in).
    /// When true, the agent stops talking as soon as the caller starts.
    /// </summary>
    public bool? Interruptible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("interruptible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("interruptible", value);
        }
    }

    /// <summary>
    /// BCP-47 language code used for both speech recognition and speech synthesis
    /// (e.g. `en`, `es`, `pt-BR`). Auto-detected from the recipient when omitted.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// Hard limit on call length in minutes. The call ends automatically when reached.
    /// </summary>
    public long? MaxCallDurationMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxCallDurationMinutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxCallDurationMinutes", value);
        }
    }

    /// <summary>
    /// How long the agent waits during silence before ending the call.
    /// </summary>
    public long? MaxIdleSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxIdleSeconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxIdleSeconds", value);
        }
    }

    /// <summary>
    /// Model that runs the conversation, co-located in the voice network for lowest
    /// latency. Independent of the model used for text messaging. Derived from the
    /// agent's text model when omitted.
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Whether the call audio is recorded.
    /// </summary>
    public bool? RecordCalls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("recordCalls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recordCalls", value);
        }
    }

    /// <summary>
    /// Speech-recognition model. Uses the default when omitted.
    /// </summary>
    public string? SttModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sttModel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sttModel", value);
        }
    }

    /// <summary>
    /// Speech-recognition provider. Uses the default when omitted.
    /// </summary>
    public string? SttProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sttProvider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sttProvider", value);
        }
    }

    /// <summary>
    /// E.164 phone number the agent can transfer the call to. When set, the agent
    /// is given a transfer tool it can use to hand the call to a human.
    /// </summary>
    public string? TransferPhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transferPhoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transferPhoneNumber", value);
        }
    }

    /// <summary>
    /// Speech-synthesis provider. Uses the default when omitted.
    /// </summary>
    public string? TtsProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ttsProvider");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ttsProvider", value);
        }
    }

    /// <summary>
    /// Identifier of the synthesized voice that speaks. Choose from the voices available
    /// in the dashboard. Uses a neutral default when omitted.
    /// </summary>
    public string? TtsVoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ttsVoiceId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ttsVoiceId", value);
        }
    }

    /// <summary>
    /// What the agent does when an answering machine or voicemail is detected on
    /// an outbound call.
    /// </summary>
    public ApiEnum<string, AgentUpdateParamsVoiceVoicemailAction>? VoicemailAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, AgentUpdateParamsVoiceVoicemailAction>
            >("voicemailAction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voicemailAction", value);
        }
    }

    /// <summary>
    /// Message spoken when `voicemailAction` is `leave_message`. Falls back to `greeting`
    /// when omitted.
    /// </summary>
    public string? VoicemailMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voicemailMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voicemailMessage", value);
        }
    }

    /// <summary>
    /// Speech rate. 1.0 is natural. Only honoured by voices that support rate control;
    /// ignored by the others.
    /// </summary>
    public double? VoiceSpeed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("voiceSpeed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voiceSpeed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.Greeting;
        _ = this.Greetings;
        _ = this.Interruptible;
        _ = this.Language;
        _ = this.MaxCallDurationMinutes;
        _ = this.MaxIdleSeconds;
        _ = this.Model;
        _ = this.RecordCalls;
        _ = this.SttModel;
        _ = this.SttProvider;
        _ = this.TransferPhoneNumber;
        _ = this.TtsProvider;
        _ = this.TtsVoiceID;
        this.VoicemailAction?.Validate();
        _ = this.VoicemailMessage;
        _ = this.VoiceSpeed;
    }

    public AgentUpdateParamsVoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentUpdateParamsVoice(AgentUpdateParamsVoice agentUpdateParamsVoice)
        : base(agentUpdateParamsVoice) { }
#pragma warning restore CS8618

    public AgentUpdateParamsVoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentUpdateParamsVoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentUpdateParamsVoiceFromRaw.FromRawUnchecked"/>
    public static AgentUpdateParamsVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentUpdateParamsVoice(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class AgentUpdateParamsVoiceFromRaw : IFromRawJson<AgentUpdateParamsVoice>
{
    /// <inheritdoc/>
    public AgentUpdateParamsVoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentUpdateParamsVoice.FromRawUnchecked(rawData);
}

/// <summary>
/// What the agent does when an answering machine or voicemail is detected on an
/// outbound call.
/// </summary>
[JsonConverter(typeof(AgentUpdateParamsVoiceVoicemailActionConverter))]
public enum AgentUpdateParamsVoiceVoicemailAction
{
    Hangup,
    LeaveMessage,
}

sealed class AgentUpdateParamsVoiceVoicemailActionConverter
    : JsonConverter<AgentUpdateParamsVoiceVoicemailAction>
{
    public override AgentUpdateParamsVoiceVoicemailAction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hangup" => AgentUpdateParamsVoiceVoicemailAction.Hangup,
            "leave_message" => AgentUpdateParamsVoiceVoicemailAction.LeaveMessage,
            _ => (AgentUpdateParamsVoiceVoicemailAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentUpdateParamsVoiceVoicemailAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentUpdateParamsVoiceVoicemailAction.Hangup => "hangup",
                AgentUpdateParamsVoiceVoicemailAction.LeaveMessage => "leave_message",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
