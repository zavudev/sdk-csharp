using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<TenDlcPhoneNumberAssignment, TenDlcPhoneNumberAssignmentFromRaw>)
)]
public sealed record class TenDlcPhoneNumberAssignment : JsonModel
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

    public required string CampaignID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("campaignId");
        }
        init { this._rawData.Set("campaignId", value); }
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

    public required string PhoneNumberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumberId");
        }
        init { this._rawData.Set("phoneNumberId", value); }
    }

    /// <summary>
    /// Assignment status.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    public DateTimeOffset? AssignedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("assignedAt");
        }
        init { this._rawData.Set("assignedAt", value); }
    }

    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failureReason");
        }
        init { this._rawData.Set("failureReason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CampaignID;
        _ = this.CreatedAt;
        _ = this.PhoneNumberID;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.AssignedAt;
        _ = this.FailureReason;
    }

    public TenDlcPhoneNumberAssignment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcPhoneNumberAssignment(TenDlcPhoneNumberAssignment tenDlcPhoneNumberAssignment)
        : base(tenDlcPhoneNumberAssignment) { }
#pragma warning restore CS8618

    public TenDlcPhoneNumberAssignment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcPhoneNumberAssignment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenDlcPhoneNumberAssignmentFromRaw.FromRawUnchecked"/>
    public static TenDlcPhoneNumberAssignment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenDlcPhoneNumberAssignmentFromRaw : IFromRawJson<TenDlcPhoneNumberAssignment>
{
    /// <inheritdoc/>
    public TenDlcPhoneNumberAssignment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TenDlcPhoneNumberAssignment.FromRawUnchecked(rawData);
}

/// <summary>
/// Assignment status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Active,
    Failed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "active" => Status.Active,
            "failed" => Status.Failed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Active => "active",
                Status.Failed => "failed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
