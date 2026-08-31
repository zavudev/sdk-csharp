using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallListParams
        {
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 100,
            Status = Status.Queued,
        };

        string expectedCursor = "cursor";
        ApiEnum<string, Direction> expectedDirection = Direction.Inbound;
        long expectedLimit = 100;
        ApiEnum<string, Status> expectedStatus = Status.Queued;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedDirection, parameters.Direction);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CallListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Direction);
        Assert.False(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CallListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Direction = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Direction);
        Assert.False(parameters.RawQueryData.ContainsKey("direction"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        CallListParams parameters = new()
        {
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 100,
            Status = Status.Queued,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/calls?cursor=cursor&direction=inbound&limit=100&status=queued"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallListParams
        {
            Cursor = "cursor",
            Direction = Direction.Inbound,
            Limit = 100,
            Status = Status.Queued,
        };

        CallListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(Direction.Inbound)]
    [InlineData(Direction.Outbound)]
    public void Validation_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Direction.Inbound)]
    [InlineData(Direction.Outbound)]
    public void SerializationRoundtrip_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Ringing)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Busy)]
    [InlineData(Status.NoAnswer)]
    [InlineData(Status.Canceled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Ringing)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Busy)]
    [InlineData(Status.NoAnswer)]
    [InlineData(Status.Canceled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
