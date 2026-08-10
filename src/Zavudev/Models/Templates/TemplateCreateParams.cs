using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using System = System;

namespace Zavudev.Models.Templates;

/// <summary>
/// Create a WhatsApp message template. Note: Templates must be approved by Meta
/// before use.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Default template body. Used when no channel-specific body is set.
    /// </summary>
    public required string Body
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("body");
        }
        init { this._rawBodyData.Set("body", value); }
    }

    public required string Language
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("language");
        }
        init { this._rawBodyData.Set("language", value); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Add 'Do not share this code' disclaimer. Only for AUTHENTICATION templates.
    /// </summary>
    public bool? AddSecurityRecommendation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("addSecurityRecommendation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("addSecurityRecommendation", value);
        }
    }

    /// <summary>
    /// Template buttons (max 3).
    /// </summary>
    public IReadOnlyList<Button>? Buttons
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Button>>("buttons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Button>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("codeExpirationMinutes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("codeExpirationMinutes", value);
        }
    }

    /// <summary>
    /// Footer text for the template.
    /// </summary>
    public string? Footer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("footer");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("footer", value);
        }
    }

    /// <summary>
    /// Header content (text string or media URL).
    /// </summary>
    public string? HeaderContent
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("headerContent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("headerContent", value);
        }
    }

    /// <summary>
    /// Type of header for the template.
    /// </summary>
    public ApiEnum<string, HeaderType>? HeaderType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, HeaderType>>("headerType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("headerType", value);
        }
    }

    /// <summary>
    /// Channel-specific body for Instagram. Falls back to `body` if not set.
    /// </summary>
    public string? InstagramBody
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("instagramBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("instagramBody", value);
        }
    }

    /// <summary>
    /// Channel-specific body for SMS. Falls back to `body` if not set.
    /// </summary>
    public string? SmsBody
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("smsBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("smsBody", value);
        }
    }

    /// <summary>
    /// Channel-specific body for Telegram. Falls back to `body` if not set.
    /// </summary>
    public string? TelegramBody
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("telegramBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("telegramBody", value);
        }
    }

    public IReadOnlyList<string>? Variables
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("variables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "variables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// WhatsApp template category.
    /// </summary>
    public ApiEnum<string, WhatsappCategory>? WhatsappCategory
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WhatsappCategory>>(
                "whatsappCategory"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("whatsappCategory", value);
        }
    }

    public TemplateCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateCreateParams(TemplateCreateParams templateCreateParams)
        : base(templateCreateParams)
    {
        this._rawBodyData = new(templateCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TemplateCreateParams(
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
    TemplateCreateParams(
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
    public static TemplateCreateParams FromRawUnchecked(
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

    public virtual bool Equals(TemplateCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/templates")
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

[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
{
    /// <summary>
    /// `request_contact_info` renders a fixed **Share Contact Info** button that
    /// asks the recipient to share their phone number — useful when a contact adopted
    /// a WhatsApp username and you only know their BSUID. It takes no other fields.
    /// </summary>
    public required ApiEnum<string, global::Zavudev.Models.Templates.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Zavudev.Models.Templates.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Sample value Meta uses to review templates with a dynamic URL button. Substituted
    /// into `{{1}}` of the URL when the template is submitted to Meta. Only meaningful
    /// when `url` contains `{{1}}`; ignored for static URLs.
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
    /// Required when type is 'otp'. COPY_CODE shows copy button, ONE_TAP enables
    /// Android autofill.
    /// </summary>
    public ApiEnum<string, OtpType>? OtpType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OtpType>>("otpType");
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

    /// <summary>
    /// Button label. Required for every type except `request_contact_info`, whose
    /// label is fixed by WhatsApp.
    /// </summary>
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

    /// <summary>
    /// Button destination. Use `{{1}}` exactly once for a dynamic URL (e.g. `https://example.com/orders/{{1}}`);
    /// WhatsApp only accepts the strict `{{1}}` form. Static URLs must not contain
    /// any `{{...}}` placeholder.
    /// </summary>
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
        this.Type.Validate();
        _ = this.Example;
        this.OtpType?.Validate();
        _ = this.PackageName;
        _ = this.PhoneNumber;
        _ = this.SignatureHash;
        _ = this.Text;
        _ = this.Url;
    }

    public Button() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Button(Button button)
        : base(button) { }
#pragma warning restore CS8618

    public Button(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Button(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ButtonFromRaw.FromRawUnchecked"/>
    public static Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Button(ApiEnum<string, global::Zavudev.Models.Templates.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class ButtonFromRaw : IFromRawJson<Button>
{
    /// <inheritdoc/>
    public Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Button.FromRawUnchecked(rawData);
}

/// <summary>
/// `request_contact_info` renders a fixed **Share Contact Info** button that asks
/// the recipient to share their phone number — useful when a contact adopted a WhatsApp
/// username and you only know their BSUID. It takes no other fields.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    QuickReply,
    Url,
    Phone,
    Otp,
    RequestContactInfo,
}

sealed class TypeConverter : JsonConverter<global::Zavudev.Models.Templates.Type>
{
    public override global::Zavudev.Models.Templates.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quick_reply" => global::Zavudev.Models.Templates.Type.QuickReply,
            "url" => global::Zavudev.Models.Templates.Type.Url,
            "phone" => global::Zavudev.Models.Templates.Type.Phone,
            "otp" => global::Zavudev.Models.Templates.Type.Otp,
            "request_contact_info" => global::Zavudev.Models.Templates.Type.RequestContactInfo,
            _ => (global::Zavudev.Models.Templates.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Zavudev.Models.Templates.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Zavudev.Models.Templates.Type.QuickReply => "quick_reply",
                global::Zavudev.Models.Templates.Type.Url => "url",
                global::Zavudev.Models.Templates.Type.Phone => "phone",
                global::Zavudev.Models.Templates.Type.Otp => "otp",
                global::Zavudev.Models.Templates.Type.RequestContactInfo => "request_contact_info",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Required when type is 'otp'. COPY_CODE shows copy button, ONE_TAP enables Android autofill.
/// </summary>
[JsonConverter(typeof(OtpTypeConverter))]
public enum OtpType
{
    CopyCode,
    OneTap,
}

sealed class OtpTypeConverter : JsonConverter<OtpType>
{
    public override OtpType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "COPY_CODE" => OtpType.CopyCode,
            "ONE_TAP" => OtpType.OneTap,
            _ => (OtpType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, OtpType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OtpType.CopyCode => "COPY_CODE",
                OtpType.OneTap => "ONE_TAP",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Type of header for the template.
/// </summary>
[JsonConverter(typeof(HeaderTypeConverter))]
public enum HeaderType
{
    Text,
    Image,
    Video,
    Document,
}

sealed class HeaderTypeConverter : JsonConverter<HeaderType>
{
    public override HeaderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => HeaderType.Text,
            "image" => HeaderType.Image,
            "video" => HeaderType.Video,
            "document" => HeaderType.Document,
            _ => (HeaderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        HeaderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                HeaderType.Text => "text",
                HeaderType.Image => "image",
                HeaderType.Video => "video",
                HeaderType.Document => "document",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
