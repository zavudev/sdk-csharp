using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts.Contacts;

[JsonConverter(typeof(JsonModelConverter<ContactAddResponse, ContactAddResponseFromRaw>))]
public sealed record class ContactAddResponse : JsonModel
{
    /// <summary>
    /// Number of contacts successfully added.
    /// </summary>
    public required long Added
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("added");
        }
        init { this._rawData.Set("added", value); }
    }

    /// <summary>
    /// Number of duplicate contacts skipped.
    /// </summary>
    public required long Duplicates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duplicates");
        }
        init { this._rawData.Set("duplicates", value); }
    }

    /// <summary>
    /// Number of invalid contacts rejected.
    /// </summary>
    public required long Invalid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("invalid");
        }
        init { this._rawData.Set("invalid", value); }
    }

    /// <summary>
    /// Details about invalid contacts.
    /// </summary>
    public IReadOnlyList<Error>? Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Error>>("errors");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Error>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Added;
        _ = this.Duplicates;
        _ = this.Invalid;
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
    }

    public ContactAddResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactAddResponse(ContactAddResponse contactAddResponse)
        : base(contactAddResponse) { }
#pragma warning restore CS8618

    public ContactAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactAddResponseFromRaw.FromRawUnchecked"/>
    public static ContactAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactAddResponseFromRaw : IFromRawJson<ContactAddResponse>
{
    /// <inheritdoc/>
    public ContactAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactAddResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    public string? Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("recipient");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("recipient", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        _ = this.Recipient;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}
