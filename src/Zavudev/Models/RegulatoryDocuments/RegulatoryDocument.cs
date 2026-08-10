using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.RegulatoryDocuments;

/// <summary>
/// A regulatory document for phone number requirements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RegulatoryDocument, RegulatoryDocumentFromRaw>))]
public sealed record class RegulatoryDocument : JsonModel
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

    public required ApiEnum<string, RegulatoryDocumentDocumentType> DocumentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RegulatoryDocumentDocumentType>>(
                "documentType"
            );
        }
        init { this._rawData.Set("documentType", value); }
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

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("fileSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileSize", value);
        }
    }

    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mimeType", value);
        }
    }

    public string? RejectionReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rejectionReason");
        }
        init { this._rawData.Set("rejectionReason", value); }
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
        this.DocumentType.Validate();
        _ = this.Name;
        this.Status.Validate();
        _ = this.FileSize;
        _ = this.MimeType;
        _ = this.RejectionReason;
        _ = this.UpdatedAt;
    }

    public RegulatoryDocument() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocument(RegulatoryDocument regulatoryDocument)
        : base(regulatoryDocument) { }
#pragma warning restore CS8618

    public RegulatoryDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegulatoryDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegulatoryDocumentFromRaw.FromRawUnchecked"/>
    public static RegulatoryDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegulatoryDocumentFromRaw : IFromRawJson<RegulatoryDocument>
{
    /// <inheritdoc/>
    public RegulatoryDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RegulatoryDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RegulatoryDocumentDocumentTypeConverter))]
public enum RegulatoryDocumentDocumentType
{
    Passport,
    NationalID,
    DriversLicense,
    UtilityBill,
    TaxID,
    BusinessRegistration,
    ProofOfAddress,
    Other,
}

sealed class RegulatoryDocumentDocumentTypeConverter : JsonConverter<RegulatoryDocumentDocumentType>
{
    public override RegulatoryDocumentDocumentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "passport" => RegulatoryDocumentDocumentType.Passport,
            "national_id" => RegulatoryDocumentDocumentType.NationalID,
            "drivers_license" => RegulatoryDocumentDocumentType.DriversLicense,
            "utility_bill" => RegulatoryDocumentDocumentType.UtilityBill,
            "tax_id" => RegulatoryDocumentDocumentType.TaxID,
            "business_registration" => RegulatoryDocumentDocumentType.BusinessRegistration,
            "proof_of_address" => RegulatoryDocumentDocumentType.ProofOfAddress,
            "other" => RegulatoryDocumentDocumentType.Other,
            _ => (RegulatoryDocumentDocumentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegulatoryDocumentDocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegulatoryDocumentDocumentType.Passport => "passport",
                RegulatoryDocumentDocumentType.NationalID => "national_id",
                RegulatoryDocumentDocumentType.DriversLicense => "drivers_license",
                RegulatoryDocumentDocumentType.UtilityBill => "utility_bill",
                RegulatoryDocumentDocumentType.TaxID => "tax_id",
                RegulatoryDocumentDocumentType.BusinessRegistration => "business_registration",
                RegulatoryDocumentDocumentType.ProofOfAddress => "proof_of_address",
                RegulatoryDocumentDocumentType.Other => "other",
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
    Pending,
    Uploaded,
    Verified,
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
            "pending" => Status.Pending,
            "uploaded" => Status.Uploaded,
            "verified" => Status.Verified,
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
                Status.Pending => "pending",
                Status.Uploaded => "uploaded",
                Status.Verified => "verified",
                Status.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
