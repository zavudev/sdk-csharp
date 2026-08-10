using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberCapabilities, PhoneNumberCapabilitiesFromRaw>))]
public sealed record class PhoneNumberCapabilities : JsonModel
{
    public bool? Mms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("mms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mms", value);
        }
    }

    public bool? Sms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("sms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sms", value);
        }
    }

    public bool? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Mms;
        _ = this.Sms;
        _ = this.Voice;
    }

    public PhoneNumberCapabilities() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberCapabilities(PhoneNumberCapabilities phoneNumberCapabilities)
        : base(phoneNumberCapabilities) { }
#pragma warning restore CS8618

    public PhoneNumberCapabilities(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberCapabilities(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberCapabilitiesFromRaw.FromRawUnchecked"/>
    public static PhoneNumberCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneNumberCapabilitiesFromRaw : IFromRawJson<PhoneNumberCapabilities>
{
    /// <inheritdoc/>
    public PhoneNumberCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberCapabilities.FromRawUnchecked(rawData);
}
