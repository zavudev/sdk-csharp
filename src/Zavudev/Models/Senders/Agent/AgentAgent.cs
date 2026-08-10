using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders.Agent;

/// <summary>
/// AI Agent configuration for a sender.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentAgent, AgentAgentFromRaw>))]
public sealed record class AgentAgent : JsonModel
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
    /// Whether the agent is active.
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
    /// Model ID (e.g., gpt-4o-mini, claude-3-5-sonnet).
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
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
    /// LLM provider for the AI agent.
    /// </summary>
    public required ApiEnum<string, AgentProvider> Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AgentProvider>>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    public required string SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("senderId");
        }
        init { this._rawData.Set("senderId", value); }
    }

    /// <summary>
    /// System prompt for the agent.
    /// </summary>
    public required string SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("systemPrompt");
        }
        init { this._rawData.Set("systemPrompt", value); }
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
    /// Number of previous messages to include as context.
    /// </summary>
    public long? ContextWindowMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("contextWindowMessages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contextWindowMessages", value);
        }
    }

    /// <summary>
    /// Whether to include contact metadata in context.
    /// </summary>
    public bool? IncludeContactMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeContactMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeContactMetadata", value);
        }
    }

    /// <summary>
    /// Maximum tokens for LLM response.
    /// </summary>
    public long? MaxTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxTokens");
        }
        init { this._rawData.Set("maxTokens", value); }
    }

    /// <summary>
    /// Senders this agent answers on. An agent can serve several; `senderId` remains
    /// the primary one, for compatibility.
    /// </summary>
    public IReadOnlyList<string>? SenderIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("senderIds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "senderIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Stats? Stats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Stats>("stats");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stats", value);
        }
    }

    /// <summary>
    /// LLM temperature (0-2).
    /// </summary>
    public double? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("temperature");
        }
        init { this._rawData.Set("temperature", value); }
    }

    /// <summary>
    /// Channels that trigger the agent.
    /// </summary>
    public IReadOnlyList<string>? TriggerOnChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("triggerOnChannels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "triggerOnChannels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Message types that trigger the agent.
    /// </summary>
    public IReadOnlyList<string>? TriggerOnMessageTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("triggerOnMessageTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "triggerOnMessageTypes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Voice Agent configuration. When present and enabled, the agent can answer
    /// inbound phone calls and place outbound calls with Zavu's managed voice pipeline.
    /// Requires the Voice Agents feature to be enabled for your team.
    /// </summary>
    public AgentAgentVoice? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentAgentVoice>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Enabled;
        _ = this.Model;
        _ = this.Name;
        this.Provider.Validate();
        _ = this.SenderID;
        _ = this.SystemPrompt;
        _ = this.UpdatedAt;
        _ = this.ContextWindowMessages;
        _ = this.IncludeContactMetadata;
        _ = this.MaxTokens;
        _ = this.SenderIds;
        this.Stats?.Validate();
        _ = this.Temperature;
        _ = this.TriggerOnChannels;
        _ = this.TriggerOnMessageTypes;
        this.Voice?.Validate();
    }

    public AgentAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentAgent(AgentAgent agentAgent)
        : base(agentAgent) { }
#pragma warning restore CS8618

    public AgentAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentAgentFromRaw.FromRawUnchecked"/>
    public static AgentAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentAgentFromRaw : IFromRawJson<AgentAgent>
{
    /// <inheritdoc/>
    public AgentAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentAgent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Stats, StatsFromRaw>))]
public sealed record class Stats : JsonModel
{
    /// <summary>
    /// Total cost in USD.
    /// </summary>
    public double? TotalCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("totalCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalCost", value);
        }
    }

    public long? TotalInvocations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalInvocations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalInvocations", value);
        }
    }

    public long? TotalTokensUsed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalTokensUsed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalTokensUsed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TotalCost;
        _ = this.TotalInvocations;
        _ = this.TotalTokensUsed;
    }

    public Stats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Stats(Stats stats)
        : base(stats) { }
#pragma warning restore CS8618

    public Stats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Stats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatsFromRaw.FromRawUnchecked"/>
    public static Stats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatsFromRaw : IFromRawJson<Stats>
{
    /// <inheritdoc/>
    public Stats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Stats.FromRawUnchecked(rawData);
}

/// <summary>
/// Voice Agent configuration. When present and enabled, the agent can answer inbound
/// phone calls and place outbound calls with Zavu's managed voice pipeline. Requires
/// the Voice Agents feature to be enabled for your team.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AgentAgentVoice, AgentAgentVoiceFromRaw>))]
public sealed record class AgentAgentVoice : JsonModel
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
    public ApiEnum<string, AgentAgentVoiceVoicemailAction>? VoicemailAction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AgentAgentVoiceVoicemailAction>>(
                "voicemailAction"
            );
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

    public AgentAgentVoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentAgentVoice(AgentAgentVoice agentAgentVoice)
        : base(agentAgentVoice) { }
#pragma warning restore CS8618

    public AgentAgentVoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentAgentVoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentAgentVoiceFromRaw.FromRawUnchecked"/>
    public static AgentAgentVoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentAgentVoice(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class AgentAgentVoiceFromRaw : IFromRawJson<AgentAgentVoice>
{
    /// <inheritdoc/>
    public AgentAgentVoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentAgentVoice.FromRawUnchecked(rawData);
}

/// <summary>
/// What the agent does when an answering machine or voicemail is detected on an
/// outbound call.
/// </summary>
[JsonConverter(typeof(AgentAgentVoiceVoicemailActionConverter))]
public enum AgentAgentVoiceVoicemailAction
{
    Hangup,
    LeaveMessage,
}

sealed class AgentAgentVoiceVoicemailActionConverter : JsonConverter<AgentAgentVoiceVoicemailAction>
{
    public override AgentAgentVoiceVoicemailAction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hangup" => AgentAgentVoiceVoicemailAction.Hangup,
            "leave_message" => AgentAgentVoiceVoicemailAction.LeaveMessage,
            _ => (AgentAgentVoiceVoicemailAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentAgentVoiceVoicemailAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentAgentVoiceVoicemailAction.Hangup => "hangup",
                AgentAgentVoiceVoicemailAction.LeaveMessage => "leave_message",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
