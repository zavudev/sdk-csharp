using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastContactStatusTest : TestBase
{
    [Theory]
    [InlineData(BroadcastContactStatus.Pending)]
    [InlineData(BroadcastContactStatus.Queued)]
    [InlineData(BroadcastContactStatus.Sending)]
    [InlineData(BroadcastContactStatus.Delivered)]
    [InlineData(BroadcastContactStatus.Failed)]
    [InlineData(BroadcastContactStatus.Skipped)]
    public void Validation_Works(BroadcastContactStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastContactStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastContactStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastContactStatus.Pending)]
    [InlineData(BroadcastContactStatus.Queued)]
    [InlineData(BroadcastContactStatus.Sending)]
    [InlineData(BroadcastContactStatus.Delivered)]
    [InlineData(BroadcastContactStatus.Failed)]
    [InlineData(BroadcastContactStatus.Skipped)]
    public void SerializationRoundtrip_Works(BroadcastContactStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastContactStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastContactStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastContactStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastContactStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
