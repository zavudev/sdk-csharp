using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        MessageListAttachmentsResponse,
        MessageListAttachmentsResponseFromRaw
    >)
)]
public sealed record class MessageListAttachmentsResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public MessageListAttachmentsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListAttachmentsResponse(
        MessageListAttachmentsResponse messageListAttachmentsResponse
    )
        : base(messageListAttachmentsResponse) { }
#pragma warning restore CS8618

    public MessageListAttachmentsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListAttachmentsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageListAttachmentsResponseFromRaw.FromRawUnchecked"/>
    public static MessageListAttachmentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageListAttachmentsResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class MessageListAttachmentsResponseFromRaw : IFromRawJson<MessageListAttachmentsResponse>
{
    /// <inheritdoc/>
    public MessageListAttachmentsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageListAttachmentsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A stored file attachment for an email message (inbound or outbound).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Content-ID for inline attachments (referenced in the HTML body as `cid:&lt;contentId&gt;`).
    /// Null for regular attachments.
    /// </summary>
    public required string? ContentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contentId");
        }
        init { this._rawData.Set("contentId", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Short-lived signed URL to download the attachment bytes. Freshly generated
    /// on each request and expires; do not cache it. Null if the stored file is no
    /// longer available.
    /// </summary>
    public required string? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("downloadUrl");
        }
        init { this._rawData.Set("downloadUrl", value); }
    }

    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// Whether the attachment is inline (embedded in the HTML body) rather than
    /// a regular attachment.
    /// </summary>
    public required bool IsInline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isInline");
        }
        init { this._rawData.Set("isInline", value); }
    }

    /// <summary>
    /// MIME type of the attachment.
    /// </summary>
    public required string MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mimeType");
        }
        init { this._rawData.Set("mimeType", value); }
    }

    /// <summary>
    /// Size of the attachment in bytes.
    /// </summary>
    public required long Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size");
        }
        init { this._rawData.Set("size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ContentID;
        _ = this.CreatedAt;
        _ = this.DownloadUrl;
        _ = this.Filename;
        _ = this.IsInline;
        _ = this.MimeType;
        _ = this.Size;
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
