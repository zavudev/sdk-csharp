using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Introspect;

[JsonConverter(
    typeof(JsonModelConverter<
        IntrospectValidatePhoneResponse,
        IntrospectValidatePhoneResponseFromRaw
    >)
)]
public sealed record class IntrospectValidatePhoneResponse : JsonModel
{
    public required string CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
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

    public required bool ValidNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("validNumber");
        }
        init { this._rawData.Set("validNumber", value); }
    }

    /// <summary>
    /// List of available messaging channels for this phone number.
    /// </summary>
    public IReadOnlyList<string>? AvailableChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("availableChannels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "availableChannels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Carrier information for the phone number.
    /// </summary>
    public Carrier? Carrier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Carrier>("carrier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// Type of phone line.
    /// </summary>
    public ApiEnum<string, LineType>? LineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LineType>>("lineType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lineType", value);
        }
    }

    /// <summary>
    /// Phone number in national format.
    /// </summary>
    public string? NationalFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nationalFormat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nationalFormat", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.PhoneNumber;
        _ = this.ValidNumber;
        _ = this.AvailableChannels;
        this.Carrier?.Validate();
        this.LineType?.Validate();
        _ = this.NationalFormat;
    }

    public IntrospectValidatePhoneResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrospectValidatePhoneResponse(
        IntrospectValidatePhoneResponse introspectValidatePhoneResponse
    )
        : base(introspectValidatePhoneResponse) { }
#pragma warning restore CS8618

    public IntrospectValidatePhoneResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrospectValidatePhoneResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrospectValidatePhoneResponseFromRaw.FromRawUnchecked"/>
    public static IntrospectValidatePhoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrospectValidatePhoneResponseFromRaw : IFromRawJson<IntrospectValidatePhoneResponse>
{
    /// <inheritdoc/>
    public IntrospectValidatePhoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntrospectValidatePhoneResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Carrier information for the phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Carrier, CarrierFromRaw>))]
public sealed record class Carrier : JsonModel
{
    /// <summary>
    /// Carrier name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Type of phone line.
    /// </summary>
    public ApiEnum<string, LineType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LineType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Type?.Validate();
    }

    public Carrier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Carrier(Carrier carrier)
        : base(carrier) { }
#pragma warning restore CS8618

    public Carrier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Carrier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CarrierFromRaw.FromRawUnchecked"/>
    public static Carrier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CarrierFromRaw : IFromRawJson<Carrier>
{
    /// <inheritdoc/>
    public Carrier FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Carrier.FromRawUnchecked(rawData);
}
