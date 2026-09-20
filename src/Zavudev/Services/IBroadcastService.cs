using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;
using Broadcasts = Zavudev.Services.Broadcasts;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBroadcastService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBroadcastServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Broadcasts::IContactService Contacts { get; }

    /// <summary>
    /// Create a new broadcast campaign. Add contacts after creation, then send.
    /// </summary>
    Task<BroadcastCreateResponse> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get broadcast
    /// </summary>
    Task<BroadcastRetrieveResponse> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BroadcastRetrieveParams, CancellationToken)"/>
    Task<BroadcastRetrieveResponse> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a broadcast in draft status.
    /// </summary>
    Task<BroadcastUpdateResponse> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BroadcastUpdateParams, CancellationToken)"/>
    Task<BroadcastUpdateResponse> Update(
        string broadcastID,
        BroadcastUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List broadcasts for this project.
    /// </summary>
    Task<BroadcastListPage> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a broadcast in draft status.
    /// </summary>
    Task Delete(BroadcastDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BroadcastDeleteParams, CancellationToken)"/>
    Task Delete(
        string broadcastID,
        BroadcastDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a broadcast. Pending contacts will be skipped, but already queued
    /// messages may still be delivered.
    /// </summary>
    Task<BroadcastCancelResponse> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BroadcastCancelParams, CancellationToken)"/>
    Task<BroadcastCancelResponse> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Request manual review by the Zavu team for a rejected broadcast. Use this after
    /// automated review rejection if you believe the content is legitimate.
    /// </summary>
    Task<BroadcastEscalateReviewResponse> EscalateReview(
        BroadcastEscalateReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="EscalateReview(BroadcastEscalateReviewParams, CancellationToken)"/>
    Task<BroadcastEscalateReviewResponse> EscalateReview(
        string broadcastID,
        BroadcastEscalateReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get real-time progress of a broadcast including delivery counts and estimated
    /// completion time.
    /// </summary>
    Task<BroadcastProgress> Progress(
        BroadcastProgressParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Progress(BroadcastProgressParams, CancellationToken)"/>
    Task<BroadcastProgress> Progress(
        string broadcastID,
        BroadcastProgressParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the scheduled time for a broadcast. The broadcast must be in scheduled
    /// status.
    /// </summary>
    Task<BroadcastRescheduleResponse> Reschedule(
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reschedule(BroadcastRescheduleParams, CancellationToken)"/>
    Task<BroadcastRescheduleResponse> Reschedule(
        string broadcastID,
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Resubmit a rejected broadcast for AI review after editing content. Maximum 3
    /// review attempts allowed per broadcast.
    /// </summary>
    Task<BroadcastRetryReviewResponse> RetryReview(
        BroadcastRetryReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetryReview(BroadcastRetryReviewParams, CancellationToken)"/>
    Task<BroadcastRetryReviewResponse> RetryReview(
        string broadcastID,
        BroadcastRetryReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Start sending the broadcast immediately or schedule for later.
    ///
    /// <para>**Sending a broadcast needs no account verification.** Identity and
    /// business verification raise daily ceilings; neither is a permission to
    /// broadcast, on any channel. What stands in front of a broadcast is the content
    /// review below, and it applies to every send path — dashboard, API and CLI. Drafts
    /// can be created, edited and kept freely.</para>
    ///
    /// <para>**Daily ceilings apply per recipient.** Each message a broadcast sends
    /// counts against the channel's daily ceiling (see `POST /v1/messages`). Once the
    /// ceiling is reached, the remaining recipients are marked `failed` with
    /// `errorCode` `DAILY_LIMIT_EXCEEDED`; they are not retried the next day.</para>
    ///
    /// <para>**Review depends on the channel, and cannot be bypassed.** A draft is
    /// submitted to automated content review here; it does not go straight out. A
    /// WhatsApp broadcast built on a Meta-approved template skips review (Meta already
    /// vetted the content) and begins sending. An email broadcast sends as soon as the
    /// review passes it, unless the review asks for a person. Every other channel moves
    /// to `pending_admin_review` and waits for a person. A broadcast the review refuses
    /// lands on `rejected`: use PATCH to edit the content then call POST /retry-review,
    /// or escalate it for a manual review.</para>
    ///
    /// <para>A broadcast is read once, on its own text, rather than per recipient.
    /// While an account's sending is suspended its recipients fail individually with
    /// `errorCode` `SENDING_SUSPENDED`; see `POST /v1/messages`.</para>
    ///
    /// <para>Calling this on a broadcast that is already `approved` or `scheduled`
    /// sends or reschedules it directly, since it has already been reviewed. Reserves
    /// the estimated cost from your balance.</para>
    /// </summary>
    Task<BroadcastSendResponse> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(BroadcastSendParams, CancellationToken)"/>
    Task<BroadcastSendResponse> Send(
        string broadcastID,
        BroadcastSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBroadcastService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBroadcastServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Broadcasts::IContactServiceWithRawResponse Contacts { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Create(BroadcastCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastCreateResponse>> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Retrieve(BroadcastRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastRetrieveResponse>> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BroadcastRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastRetrieveResponse>> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Update(BroadcastUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastUpdateResponse>> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BroadcastUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastUpdateResponse>> Update(
        string broadcastID,
        BroadcastUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/broadcasts</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.List(BroadcastListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastListPage>> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Delete(BroadcastDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BroadcastDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BroadcastDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string broadcastID,
        BroadcastDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts/{broadcastId}/cancel</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Cancel(BroadcastCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastCancelResponse>> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BroadcastCancelParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastCancelResponse>> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts/{broadcastId}/escalate</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.EscalateReview(BroadcastEscalateReviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastEscalateReviewResponse>> EscalateReview(
        BroadcastEscalateReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="EscalateReview(BroadcastEscalateReviewParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastEscalateReviewResponse>> EscalateReview(
        string broadcastID,
        BroadcastEscalateReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/broadcasts/{broadcastId}/progress</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Progress(BroadcastProgressParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastProgress>> Progress(
        BroadcastProgressParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Progress(BroadcastProgressParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastProgress>> Progress(
        string broadcastID,
        BroadcastProgressParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/broadcasts/{broadcastId}/schedule</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Reschedule(BroadcastRescheduleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastRescheduleResponse>> Reschedule(
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reschedule(BroadcastRescheduleParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastRescheduleResponse>> Reschedule(
        string broadcastID,
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts/{broadcastId}/retry-review</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.RetryReview(BroadcastRetryReviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastRetryReviewResponse>> RetryReview(
        BroadcastRetryReviewParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetryReview(BroadcastRetryReviewParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastRetryReviewResponse>> RetryReview(
        string broadcastID,
        BroadcastRetryReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts/{broadcastId}/send</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Send(BroadcastSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastSendResponse>> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(BroadcastSendParams, CancellationToken)"/>
    Task<HttpResponse<BroadcastSendResponse>> Send(
        string broadcastID,
        BroadcastSendParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
