using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders.Agent;

/// <summary>
/// Status of an agent execution.
/// </summary>
[JsonConverter(typeof(AgentExecutionStatusConverter))]
public enum AgentExecutionStatus
{
    Success,
    Error,
    Filtered,
    RateLimited,
    BalanceInsufficient,
}

sealed class AgentExecutionStatusConverter : JsonConverter<AgentExecutionStatus>
{
    public override AgentExecutionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AgentExecutionStatus.Success,
            "error" => AgentExecutionStatus.Error,
            "filtered" => AgentExecutionStatus.Filtered,
            "rate_limited" => AgentExecutionStatus.RateLimited,
            "balance_insufficient" => AgentExecutionStatus.BalanceInsufficient,
            _ => (AgentExecutionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentExecutionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentExecutionStatus.Success => "success",
                AgentExecutionStatus.Error => "error",
                AgentExecutionStatus.Filtered => "filtered",
                AgentExecutionStatus.RateLimited => "rate_limited",
                AgentExecutionStatus.BalanceInsufficient => "balance_insufficient",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
