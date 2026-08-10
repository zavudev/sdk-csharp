using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(
    typeof(JsonModelConverter<SubAccountDeactivateResponse, SubAccountDeactivateResponseFromRaw>)
)]
public sealed record class SubAccountDeactivateResponse : JsonModel
{
    /// <summary>
    /// Number of API keys revoked.
    /// </summary>
    public required long KeysRevoked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("keysRevoked");
        }
        init { this._rawData.Set("keysRevoked", value); }
    }

    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.KeysRevoked;
        _ = this.Message;
    }

    public SubAccountDeactivateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccountDeactivateResponse(SubAccountDeactivateResponse subAccountDeactivateResponse)
        : base(subAccountDeactivateResponse) { }
#pragma warning restore CS8618

    public SubAccountDeactivateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccountDeactivateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountDeactivateResponseFromRaw.FromRawUnchecked"/>
    public static SubAccountDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubAccountDeactivateResponseFromRaw : IFromRawJson<SubAccountDeactivateResponse>
{
    /// <inheritdoc/>
    public SubAccountDeactivateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubAccountDeactivateResponse.FromRawUnchecked(rawData);
}
