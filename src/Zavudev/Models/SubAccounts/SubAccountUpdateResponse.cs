using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(
    typeof(JsonModelConverter<SubAccountUpdateResponse, SubAccountUpdateResponseFromRaw>)
)]
public sealed record class SubAccountUpdateResponse : JsonModel
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

    public SubAccountUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccountUpdateResponse(SubAccountUpdateResponse subAccountUpdateResponse)
        : base(subAccountUpdateResponse) { }
#pragma warning restore CS8618

    public SubAccountUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccountUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountUpdateResponseFromRaw.FromRawUnchecked"/>
    public static SubAccountUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubAccountUpdateResponse(SubAccount subAccount)
        : this()
    {
        this.SubAccount = subAccount;
    }
}

class SubAccountUpdateResponseFromRaw : IFromRawJson<SubAccountUpdateResponse>
{
    /// <inheritdoc/>
    public SubAccountUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubAccountUpdateResponse.FromRawUnchecked(rawData);
}
