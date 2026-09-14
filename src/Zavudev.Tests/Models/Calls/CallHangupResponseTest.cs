using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallHangupResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallHangupResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallHangupResponseCallDirection.Inbound,
                From = "+13125551212",
                Status = CallHangupResponseCallStatus.Queued,
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
                        Role = CallHangupResponseCallTranscriptRole.User,
                        Seq = 0,
                        Text = "text",
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                TurnCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        CallHangupResponseCall expectedCall = new()
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedCall, model.Call);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallHangupResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallHangupResponseCallDirection.Inbound,
                From = "+13125551212",
                Status = CallHangupResponseCallStatus.Queued,
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
                        Role = CallHangupResponseCallTranscriptRole.User,
                        Seq = 0,
                        Text = "text",
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                TurnCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallHangupResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallHangupResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallHangupResponseCallDirection.Inbound,
                From = "+13125551212",
                Status = CallHangupResponseCallStatus.Queued,
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
                        Role = CallHangupResponseCallTranscriptRole.User,
                        Seq = 0,
                        Text = "text",
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                TurnCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallHangupResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CallHangupResponseCall expectedCall = new()
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedCall, deserialized.Call);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallHangupResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallHangupResponseCallDirection.Inbound,
                From = "+13125551212",
                Status = CallHangupResponseCallStatus.Queued,
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
                        Role = CallHangupResponseCallTranscriptRole.User,
                        Seq = 0,
                        Text = "text",
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                TurnCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallHangupResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallHangupResponseCallDirection.Inbound,
                From = "+13125551212",
                Status = CallHangupResponseCallStatus.Queued,
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
                        Role = CallHangupResponseCallTranscriptRole.User,
                        Seq = 0,
                        Text = "text",
                        EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
                TurnCount = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        CallHangupResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallHangupResponseCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        ApiEnum<string, CallHangupResponseCallDirection> expectedDirection =
            CallHangupResponseCallDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallHangupResponseCallStatus> expectedStatus =
            CallHangupResponseCallStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<CallHangupResponseCallTranscript> expectedTranscript =
        [
            new()
            {
                Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var deserialized = JsonSerializer.Deserialize<CallHangupResponseCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var deserialized = JsonSerializer.Deserialize<CallHangupResponseCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "call_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CallHangupResponseCallDirection> expectedDirection =
            CallHangupResponseCallDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallHangupResponseCallStatus> expectedStatus =
            CallHangupResponseCallStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<CallHangupResponseCallTranscript> expectedTranscript =
        [
            new()
            {
                Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCall
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallHangupResponseCallDirection.Inbound,
            From = "+13125551212",
            Status = CallHangupResponseCallStatus.Queued,
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
                    Role = CallHangupResponseCallTranscriptRole.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallHangupResponseCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallHangupResponseCallDirectionTest : TestBase
{
    [Theory]
    [InlineData(CallHangupResponseCallDirection.Inbound)]
    [InlineData(CallHangupResponseCallDirection.Outbound)]
    public void Validation_Works(CallHangupResponseCallDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallHangupResponseCallDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallHangupResponseCallDirection.Inbound)]
    [InlineData(CallHangupResponseCallDirection.Outbound)]
    public void SerializationRoundtrip_Works(CallHangupResponseCallDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallDirection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallHangupResponseCallDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallDirection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CallHangupResponseCallStatusTest : TestBase
{
    [Theory]
    [InlineData(CallHangupResponseCallStatus.Queued)]
    [InlineData(CallHangupResponseCallStatus.Ringing)]
    [InlineData(CallHangupResponseCallStatus.InProgress)]
    [InlineData(CallHangupResponseCallStatus.Completed)]
    [InlineData(CallHangupResponseCallStatus.Failed)]
    [InlineData(CallHangupResponseCallStatus.Busy)]
    [InlineData(CallHangupResponseCallStatus.NoAnswer)]
    [InlineData(CallHangupResponseCallStatus.Canceled)]
    public void Validation_Works(CallHangupResponseCallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallHangupResponseCallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallHangupResponseCallStatus.Queued)]
    [InlineData(CallHangupResponseCallStatus.Ringing)]
    [InlineData(CallHangupResponseCallStatus.InProgress)]
    [InlineData(CallHangupResponseCallStatus.Completed)]
    [InlineData(CallHangupResponseCallStatus.Failed)]
    [InlineData(CallHangupResponseCallStatus.Busy)]
    [InlineData(CallHangupResponseCallStatus.NoAnswer)]
    [InlineData(CallHangupResponseCallStatus.Canceled)]
    public void SerializationRoundtrip_Works(CallHangupResponseCallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallHangupResponseCallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CallHangupResponseCallTranscriptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, CallHangupResponseCallTranscriptRole> expectedRole =
            CallHangupResponseCallTranscriptRole.User;
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallHangupResponseCallTranscript>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallHangupResponseCallTranscript>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CallHangupResponseCallTranscriptRole> expectedRole =
            CallHangupResponseCallTranscriptRole.User;
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
            Seq = 0,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
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
        var model = new CallHangupResponseCallTranscript
        {
            Role = CallHangupResponseCallTranscriptRole.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CallHangupResponseCallTranscript copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallHangupResponseCallTranscriptRoleTest : TestBase
{
    [Theory]
    [InlineData(CallHangupResponseCallTranscriptRole.User)]
    [InlineData(CallHangupResponseCallTranscriptRole.Assistant)]
    [InlineData(CallHangupResponseCallTranscriptRole.Tool)]
    public void Validation_Works(CallHangupResponseCallTranscriptRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallTranscriptRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallTranscriptRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallHangupResponseCallTranscriptRole.User)]
    [InlineData(CallHangupResponseCallTranscriptRole.Assistant)]
    [InlineData(CallHangupResponseCallTranscriptRole.Tool)]
    public void SerializationRoundtrip_Works(CallHangupResponseCallTranscriptRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallHangupResponseCallTranscriptRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallTranscriptRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallTranscriptRole>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CallHangupResponseCallTranscriptRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
