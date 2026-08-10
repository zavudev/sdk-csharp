using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Invitations;

[JsonConverter(
    typeof(JsonModelConverter<InvitationCreateResponse, InvitationCreateResponseFromRaw>)
)]
public sealed record class InvitationCreateResponse : JsonModel
{
    public required Invitation Invitation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Invitation>("invitation");
        }
        init { this._rawData.Set("invitation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Invitation.Validate();
    }

    public InvitationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationCreateResponse(InvitationCreateResponse invitationCreateResponse)
        : base(invitationCreateResponse) { }
#pragma warning restore CS8618

    public InvitationCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationCreateResponseFromRaw.FromRawUnchecked"/>
    public static InvitationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvitationCreateResponse(Invitation invitation)
        : this()
    {
        this.Invitation = invitation;
    }
}

class InvitationCreateResponseFromRaw : IFromRawJson<InvitationCreateResponse>
{
    /// <inheritdoc/>
    public InvitationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationCreateResponse.FromRawUnchecked(rawData);
}
