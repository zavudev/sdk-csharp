using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallCreateResponse, CallCreateResponseFromRaw>))]
public sealed record class CallCreateResponse : JsonModel
{
    public required Call Call
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Call>("call");
        }
        init { this._rawData.Set("call", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Call.Validate();
    }

    public CallCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCreateResponse(CallCreateResponse callCreateResponse)
        : base(callCreateResponse) { }
#pragma warning restore CS8618

    public CallCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallCreateResponseFromRaw.FromRawUnchecked"/>
    public static CallCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CallCreateResponse(Call call)
        : this()
    {
        this.Call = call;
    }
}

class CallCreateResponseFromRaw : IFromRawJson<CallCreateResponse>
{
    /// <inheritdoc/>
    public CallCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CallCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Call, CallFromRaw>))]
public sealed record class Call : JsonModel
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
    /// Whether the call was placed by Zavu (outbound) or received from a caller (inbound).
    /// </summary>
    public required ApiEnum<string, CallDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallDirection>>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// Caller phone number in E.164 format. Your sender's number for outbound calls;
    /// the caller's number for inbound calls.
    /// </summary>
    public required string From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Lifecycle status of a voice call. - `queued`: outbound call created, not
    /// yet dialing. - `ringing`: dialing (outbound) or received and ringing (inbound).
    /// - `in_progress`: answered, the agent is connected. - `completed`: ended after
    /// a conversation. - `failed`: could not be completed. - `busy`: the line was
    /// busy. - `no_answer`: rang but was not answered. - `canceled`: canceled before
    /// it was answered.
    /// </summary>
    public required ApiEnum<string, CallStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Callee phone number in E.164 format.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// When the call was answered.
    /// </summary>
    public DateTimeOffset? AnsweredAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("answeredAt");
        }
        init { this._rawData.Set("answeredAt", value); }
    }

    /// <summary>
    /// Total cost of the call in USD, combining the managed voice pipeline per-minute
    /// charge and telephony. Available once the call has ended.
    /// </summary>
    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Billable talk time in seconds, measured from answer to hangup.
    /// </summary>
    public long? DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("durationSeconds");
        }
        init { this._rawData.Set("durationSeconds", value); }
    }

    /// <summary>
    /// When the call ended.
    /// </summary>
    public DateTimeOffset? EndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("endedAt");
        }
        init { this._rawData.Set("endedAt", value); }
    }

    /// <summary>
    /// Why the call ended (e.g. `agent_ended`, `max_duration`, `transfer`, `hangup`).
    /// Present once the call is no longer active.
    /// </summary>
    public string? EndReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endReason");
        }
        init { this._rawData.Set("endReason", value); }
    }

    /// <summary>
    /// Arbitrary metadata you attached when creating the call.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Ordered transcript of the call. Included when retrieving a single call; omitted
    /// from list responses.
    /// </summary>
    public IReadOnlyList<Transcript>? Transcript
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Transcript>>("transcript");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Transcript>?>(
                "transcript",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of conversation turns exchanged during the call.
    /// </summary>
    public long? TurnCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turnCount");
        }
        init { this._rawData.Set("turnCount", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Direction.Validate();
        _ = this.From;
        this.Status.Validate();
        _ = this.To;
        _ = this.AnsweredAt;
        _ = this.Cost;
        _ = this.DurationSeconds;
        _ = this.EndedAt;
        _ = this.EndReason;
        _ = this.Metadata;
        foreach (var item in this.Transcript ?? [])
        {
            item.Validate();
        }
        _ = this.TurnCount;
        _ = this.UpdatedAt;
    }

    public Call() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Call(Call call)
        : base(call) { }
#pragma warning restore CS8618

    public Call(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Call(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallFromRaw.FromRawUnchecked"/>
    public static Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallFromRaw : IFromRawJson<Call>
{
    /// <inheritdoc/>
    public Call FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Call.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the call was placed by Zavu (outbound) or received from a caller (inbound).
/// </summary>
[JsonConverter(typeof(CallDirectionConverter))]
public enum CallDirection
{
    Inbound,
    Outbound,
}

sealed class CallDirectionConverter : JsonConverter<CallDirection>
{
    public override CallDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound" => CallDirection.Inbound,
            "outbound" => CallDirection.Outbound,
            _ => (CallDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallDirection.Inbound => "inbound",
                CallDirection.Outbound => "outbound",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Lifecycle status of a voice call. - `queued`: outbound call created, not yet dialing.
/// - `ringing`: dialing (outbound) or received and ringing (inbound). - `in_progress`:
/// answered, the agent is connected. - `completed`: ended after a conversation.
/// - `failed`: could not be completed. - `busy`: the line was busy. - `no_answer`:
/// rang but was not answered. - `canceled`: canceled before it was answered.
/// </summary>
[JsonConverter(typeof(CallStatusConverter))]
public enum CallStatus
{
    Queued,
    Ringing,
    InProgress,
    Completed,
    Failed,
    Busy,
    NoAnswer,
    Canceled,
}

sealed class CallStatusConverter : JsonConverter<CallStatus>
{
    public override CallStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => CallStatus.Queued,
            "ringing" => CallStatus.Ringing,
            "in_progress" => CallStatus.InProgress,
            "completed" => CallStatus.Completed,
            "failed" => CallStatus.Failed,
            "busy" => CallStatus.Busy,
            "no_answer" => CallStatus.NoAnswer,
            "canceled" => CallStatus.Canceled,
            _ => (CallStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallStatus.Queued => "queued",
                CallStatus.Ringing => "ringing",
                CallStatus.InProgress => "in_progress",
                CallStatus.Completed => "completed",
                CallStatus.Failed => "failed",
                CallStatus.Busy => "busy",
                CallStatus.NoAnswer => "no_answer",
                CallStatus.Canceled => "canceled",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A single turn in a voice call transcript.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transcript, TranscriptFromRaw>))]
public sealed record class Transcript : JsonModel
{
    /// <summary>
    /// Who produced the turn. `tool` records a tool call the agent made during the conversation.
    /// </summary>
    public required ApiEnum<string, Role> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Ordinal position of the turn within the call, starting at 0.
    /// </summary>
    public required long Seq
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("seq");
        }
        init { this._rawData.Set("seq", value); }
    }

    /// <summary>
    /// Transcribed speech for `user` and `assistant` turns, or a JSON summary of
    /// the tool call for `tool` turns.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// When the turn ended.
    /// </summary>
    public DateTimeOffset? EndedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("endedAt");
        }
        init { this._rawData.Set("endedAt", value); }
    }

    /// <summary>
    /// When the turn started.
    /// </summary>
    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startedAt");
        }
        init { this._rawData.Set("startedAt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Role.Validate();
        _ = this.Seq;
        _ = this.Text;
        _ = this.EndedAt;
        _ = this.StartedAt;
    }

    public Transcript() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transcript(Transcript transcript)
        : base(transcript) { }
#pragma warning restore CS8618

    public Transcript(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transcript(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TranscriptFromRaw.FromRawUnchecked"/>
    public static Transcript FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TranscriptFromRaw : IFromRawJson<Transcript>
{
    /// <inheritdoc/>
    public Transcript FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transcript.FromRawUnchecked(rawData);
}

/// <summary>
/// Who produced the turn. `tool` records a tool call the agent made during the conversation.
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    User,
    Assistant,
    Tool,
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
            "tool" => Role.Tool,
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
                Role.Tool => "tool",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
