using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<BroadcastContact, BroadcastContactFromRaw>))]
public sealed record class BroadcastContact : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    public required ApiEnum<string, RecipientType> RecipientType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecipientType>>("recipientType");
        }
        init { this._rawData.Set("recipientType", value); }
    }

    /// <summary>
    /// Status of a contact within a broadcast.
    /// </summary>
    public required ApiEnum<string, BroadcastContactStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastContactStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorCode", value);
        }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("errorMessage", value);
        }
    }

    /// <summary>
    /// Associated message ID after processing.
    /// </summary>
    public string? MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("messageId", value);
        }
    }

    public DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("processedAt", value);
        }
    }

    public IReadOnlyDictionary<string, string>? TemplateButtonVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateButtonVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateButtonVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, string>? TemplateHeaderVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateHeaderVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateHeaderVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, string>? TemplateVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Recipient;
        this.RecipientType.Validate();
        this.Status.Validate();
        _ = this.Cost;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.MessageID;
        _ = this.ProcessedAt;
        _ = this.TemplateButtonVariables;
        _ = this.TemplateHeaderVariables;
        _ = this.TemplateVariables;
    }

    public BroadcastContact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastContact(BroadcastContact broadcastContact)
        : base(broadcastContact) { }
#pragma warning restore CS8618

    public BroadcastContact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastContact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastContactFromRaw.FromRawUnchecked"/>
    public static BroadcastContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastContactFromRaw : IFromRawJson<BroadcastContact>
{
    /// <inheritdoc/>
    public BroadcastContact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BroadcastContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecipientTypeConverter))]
public enum RecipientType
{
    Phone,
    Email,
}

sealed class RecipientTypeConverter : JsonConverter<RecipientType>
{
    public override RecipientType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "phone" => RecipientType.Phone,
            "email" => RecipientType.Email,
            _ => (RecipientType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecipientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RecipientType.Phone => "phone",
                RecipientType.Email => "email",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
