using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Templates;

[JsonConverter(
    typeof(JsonModelConverter<TemplateListPageResponse, TemplateListPageResponseFromRaw>)
)]
public sealed record class TemplateListPageResponse : JsonModel
{
    public required IReadOnlyList<Template> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Template>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Template>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public TemplateListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateListPageResponse(TemplateListPageResponse templateListPageResponse)
        : base(templateListPageResponse) { }
#pragma warning restore CS8618

    public TemplateListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateListPageResponseFromRaw.FromRawUnchecked"/>
    public static TemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TemplateListPageResponse(IReadOnlyList<Template> items)
        : this()
    {
        this.Items = items;
    }
}

class TemplateListPageResponseFromRaw : IFromRawJson<TemplateListPageResponse>
{
    /// <inheritdoc/>
    public TemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateListPageResponse.FromRawUnchecked(rawData);
}
