using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;
using Zavudev.Services;

namespace Zavudev.Models.Conversations;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IConversationService.ListMessages(ConversationListMessagesParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ConversationListMessagesPage(
    IConversationServiceWithRawResponse service,
    ConversationListMessagesParams parameters,
    ConversationListMessagesPageResponse response
) : IPage<Message>
{
    /// <inheritdoc/>
    public IReadOnlyList<Message> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.NextCursor != null;
        }
        catch (ZavudevInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<Message>> IPage<Message>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ConversationListMessagesPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor =
            response.NextCursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .ListMessages(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not ConversationListMessagesPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
