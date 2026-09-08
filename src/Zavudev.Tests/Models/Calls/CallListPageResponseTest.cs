using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        List<CallListResponse> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CallListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CallListResponse> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CallListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextCursor = "nextCursor",
        };

        CallListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
