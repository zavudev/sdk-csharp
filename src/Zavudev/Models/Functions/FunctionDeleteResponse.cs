using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions;

[JsonConverter(typeof(JsonModelConverter<FunctionDeleteResponse, FunctionDeleteResponseFromRaw>))]
public sealed record class FunctionDeleteResponse : JsonModel
{
    public required bool Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("deleted");
        }
        init { this._rawData.Set("deleted", value); }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slug");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deleted;
        _ = this.Name;
        _ = this.Slug;
    }

    public FunctionDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionDeleteResponse(FunctionDeleteResponse functionDeleteResponse)
        : base(functionDeleteResponse) { }
#pragma warning restore CS8618

    public FunctionDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FunctionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FunctionDeleteResponse(bool deleted)
        : this()
    {
        this.Deleted = deleted;
    }
}

class FunctionDeleteResponseFromRaw : IFromRawJson<FunctionDeleteResponse>
{
    /// <inheritdoc/>
    public FunctionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FunctionDeleteResponse.FromRawUnchecked(rawData);
}
