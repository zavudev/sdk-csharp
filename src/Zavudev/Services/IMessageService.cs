using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Messages;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get message by ID
    /// </summary>
    Task<MessageResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<MessageResponse> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List messages previously sent by this project.
    /// </summary>
    Task<MessageListPage> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the stored file attachments for an email message and get a short-lived
    /// signed `downloadUrl` for each. Works for both inbound emails (received via
    /// `message.inbound`) and outbound emails you sent with attachments. Messages
    /// without stored attachments (including SMS, WhatsApp, and other channels) return
    /// an empty list. Each `downloadUrl` is generated fresh per request and expires —
    /// fetch the file promptly and do not cache the URL.
    /// </summary>
    Task<MessageListAttachmentsResponse> ListAttachments(
        MessageListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(MessageListAttachmentsParams, CancellationToken)"/>
    Task<MessageListAttachmentsResponse> ListAttachments(
        string messageID,
        MessageListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send an emoji reaction to an existing WhatsApp message. Reactions are only
    /// supported for WhatsApp messages.
    /// </summary>
    Task<MessageResponse> React(
        MessageReactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="React(MessageReactParams, CancellationToken)"/>
    Task<MessageResponse> React(
        string messageID,
        MessageReactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a message to a recipient via SMS or WhatsApp.
    ///
    /// <para>**Channel selection:** - If `channel` is omitted and `messageType` is
    /// `text`, defaults to SMS - If `messageType` is anything other than `text`,
    /// WhatsApp is used automatically</para>
    ///
    /// <para>**WhatsApp 24-hour window:** - Free-form messages (non-template) require
    /// an open 24h window - Window opens when the user messages you first - Use
    /// template messages to initiate conversations outside the window</para>
    ///
    /// <para>**Plan allowances and email billing:** - WhatsApp, Telegram, Instagram and
    /// Messenger share an allowance of 2,000 messages per month on Free. Over it, sends
    /// return 429 with code `a2p_limit_exceeded` and upgrade details; the counter
    /// resets on the 1st of each month. Paid plans have no message caps - Email is
    /// billed from your prepaid balance in 1,000-message blocks: $0.40 per 1,000
    /// transactional emails, $0.80 per 1,000 marketing (broadcast) emails. A block is
    /// charged when your monthly count crosses each 1,000 boundary, and at zero balance
    /// email sends return 402 with code `insufficient_balance`. Free teams start with
    /// $2 of credit and additionally cap at 3,000 emails/month and 100/day. Teams on
    /// earlier plans keep their original email quotas instead - SMS and voice are
    /// billed per message from your balance on every plan</para>
    ///
    /// <para>**Account verification and daily limits:** - A brand-new account can send
    /// on every channel immediately, but `sms`, `sms_oneway` and `voice` reach only the
    /// phone numbers the project has verified. Sending elsewhere returns `403` with
    /// code `destination_not_verified`; `details.verifiedNumbers` lists the numbers
    /// that are reachable. A number is verified from the dashboard's Sandbox screen:
    /// generate a code and send the pre-filled WhatsApp message from that phone to
    /// Zavu's sandbox number. One verification covers WhatsApp, SMS and calls, up to 5
    /// numbers per project. To send to any destination, do any one of these: verify
    /// your identity, add a payment method, settle a deposit, or subscribe to a paid
    /// plan. Business verification (KYB) is never required to send - Daily ceilings
    /// apply per channel group and rise with verification. An account that has verified
    /// nothing: 25/day across `sms` + `sms_oneway`, 5/day for `voice`, 100/day across
    /// WhatsApp, Telegram, Instagram and Messenger combined. Past that floor: 200/day
    /// for SMS, or 10,000/day once identity or business verification is approved (or a
    /// higher limit agreed for your account); 50/day voice and 250/day conversational
    /// on Free. **Paid plans have no voice or conversational daily ceiling.** Over a
    /// ceiling, sends return `429` with code `daily_limit_exceeded` and
    /// `details.limit`; the count resets at 00:00 UTC - The daily ceiling never reduces
    /// the monthly allowance: 100/day on the conversational group still reaches the
    /// 2,000 monthly A2P messages Free includes - Email needs no account verification
    /// here: a sender with a verified domain sends from day one, within the plan quota
    /// (100/day and 3,000/month on Free). Over the daily quota it returns `429` with
    /// code `daily_limit_exceeded`. Email broadcasts are the exception: they need the
    /// account past the unverified level, see `POST /v1/broadcasts/{broadcastId}/send`
    /// - Full reference: https://docs.zavu.dev/concepts/sending-limits</para>
    ///
    /// <para>**Email recipient pre-flight:** Email messages are validated automatically
    /// before dispatch. Sends that would be a guaranteed hard bounce are failed instead
    /// of sent, protecting your bounce rate: the message transitions to `failed`
    /// (visible via `GET /v1/messages/{messageId}` and the `message.failed` webhook)
    /// with `errorCode` set to `EMAIL_INVALID_RECIPIENT` (malformed address),
    /// `EMAIL_DOMAIN_NOT_FOUND` (recipient domain has no MX or A records), or
    /// `EMAIL_RECIPIENT_SUPPRESSED` (address is on your suppression list after a
    /// previous bounce or complaint). Advisory signals (role addresses, disposable
    /// domains) do not block sends — check them beforehand with `POST
    /// /v1/introspect/email`.</para>
    /// </summary>
    Task<MessageResponse> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Mark an inbound WhatsApp message as read and display a typing indicator to the
    /// user while you prepare a response. The indicator is automatically dismissed when
    /// you send a reply, or after 25 seconds — whichever comes first. Only valid for
    /// inbound WhatsApp messages. Use this when a reply will take more than a couple of
    /// seconds (LLM agent, tool call, lookup) to improve the recipient's experience.
    /// </summary>
    Task<MessageShowTypingResponse> ShowTyping(
        MessageShowTypingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ShowTyping(MessageShowTypingParams, CancellationToken)"/>
    Task<MessageShowTypingResponse> ShowTyping(
        string messageID,
        MessageShowTypingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/messages/{messageId}</c>, but is otherwise the
    /// same as <see cref="IMessageService.Retrieve(MessageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessageResponse>> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.List(MessageListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageListPage>> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/messages/{messageId}/attachments</c>, but is otherwise the
    /// same as <see cref="IMessageService.ListAttachments(MessageListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageListAttachmentsResponse>> ListAttachments(
        MessageListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(MessageListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<MessageListAttachmentsResponse>> ListAttachments(
        string messageID,
        MessageListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages/{messageId}/reactions</c>, but is otherwise the
    /// same as <see cref="IMessageService.React(MessageReactParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageResponse>> React(
        MessageReactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="React(MessageReactParams, CancellationToken)"/>
    Task<HttpResponse<MessageResponse>> React(
        string messageID,
        MessageReactParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.Send(MessageSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageResponse>> Send(
        MessageSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/messages/{messageId}/typing</c>, but is otherwise the
    /// same as <see cref="IMessageService.ShowTyping(MessageShowTypingParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageShowTypingResponse>> ShowTyping(
        MessageShowTypingParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ShowTyping(MessageShowTypingParams, CancellationToken)"/>
    Task<HttpResponse<MessageShowTypingResponse>> ShowTyping(
        string messageID,
        MessageShowTypingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
