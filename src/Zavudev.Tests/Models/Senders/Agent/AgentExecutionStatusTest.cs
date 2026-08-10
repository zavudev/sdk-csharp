using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentExecutionStatusTest : TestBase
{
    [Theory]
    [InlineData(AgentExecutionStatus.Success)]
    [InlineData(AgentExecutionStatus.Error)]
    [InlineData(AgentExecutionStatus.Filtered)]
    [InlineData(AgentExecutionStatus.RateLimited)]
    [InlineData(AgentExecutionStatus.BalanceInsufficient)]
    public void Validation_Works(AgentExecutionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentExecutionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentExecutionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentExecutionStatus.Success)]
    [InlineData(AgentExecutionStatus.Error)]
    [InlineData(AgentExecutionStatus.Filtered)]
    [InlineData(AgentExecutionStatus.RateLimited)]
    [InlineData(AgentExecutionStatus.BalanceInsufficient)]
    public void SerializationRoundtrip_Works(AgentExecutionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentExecutionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentExecutionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentExecutionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentExecutionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
