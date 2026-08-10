using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Services.Senders;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWhatsappSyncService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWhatsappSyncServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappSyncService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the current sync status for a sender's WhatsApp coexistence account. Only
    /// available for senders connected in coexistence mode (WhatsApp Business App +
    /// Cloud API).
    /// </summary>
    Task<WhatsappSyncRetrieveResponse> Retrieve(
        WhatsappSyncRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WhatsappSyncRetrieveParams, CancellationToken)"/>
    Task<WhatsappSyncRetrieveResponse> Retrieve(
        string senderID,
        WhatsappSyncRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initiate contact names sync from the WhatsApp Business App. This imports contact
    /// names stored in the app to Zavu. Only available for coexistence accounts with
    /// active status.
    /// </summary>
    Task<WhatsappSyncStartContactsSyncResponse> StartContactsSync(
        WhatsappSyncStartContactsSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StartContactsSync(WhatsappSyncStartContactsSyncParams, CancellationToken)"/>
    Task<WhatsappSyncStartContactsSyncResponse> StartContactsSync(
        string senderID,
        WhatsappSyncStartContactsSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initiate message history sync from the WhatsApp Business App. This sends a
    /// request to the account owner to approve sharing their conversation history. Only
    /// available for coexistence accounts with active status.
    /// </summary>
    Task<WhatsappSyncStartHistorySyncResponse> StartHistorySync(
        WhatsappSyncStartHistorySyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StartHistorySync(WhatsappSyncStartHistorySyncParams, CancellationToken)"/>
    Task<WhatsappSyncStartHistorySyncResponse> StartHistorySync(
        string senderID,
        WhatsappSyncStartHistorySyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWhatsappSyncService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWhatsappSyncServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappSyncServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/whatsapp-sync</c>, but is otherwise the
    /// same as <see cref="IWhatsappSyncService.Retrieve(WhatsappSyncRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WhatsappSyncRetrieveResponse>> Retrieve(
        WhatsappSyncRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WhatsappSyncRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappSyncRetrieveResponse>> Retrieve(
        string senderID,
        WhatsappSyncRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/whatsapp-sync/contacts</c>, but is otherwise the
    /// same as <see cref="IWhatsappSyncService.StartContactsSync(WhatsappSyncStartContactsSyncParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WhatsappSyncStartContactsSyncResponse>> StartContactsSync(
        WhatsappSyncStartContactsSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StartContactsSync(WhatsappSyncStartContactsSyncParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappSyncStartContactsSyncResponse>> StartContactsSync(
        string senderID,
        WhatsappSyncStartContactsSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/whatsapp-sync/history</c>, but is otherwise the
    /// same as <see cref="IWhatsappSyncService.StartHistorySync(WhatsappSyncStartHistorySyncParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WhatsappSyncStartHistorySyncResponse>> StartHistorySync(
        WhatsappSyncStartHistorySyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="StartHistorySync(WhatsappSyncStartHistorySyncParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappSyncStartHistorySyncResponse>> StartHistorySync(
        string senderID,
        WhatsappSyncStartHistorySyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
