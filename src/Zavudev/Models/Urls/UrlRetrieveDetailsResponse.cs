using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Urls;

[JsonConverter(
    typeof(JsonModelConverter<UrlRetrieveDetailsResponse, UrlRetrieveDetailsResponseFromRaw>)
)]
public sealed record class UrlRetrieveDetailsResponse : JsonModel
{
    public required VerifiedUrl Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifiedUrl>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Url.Validate();
    }

    public UrlRetrieveDetailsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlRetrieveDetailsResponse(UrlRetrieveDetailsResponse urlRetrieveDetailsResponse)
        : base(urlRetrieveDetailsResponse) { }
#pragma warning restore CS8618

    public UrlRetrieveDetailsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlRetrieveDetailsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlRetrieveDetailsResponseFromRaw.FromRawUnchecked"/>
    public static UrlRetrieveDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlRetrieveDetailsResponse(VerifiedUrl url)
        : this()
    {
        this.Url = url;
    }
}

class UrlRetrieveDetailsResponseFromRaw : IFromRawJson<UrlRetrieveDetailsResponse>
{
    /// <inheritdoc/>
    public UrlRetrieveDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlRetrieveDetailsResponse.FromRawUnchecked(rawData);
}
