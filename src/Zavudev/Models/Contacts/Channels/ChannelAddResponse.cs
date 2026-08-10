using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Contacts.Channels;

[JsonConverter(typeof(JsonModelConverter<ChannelAddResponse, ChannelAddResponseFromRaw>))]
public sealed record class ChannelAddResponse : JsonModel
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

    public ChannelAddResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelAddResponse(ChannelAddResponse channelAddResponse)
        : base(channelAddResponse) { }
#pragma warning restore CS8618

    public ChannelAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelAddResponseFromRaw.FromRawUnchecked"/>
    public static ChannelAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelAddResponse(ContactChannel channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ChannelAddResponseFromRaw : IFromRawJson<ChannelAddResponse>
{
    /// <inheritdoc/>
    public ChannelAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelAddResponse.FromRawUnchecked(rawData);
}
