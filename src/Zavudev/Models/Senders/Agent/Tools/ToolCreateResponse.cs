using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolCreateResponse, ToolCreateResponseFromRaw>))]
public sealed record class ToolCreateResponse : JsonModel
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

    public ToolCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolCreateResponse(ToolCreateResponse toolCreateResponse)
        : base(toolCreateResponse) { }
#pragma warning restore CS8618

    public ToolCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolCreateResponseFromRaw.FromRawUnchecked"/>
    public static ToolCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolCreateResponse(AgentTool tool)
        : this()
    {
        this.Tool = tool;
    }
}

class ToolCreateResponseFromRaw : IFromRawJson<ToolCreateResponse>
{
    /// <inheritdoc/>
    public ToolCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolCreateResponse.FromRawUnchecked(rawData);
}
