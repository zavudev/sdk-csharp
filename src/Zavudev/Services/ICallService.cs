using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Calls;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Place an outbound voice call answered by the voice agent configured on the
    /// sender. Zavu dials the recipient and runs the conversation through its managed
    /// voice pipeline (speech recognition, the agent's LLM, and speech synthesis, with
    /// real-time interruption handling).
    ///
    /// <para>**Requirements:** - The Voice Agents feature must be enabled for your team
    /// (otherwise `403`). - An account that has verified nothing may only call the
    /// phone numbers the project has verified (`403` with code
    /// `destination_not_verified`, and `details.verifiedNumbers` lists them), and at
    /// most 5 calls a day (`429` with code `daily_limit_exceeded`). A number is
    /// verified from the dashboard's Sandbox screen by sending the pre-filled WhatsApp
    /// message from that phone; the same verification covers SMS and calls. Verify your
    /// identity, add a payment method, settle a deposit or subscribe to call any
    /// destination. That raises the ceiling to 50 calls a day on Free; paid plans have
    /// no daily call ceiling. Full reference:
    /// https://docs.zavu.dev/concepts/sending-limits - The sender's agent must have
    /// `voice.enabled` set to `true`. - Not available with test-mode API keys.</para>
    ///
    /// <para>**Billing:** Voice calls are billed per minute of connected time plus
    /// telephony, deducted from your prepaid balance. A short-duration estimate is
    /// reserved when the call is placed; you are charged for the actual duration when
    /// the call ends.</para>
    /// </summary>
    Task<CallCreateResponse> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single voice call, including its full transcript once the
    /// conversation has produced turns.
    /// </summary>
    Task<CallRetrieveResponse> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<CallRetrieveResponse> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List voice calls for this project, most recent first. Transcripts are omitted
    /// from the list; fetch a single call to get its transcript.
    /// </summary>
    Task<CallListPage> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// End an active voice call. The call must still be ringing or in progress. Not
    /// available with test-mode API keys.
    /// </summary>
    Task<CallHangupResponse> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hangup(CallHangupParams, CancellationToken)"/>
    Task<CallHangupResponse> Hangup(
        string callID,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/calls</c>, but is otherwise the
    /// same as <see cref="ICallService.Create(CallCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallCreateResponse>> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/calls/{callId}</c>, but is otherwise the
    /// same as <see cref="ICallService.Retrieve(CallRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/calls</c>, but is otherwise the
    /// same as <see cref="ICallService.List(CallListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallListPage>> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/calls/{callId}/hangup</c>, but is otherwise the
    /// same as <see cref="ICallService.Hangup(CallHangupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CallHangupResponse>> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Hangup(CallHangupParams, CancellationToken)"/>
    Task<HttpResponse<CallHangupResponse>> Hangup(
        string callID,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
