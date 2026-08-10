using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Services.Broadcasts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContactService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IContactServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContactService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List contacts in a broadcast with optional status filter.
    /// </summary>
    Task<ContactListPage> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ContactListParams, CancellationToken)"/>
    Task<ContactListPage> List(
        string broadcastID,
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add contacts to a broadcast in batch. Maximum 1000 contacts per request.
    /// </summary>
    Task<ContactAddResponse> Add(
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ContactAddParams, CancellationToken)"/>
    Task<ContactAddResponse> Add(
        string broadcastID,
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a contact from a broadcast in draft status.
    /// </summary>
    Task Remove(ContactRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(ContactRemoveParams, CancellationToken)"/>
    Task Remove(
        string contactID,
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IContactService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IContactServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IContactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/broadcasts/{broadcastId}/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.List(ContactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListPage>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ContactListParams, CancellationToken)"/>
    Task<HttpResponse<ContactListPage>> List(
        string broadcastID,
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/broadcasts/{broadcastId}/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.Add(ContactAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactAddResponse>> Add(
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ContactAddParams, CancellationToken)"/>
    Task<HttpResponse<ContactAddResponse>> Add(
        string broadcastID,
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/broadcasts/{broadcastId}/contacts/{contactId}</c>, but is otherwise the
    /// same as <see cref="IContactService.Remove(ContactRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ContactRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string contactID,
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
