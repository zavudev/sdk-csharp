using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(
    typeof(JsonModelConverter<SubAccountRetrieveResponse, SubAccountRetrieveResponseFromRaw>)
)]
public sealed record class SubAccountRetrieveResponse : JsonModel
{
    public required SubAccount SubAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SubAccount>("subAccount");
        }
        init { this._rawData.Set("subAccount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SubAccount.Validate();
    }

    public SubAccountRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccountRetrieveResponse(SubAccountRetrieveResponse subAccountRetrieveResponse)
        : base(subAccountRetrieveResponse) { }
#pragma warning restore CS8618

    public SubAccountRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccountRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SubAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubAccountRetrieveResponse(SubAccount subAccount)
        : this()
    {
        this.SubAccount = subAccount;
    }
}

class SubAccountRetrieveResponseFromRaw : IFromRawJson<SubAccountRetrieveResponse>
{
    /// <inheritdoc/>
    public SubAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubAccountRetrieveResponse.FromRawUnchecked(rawData);
}
