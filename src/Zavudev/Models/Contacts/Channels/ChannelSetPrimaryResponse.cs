using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Contacts.Channels;

[JsonConverter(
    typeof(JsonModelConverter<ChannelSetPrimaryResponse, ChannelSetPrimaryResponseFromRaw>)
)]
public sealed record class ChannelSetPrimaryResponse : JsonModel
{
    /// <summary>
    /// A communication channel for a contact.
    /// </summary>
    public required ContactChannel Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContactChannel>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channel.Validate();
    }

    public ChannelSetPrimaryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelSetPrimaryResponse(ChannelSetPrimaryResponse channelSetPrimaryResponse)
        : base(channelSetPrimaryResponse) { }
#pragma warning restore CS8618

    public ChannelSetPrimaryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelSetPrimaryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelSetPrimaryResponseFromRaw.FromRawUnchecked"/>
    public static ChannelSetPrimaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelSetPrimaryResponse(ContactChannel channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ChannelSetPrimaryResponseFromRaw : IFromRawJson<ChannelSetPrimaryResponse>
{
    /// <inheritdoc/>
    public ChannelSetPrimaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChannelSetPrimaryResponse.FromRawUnchecked(rawData);
}
