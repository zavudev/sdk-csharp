using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Invitations;

[JsonConverter(
    typeof(JsonModelConverter<InvitationCancelResponse, InvitationCancelResponseFromRaw>)
)]
public sealed record class InvitationCancelResponse : JsonModel
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

    public InvitationCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationCancelResponse(InvitationCancelResponse invitationCancelResponse)
        : base(invitationCancelResponse) { }
#pragma warning restore CS8618

    public InvitationCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvitationCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvitationCancelResponseFromRaw.FromRawUnchecked"/>
    public static InvitationCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvitationCancelResponse(Invitation invitation)
        : this()
    {
        this.Invitation = invitation;
    }
}

class InvitationCancelResponseFromRaw : IFromRawJson<InvitationCancelResponse>
{
    /// <inheritdoc/>
    public InvitationCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvitationCancelResponse.FromRawUnchecked(rawData);
}
