using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<OwnedPhoneNumber, OwnedPhoneNumberFromRaw>))]
public sealed record class OwnedPhoneNumber : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyList<string> Capabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("capabilities");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "capabilities",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public required OwnedPhoneNumberPricing Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OwnedPhoneNumberPricing>("pricing");
        }
        init { this._rawData.Set("pricing", value); }
    }

    public required ApiEnum<string, PhoneNumberStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhoneNumberStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Optional custom name for the phone number.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public DateTimeOffset? NextRenewalDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("nextRenewalDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nextRenewalDate", value);
        }
    }

    /// <summary>
    /// Sender ID if the phone number is assigned to a sender.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("senderId", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Capabilities;
        _ = this.CreatedAt;
        _ = this.PhoneNumber;
        this.Pricing.Validate();
        this.Status.Validate();
        _ = this.Name;
        _ = this.NextRenewalDate;
        _ = this.SenderID;
        _ = this.UpdatedAt;
    }

    public OwnedPhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OwnedPhoneNumber(OwnedPhoneNumber ownedPhoneNumber)
        : base(ownedPhoneNumber) { }
#pragma warning restore CS8618

    public OwnedPhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OwnedPhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OwnedPhoneNumberFromRaw.FromRawUnchecked"/>
    public static OwnedPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnedPhoneNumberFromRaw : IFromRawJson<OwnedPhoneNumber>
{
    /// <inheritdoc/>
    public OwnedPhoneNumber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OwnedPhoneNumber.FromRawUnchecked(rawData);
}
