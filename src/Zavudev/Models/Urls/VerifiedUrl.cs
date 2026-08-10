using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Urls;

[JsonConverter(typeof(JsonModelConverter<VerifiedUrl, VerifiedUrlFromRaw>))]
public sealed record class VerifiedUrl : JsonModel
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

    /// <summary>
    /// Domain extracted from the URL.
    /// </summary>
    public required string Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <summary>
    /// Status of a verified URL.
    /// </summary>
    public required ApiEnum<string, VerifiedUrlStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, VerifiedUrlStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The verified URL.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// How the URL was approved or rejected.
    /// </summary>
    public ApiEnum<string, ApprovalType>? ApprovalType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApprovalType>>("approvalType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("approvalType", value);
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
        _ = this.CreatedAt;
        _ = this.Domain;
        this.Status.Validate();
        _ = this.Url;
        this.ApprovalType?.Validate();
        _ = this.UpdatedAt;
    }

    public VerifiedUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifiedUrl(VerifiedUrl verifiedUrl)
        : base(verifiedUrl) { }
#pragma warning restore CS8618

    public VerifiedUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifiedUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VerifiedUrlFromRaw.FromRawUnchecked"/>
    public static VerifiedUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VerifiedUrlFromRaw : IFromRawJson<VerifiedUrl>
{
    /// <inheritdoc/>
    public VerifiedUrl FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VerifiedUrl.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of a verified URL.
/// </summary>
[JsonConverter(typeof(VerifiedUrlStatusConverter))]
public enum VerifiedUrlStatus
{
    Pending,
    Approved,
    Rejected,
    Escalated,
    Malicious,
}

sealed class VerifiedUrlStatusConverter : JsonConverter<VerifiedUrlStatus>
{
    public override VerifiedUrlStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => VerifiedUrlStatus.Pending,
            "approved" => VerifiedUrlStatus.Approved,
            "rejected" => VerifiedUrlStatus.Rejected,
            "escalated" => VerifiedUrlStatus.Escalated,
            "malicious" => VerifiedUrlStatus.Malicious,
            _ => (VerifiedUrlStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifiedUrlStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VerifiedUrlStatus.Pending => "pending",
                VerifiedUrlStatus.Approved => "approved",
                VerifiedUrlStatus.Rejected => "rejected",
                VerifiedUrlStatus.Escalated => "escalated",
                VerifiedUrlStatus.Malicious => "malicious",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// How the URL was approved or rejected.
/// </summary>
[JsonConverter(typeof(ApprovalTypeConverter))]
public enum ApprovalType
{
    Manual,
    AutoWebRisk,
}

sealed class ApprovalTypeConverter : JsonConverter<ApprovalType>
{
    public override ApprovalType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "manual" => ApprovalType.Manual,
            "auto_web_risk" => ApprovalType.AutoWebRisk,
            _ => (ApprovalType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApprovalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ApprovalType.Manual => "manual",
                ApprovalType.AutoWebRisk => "auto_web_risk",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
