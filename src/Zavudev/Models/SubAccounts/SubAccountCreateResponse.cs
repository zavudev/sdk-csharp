using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(
    typeof(JsonModelConverter<SubAccountCreateResponse, SubAccountCreateResponseFromRaw>)
)]
public sealed record class SubAccountCreateResponse : JsonModel
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

    public SubAccountCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccountCreateResponse(SubAccountCreateResponse subAccountCreateResponse)
        : base(subAccountCreateResponse) { }
#pragma warning restore CS8618

    public SubAccountCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccountCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountCreateResponseFromRaw.FromRawUnchecked"/>
    public static SubAccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubAccountCreateResponse(SubAccount subAccount)
        : this()
    {
        this.SubAccount = subAccount;
    }
}

class SubAccountCreateResponseFromRaw : IFromRawJson<SubAccountCreateResponse>
{
    /// <inheritdoc/>
    public SubAccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubAccountCreateResponse.FromRawUnchecked(rawData);
}
