using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Telegram;

namespace Zavudev.Services.Senders;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITelegramService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITelegramServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelegramService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Connect a Telegram bot to a sender. Provide the bot token from @BotFather; Zavu
    /// validates it, registers the webhook, and routes the sender's Telegram messages
    /// through it.
    /// </summary>
    Task<TelegramConnectResponse> Connect(
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Connect(TelegramConnectParams, CancellationToken)"/>
    Task<TelegramConnectResponse> Connect(
        string senderID,
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disconnect Telegram from a sender and remove the webhook.
    /// </summary>
    Task Disconnect(
        TelegramDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disconnect(TelegramDisconnectParams, CancellationToken)"/>
    Task Disconnect(
        string senderID,
        TelegramDisconnectParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITelegramService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITelegramServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITelegramServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/telegram</c>, but is otherwise the
    /// same as <see cref="ITelegramService.Connect(TelegramConnectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TelegramConnectResponse>> Connect(
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Connect(TelegramConnectParams, CancellationToken)"/>
    Task<HttpResponse<TelegramConnectResponse>> Connect(
        string senderID,
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/telegram</c>, but is otherwise the
    /// same as <see cref="ITelegramService.Disconnect(TelegramDisconnectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Disconnect(
        TelegramDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disconnect(TelegramDisconnectParams, CancellationToken)"/>
    Task<HttpResponse> Disconnect(
        string senderID,
        TelegramDisconnectParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
