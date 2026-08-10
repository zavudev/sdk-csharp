using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Content for non-text broadcast message types.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BroadcastContent, BroadcastContentFromRaw>))]
public sealed record class BroadcastContent : JsonModel
{
    /// <summary>
    /// Filename for documents.
    /// </summary>
    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// Media ID if already uploaded.
    /// </summary>
    public string? MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaId", value);
        }
    }

    /// <summary>
    /// URL of the media file.
    /// </summary>
    public string? MediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaUrl", value);
        }
    }

    /// <summary>
    /// MIME type of the media.
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mimeType", value);
        }
    }

    /// <summary>
    /// Default button variables for dynamic URL/OTP buttons. Keys are the button
    /// index (0, 1, 2). Per-contact values override these.
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateButtonVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateButtonVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateButtonVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Default value for a text-header variable, keyed by `1` (can be overridden
    /// per contact). If omitted, Zavu resolves the header from `templateVariables`
    /// by the header placeholder's name.
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateHeaderVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateHeaderVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateHeaderVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Template ID for template messages.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("templateId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("templateId", value);
        }
    }

    /// <summary>
    /// Default body variables (can be overridden per contact). Key them to match
    /// the template body: by position (`1`, `2`, ...) for positional templates, or
    /// by name (e.g. `customer_name`) for named templates. Zavu detects the template's
    /// format and sends the correct payload to Meta. Do not mix positional and named keys.
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Filename;
        _ = this.MediaID;
        _ = this.MediaUrl;
        _ = this.MimeType;
        _ = this.TemplateButtonVariables;
        _ = this.TemplateHeaderVariables;
        _ = this.TemplateID;
        _ = this.TemplateVariables;
    }

    public BroadcastContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastContent(BroadcastContent broadcastContent)
        : base(broadcastContent) { }
#pragma warning restore CS8618

    public BroadcastContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastContentFromRaw.FromRawUnchecked"/>
    public static BroadcastContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastContentFromRaw : IFromRawJson<BroadcastContent>
{
    /// <inheritdoc/>
    public BroadcastContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BroadcastContent.FromRawUnchecked(rawData);
}
