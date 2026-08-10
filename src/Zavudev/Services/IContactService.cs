using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Contacts;
using Zavudev.Services.Contacts;

namespace Zavudev.Services;

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

    IChannelService Channels { get; }

    /// <summary>
    /// Create a new contact with one or more communication channels.
    /// </summary>
    Task<Contact> Create(
        ContactCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get contact
    /// </summary>
    Task<Contact> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<Contact> Retrieve(
        string contactID,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update contact
    /// </summary>
    Task<Contact> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<Contact> Update(
        string contactID,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List contacts with their communication channels.
    /// </summary>
    Task<ContactListPage> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a contact and its communication channels. Implements
    /// right-to-erasure obligations under GDPR Art. 17, Ley 19.628 (Chile) Art. 12,
    /// CCPA § 1798.105, and LGPD Art. 18.VI. The contact, its channels, and any
    /// associated agent flow sessions and conversation threads are removed. Past
    /// message records and broadcast delivery logs are retained for billing/audit but
    /// no longer reference the deleted contact.
    /// </summary>
    Task Delete(ContactDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    Task Delete(
        string contactID,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Dismiss the merge suggestion for a contact.
    /// </summary>
    Task DismissMergeSuggestion(
        ContactDismissMergeSuggestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DismissMergeSuggestion(ContactDismissMergeSuggestionParams, CancellationToken)"/>
    Task DismissMergeSuggestion(
        string contactID,
        ContactDismissMergeSuggestionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Merge a source contact into this contact. All channels from the source contact
    /// will be moved to the target contact, and the source contact will be marked as
    /// merged.
    /// </summary>
    Task<Contact> Merge(
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Merge(ContactMergeParams, CancellationToken)"/>
    Task<Contact> Merge(
        string contactID,
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get contact by phone number
    /// </summary>
    Task<Contact> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByPhone(ContactRetrieveByPhoneParams, CancellationToken)"/>
    Task<Contact> RetrieveByPhone(
        string phoneNumber,
        ContactRetrieveByPhoneParams? parameters = null,
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

    IChannelServiceWithRawResponse Channels { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.Create(ContactCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Contact>> Create(
        ContactCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/contacts/{contactId}</c>, but is otherwise the
    /// same as <see cref="IContactService.Retrieve(ContactRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Contact>> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ContactRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Contact>> Retrieve(
        string contactID,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/contacts/{contactId}</c>, but is otherwise the
    /// same as <see cref="IContactService.Update(ContactUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Contact>> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ContactUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Contact>> Update(
        string contactID,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/contacts</c>, but is otherwise the
    /// same as <see cref="IContactService.List(ContactListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ContactListPage>> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/contacts/{contactId}</c>, but is otherwise the
    /// same as <see cref="IContactService.Delete(ContactDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ContactDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string contactID,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/contacts/{contactId}/merge-suggestion</c>, but is otherwise the
    /// same as <see cref="IContactService.DismissMergeSuggestion(ContactDismissMergeSuggestionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DismissMergeSuggestion(
        ContactDismissMergeSuggestionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DismissMergeSuggestion(ContactDismissMergeSuggestionParams, CancellationToken)"/>
    Task<HttpResponse> DismissMergeSuggestion(
        string contactID,
        ContactDismissMergeSuggestionParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/contacts/{contactId}/merge</c>, but is otherwise the
    /// same as <see cref="IContactService.Merge(ContactMergeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Contact>> Merge(
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Merge(ContactMergeParams, CancellationToken)"/>
    Task<HttpResponse<Contact>> Merge(
        string contactID,
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/contacts/phone/{phoneNumber}</c>, but is otherwise the
    /// same as <see cref="IContactService.RetrieveByPhone(ContactRetrieveByPhoneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Contact>> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByPhone(ContactRetrieveByPhoneParams, CancellationToken)"/>
    Task<HttpResponse<Contact>> RetrieveByPhone(
        string phoneNumber,
        ContactRetrieveByPhoneParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
