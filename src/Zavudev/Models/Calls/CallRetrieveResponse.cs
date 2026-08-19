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

[JsonConverter(typeof(JsonModelConverter<CallRetrieveResponse, CallRetrieveResponseFromRaw>))]
public sealed record class CallRetrieveResponse : JsonModel
{
    public required CallRetrieveResponseCall Call
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CallRetrieveResponseCall>("call");
        }
        init { this._rawData.Set("call", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Call.Validate();
    }

    public CallRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveResponse(CallRetrieveResponse callRetrieveResponse)
        : base(callRetrieveResponse) { }
#pragma warning restore CS8618

    public CallRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CallRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CallRetrieveResponse(CallRetrieveResponseCall call)
        : this()
    {
        this.Call = call;
    }
}

class CallRetrieveResponseFromRaw : IFromRawJson<CallRetrieveResponse>
{
    /// <inheritdoc/>
    public CallRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<CallRetrieveResponseCall, CallRetrieveResponseCallFromRaw>)
)]
public sealed record class CallRetrieveResponseCall : JsonModel
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
    public required ApiEnum<string, CallRetrieveResponseCallDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CallRetrieveResponseCallDirection>
            >("direction");
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
    public required ApiEnum<string, CallRetrieveResponseCallStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallRetrieveResponseCallStatus>>(
                "status"
            );
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
    public IReadOnlyList<CallRetrieveResponseCallTranscript>? Transcript
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CallRetrieveResponseCallTranscript>
            >("transcript");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CallRetrieveResponseCallTranscript>?>(
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

    public CallRetrieveResponseCall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveResponseCall(CallRetrieveResponseCall callRetrieveResponseCall)
        : base(callRetrieveResponseCall) { }
#pragma warning restore CS8618

    public CallRetrieveResponseCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveResponseCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveResponseCallFromRaw.FromRawUnchecked"/>
    public static CallRetrieveResponseCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallRetrieveResponseCallFromRaw : IFromRawJson<CallRetrieveResponseCall>
{
    /// <inheritdoc/>
    public CallRetrieveResponseCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallRetrieveResponseCall.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the call was placed by Zavu (outbound) or received from a caller (inbound).
/// </summary>
[JsonConverter(typeof(CallRetrieveResponseCallDirectionConverter))]
public enum CallRetrieveResponseCallDirection
{
    Inbound,
    Outbound,
}

sealed class CallRetrieveResponseCallDirectionConverter
    : JsonConverter<CallRetrieveResponseCallDirection>
{
    public override CallRetrieveResponseCallDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound" => CallRetrieveResponseCallDirection.Inbound,
            "outbound" => CallRetrieveResponseCallDirection.Outbound,
            _ => (CallRetrieveResponseCallDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRetrieveResponseCallDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallRetrieveResponseCallDirection.Inbound => "inbound",
                CallRetrieveResponseCallDirection.Outbound => "outbound",
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
[JsonConverter(typeof(CallRetrieveResponseCallStatusConverter))]
public enum CallRetrieveResponseCallStatus
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

sealed class CallRetrieveResponseCallStatusConverter : JsonConverter<CallRetrieveResponseCallStatus>
{
    public override CallRetrieveResponseCallStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => CallRetrieveResponseCallStatus.Queued,
            "ringing" => CallRetrieveResponseCallStatus.Ringing,
            "in_progress" => CallRetrieveResponseCallStatus.InProgress,
            "completed" => CallRetrieveResponseCallStatus.Completed,
            "failed" => CallRetrieveResponseCallStatus.Failed,
            "busy" => CallRetrieveResponseCallStatus.Busy,
            "no_answer" => CallRetrieveResponseCallStatus.NoAnswer,
            "canceled" => CallRetrieveResponseCallStatus.Canceled,
            _ => (CallRetrieveResponseCallStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRetrieveResponseCallStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallRetrieveResponseCallStatus.Queued => "queued",
                CallRetrieveResponseCallStatus.Ringing => "ringing",
                CallRetrieveResponseCallStatus.InProgress => "in_progress",
                CallRetrieveResponseCallStatus.Completed => "completed",
                CallRetrieveResponseCallStatus.Failed => "failed",
                CallRetrieveResponseCallStatus.Busy => "busy",
                CallRetrieveResponseCallStatus.NoAnswer => "no_answer",
                CallRetrieveResponseCallStatus.Canceled => "canceled",
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
[JsonConverter(
    typeof(JsonModelConverter<
        CallRetrieveResponseCallTranscript,
        CallRetrieveResponseCallTranscriptFromRaw
    >)
)]
public sealed record class CallRetrieveResponseCallTranscript : JsonModel
{
    /// <summary>
    /// Who produced the turn. `tool` records a tool call the agent made during the conversation.
    /// </summary>
    public required ApiEnum<string, CallRetrieveResponseCallTranscriptRole> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CallRetrieveResponseCallTranscriptRole>
            >("role");
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

    public CallRetrieveResponseCallTranscript() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveResponseCallTranscript(
        CallRetrieveResponseCallTranscript callRetrieveResponseCallTranscript
    )
        : base(callRetrieveResponseCallTranscript) { }
#pragma warning restore CS8618

    public CallRetrieveResponseCallTranscript(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveResponseCallTranscript(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveResponseCallTranscriptFromRaw.FromRawUnchecked"/>
    public static CallRetrieveResponseCallTranscript FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CallRetrieveResponseCallTranscriptFromRaw : IFromRawJson<CallRetrieveResponseCallTranscript>
{
    /// <inheritdoc/>
    public CallRetrieveResponseCallTranscript FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CallRetrieveResponseCallTranscript.FromRawUnchecked(rawData);
}

/// <summary>
/// Who produced the turn. `tool` records a tool call the agent made during the conversation.
/// </summary>
[JsonConverter(typeof(CallRetrieveResponseCallTranscriptRoleConverter))]
public enum CallRetrieveResponseCallTranscriptRole
{
    User,
    Assistant,
    Tool,
}

sealed class CallRetrieveResponseCallTranscriptRoleConverter
    : JsonConverter<CallRetrieveResponseCallTranscriptRole>
{
    public override CallRetrieveResponseCallTranscriptRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => CallRetrieveResponseCallTranscriptRole.User,
            "assistant" => CallRetrieveResponseCallTranscriptRole.Assistant,
            "tool" => CallRetrieveResponseCallTranscriptRole.Tool,
            _ => (CallRetrieveResponseCallTranscriptRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRetrieveResponseCallTranscriptRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CallRetrieveResponseCallTranscriptRole.User => "user",
                CallRetrieveResponseCallTranscriptRole.Assistant => "assistant",
                CallRetrieveResponseCallTranscriptRole.Tool => "tool",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
