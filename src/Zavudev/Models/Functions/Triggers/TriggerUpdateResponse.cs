using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions.Triggers;

[JsonConverter(typeof(JsonModelConverter<TriggerUpdateResponse, TriggerUpdateResponseFromRaw>))]
public sealed record class TriggerUpdateResponse : JsonModel
{
    public required bool Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("active");
        }
        init { this._rawData.Set("active", value); }
    }

    public required bool Ok
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("ok");
        }
        init { this._rawData.Set("ok", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        _ = this.Ok;
    }

    public TriggerUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TriggerUpdateResponse(TriggerUpdateResponse triggerUpdateResponse)
        : base(triggerUpdateResponse) { }
#pragma warning restore CS8618

    public TriggerUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TriggerUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TriggerUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TriggerUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TriggerUpdateResponseFromRaw : IFromRawJson<TriggerUpdateResponse>
{
    /// <inheritdoc/>
    public TriggerUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TriggerUpdateResponse.FromRawUnchecked(rawData);
}
