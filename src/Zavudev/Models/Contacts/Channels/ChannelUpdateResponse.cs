using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Contacts.Channels;

[JsonConverter(typeof(JsonModelConverter<ChannelUpdateResponse, ChannelUpdateResponseFromRaw>))]
public sealed record class ChannelUpdateResponse : JsonModel
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

    public ChannelUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelUpdateResponse(ChannelUpdateResponse channelUpdateResponse)
        : base(channelUpdateResponse) { }
#pragma warning restore CS8618

    public ChannelUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ChannelUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelUpdateResponse(ContactChannel channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ChannelUpdateResponseFromRaw : IFromRawJson<ChannelUpdateResponse>
{
    /// <inheritdoc/>
    public ChannelUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChannelUpdateResponse.FromRawUnchecked(rawData);
}
