using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

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

    /// <summary>
    /// Regulatory review state. Numbers that need no review are `approved` immediately.
    /// A number bought with regulatory information is owned and billed from purchase
    /// and starts `pending_review`; it cannot send messages or place calls until
    /// this is `approved`. The state is re-checked every 6 hours: poll `GET /v1/phone-numbers/{phoneNumberId}`
    /// to follow it.
    ///
    /// <para>Assign it to a sender with `PATCH /v1/phone-numbers/{phoneNumberId}`
    /// (`senderId`) before or after approval. A number assigned while under review
    /// is recorded and connected to that sender when it is approved; the connection
    /// is retried until it succeeds. A sender created over the API is set up for
    /// SMS as part of the assignment. `rejected` means review refused the information:
    /// the number cannot be assigned to a sender. A number that stays `pending_review`
    /// may be waiting on information the API cannot supply; contact support.</para>
    /// </summary>
    public required ApiEnum<string, RegulatoryStatus> RegulatoryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RegulatoryStatus>>(
                "regulatoryStatus"
            );
        }
        init { this._rawData.Set("regulatoryStatus", value); }
    }

    /// <summary>
    /// Billing state of an owned number, separate from `regulatoryStatus`. `pending`
    /// is legacy and is not written to numbers today. The SDKs carry `active`, `suspended`
    /// and `pending` only; `releasing` and `released` are returned by the REST API
    /// until their next release.
    /// </summary>
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
        this.RegulatoryStatus.Validate();
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

/// <summary>
/// Regulatory review state. Numbers that need no review are `approved` immediately.
/// A number bought with regulatory information is owned and billed from purchase
/// and starts `pending_review`; it cannot send messages or place calls until this
/// is `approved`. The state is re-checked every 6 hours: poll `GET /v1/phone-numbers/{phoneNumberId}`
/// to follow it.
///
/// <para>Assign it to a sender with `PATCH /v1/phone-numbers/{phoneNumberId}` (`senderId`)
/// before or after approval. A number assigned while under review is recorded and
/// connected to that sender when it is approved; the connection is retried until
/// it succeeds. A sender created over the API is set up for SMS as part of the assignment.
/// `rejected` means review refused the information: the number cannot be assigned
/// to a sender. A number that stays `pending_review` may be waiting on information
/// the API cannot supply; contact support.</para>
/// </summary>
[JsonConverter(typeof(RegulatoryStatusConverter))]
public enum RegulatoryStatus
{
    Approved,
    PendingReview,
    Rejected,
}

sealed class RegulatoryStatusConverter : JsonConverter<RegulatoryStatus>
{
    public override RegulatoryStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => RegulatoryStatus.Approved,
            "pending_review" => RegulatoryStatus.PendingReview,
            "rejected" => RegulatoryStatus.Rejected,
            _ => (RegulatoryStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegulatoryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegulatoryStatus.Approved => "approved",
                RegulatoryStatus.PendingReview => "pending_review",
                RegulatoryStatus.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
