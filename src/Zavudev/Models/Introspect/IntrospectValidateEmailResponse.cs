using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Introspect;

[JsonConverter(
    typeof(JsonModelConverter<
        IntrospectValidateEmailResponse,
        IntrospectValidateEmailResponseFromRaw
    >)
)]
public sealed record class IntrospectValidateEmailResponse : JsonModel
{
    /// <summary>
    /// One result per submitted address, in the same order.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Summary Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Summary>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        this.Summary.Validate();
    }

    public IntrospectValidateEmailResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrospectValidateEmailResponse(
        IntrospectValidateEmailResponse introspectValidateEmailResponse
    )
        : base(introspectValidateEmailResponse) { }
#pragma warning restore CS8618

    public IntrospectValidateEmailResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrospectValidateEmailResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrospectValidateEmailResponseFromRaw.FromRawUnchecked"/>
    public static IntrospectValidateEmailResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrospectValidateEmailResponseFromRaw : IFromRawJson<IntrospectValidateEmailResponse>
{
    /// <inheritdoc/>
    public IntrospectValidateEmailResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntrospectValidateEmailResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Domain part of the address. Null when the syntax is invalid.
    /// </summary>
    public required string? Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <summary>
    /// The address exactly as submitted.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Lowercased, trimmed form of the address. Null when the syntax is invalid.
    /// </summary>
    public required string? Normalized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("normalized");
        }
        init { this._rawData.Set("normalized", value); }
    }

    /// <summary>
    /// Signals behind the verdict. Empty for a clean `deliverable` address.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Reason>> Reasons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Reason>>>(
                "reasons"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Reason>>>(
                "reasons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Validation verdict. - `deliverable`: nothing suggests the address will bounce.
    /// - `risky`: sendable, but a signal predicts elevated bounce/complaint odds
    /// (role address, disposable domain, MX-less domain, prior soft bounce). - `undeliverable`:
    /// will bounce or is blocked (invalid syntax, dead domain, or the address is
    /// on your suppression list after a hard bounce/complaint).
    /// </summary>
    public required ApiEnum<string, Verdict> Verdict
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Verdict>>("verdict");
        }
        init { this._rawData.Set("verdict", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Domain;
        _ = this.Email;
        _ = this.Normalized;
        foreach (var item in this.Reasons)
        {
            item.Validate();
        }
        this.Verdict.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    InvalidSyntax,
    DomainNotFound,
    DomainNoMx,
    DisposableDomain,
    RoleAddress,
    SuppressedHardBounce,
    SuppressedSoftBounce,
    SuppressedComplaint,
    SuppressedManual,
    SuppressedUnsubscribe,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_syntax" => Reason.InvalidSyntax,
            "domain_not_found" => Reason.DomainNotFound,
            "domain_no_mx" => Reason.DomainNoMx,
            "disposable_domain" => Reason.DisposableDomain,
            "role_address" => Reason.RoleAddress,
            "suppressed_hard_bounce" => Reason.SuppressedHardBounce,
            "suppressed_soft_bounce" => Reason.SuppressedSoftBounce,
            "suppressed_complaint" => Reason.SuppressedComplaint,
            "suppressed_manual" => Reason.SuppressedManual,
            "suppressed_unsubscribe" => Reason.SuppressedUnsubscribe,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.InvalidSyntax => "invalid_syntax",
                Reason.DomainNotFound => "domain_not_found",
                Reason.DomainNoMx => "domain_no_mx",
                Reason.DisposableDomain => "disposable_domain",
                Reason.RoleAddress => "role_address",
                Reason.SuppressedHardBounce => "suppressed_hard_bounce",
                Reason.SuppressedSoftBounce => "suppressed_soft_bounce",
                Reason.SuppressedComplaint => "suppressed_complaint",
                Reason.SuppressedManual => "suppressed_manual",
                Reason.SuppressedUnsubscribe => "suppressed_unsubscribe",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Validation verdict. - `deliverable`: nothing suggests the address will bounce.
/// - `risky`: sendable, but a signal predicts elevated bounce/complaint odds (role
/// address, disposable domain, MX-less domain, prior soft bounce). - `undeliverable`:
/// will bounce or is blocked (invalid syntax, dead domain, or the address is on your
/// suppression list after a hard bounce/complaint).
/// </summary>
[JsonConverter(typeof(VerdictConverter))]
public enum Verdict
{
    Deliverable,
    Risky,
    Undeliverable,
}

sealed class VerdictConverter : JsonConverter<Verdict>
{
    public override Verdict Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deliverable" => Verdict.Deliverable,
            "risky" => Verdict.Risky,
            "undeliverable" => Verdict.Undeliverable,
            _ => (Verdict)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Verdict value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Verdict.Deliverable => "deliverable",
                Verdict.Risky => "risky",
                Verdict.Undeliverable => "undeliverable",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    public required long Deliverable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("deliverable");
        }
        init { this._rawData.Set("deliverable", value); }
    }

    public required long Risky
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("risky");
        }
        init { this._rawData.Set("risky", value); }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public required long Undeliverable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("undeliverable");
        }
        init { this._rawData.Set("undeliverable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deliverable;
        _ = this.Risky;
        _ = this.Total;
        _ = this.Undeliverable;
    }

    public Summary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary(Summary summary)
        : base(summary) { }
#pragma warning restore CS8618

    public Summary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Summary.FromRawUnchecked(rawData);
}
