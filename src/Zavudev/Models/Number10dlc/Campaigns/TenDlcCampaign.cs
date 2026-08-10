using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(typeof(JsonModelConverter<TenDlcCampaign, TenDlcCampaignFromRaw>))]
public sealed record class TenDlcCampaign : JsonModel
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

    public required bool AffiliateMarketing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("affiliateMarketing");
        }
        init { this._rawData.Set("affiliateMarketing", value); }
    }

    public required bool AgeGated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("ageGated");
        }
        init { this._rawData.Set("ageGated", value); }
    }

    /// <summary>
    /// ID of the brand this campaign belongs to.
    /// </summary>
    public required string BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("brandId");
        }
        init { this._rawData.Set("brandId", value); }
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
    /// Description of the messaging campaign.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required bool DirectLending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("directLending");
        }
        init { this._rawData.Set("directLending", value); }
    }

    public required bool EmbeddedLink
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("embeddedLink");
        }
        init { this._rawData.Set("embeddedLink", value); }
    }

    public required bool EmbeddedPhone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("embeddedPhone");
        }
        init { this._rawData.Set("embeddedPhone", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required bool NumberPooling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("numberPooling");
        }
        init { this._rawData.Set("numberPooling", value); }
    }

    /// <summary>
    /// Sample messages representative of campaign content.
    /// </summary>
    public required IReadOnlyList<string> SampleMessages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("sampleMessages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "sampleMessages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Status of a 10DLC campaign registration.
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

    public required bool SubscriberHelp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("subscriberHelp");
        }
        init { this._rawData.Set("subscriberHelp", value); }
    }

    public required bool SubscriberOptIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("subscriberOptIn");
        }
        init { this._rawData.Set("subscriberOptIn", value); }
    }

    public required bool SubscriberOptOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("subscriberOptOut");
        }
        init { this._rawData.Set("subscriberOptOut", value); }
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

    /// <summary>
    /// Campaign use case type.
    /// </summary>
    public required string UseCase
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("useCase");
        }
        init { this._rawData.Set("useCase", value); }
    }

    public DateTimeOffset? ApprovedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("approvedAt");
        }
        init { this._rawData.Set("approvedAt", value); }
    }

    /// <summary>
    /// Daily message limit based on brand trust score.
    /// </summary>
    public long? DailyLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("dailyLimit");
        }
        init { this._rawData.Set("dailyLimit", value); }
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

    public string? HelpMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("helpMessage");
        }
        init { this._rawData.Set("helpMessage", value); }
    }

    public string? MessageFlow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("messageFlow");
        }
        init { this._rawData.Set("messageFlow", value); }
    }

    /// <summary>
    /// Recurring monthly fee in cents.
    /// </summary>
    public long? MonthlyFeeCents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("monthlyFeeCents");
        }
        init { this._rawData.Set("monthlyFeeCents", value); }
    }

    public IReadOnlyList<string>? OptInKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("optInKeywords");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "optInKeywords",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? OptOutKeywords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("optOutKeywords");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "optOutKeywords",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One-time registration cost in cents.
    /// </summary>
    public long? RegistrationCostCents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("registrationCostCents");
        }
        init { this._rawData.Set("registrationCostCents", value); }
    }

    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submittedAt");
        }
        init { this._rawData.Set("submittedAt", value); }
    }

    public IReadOnlyList<string>? SubUseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("subUseCases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "subUseCases",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AffiliateMarketing;
        _ = this.AgeGated;
        _ = this.BrandID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DirectLending;
        _ = this.EmbeddedLink;
        _ = this.EmbeddedPhone;
        _ = this.Name;
        _ = this.NumberPooling;
        _ = this.SampleMessages;
        this.Status.Validate();
        _ = this.SubscriberHelp;
        _ = this.SubscriberOptIn;
        _ = this.SubscriberOptOut;
        _ = this.UpdatedAt;
        _ = this.UseCase;
        _ = this.ApprovedAt;
        _ = this.DailyLimit;
        _ = this.FailureReason;
        _ = this.HelpMessage;
        _ = this.MessageFlow;
        _ = this.MonthlyFeeCents;
        _ = this.OptInKeywords;
        _ = this.OptOutKeywords;
        _ = this.RegistrationCostCents;
        _ = this.SubmittedAt;
        _ = this.SubUseCases;
    }

    public TenDlcCampaign() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcCampaign(TenDlcCampaign tenDlcCampaign)
        : base(tenDlcCampaign) { }
#pragma warning restore CS8618

    public TenDlcCampaign(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcCampaign(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenDlcCampaignFromRaw.FromRawUnchecked"/>
    public static TenDlcCampaign FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenDlcCampaignFromRaw : IFromRawJson<TenDlcCampaign>
{
    /// <inheritdoc/>
    public TenDlcCampaign FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenDlcCampaign.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of a 10DLC campaign registration.
/// </summary>
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
        Type typeToConvert,
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
