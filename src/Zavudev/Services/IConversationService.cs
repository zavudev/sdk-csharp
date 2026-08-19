using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Conversations;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConversationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get conversation
    /// </summary>
    Task<ConversationRetrieveResponse> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ConversationRetrieveParams, CancellationToken)"/>
    Task<ConversationRetrieveResponse> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List inbox threads, most recently active first. A conversation groups every
    /// message with one contact across channels, which is what you need to build an
    /// inbox: `GET /v1/messages` returns a flat log with no thread to hang it on.
    ///
    /// <para>Use `senderId` to scope the list to a single number, and `channel` to keep
    /// only threads that have carried that channel.</para>
    /// </summary>
    Task<ConversationListPage> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Messages in this thread, newest first, across every channel it has carried.
    /// Reply with `POST /v1/messages`, passing the conversation's `senderId` as the
    /// `Zavu-Sender` header so the answer leaves from the number the contact already
    /// knows.
    /// </summary>
    Task<ConversationListMessagesPage> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(ConversationListMessagesParams, CancellationToken)"/>
    Task<ConversationListMessagesPage> ListMessages(
        string conversationID,
        ConversationListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reset the thread's `unreadCount` to zero. Marks the thread read in your own
    /// inbox only: it does not send a read receipt to the contact.
    /// </summary>
    Task<ConversationMarkAsReadResponse> MarkAsRead(
        ConversationMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkAsRead(ConversationMarkAsReadParams, CancellationToken)"/>
    Task<ConversationMarkAsReadResponse> MarkAsRead(
        string conversationID,
        ConversationMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConversationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConversationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/conversations/{conversationId}</c>, but is otherwise the
    /// same as <see cref="IConversationService.Retrieve(ConversationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ConversationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/conversations</c>, but is otherwise the
    /// same as <see cref="IConversationService.List(ConversationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConversationListPage>> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/conversations/{conversationId}/messages</c>, but is otherwise the
    /// same as <see cref="IConversationService.ListMessages(ConversationListMessagesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConversationListMessagesPage>> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListMessages(ConversationListMessagesParams, CancellationToken)"/>
    Task<HttpResponse<ConversationListMessagesPage>> ListMessages(
        string conversationID,
        ConversationListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/conversations/{conversationId}/read</c>, but is otherwise the
    /// same as <see cref="IConversationService.MarkAsRead(ConversationMarkAsReadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConversationMarkAsReadResponse>> MarkAsRead(
        ConversationMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MarkAsRead(ConversationMarkAsReadParams, CancellationToken)"/>
    Task<HttpResponse<ConversationMarkAsReadResponse>> MarkAsRead(
        string conversationID,
        ConversationMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
