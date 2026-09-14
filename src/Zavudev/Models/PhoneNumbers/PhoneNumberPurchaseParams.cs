using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Purchase an available phone number. Requires a paid plan: the Free plan cannot
/// purchase phone numbers and receives `402` with code `paid_plan_required`.
///
/// <para>**The included number.** A paid plan includes one number at no charge,
/// once per account: it must be a US or Canadian number (a +1 number) costing $20
/// a month or less. `isFreeEligible` in `GET /v1/phone-numbers/available` marks the
/// numbers that qualify. Claiming it spends the benefit for good, across every team
/// the account owner owns, so releasing that number does not make another one free.</para>
///
/// <para>**Numbers with regulatory requirements.** Which numbers need regulatory
/// information is decided per number, not by a fixed country list. The purchase looks
/// the requirements up for the exact number before charging anything:</para>
///
/// <para>1. `GET /v1/phone-numbers/requirements?phoneNumber=...`. If `items` is
/// empty, buy normally. 2. Create what it asks for: addresses with `POST /v1/addresses`,
/// documents with `POST /v1/documents`. 3. Purchase with `type` and `regulatoryRequirements`.
/// The number is bought and billed at once with `regulatoryStatus: pending_review`.
/// 4. Poll `GET /v1/phone-numbers/{phoneNumberId}` until `regulatoryStatus` is `approved`.
/// Assign it to a sender before or after approval; it starts carrying messages once approved.</para>
///
/// <para>**Reuse.** Information you submitted is kept for your project, per country
/// and `type`, and a later purchase there may omit `regulatoryRequirements`. Reuse
/// only happens when what is kept still covers every requirement of the new number
/// and every address and document in it belongs to the project. Otherwise, or when
/// nothing is kept, the purchase returns `400 regulatory_compliance_required` with
/// the missing requirements in `details`.</para>
///
/// <para>Invalid values (a missing, unknown or repeated requirement id, an address
/// or document from another project, or one rejected in review) return `400 invalid_request`.
/// If an address or document cannot be registered for review, the purchase returns
/// `400 invalid_request` naming the requirement. If the requirements cannot be looked
/// up, the purchase returns `502 requirements_unavailable`, except for US and Canadian
/// numbers, which are sold as numbers without requirements. None of these errors
/// charge anything.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberPurchaseParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Phone number in E.164 format.
    /// </summary>
    public required string PhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawBodyData.Set("phoneNumber", value); }
    }

    /// <summary>
    /// Optional custom name for the phone number.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// Regulatory information, for numbers whose requirements list is not empty.
    /// Get the list with `GET /v1/phone-numbers/requirements?phoneNumber=...` and
    /// send one entry per requirement id, except `action` requirements, which take
    /// no value. Every required id must be present, once, and no unknown id may
    /// be sent; otherwise the purchase is refused with `400 invalid_request` before
    /// anything is charged.
    ///
    /// <para>The information is kept for your project under the number's country
    /// and `type`. A later purchase there may omit this field if what is kept still
    /// covers that number's requirements. Omit it for numbers without requirements.</para>
    /// </summary>
    public IReadOnlyList<RegulatoryRequirement>? RegulatoryRequirements
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<RegulatoryRequirement>>(
                "regulatoryRequirements"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<RegulatoryRequirement>?>(
                "regulatoryRequirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Type of phone number. `mobile` is stocked in countries where no geographic
    /// (`local`) or non-geographic (`national`) inventory exists, and in several
    /// markets it is the only type that can receive SMS.
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? Type
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PhoneNumberType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    public PhoneNumberPurchaseParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberPurchaseParams(PhoneNumberPurchaseParams phoneNumberPurchaseParams)
        : base(phoneNumberPurchaseParams)
    {
        this._rawBodyData = new(phoneNumberPurchaseParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PhoneNumberPurchaseParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberPurchaseParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberPurchaseParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PhoneNumberPurchaseParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/phone-numbers")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<RegulatoryRequirement, RegulatoryRequirementFromRaw>))]
public sealed record class RegulatoryRequirement : JsonModel
{
    /// <summary>
    /// Depends on the requirement's `type`: the text itself for `textual`; for `address`,
    /// the `id` of an address created in this project with `POST /v1/addresses`;
    /// for `document`, the `id` of a document created with `POST /v1/documents`.
    /// An address or document from another project, or one rejected in review, is refused.
    /// </summary>
    public required string FieldValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fieldValue");
        }
        init { this._rawData.Set("fieldValue", value); }
    }

    /// <summary>
    /// A `requirementTypes[].id` from `GET /v1/phone-numbers/requirements`. Each
    /// id may appear only once.
    /// </summary>
    public required string RequirementType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requirementType");
        }
        init { this._rawData.Set("requirementType", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldValue;
        _ = this.RequirementType;
    }

    public RegulatoryRequirement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryRequirement(RegulatoryRequirement regulatoryRequirement)
        : base(regulatoryRequirement) { }
#pragma warning restore CS8618

    public RegulatoryRequirement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryRequirement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegulatoryRequirementFromRaw : IFromRawJson<RegulatoryRequirement>
{
    /// <inheritdoc/>
    public RegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RegulatoryRequirement.FromRawUnchecked(rawData);
}
