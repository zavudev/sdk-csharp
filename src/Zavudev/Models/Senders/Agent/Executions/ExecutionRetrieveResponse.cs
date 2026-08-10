using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Executions;

[JsonConverter(
    typeof(JsonModelConverter<ExecutionRetrieveResponse, ExecutionRetrieveResponseFromRaw>)
)]
public sealed record class ExecutionRetrieveResponse : JsonModel
{
    public required AgentExecution Execution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentExecution>("execution");
        }
        init { this._rawData.Set("execution", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Execution.Validate();
    }

    public ExecutionRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExecutionRetrieveResponse(ExecutionRetrieveResponse executionRetrieveResponse)
        : base(executionRetrieveResponse) { }
#pragma warning restore CS8618

    public ExecutionRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExecutionRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExecutionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ExecutionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExecutionRetrieveResponse(AgentExecution execution)
        : this()
    {
        this.Execution = execution;
    }
}

class ExecutionRetrieveResponseFromRaw : IFromRawJson<ExecutionRetrieveResponse>
{
    /// <inheritdoc/>
    public ExecutionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExecutionRetrieveResponse.FromRawUnchecked(rawData);
}
