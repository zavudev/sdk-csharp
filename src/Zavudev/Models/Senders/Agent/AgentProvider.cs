using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders.Agent;

/// <summary>
/// LLM provider for the AI agent.
/// </summary>
[JsonConverter(typeof(AgentProviderConverter))]
public enum AgentProvider
{
    OpenAI,
    Anthropic,
    Google,
    Mistral,
    Zavu,
}

sealed class AgentProviderConverter : JsonConverter<AgentProvider>
{
    public override AgentProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "openai" => AgentProvider.OpenAI,
            "anthropic" => AgentProvider.Anthropic,
            "google" => AgentProvider.Google,
            "mistral" => AgentProvider.Mistral,
            "zavu" => AgentProvider.Zavu,
            _ => (AgentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgentProvider.OpenAI => "openai",
                AgentProvider.Anthropic => "anthropic",
                AgentProvider.Google => "google",
                AgentProvider.Mistral => "mistral",
                AgentProvider.Zavu => "zavu",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
