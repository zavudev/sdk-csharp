using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Urls;

[JsonConverter(
    typeof(JsonModelConverter<
        UrlSubmitForVerificationResponse,
        UrlSubmitForVerificationResponseFromRaw
    >)
)]
public sealed record class UrlSubmitForVerificationResponse : JsonModel
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

    public UrlSubmitForVerificationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlSubmitForVerificationResponse(
        UrlSubmitForVerificationResponse urlSubmitForVerificationResponse
    )
        : base(urlSubmitForVerificationResponse) { }
#pragma warning restore CS8618

    public UrlSubmitForVerificationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlSubmitForVerificationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlSubmitForVerificationResponseFromRaw.FromRawUnchecked"/>
    public static UrlSubmitForVerificationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlSubmitForVerificationResponse(VerifiedUrl url)
        : this()
    {
        this.Url = url;
    }
}

class UrlSubmitForVerificationResponseFromRaw : IFromRawJson<UrlSubmitForVerificationResponse>
{
    /// <inheritdoc/>
    public UrlSubmitForVerificationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlSubmitForVerificationResponse.FromRawUnchecked(rawData);
}
