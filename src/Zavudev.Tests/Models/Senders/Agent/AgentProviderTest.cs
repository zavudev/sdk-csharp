using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentProviderTest : TestBase
{
    [Theory]
    [InlineData(AgentProvider.OpenAI)]
    [InlineData(AgentProvider.Anthropic)]
    [InlineData(AgentProvider.Google)]
    [InlineData(AgentProvider.Mistral)]
    [InlineData(AgentProvider.Zavu)]
    public void Validation_Works(AgentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentProvider.OpenAI)]
    [InlineData(AgentProvider.Anthropic)]
    [InlineData(AgentProvider.Google)]
    [InlineData(AgentProvider.Mistral)]
    [InlineData(AgentProvider.Zavu)]
    public void SerializationRoundtrip_Works(AgentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
