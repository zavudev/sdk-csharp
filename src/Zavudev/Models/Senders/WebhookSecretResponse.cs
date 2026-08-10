using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

[JsonConverter(typeof(JsonModelConverter<WebhookSecretResponse, WebhookSecretResponseFromRaw>))]
public sealed record class WebhookSecretResponse : JsonModel
{
    /// <summary>
    /// The new webhook secret.
    /// </summary>
    public required string Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Secret;
    }

    public WebhookSecretResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookSecretResponse(WebhookSecretResponse webhookSecretResponse)
        : base(webhookSecretResponse) { }
#pragma warning restore CS8618

    public WebhookSecretResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookSecretResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookSecretResponseFromRaw.FromRawUnchecked"/>
    public static WebhookSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookSecretResponse(string secret)
        : this()
    {
        this.Secret = secret;
    }
}

class WebhookSecretResponseFromRaw : IFromRawJson<WebhookSecretResponse>
{
    /// <inheritdoc/>
    public WebhookSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookSecretResponse.FromRawUnchecked(rawData);
}
