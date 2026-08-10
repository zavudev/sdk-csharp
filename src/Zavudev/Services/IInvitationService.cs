using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Invitations;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvitationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvitationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvitationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a partner invitation link for a client to connect a Meta channel. The
    /// client opens the returned `url` and authorizes with Meta; the resulting sender
    /// is created in your project when they finish, and the invitation transitions to
    /// `completed`.
    ///
    /// <para>`connectionType` picks the channel: - `whatsapp_waba` (default): Meta's
    /// embedded signup links an official WhatsApp Business Account. - `messenger`: the
    /// client picks a Facebook Page they administer; its Messenger inbox (including
    /// Marketplace chats) is routed to Zavu.</para>
    ///
    /// <para>One invitation connects one channel — create one per channel to onboard a
    /// client on several. `phoneNumberId` and `allowedPhoneCountries` apply to
    /// `whatsapp_waba` only.</para>
    /// </summary>
    Task<InvitationCreateResponse> Create(
        InvitationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get invitation
    /// </summary>
    Task<InvitationRetrieveResponse> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvitationRetrieveParams, CancellationToken)"/>
    Task<InvitationRetrieveResponse> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List partner invitations for this project.
    /// </summary>
    Task<InvitationListPage> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel an active invitation. The client will no longer be able to use the
    /// invitation link.
    /// </summary>
    Task<InvitationCancelResponse> Cancel(
        InvitationCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(InvitationCancelParams, CancellationToken)"/>
    Task<InvitationCancelResponse> Cancel(
        string invitationID,
        InvitationCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvitationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvitationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvitationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/invitations</c>, but is otherwise the
    /// same as <see cref="IInvitationService.Create(InvitationCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationCreateResponse>> Create(
        InvitationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/invitations/{invitationId}</c>, but is otherwise the
    /// same as <see cref="IInvitationService.Retrieve(InvitationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(InvitationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/invitations</c>, but is otherwise the
    /// same as <see cref="IInvitationService.List(InvitationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationListPage>> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/invitations/{invitationId}/cancel</c>, but is otherwise the
    /// same as <see cref="IInvitationService.Cancel(InvitationCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<InvitationCancelResponse>> Cancel(
        InvitationCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(InvitationCancelParams, CancellationToken)"/>
    Task<HttpResponse<InvitationCancelResponse>> Cancel(
        string invitationID,
        InvitationCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
