using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
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
    /// Default template body with variables: positional ({{1}}, {{2}}) or named
    /// ({{customer_name}}, {{contact.first_name}}). Templates created in Zavu are
    /// submitted to Meta as positional; templates imported from a WhatsApp Business
    /// Account keep their original format (named or positional). Used when no channel-specific
    /// body is set.
    /// </summary>
    public required string Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// WhatsApp template category.
    /// </summary>
    public required ApiEnum<string, WhatsappCategory> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WhatsappCategory>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Language code.
    /// </summary>
    public required string Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("language");
        }
        init { this._rawData.Set("language", value); }
    }

    /// <summary>
    /// Template name. For WhatsApp, must match the approved template name in Meta.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Add 'Do not share this code' disclaimer. Only for AUTHENTICATION templates.
    /// </summary>
    public bool? AddSecurityRecommendation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("addSecurityRecommendation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("addSecurityRecommendation", value);
        }
    }

    /// <summary>
    /// Template buttons.
    /// </summary>
    public IReadOnlyList<TemplateButton>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TemplateButton>>("buttons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TemplateButton>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Code expiration time in minutes. Only for AUTHENTICATION templates.
    /// </summary>
    public long? CodeExpirationMinutes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("codeExpirationMinutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("codeExpirationMinutes", value);
        }
    }

    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Footer text for the template.
    /// </summary>
    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footer", value);
        }
    }

    /// <summary>
    /// Header content (text or media URL).
    /// </summary>
    public string? HeaderContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("headerContent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headerContent", value);
        }
    }

    /// <summary>
    /// Type of header (text, image, video, document).
    /// </summary>
    public string? HeaderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("headerType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("headerType", value);
        }
    }

    /// <summary>
    /// Channel-specific body for Instagram messages. Falls back to `body` if not set.
    /// </summary>
    public string? InstagramBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instagramBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("instagramBody", value);
        }
    }

    /// <summary>
    /// Channel-specific body for SMS messages. Falls back to `body` if not set.
    /// </summary>
    public string? SmsBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("smsBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("smsBody", value);
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Channel-specific body for Telegram messages. Falls back to `body` if not set.
    /// </summary>
    public string? TelegramBody
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("telegramBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("telegramBody", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
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

    /// <summary>
    /// List of variable names for documentation.
    /// </summary>
    public IReadOnlyList<string>? Variables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// WhatsApp-specific template information.
    /// </summary>
    public Whatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Whatsapp>("whatsapp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Body;
        this.Category.Validate();
        _ = this.Language;
        _ = this.Name;
        _ = this.AddSecurityRecommendation;
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        _ = this.CodeExpirationMinutes;
        _ = this.CreatedAt;
        _ = this.Footer;
        _ = this.HeaderContent;
        _ = this.HeaderType;
        _ = this.InstagramBody;
        _ = this.SmsBody;
        this.Status?.Validate();
        _ = this.TelegramBody;
        _ = this.UpdatedAt;
        _ = this.Variables;
        this.Whatsapp?.Validate();
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TemplateButton, TemplateButtonFromRaw>))]
public sealed record class TemplateButton : JsonModel
{
    /// <summary>
    /// Sample value used to substitute `{{1}}` in the URL when submitting the template
    /// to Meta for review. Only present for dynamic URL buttons.
    /// </summary>
    public string? Example
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("example");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("example", value);
        }
    }

    /// <summary>
    /// OTP button type. Required when type is 'otp'.
    /// </summary>
    public ApiEnum<string, TemplateButtonOtpType>? OtpType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TemplateButtonOtpType>>(
                "otpType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("otpType", value);
        }
    }

    /// <summary>
    /// Android package name. Required for ONE_TAP buttons.
    /// </summary>
    public string? PackageName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("packageName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("packageName", value);
        }
    }

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
    /// Android app signature hash. Required for ONE_TAP buttons.
    /// </summary>
    public string? SignatureHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signatureHash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signatureHash", value);
        }
    }

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public ApiEnum<string, TemplateButtonType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TemplateButtonType>>("type");
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

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Example;
        this.OtpType?.Validate();
        _ = this.PackageName;
        _ = this.PhoneNumber;
        _ = this.SignatureHash;
        _ = this.Text;
        this.Type?.Validate();
        _ = this.Url;
    }

    public TemplateButton() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateButton(TemplateButton templateButton)
        : base(templateButton) { }
#pragma warning restore CS8618

    public TemplateButton(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateButton(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateButtonFromRaw.FromRawUnchecked"/>
    public static TemplateButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateButtonFromRaw : IFromRawJson<TemplateButton>
{
    /// <inheritdoc/>
    public TemplateButton FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TemplateButton.FromRawUnchecked(rawData);
}

/// <summary>
/// OTP button type. Required when type is 'otp'.
/// </summary>
[JsonConverter(typeof(TemplateButtonOtpTypeConverter))]
public enum TemplateButtonOtpType
{
    CopyCode,
    OneTap,
}

sealed class TemplateButtonOtpTypeConverter : JsonConverter<TemplateButtonOtpType>
{
    public override TemplateButtonOtpType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COPY_CODE" => TemplateButtonOtpType.CopyCode,
            "ONE_TAP" => TemplateButtonOtpType.OneTap,
            _ => (TemplateButtonOtpType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TemplateButtonOtpType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TemplateButtonOtpType.CopyCode => "COPY_CODE",
                TemplateButtonOtpType.OneTap => "ONE_TAP",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TemplateButtonTypeConverter))]
public enum TemplateButtonType
{
    QuickReply,
    Url,
    Phone,
    Otp,
    RequestContactInfo,
}

sealed class TemplateButtonTypeConverter : JsonConverter<TemplateButtonType>
{
    public override TemplateButtonType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quick_reply" => TemplateButtonType.QuickReply,
            "url" => TemplateButtonType.Url,
            "phone" => TemplateButtonType.Phone,
            "otp" => TemplateButtonType.Otp,
            "request_contact_info" => TemplateButtonType.RequestContactInfo,
            _ => (TemplateButtonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TemplateButtonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TemplateButtonType.QuickReply => "quick_reply",
                TemplateButtonType.Url => "url",
                TemplateButtonType.Phone => "phone",
                TemplateButtonType.Otp => "otp",
                TemplateButtonType.RequestContactInfo => "request_contact_info",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Pending,
    Approved,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => Status.Draft,
            "pending" => Status.Pending,
            "approved" => Status.Approved,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Pending => "pending",
                Status.Approved => "approved",
                Status.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// WhatsApp-specific template information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Whatsapp, WhatsappFromRaw>))]
public sealed record class Whatsapp : JsonModel
{
    /// <summary>
    /// WhatsApp Business Account namespace.
    /// </summary>
    public string? Namespace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("namespace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("namespace", value);
        }
    }

    /// <summary>
    /// WhatsApp approval status.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// WhatsApp template name.
    /// </summary>
    public string? TemplateName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("templateName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("templateName", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Namespace;
        _ = this.Status;
        _ = this.TemplateName;
    }

    public Whatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Whatsapp(Whatsapp whatsapp)
        : base(whatsapp) { }
#pragma warning restore CS8618

    public Whatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Whatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappFromRaw.FromRawUnchecked"/>
    public static Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappFromRaw : IFromRawJson<Whatsapp>
{
    /// <inheritdoc/>
    public Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Whatsapp.FromRawUnchecked(rawData);
}
