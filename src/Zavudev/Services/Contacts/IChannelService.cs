using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Services.Contacts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Update a contact's channel properties.
    /// </summary>
    Task<ChannelUpdateResponse> Update(
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ChannelUpdateParams, CancellationToken)"/>
    Task<ChannelUpdateResponse> Update(
        string channelID,
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a new communication channel to an existing contact.
    /// </summary>
    Task<ChannelAddResponse> Add(
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ChannelAddParams, CancellationToken)"/>
    Task<ChannelAddResponse> Add(
        string contactID,
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a communication channel from a contact. Cannot remove the last channel.
    /// </summary>
    Task Remove(ChannelRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Remove(ChannelRemoveParams, CancellationToken)"/>
    Task Remove(
        string channelID,
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set a channel as the primary channel for its type.
    /// </summary>
    Task<ChannelSetPrimaryResponse> SetPrimary(
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPrimary(ChannelSetPrimaryParams, CancellationToken)"/>
    Task<ChannelSetPrimaryResponse> SetPrimary(
        string channelID,
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/contacts/{contactId}/channels/{channelId}</c>, but is otherwise the
    /// same as <see cref="IChannelService.Update(ChannelUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChannelUpdateResponse>> Update(
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ChannelUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ChannelUpdateResponse>> Update(
        string channelID,
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/contacts/{contactId}/channels</c>, but is otherwise the
    /// same as <see cref="IChannelService.Add(ChannelAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChannelAddResponse>> Add(
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(ChannelAddParams, CancellationToken)"/>
    Task<HttpResponse<ChannelAddResponse>> Add(
        string contactID,
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/contacts/{contactId}/channels/{channelId}</c>, but is otherwise the
    /// same as <see cref="IChannelService.Remove(ChannelRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(ChannelRemoveParams, CancellationToken)"/>
    Task<HttpResponse> Remove(
        string channelID,
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/contacts/{contactId}/channels/{channelId}/primary</c>, but is otherwise the
    /// same as <see cref="IChannelService.SetPrimary(ChannelSetPrimaryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChannelSetPrimaryResponse>> SetPrimary(
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetPrimary(ChannelSetPrimaryParams, CancellationToken)"/>
    Task<HttpResponse<ChannelSetPrimaryResponse>> SetPrimary(
        string channelID,
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    );
}
