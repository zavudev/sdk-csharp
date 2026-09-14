using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Urls;

[JsonConverter(typeof(JsonModelConverter<UrlEscalateResponse, UrlEscalateResponseFromRaw>))]
public sealed record class UrlEscalateResponse : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

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
        _ = this.Message;
        this.Url.Validate();
    }

    public UrlEscalateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEscalateResponse(UrlEscalateResponse urlEscalateResponse)
        : base(urlEscalateResponse) { }
#pragma warning restore CS8618

    public UrlEscalateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEscalateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEscalateResponseFromRaw.FromRawUnchecked"/>
    public static UrlEscalateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlEscalateResponseFromRaw : IFromRawJson<UrlEscalateResponse>
{
    /// <inheritdoc/>
    public UrlEscalateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlEscalateResponse.FromRawUnchecked(rawData);
}
