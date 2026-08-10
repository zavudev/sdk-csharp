using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<AgentTool, AgentToolFromRaw>))]
public sealed record class AgentTool : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentId");
        }
        init { this._rawData.Set("agentId", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Description for the LLM to understand when to use this tool.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ToolParameters Parameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToolParameters>("parameters");
        }
        init { this._rawData.Set("parameters", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// HTTPS URL to call when the tool is executed.
    /// </summary>
    public required string WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("webhookUrl");
        }
        init { this._rawData.Set("webhookUrl", value); }
    }

    /// <summary>
    /// Signing secret for this tool's webhook. **Returned only when the tool is
    /// created**, never on a later read.
    ///
    /// <para>Zavu generates one if you do not supply it, and signs every call to
    /// this tool with it: `X-Zavu-Signature: &lt;hex&gt;`, the HMAC-SHA256 of the
    /// request body. Verify it before trusting the call. Lost it? Rotate with `POST /v1/senders/{senderId}/agent/tools/{toolId}/webhook/secret`.</para>
    /// </summary>
    public string? WebhookSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhookSecret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookSecret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Enabled;
        _ = this.Name;
        this.Parameters.Validate();
        _ = this.UpdatedAt;
        _ = this.WebhookUrl;
        _ = this.WebhookSecret;
    }

    public AgentTool() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTool(AgentTool agentTool)
        : base(agentTool) { }
#pragma warning restore CS8618

    public AgentTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentToolFromRaw.FromRawUnchecked"/>
    public static AgentTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentToolFromRaw : IFromRawJson<AgentTool>
{
    /// <inheritdoc/>
    public AgentTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentTool.FromRawUnchecked(rawData);
}
