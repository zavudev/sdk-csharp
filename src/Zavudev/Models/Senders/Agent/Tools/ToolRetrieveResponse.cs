using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolRetrieveResponse, ToolRetrieveResponseFromRaw>))]
public sealed record class ToolRetrieveResponse : JsonModel
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

    public ToolRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolRetrieveResponse(ToolRetrieveResponse toolRetrieveResponse)
        : base(toolRetrieveResponse) { }
#pragma warning restore CS8618

    public ToolRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ToolRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolRetrieveResponse(AgentTool tool)
        : this()
    {
        this.Tool = tool;
    }
}

class ToolRetrieveResponseFromRaw : IFromRawJson<ToolRetrieveResponse>
{
    /// <inheritdoc/>
    public ToolRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolRetrieveResponse.FromRawUnchecked(rawData);
}
