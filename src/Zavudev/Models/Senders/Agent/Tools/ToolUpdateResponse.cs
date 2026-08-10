using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolUpdateResponse, ToolUpdateResponseFromRaw>))]
public sealed record class ToolUpdateResponse : JsonModel
{
    public required AgentTool Tool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentTool>("tool");
        }
        init { this._rawData.Set("tool", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Tool.Validate();
    }

    public ToolUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUpdateResponse(ToolUpdateResponse toolUpdateResponse)
        : base(toolUpdateResponse) { }
#pragma warning restore CS8618

    public ToolUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ToolUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolUpdateResponse(AgentTool tool)
        : this()
    {
        this.Tool = tool;
    }
}

class ToolUpdateResponseFromRaw : IFromRawJson<ToolUpdateResponse>
{
    /// <inheritdoc/>
    public ToolUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolUpdateResponse.FromRawUnchecked(rawData);
}
