using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Invitations;

[JsonConverter(
    typeof(JsonModelConverter<InvitationListPageResponse, InvitationListPageResponseFromRaw>)
)]
public sealed record class InvitationListPageResponse : JsonModel
{
    public required IReadOnlyList<Invitation> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Invitation>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Invitation>>(
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

    public InvitationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationListPageResponse(InvitationListPageResponse invitationListPageResponse)
        : base(invitationListPageResponse) { }
#pragma warning restore CS8618

    public InvitationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationListPageResponseFromRaw.FromRawUnchecked"/>
    public static InvitationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvitationListPageResponse(IReadOnlyList<Invitation> items)
        : this()
    {
        this.Items = items;
    }
}

class InvitationListPageResponseFromRaw : IFromRawJson<InvitationListPageResponse>
{
    /// <inheritdoc/>
    public InvitationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationListPageResponse.FromRawUnchecked(rawData);
}
