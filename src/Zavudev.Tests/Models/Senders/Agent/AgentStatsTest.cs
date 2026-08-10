using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentStatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
            AvgLatencyMs = 0,
        };

        long expectedErrorCount = 0;
        long expectedSuccessCount = 0;
        double expectedTotalCost = 0;
        long expectedTotalInvocations = 0;
        long expectedTotalTokensUsed = 0;
        double expectedAvgLatencyMs = 0;

        Assert.Equal(expectedErrorCount, model.ErrorCount);
        Assert.Equal(expectedSuccessCount, model.SuccessCount);
        Assert.Equal(expectedTotalCost, model.TotalCost);
        Assert.Equal(expectedTotalInvocations, model.TotalInvocations);
        Assert.Equal(expectedTotalTokensUsed, model.TotalTokensUsed);
        Assert.Equal(expectedAvgLatencyMs, model.AvgLatencyMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
            AvgLatencyMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentStats>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
            AvgLatencyMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentStats>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedErrorCount = 0;
        long expectedSuccessCount = 0;
        double expectedTotalCost = 0;
        long expectedTotalInvocations = 0;
        long expectedTotalTokensUsed = 0;
        double expectedAvgLatencyMs = 0;

        Assert.Equal(expectedErrorCount, deserialized.ErrorCount);
        Assert.Equal(expectedSuccessCount, deserialized.SuccessCount);
        Assert.Equal(expectedTotalCost, deserialized.TotalCost);
        Assert.Equal(expectedTotalInvocations, deserialized.TotalInvocations);
        Assert.Equal(expectedTotalTokensUsed, deserialized.TotalTokensUsed);
        Assert.Equal(expectedAvgLatencyMs, deserialized.AvgLatencyMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
            AvgLatencyMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        Assert.Null(model.AvgLatencyMs);
        Assert.False(model.RawData.ContainsKey("avgLatencyMs"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,

            AvgLatencyMs = null,
        };

        Assert.Null(model.AvgLatencyMs);
        Assert.True(model.RawData.ContainsKey("avgLatencyMs"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,

            AvgLatencyMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentStats
        {
            ErrorCount = 0,
            SuccessCount = 0,
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
            AvgLatencyMs = 0,
        };

        AgentStats copied = new(model);

        Assert.Equal(model, copied);
    }
}
