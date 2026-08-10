using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastStatusTest : TestBase
{
    [Theory]
    [InlineData(BroadcastStatus.Draft)]
    [InlineData(BroadcastStatus.PendingReview)]
    [InlineData(BroadcastStatus.Approved)]
    [InlineData(BroadcastStatus.Rejected)]
    [InlineData(BroadcastStatus.Escalated)]
    [InlineData(BroadcastStatus.RejectedFinal)]
    [InlineData(BroadcastStatus.Scheduled)]
    [InlineData(BroadcastStatus.Sending)]
    [InlineData(BroadcastStatus.Paused)]
    [InlineData(BroadcastStatus.Completed)]
    [InlineData(BroadcastStatus.Cancelled)]
    [InlineData(BroadcastStatus.Failed)]
    public void Validation_Works(BroadcastStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastStatus.Draft)]
    [InlineData(BroadcastStatus.PendingReview)]
    [InlineData(BroadcastStatus.Approved)]
    [InlineData(BroadcastStatus.Rejected)]
    [InlineData(BroadcastStatus.Escalated)]
    [InlineData(BroadcastStatus.RejectedFinal)]
    [InlineData(BroadcastStatus.Scheduled)]
    [InlineData(BroadcastStatus.Sending)]
    [InlineData(BroadcastStatus.Paused)]
    [InlineData(BroadcastStatus.Completed)]
    [InlineData(BroadcastStatus.Cancelled)]
    [InlineData(BroadcastStatus.Failed)]
    public void SerializationRoundtrip_Works(BroadcastStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
