using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Calls;

/// <summary>
/// Place an outbound voice call answered by the voice agent configured on the sender.
/// Zavu dials the recipient and runs the conversation through its managed voice
/// pipeline (speech recognition, the agent's LLM, and speech synthesis, with real-time
/// interruption handling).
///
/// <para>**Requirements:** - The Voice Agents feature must be enabled for your team
/// (otherwise `403`). - An account that has verified nothing may only call the phone
/// numbers the project has verified (`403` with code `destination_not_verified`,
/// and `details.verifiedNumbers` lists them), and at most 5 calls a day (`429` with
/// code `daily_limit_exceeded`). A number is verified from the dashboard's Sandbox
/// screen by sending the pre-filled WhatsApp message from that phone; the same verification
/// covers SMS and calls. Verify your identity, add a payment method, settle a deposit
/// or subscribe to call any destination. That raises the ceiling to 50 calls a day
/// on Free; paid plans have no daily call ceiling. Full reference: https://docs.zavu.dev/concepts/sending-limits
/// - The sender's agent must have `voice.enabled` set to `true`. - Not available
/// with test-mode API keys.</para>
///
/// <para>**Billing:** Voice calls are billed per minute of connected time plus telephony,
/// deducted from your prepaid balance. A short-duration estimate is reserved when
/// the call is placed; you are charged for the actual duration when the call ends.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Recipient phone number in E.164 format.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("to");
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// Overrides the agent's configured greeting for this call only.
    /// </summary>
    public string? Greeting
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("greeting");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("greeting", value);
        }
    }

    /// <summary>
    /// Language the agent speaks on this call only, as a BCP-47 tag (`en`, `es`,
    /// `es-ES`, `pt-BR`), or `auto` to detect the caller's language and follow it.
    /// Overrides the agent's configured language for speech recognition, the agent's
    /// replies, and the synthesized voice. If the agent uses a custom voice you supplied,
    /// that voice is kept and only the language changes. When omitted, the agent's
    /// configured language is used.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("language", value);
        }
    }

    /// <summary>
    /// Overrides the agent's maximum call duration for this call only.
    /// </summary>
    public long? MaxDurationMinutes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("maxDurationMinutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("maxDurationMinutes", value);
        }
    }

    /// <summary>
    /// Arbitrary metadata to associate with the call. Returned on the call object
    /// and included in voice webhooks.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Sender profile that places the call. Uses the project's default sender if
    /// omitted. The sender's agent must have voice enabled.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("senderId", value);
        }
    }

    public CallCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCreateParams(CallCreateParams callCreateParams)
        : base(callCreateParams)
    {
        this._rawBodyData = new(callCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CallCreateParams(
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
    CallCreateParams(
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
    public static CallCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CallCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/calls")
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
