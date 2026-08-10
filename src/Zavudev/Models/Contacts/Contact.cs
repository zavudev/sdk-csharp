using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Contacts;

[JsonConverter(typeof(JsonModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : JsonModel
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

    /// <summary>
    /// List of available messaging channels for this contact.
    /// </summary>
    public required IReadOnlyList<string> AvailableChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("availableChannels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "availableChannels",
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

    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether this contact has been verified.
    /// </summary>
    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
    }

    /// <summary>
    /// All communication channels for this contact.
    /// </summary>
    public IReadOnlyList<ContactChannel>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ContactChannel>>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ContactChannel>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// Preferred channel for this contact.
    /// </summary>
    public ApiEnum<string, ContactDefaultChannel>? DefaultChannel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ContactDefaultChannel>>(
                "defaultChannel"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultChannel", value);
        }
    }

    /// <summary>
    /// Display name for the contact.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("displayName", value);
        }
    }

    /// <summary>
    /// DEPRECATED: Use primaryPhone instead. Primary phone number in E.164 format.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// Primary email address.
    /// </summary>
    public string? PrimaryEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primaryEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primaryEmail", value);
        }
    }

    /// <summary>
    /// Primary phone number in E.164 format.
    /// </summary>
    public string? PrimaryPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primaryPhone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("primaryPhone", value);
        }
    }

    /// <summary>
    /// Contact's WhatsApp profile name. Only available for WhatsApp contacts.
    /// </summary>
    public string? ProfileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("profileName");
        }
        init { this._rawData.Set("profileName", value); }
    }

    /// <summary>
    /// ID of a contact suggested for merging.
    /// </summary>
    public string? SuggestedMergeWith
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("suggestedMergeWith");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("suggestedMergeWith", value);
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
        _ = this.AvailableChannels;
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Verified;
        foreach (var item in this.Channels ?? [])
        {
            item.Validate();
        }
        _ = this.CountryCode;
        this.DefaultChannel?.Validate();
        _ = this.DisplayName;
        _ = this.PhoneNumber;
        _ = this.PrimaryEmail;
        _ = this.PrimaryPhone;
        _ = this.ProfileName;
        _ = this.SuggestedMergeWith;
        _ = this.UpdatedAt;
    }

    public Contact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contact(Contact contact)
        : base(contact) { }
#pragma warning restore CS8618

    public Contact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactFromRaw : IFromRawJson<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// Preferred channel for this contact.
/// </summary>
[JsonConverter(typeof(ContactDefaultChannelConverter))]
public enum ContactDefaultChannel
{
    Sms,
    Whatsapp,
    Telegram,
    Email,
    Instagram,
    Messenger,
    Voice,
}

sealed class ContactDefaultChannelConverter : JsonConverter<ContactDefaultChannel>
{
    public override ContactDefaultChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => ContactDefaultChannel.Sms,
            "whatsapp" => ContactDefaultChannel.Whatsapp,
            "telegram" => ContactDefaultChannel.Telegram,
            "email" => ContactDefaultChannel.Email,
            "instagram" => ContactDefaultChannel.Instagram,
            "messenger" => ContactDefaultChannel.Messenger,
            "voice" => ContactDefaultChannel.Voice,
            _ => (ContactDefaultChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContactDefaultChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContactDefaultChannel.Sms => "sms",
                ContactDefaultChannel.Whatsapp => "whatsapp",
                ContactDefaultChannel.Telegram => "telegram",
                ContactDefaultChannel.Email => "email",
                ContactDefaultChannel.Instagram => "instagram",
                ContactDefaultChannel.Messenger => "messenger",
                ContactDefaultChannel.Voice => "voice",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
