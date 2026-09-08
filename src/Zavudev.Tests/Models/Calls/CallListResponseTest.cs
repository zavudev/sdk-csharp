using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "call_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CallListResponseDirection> expectedDirection =
            CallListResponseDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallListResponseStatus> expectedStatus = CallListResponseStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<CallListResponseTranscript> expectedTranscript =
        [
            new()
            {
                Role = CallListResponseTranscriptRole.User,
                Seq = 0,
                Text = "text",
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTurnCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedFrom, model.From);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedAnsweredAt, model.AnsweredAt);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedDurationSeconds, model.DurationSeconds);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedEndReason, model.EndReason);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.NotNull(model.Transcript);
        Assert.Equal(expectedTranscript.Count, model.Transcript.Count);
        for (int i = 0; i < expectedTranscript.Count; i++)
        {
            Assert.Equal(expectedTranscript[i], model.Transcript[i]);
        }
        Assert.Equal(expectedTurnCount, model.TurnCount);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "call_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CallListResponseDirection> expectedDirection =
            CallListResponseDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallListResponseStatus> expectedStatus = CallListResponseStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<CallListResponseTranscript> expectedTranscript =
        [
            new()
            {
                Role = CallListResponseTranscriptRole.User,
                Seq = 0,
                Text = "text",
                EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        long expectedTurnCount = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedFrom, deserialized.From);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedAnsweredAt, deserialized.AnsweredAt);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedDurationSeconds, deserialized.DurationSeconds);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedEndReason, deserialized.EndReason);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.NotNull(deserialized.Transcript);
        Assert.Equal(expectedTranscript.Count, deserialized.Transcript.Count);
        for (int i = 0; i < expectedTranscript.Count; i++)
        {
            Assert.Equal(expectedTranscript[i], deserialized.Transcript[i]);
        }
        Assert.Equal(expectedTurnCount, deserialized.TurnCount);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            TurnCount = 0,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Transcript);
        Assert.False(model.RawData.ContainsKey("transcript"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            TurnCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            TurnCount = 0,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Transcript = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Transcript);
        Assert.False(model.RawData.ContainsKey("transcript"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            TurnCount = 0,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Transcript = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AnsweredAt);
        Assert.False(model.RawData.ContainsKey("answeredAt"));
        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DurationSeconds);
        Assert.False(model.RawData.ContainsKey("durationSeconds"));
        Assert.Null(model.EndedAt);
        Assert.False(model.RawData.ContainsKey("endedAt"));
        Assert.Null(model.EndReason);
        Assert.False(model.RawData.ContainsKey("endReason"));
        Assert.Null(model.TurnCount);
        Assert.False(model.RawData.ContainsKey("turnCount"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AnsweredAt = null,
            Cost = null,
            DurationSeconds = null,
            EndedAt = null,
            EndReason = null,
            TurnCount = null,
        };

        Assert.Null(model.AnsweredAt);
        Assert.True(model.RawData.ContainsKey("answeredAt"));
        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
        Assert.Null(model.DurationSeconds);
        Assert.True(model.RawData.ContainsKey("durationSeconds"));
        Assert.Null(model.EndedAt);
        Assert.True(model.RawData.ContainsKey("endedAt"));
        Assert.Null(model.EndReason);
        Assert.True(model.RawData.ContainsKey("endReason"));
        Assert.Null(model.TurnCount);
        Assert.True(model.RawData.ContainsKey("turnCount"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AnsweredAt = null,
            Cost = null,
            DurationSeconds = null,
            EndedAt = null,
            EndReason = null,
            TurnCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallListResponse
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallListResponseDirection.Inbound,
            From = "+13125551212",
            Status = CallListResponseStatus.Queued,
            To = "+56912345678",
            AnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cost = 0,
            DurationSeconds = 0,
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndReason = "endReason",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallListResponseTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallListResponseDirectionTest : TestBase
{
    [Theory]
    [InlineData(CallListResponseDirection.Inbound)]
    [InlineData(CallListResponseDirection.Outbound)]
    public void Validation_Works(CallListResponseDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallListResponseDirection.Inbound)]
    [InlineData(CallListResponseDirection.Outbound)]
    public void SerializationRoundtrip_Works(CallListResponseDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CallListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(CallListResponseStatus.Queued)]
    [InlineData(CallListResponseStatus.Ringing)]
    [InlineData(CallListResponseStatus.InProgress)]
    [InlineData(CallListResponseStatus.Completed)]
    [InlineData(CallListResponseStatus.Failed)]
    [InlineData(CallListResponseStatus.Busy)]
    [InlineData(CallListResponseStatus.NoAnswer)]
    [InlineData(CallListResponseStatus.Canceled)]
    public void Validation_Works(CallListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallListResponseStatus.Queued)]
    [InlineData(CallListResponseStatus.Ringing)]
    [InlineData(CallListResponseStatus.InProgress)]
    [InlineData(CallListResponseStatus.Completed)]
    [InlineData(CallListResponseStatus.Failed)]
    [InlineData(CallListResponseStatus.Busy)]
    [InlineData(CallListResponseStatus.NoAnswer)]
    [InlineData(CallListResponseStatus.Canceled)]
    public void SerializationRoundtrip_Works(CallListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CallListResponseTranscriptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, CallListResponseTranscriptRole> expectedRole =
            CallListResponseTranscriptRole.User;
        long expectedSeq = 0;
        string expectedText = "text";
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedSeq, model.Seq);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedEndedAt, model.EndedAt);
        Assert.Equal(expectedStartedAt, model.StartedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListResponseTranscript>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListResponseTranscript>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CallListResponseTranscriptRole> expectedRole =
            CallListResponseTranscriptRole.User;
        long expectedSeq = 0;
        string expectedText = "text";
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedSeq, deserialized.Seq);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedEndedAt, deserialized.EndedAt);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
        };

        Assert.Null(model.EndedAt);
        Assert.False(model.RawData.ContainsKey("endedAt"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",

            EndedAt = null,
            StartedAt = null,
        };

        Assert.Null(model.EndedAt);
        Assert.True(model.RawData.ContainsKey("endedAt"));
        Assert.Null(model.StartedAt);
        Assert.True(model.RawData.ContainsKey("startedAt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",

            EndedAt = null,
            StartedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallListResponseTranscript
        {
            Role = CallListResponseTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallListResponseTranscript copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallListResponseTranscriptRoleTest : TestBase
{
    [Theory]
    [InlineData(CallListResponseTranscriptRole.User)]
    [InlineData(CallListResponseTranscriptRole.Assistant)]
    [InlineData(CallListResponseTranscriptRole.Tool)]
    public void Validation_Works(CallListResponseTranscriptRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseTranscriptRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseTranscriptRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallListResponseTranscriptRole.User)]
    [InlineData(CallListResponseTranscriptRole.Assistant)]
    [InlineData(CallListResponseTranscriptRole.Tool)]
    public void SerializationRoundtrip_Works(CallListResponseTranscriptRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallListResponseTranscriptRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallListResponseTranscriptRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallListResponseTranscriptRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallListResponseTranscriptRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
