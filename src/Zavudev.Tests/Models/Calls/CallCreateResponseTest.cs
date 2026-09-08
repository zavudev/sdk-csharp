using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallCreateResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallDirection.Inbound,
                From = "+13125551212",
                Status = CallStatus.Queued,
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
                        Role = Role.User,
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

        Call expectedCall = new()
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        var model = new CallCreateResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallDirection.Inbound,
                From = "+13125551212",
                Status = CallStatus.Queued,
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
                        Role = Role.User,
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
        var deserialized = JsonSerializer.Deserialize<CallCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallCreateResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallDirection.Inbound,
                From = "+13125551212",
                Status = CallStatus.Queued,
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
                        Role = Role.User,
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
        var deserialized = JsonSerializer.Deserialize<CallCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Call expectedCall = new()
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        var model = new CallCreateResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallDirection.Inbound,
                From = "+13125551212",
                Status = CallStatus.Queued,
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
                        Role = Role.User,
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
        var model = new CallCreateResponse
        {
            Call = new()
            {
                ID = "call_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Direction = CallDirection.Inbound,
                From = "+13125551212",
                Status = CallStatus.Queued,
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
                        Role = Role.User,
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

        CallCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        ApiEnum<string, CallDirection> expectedDirection = CallDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallStatus> expectedStatus = CallStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Transcript> expectedTranscript =
        [
            new()
            {
                Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        var deserialized = JsonSerializer.Deserialize<Call>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        var deserialized = JsonSerializer.Deserialize<Call>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "call_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CallDirection> expectedDirection = CallDirection.Inbound;
        string expectedFrom = "+13125551212";
        ApiEnum<string, CallStatus> expectedStatus = CallStatus.Queued;
        string expectedTo = "+56912345678";
        DateTimeOffset expectedAnsweredAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedCost = 0;
        long expectedDurationSeconds = 0;
        DateTimeOffset expectedEndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEndReason = "endReason";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        List<Transcript> expectedTranscript =
        [
            new()
            {
                Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
            To = "+56912345678",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Transcript =
            [
                new()
                {
                    Role = Role.User,
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
        var model = new Call
        {
            ID = "call_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Direction = CallDirection.Inbound,
            From = "+13125551212",
            Status = CallStatus.Queued,
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
                    Role = Role.User,
                    Seq = 0,
                    Text = "text",
                    EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            TurnCount = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Call copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CallDirectionTest : TestBase
{
    [Theory]
    [InlineData(CallDirection.Inbound)]
    [InlineData(CallDirection.Outbound)]
    public void Validation_Works(CallDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallDirection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallDirection.Inbound)]
    [InlineData(CallDirection.Outbound)]
    public void SerializationRoundtrip_Works(CallDirection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallDirection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallDirection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallDirection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CallStatusTest : TestBase
{
    [Theory]
    [InlineData(CallStatus.Queued)]
    [InlineData(CallStatus.Ringing)]
    [InlineData(CallStatus.InProgress)]
    [InlineData(CallStatus.Completed)]
    [InlineData(CallStatus.Failed)]
    [InlineData(CallStatus.Busy)]
    [InlineData(CallStatus.NoAnswer)]
    [InlineData(CallStatus.Canceled)]
    public void Validation_Works(CallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CallStatus.Queued)]
    [InlineData(CallStatus.Ringing)]
    [InlineData(CallStatus.InProgress)]
    [InlineData(CallStatus.Completed)]
    [InlineData(CallStatus.Failed)]
    [InlineData(CallStatus.Busy)]
    [InlineData(CallStatus.NoAnswer)]
    [InlineData(CallStatus.Canceled)]
    public void SerializationRoundtrip_Works(CallStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CallStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CallStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TranscriptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transcript
        {
            Role = Role.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, Role> expectedRole = Role.User;
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
        var model = new Transcript
        {
            Role = Role.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transcript>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transcript
        {
            Role = Role.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transcript>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Role> expectedRole = Role.User;
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
        var model = new Transcript
        {
            Role = Role.User,
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
        var model = new Transcript
        {
            Role = Role.User,
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
        var model = new Transcript
        {
            Role = Role.User,
            Seq = 0,
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Transcript
        {
            Role = Role.User,
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
        var model = new Transcript
        {
            Role = Role.User,
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
        var model = new Transcript
        {
            Role = Role.User,
            Seq = 0,
            Text = "text",
            EndedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Transcript copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.Tool)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    [InlineData(Role.Tool)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
