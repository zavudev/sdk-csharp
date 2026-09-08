using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionListEventTypesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionListEventTypesResponse
        {
            Events = ["message.inbound", "message.delivered", "cron"],
        };

        List<string> expectedEvents = ["message.inbound", "message.delivered", "cron"];

        Assert.Equal(expectedEvents.Count, model.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], model.Events[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionListEventTypesResponse
        {
            Events = ["message.inbound", "message.delivered", "cron"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListEventTypesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionListEventTypesResponse
        {
            Events = ["message.inbound", "message.delivered", "cron"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionListEventTypesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedEvents = ["message.inbound", "message.delivered", "cron"];

        Assert.Equal(expectedEvents.Count, deserialized.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], deserialized.Events[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionListEventTypesResponse
        {
            Events = ["message.inbound", "message.delivered", "cron"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionListEventTypesResponse
        {
            Events = ["message.inbound", "message.delivered", "cron"],
        };

        FunctionListEventTypesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
