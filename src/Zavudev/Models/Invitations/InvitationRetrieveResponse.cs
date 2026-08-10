using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Invitations;

[JsonConverter(
    typeof(JsonModelConverter<InvitationRetrieveResponse, InvitationRetrieveResponseFromRaw>)
)]
public sealed record class InvitationRetrieveResponse : JsonModel
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

    public InvitationRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationRetrieveResponse(InvitationRetrieveResponse invitationRetrieveResponse)
        : base(invitationRetrieveResponse) { }
#pragma warning restore CS8618

    public InvitationRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InvitationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvitationRetrieveResponse(Invitation invitation)
        : this()
    {
        this.Invitation = invitation;
    }
}

class InvitationRetrieveResponseFromRaw : IFromRawJson<InvitationRetrieveResponse>
{
    /// <inheritdoc/>
    public InvitationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationRetrieveResponse.FromRawUnchecked(rawData);
}
