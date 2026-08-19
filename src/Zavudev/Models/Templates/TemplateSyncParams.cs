using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Templates;

/// <summary>
/// Reconcile this project's templates against WhatsApp. Two things happen per connected
/// WhatsApp Business Account: templates that exist on Meta but not in Zavu are imported
/// (or linked to an existing template with the same name), and the approval status
/// of the templates Zavu already knows about is refreshed from Meta.
///
/// <para>This is what to call when a template was created outside Zavu — in Meta
/// Business Manager, or by another tool — or when a `template.status_changed` webhook
/// was missed and a template is stuck in `pending`. Status changes normally arrive
/// by webhook; this endpoint is the recovery path and the only path for a template
/// Zavu never created.</para>
///
/// <para>Templates that Meta reports as rejected or disabled are not imported; they
/// are counted in `skipped`. Existing local templates are matched first by Meta
/// template ID, then by name.</para>
///
/// <para>By default every sender in the project with a WhatsApp Business Account
/// is synced. Pass `senderId` to sync only that sender's account. The call is synchronous
/// — it waits for Meta and returns what changed — so it can take a few seconds per
/// account. A failure on one account does not fail the request: it is reported in
/// `errors` and the remaining accounts are still synced.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateSyncParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Sync only the WhatsApp Business Account attached to this sender. If omitted,
    /// every WhatsApp sender in the project is synced.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("senderId", value);
        }
    }

    public TemplateSyncParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateSyncParams(TemplateSyncParams templateSyncParams)
        : base(templateSyncParams)
    {
        this._rawBodyData = new(templateSyncParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplateSyncParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateSyncParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TemplateSyncParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TemplateSyncParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/templates/sync")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
