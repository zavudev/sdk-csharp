using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders;

/// <summary>
/// WhatsApp Business profile information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WhatsappBusinessProfile, WhatsappBusinessProfileFromRaw>))]
public sealed record class WhatsappBusinessProfile : JsonModel
{
    /// <summary>
    /// Short description of the business (max 139 characters).
    /// </summary>
    public string? About
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("about");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("about", value);
        }
    }

    /// <summary>
    /// Physical address of the business (max 256 characters).
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Extended description of the business (max 512 characters).
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Business email address.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// URL of the business profile picture.
    /// </summary>
    public string? ProfilePictureUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profilePictureUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("profilePictureUrl", value);
        }
    }

    /// <summary>
    /// Business category for WhatsApp Business profile.
    /// </summary>
    public ApiEnum<string, WhatsappBusinessProfileVertical>? Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WhatsappBusinessProfileVertical>>(
                "vertical"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vertical", value);
        }
    }

    /// <summary>
    /// Business website URLs (maximum 2).
    /// </summary>
    public IReadOnlyList<string>? Websites
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("websites");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "websites",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.About;
        _ = this.Address;
        _ = this.Description;
        _ = this.Email;
        _ = this.ProfilePictureUrl;
        this.Vertical?.Validate();
        _ = this.Websites;
    }

    public WhatsappBusinessProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappBusinessProfile(WhatsappBusinessProfile whatsappBusinessProfile)
        : base(whatsappBusinessProfile) { }
#pragma warning restore CS8618

    public WhatsappBusinessProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappBusinessProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappBusinessProfileFromRaw.FromRawUnchecked"/>
    public static WhatsappBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappBusinessProfileFromRaw : IFromRawJson<WhatsappBusinessProfile>
{
    /// <inheritdoc/>
    public WhatsappBusinessProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WhatsappBusinessProfile.FromRawUnchecked(rawData);
}
