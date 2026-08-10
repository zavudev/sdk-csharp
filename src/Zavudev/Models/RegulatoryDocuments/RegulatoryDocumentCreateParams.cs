using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.RegulatoryDocuments;

/// <summary>
/// Create a regulatory document record after uploading the file. Use the upload-url
/// endpoint first to get an upload URL.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RegulatoryDocumentCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required ApiEnum<string, DocumentType> DocumentType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, DocumentType>>("documentType");
        }
        init { this._rawBodyData.Set("documentType", value); }
    }

    public required long FileSize
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("fileSize");
        }
        init { this._rawBodyData.Set("fileSize", value); }
    }

    public required string MimeType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("mimeType");
        }
        init { this._rawBodyData.Set("mimeType", value); }
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
    /// Storage ID from the upload-url endpoint.
    /// </summary>
    public required string StorageID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("storageId");
        }
        init { this._rawBodyData.Set("storageId", value); }
    }

    public RegulatoryDocumentCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegulatoryDocumentCreateParams(
        RegulatoryDocumentCreateParams regulatoryDocumentCreateParams
    )
        : base(regulatoryDocumentCreateParams)
    {
        this._rawBodyData = new(regulatoryDocumentCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RegulatoryDocumentCreateParams(
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
    RegulatoryDocumentCreateParams(
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
    public static RegulatoryDocumentCreateParams FromRawUnchecked(
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

    public virtual bool Equals(RegulatoryDocumentCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/documents")
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

[JsonConverter(typeof(DocumentTypeConverter))]
public enum DocumentType
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

sealed class DocumentTypeConverter : JsonConverter<DocumentType>
{
    public override DocumentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "passport" => DocumentType.Passport,
            "national_id" => DocumentType.NationalID,
            "drivers_license" => DocumentType.DriversLicense,
            "utility_bill" => DocumentType.UtilityBill,
            "tax_id" => DocumentType.TaxID,
            "business_registration" => DocumentType.BusinessRegistration,
            "proof_of_address" => DocumentType.ProofOfAddress,
            "other" => DocumentType.Other,
            _ => (DocumentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DocumentType.Passport => "passport",
                DocumentType.NationalID => "national_id",
                DocumentType.DriversLicense => "drivers_license",
                DocumentType.UtilityBill => "utility_bill",
                DocumentType.TaxID => "tax_id",
                DocumentType.BusinessRegistration => "business_registration",
                DocumentType.ProofOfAddress => "proof_of_address",
                DocumentType.Other => "other",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
