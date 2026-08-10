using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Balance;

[JsonConverter(typeof(JsonModelConverter<BalanceRetrieveResponse, BalanceRetrieveResponseFromRaw>))]
public sealed record class BalanceRetrieveResponse : JsonModel
{
    /// <summary>
    /// Team balance in cents. All charges are billed to the parent team.
    /// </summary>
    public required long Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Spending cap in cents (only for sub-accounts).
    /// </summary>
    public long? CreditLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("creditLimit");
        }
        init { this._rawData.Set("creditLimit", value); }
    }

    /// <summary>
    /// Whether this API key belongs to a sub-account.
    /// </summary>
    public bool? IsSubAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isSubAccount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isSubAccount", value);
        }
    }

    /// <summary>
    /// Total amount spent by this sub-account in cents (only for sub-accounts).
    /// </summary>
    public long? TotalSpent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalSpent");
        }
        init { this._rawData.Set("totalSpent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Balance;
        _ = this.Currency;
        _ = this.CreditLimit;
        _ = this.IsSubAccount;
        _ = this.TotalSpent;
    }

    public BalanceRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceRetrieveResponse(BalanceRetrieveResponse balanceRetrieveResponse)
        : base(balanceRetrieveResponse) { }
#pragma warning restore CS8618

    public BalanceRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BalanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceRetrieveResponseFromRaw : IFromRawJson<BalanceRetrieveResponse>
{
    /// <inheritdoc/>
    public BalanceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceRetrieveResponse.FromRawUnchecked(rawData);
}
