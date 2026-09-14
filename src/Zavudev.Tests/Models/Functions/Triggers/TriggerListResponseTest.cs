using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Tests.Models.Functions.Triggers;

public class TriggerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TriggerListResponse
        {
            Triggers =
            [
                new()
                {
                    ID = "id",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventType = "eventType",
                    FunctionID = "functionId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cron = "*/15 * * * *",
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                },
            ],
        };

        List<TriggerListResponseTrigger> expectedTriggers =
        [
            new()
            {
                ID = "id",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventType = "eventType",
                FunctionID = "functionId",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cron = "*/15 * * * *",
                LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SenderID = "senderId",
            },
        ];

        Assert.Equal(expectedTriggers.Count, model.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], model.Triggers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TriggerListResponse
        {
            Triggers =
            [
                new()
                {
                    ID = "id",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventType = "eventType",
                    FunctionID = "functionId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cron = "*/15 * * * *",
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TriggerListResponse
        {
            Triggers =
            [
                new()
                {
                    ID = "id",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventType = "eventType",
                    FunctionID = "functionId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cron = "*/15 * * * *",
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TriggerListResponseTrigger> expectedTriggers =
        [
            new()
            {
                ID = "id",
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventType = "eventType",
                FunctionID = "functionId",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Cron = "*/15 * * * *",
                LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SenderID = "senderId",
            },
        ];

        Assert.Equal(expectedTriggers.Count, deserialized.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], deserialized.Triggers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TriggerListResponse
        {
            Triggers =
            [
                new()
                {
                    ID = "id",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventType = "eventType",
                    FunctionID = "functionId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cron = "*/15 * * * *",
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TriggerListResponse
        {
            Triggers =
            [
                new()
                {
                    ID = "id",
                    Active = true,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EventType = "eventType",
                    FunctionID = "functionId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Cron = "*/15 * * * *",
                    LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    SenderID = "senderId",
                },
            ],
        };

        TriggerListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TriggerListResponseTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cron = "*/15 * * * *",
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
        };

        string expectedID = "id";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "eventType";
        string expectedFunctionID = "functionId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCron = "*/15 * * * *";
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedCron, model.Cron);
        Assert.Equal(expectedLastRunAt, model.LastRunAt);
        Assert.Equal(expectedNextRunAt, model.NextRunAt);
        Assert.Equal(expectedSenderID, model.SenderID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cron = "*/15 * * * *",
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerListResponseTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cron = "*/15 * * * *",
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerListResponseTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEventType = "eventType";
        string expectedFunctionID = "functionId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCron = "*/15 * * * *";
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedNextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedCron, deserialized.Cron);
        Assert.Equal(expectedLastRunAt, deserialized.LastRunAt);
        Assert.Equal(expectedNextRunAt, deserialized.NextRunAt);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cron = "*/15 * * * *",
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Cron);
        Assert.False(model.RawData.ContainsKey("cron"));
        Assert.Null(model.LastRunAt);
        Assert.False(model.RawData.ContainsKey("lastRunAt"));
        Assert.Null(model.NextRunAt);
        Assert.False(model.RawData.ContainsKey("nextRunAt"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Cron = null,
            LastRunAt = null,
            NextRunAt = null,
            SenderID = null,
        };

        Assert.Null(model.Cron);
        Assert.True(model.RawData.ContainsKey("cron"));
        Assert.Null(model.LastRunAt);
        Assert.True(model.RawData.ContainsKey("lastRunAt"));
        Assert.Null(model.NextRunAt);
        Assert.True(model.RawData.ContainsKey("nextRunAt"));
        Assert.Null(model.SenderID);
        Assert.True(model.RawData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Cron = null,
            LastRunAt = null,
            NextRunAt = null,
            SenderID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TriggerListResponseTrigger
        {
            ID = "id",
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventType = "eventType",
            FunctionID = "functionId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Cron = "*/15 * * * *",
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NextRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
        };

        TriggerListResponseTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}
