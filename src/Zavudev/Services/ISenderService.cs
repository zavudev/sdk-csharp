using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders;
using Senders = Zavudev.Services.Senders;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISenderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISenderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Senders::IAgentService Agent { get; }

    Senders::IWhatsappSyncService WhatsappSync { get; }

    Senders::ITelegramService Telegram { get; }

    /// <summary>
    /// Create sender
    /// </summary>
    Task<Sender> Create(
        SenderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get sender
    /// </summary>
    Task<Sender> Retrieve(
        SenderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SenderRetrieveParams, CancellationToken)"/>
    Task<Sender> Retrieve(
        string senderID,
        SenderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update sender
    /// </summary>
    Task<Sender> Update(
        SenderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SenderUpdateParams, CancellationToken)"/>
    Task<Sender> Update(
        string senderID,
        SenderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List senders
    /// </summary>
    Task<SenderListPage> List(
        SenderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete sender
    /// </summary>
    Task Delete(SenderDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(SenderDeleteParams, CancellationToken)"/>
    Task Delete(
        string senderID,
        SenderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the WhatsApp Business profile for a sender. The sender must have a WhatsApp
    /// Business Account connected.
    /// </summary>
    Task<WhatsappBusinessProfileResponse> GetProfile(
        SenderGetProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetProfile(SenderGetProfileParams, CancellationToken)"/>
    Task<WhatsappBusinessProfileResponse> GetProfile(
        string senderID,
        SenderGetProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Regenerate the webhook secret for a sender. The old secret will be invalidated
    /// immediately.
    /// </summary>
    Task<WebhookSecretResponse> RegenerateWebhookSecret(
        SenderRegenerateWebhookSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RegenerateWebhookSecret(SenderRegenerateWebhookSecretParams, CancellationToken)"/>
    Task<WebhookSecretResponse> RegenerateWebhookSecret(
        string senderID,
        SenderRegenerateWebhookSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the WhatsApp Business profile for a sender. The sender must have a
    /// WhatsApp Business Account connected.
    /// </summary>
    Task<SenderUpdateProfileResponse> UpdateProfile(
        SenderUpdateProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateProfile(SenderUpdateProfileParams, CancellationToken)"/>
    Task<SenderUpdateProfileResponse> UpdateProfile(
        string senderID,
        SenderUpdateProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a new profile picture for the WhatsApp Business profile. The image will
    /// be uploaded to Meta and set as the profile picture.
    /// </summary>
    Task<SenderUploadProfilePictureResponse> UploadProfilePicture(
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadProfilePicture(SenderUploadProfilePictureParams, CancellationToken)"/>
    Task<SenderUploadProfilePictureResponse> UploadProfilePicture(
        string senderID,
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISenderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISenderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Senders::IAgentServiceWithRawResponse Agent { get; }

    Senders::IWhatsappSyncServiceWithRawResponse WhatsappSync { get; }

    Senders::ITelegramServiceWithRawResponse Telegram { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders</c>, but is otherwise the
    /// same as <see cref="ISenderService.Create(SenderCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Sender>> Create(
        SenderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}</c>, but is otherwise the
    /// same as <see cref="ISenderService.Retrieve(SenderRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Sender>> Retrieve(
        SenderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SenderRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Sender>> Retrieve(
        string senderID,
        SenderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}</c>, but is otherwise the
    /// same as <see cref="ISenderService.Update(SenderUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Sender>> Update(
        SenderUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SenderUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Sender>> Update(
        string senderID,
        SenderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders</c>, but is otherwise the
    /// same as <see cref="ISenderService.List(SenderListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SenderListPage>> List(
        SenderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}</c>, but is otherwise the
    /// same as <see cref="ISenderService.Delete(SenderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        SenderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SenderDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string senderID,
        SenderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/profile</c>, but is otherwise the
    /// same as <see cref="ISenderService.GetProfile(SenderGetProfileParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WhatsappBusinessProfileResponse>> GetProfile(
        SenderGetProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetProfile(SenderGetProfileParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappBusinessProfileResponse>> GetProfile(
        string senderID,
        SenderGetProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/webhook/secret</c>, but is otherwise the
    /// same as <see cref="ISenderService.RegenerateWebhookSecret(SenderRegenerateWebhookSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSecretResponse>> RegenerateWebhookSecret(
        SenderRegenerateWebhookSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RegenerateWebhookSecret(SenderRegenerateWebhookSecretParams, CancellationToken)"/>
    Task<HttpResponse<WebhookSecretResponse>> RegenerateWebhookSecret(
        string senderID,
        SenderRegenerateWebhookSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}/profile</c>, but is otherwise the
    /// same as <see cref="ISenderService.UpdateProfile(SenderUpdateProfileParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SenderUpdateProfileResponse>> UpdateProfile(
        SenderUpdateProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateProfile(SenderUpdateProfileParams, CancellationToken)"/>
    Task<HttpResponse<SenderUpdateProfileResponse>> UpdateProfile(
        string senderID,
        SenderUpdateProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/profile/picture</c>, but is otherwise the
    /// same as <see cref="ISenderService.UploadProfilePicture(SenderUploadProfilePictureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SenderUploadProfilePictureResponse>> UploadProfilePicture(
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadProfilePicture(SenderUploadProfilePictureParams, CancellationToken)"/>
    Task<HttpResponse<SenderUploadProfilePictureResponse>> UploadProfilePicture(
        string senderID,
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    );
}
