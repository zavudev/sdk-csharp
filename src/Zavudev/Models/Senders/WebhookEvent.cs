using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders;

/// <summary>
/// Type of event that triggers the webhook.
///
/// <para>**Message lifecycle events:** - `message.queued`: Message created and queued
/// for sending. `data.status` = `queued` - `message.sent`: Message accepted by the
/// provider. `data.status` = `sent` - `message.delivered`: Message delivered to recipient.
/// `data.status` = `delivered` - `message.read`: Message was read by the recipient
/// (WhatsApp only). `data.status` = `read` - `message.failed`: Message failed to
/// send. `data.status` = `failed`</para>
///
/// <para>**Inbound events:** - `message.inbound`: New message received from a contact.
/// `data.conversationId` is the inbox thread id (deep-link with `https://dashboard.zavu.dev/{locale}/inbox?conv={conversationId}`);
/// it is `null` while the conversation row is still being created (the first message
/// of a brand-new thread, or several near-simultaneous first messages), where `conversation.new`
/// carries the id instead — `GET /v1/messages/{messageId}` always has it. Reactions
/// are delivered as `message.inbound` with `messageType='reaction'`. When the contact
/// replied to (quoted) an earlier message, `data.content` carries the reply context:
/// `replyToMessageId`, `replyToProviderMessageId`, `replyToFrom`, `replyToText`,
/// and `replyToMessageType`. `data.providerTimestamp` is the provider's original
/// receive time in Unix milliseconds (the moment the channel received the message
/// from the contact — WhatsApp, Telegram, Instagram, Messenger; `null` for SMS and
/// email). Compare it against the top-level `timestamp` (when Zavu dispatched the
/// webhook) to detect and ignore delayed deliveries. When the conversation was opened
/// from a Click-to-WhatsApp ad or post, `data.referral` carries the ad attribution
/// — including `ctwaClid`, the identifier Meta's Conversions API needs to credit
/// a conversion back to that ad. WhatsApp only, and only on the first message of
/// the thread: it is absent from every later message, so persist it when it arrives.
/// - `message.unsupported`: Received a message type that is not supported</para>
///
/// <para>**Broadcast events:** - `broadcast.status_changed`: Broadcast status changed
/// (pending_review, approved, rejected, sending, completed, cancelled)</para>
///
/// <para>**Other events:** - `conversation.new`: New conversation started with a
/// contact. `data` carries `conversationId` (the inbox thread id — deep-link with
/// `https://dashboard.zavu.dev/{locale}/inbox?conv={conversationId}`), the `phoneNumber`
/// or `email` key, `channel`, `firstMessageId`, `firstMessageText`, and `profileName`.
/// - `template.status_changed`: WhatsApp template approval status changed</para>
///
/// <para>**Partner events:** - `invitation.status_changed`: A partner invitation
/// status changed (pending, in_progress, completed, cancelled, failed). `data` carries
/// `invitationId`, `clientName`, `clientEmail`, `connectionType` (`whatsapp_waba`
/// or `messenger`), `previousStatus`, and `currentStatus`. On `completed` it also
/// carries `senderId` and `connectedAccount` (`channel`, `id`, `name`) — the WhatsApp
/// number or Facebook Page that was linked. On `failed` it carries `failureReason`;
/// the invitation link stays usable, so a client can retry it.</para>
///
/// <para>**Voice Agent events:** For every voice event, `data` carries `callId`,
/// `direction`, `from`, `to`, `status`, `durationSeconds`, `endReason`, and `transcriptAvailable`.
/// The terminal events (`call.completed`, `call.failed`) additionally carry `cost`
/// — what the call was billed, in USD, combining telephony and the managed voice
/// pipeline — and `currency`. They are dispatched after the call is charged, so `cost`
/// is populated rather than zero; telephony can still be settling on an outbound
/// call, in which case `GET /v1/calls/{callId}` holds the reconciled figure. - `call.initiated`:
/// An outbound call was created and is dialing, or an inbound call was received.
/// `data.status` = `ringing` - `call.answered`: The call was answered and the voice
/// agent is connected. `data.status` = `in_progress` - `call.completed`: The call
/// ended after a conversation. `data.status` = `completed`; `durationSeconds` and
/// `endReason` describe how it ended, and `transcriptAvailable` indicates whether
/// a transcript can be fetched. - `call.failed`: The call could not be completed
/// (busy, no answer, canceled, or an error). `data.status` is the terminal status
/// and `endReason` explains the cause.</para>
///
/// <para>**Custom domain events:** - `domain.verified`: A custom email domain passed
/// verification (DKIM, and SPF/DMARC/MAIL FROM if enhanced records are enabled)
/// - `domain.failed`: A custom email domain failed verification or is partially verified</para>
/// </summary>
[JsonConverter(typeof(WebhookEventConverter))]
public enum WebhookEvent
{
    MessageQueued,
    MessageSent,
    MessageDelivered,
    MessageRead,
    MessageStatus,
    MessageFailed,
    MessageInbound,
    MessageUnsupported,
    BroadcastStatusChanged,
    ConversationNew,
    TemplateStatusChanged,
    InvitationStatusChanged,
    CallInitiated,
    CallAnswered,
    CallCompleted,
    CallFailed,
    DomainVerified,
    DomainFailed,
}

sealed class WebhookEventConverter : JsonConverter<WebhookEvent>
{
    public override WebhookEvent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message.queued" => WebhookEvent.MessageQueued,
            "message.sent" => WebhookEvent.MessageSent,
            "message.delivered" => WebhookEvent.MessageDelivered,
            "message.read" => WebhookEvent.MessageRead,
            "message.status" => WebhookEvent.MessageStatus,
            "message.failed" => WebhookEvent.MessageFailed,
            "message.inbound" => WebhookEvent.MessageInbound,
            "message.unsupported" => WebhookEvent.MessageUnsupported,
            "broadcast.status_changed" => WebhookEvent.BroadcastStatusChanged,
            "conversation.new" => WebhookEvent.ConversationNew,
            "template.status_changed" => WebhookEvent.TemplateStatusChanged,
            "invitation.status_changed" => WebhookEvent.InvitationStatusChanged,
            "call.initiated" => WebhookEvent.CallInitiated,
            "call.answered" => WebhookEvent.CallAnswered,
            "call.completed" => WebhookEvent.CallCompleted,
            "call.failed" => WebhookEvent.CallFailed,
            "domain.verified" => WebhookEvent.DomainVerified,
            "domain.failed" => WebhookEvent.DomainFailed,
            _ => (WebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEvent.MessageQueued => "message.queued",
                WebhookEvent.MessageSent => "message.sent",
                WebhookEvent.MessageDelivered => "message.delivered",
                WebhookEvent.MessageRead => "message.read",
                WebhookEvent.MessageStatus => "message.status",
                WebhookEvent.MessageFailed => "message.failed",
                WebhookEvent.MessageInbound => "message.inbound",
                WebhookEvent.MessageUnsupported => "message.unsupported",
                WebhookEvent.BroadcastStatusChanged => "broadcast.status_changed",
                WebhookEvent.ConversationNew => "conversation.new",
                WebhookEvent.TemplateStatusChanged => "template.status_changed",
                WebhookEvent.InvitationStatusChanged => "invitation.status_changed",
                WebhookEvent.CallInitiated => "call.initiated",
                WebhookEvent.CallAnswered => "call.answered",
                WebhookEvent.CallCompleted => "call.completed",
                WebhookEvent.CallFailed => "call.failed",
                WebhookEvent.DomainVerified => "domain.verified",
                WebhookEvent.DomainFailed => "domain.failed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
