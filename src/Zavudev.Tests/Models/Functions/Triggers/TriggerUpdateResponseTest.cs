using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Tests.Models.Functions.Triggers;

public class TriggerUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TriggerUpdateResponse { Active = true, Ok = true };

        bool expectedActive = true;
        bool expectedOk = true;

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedOk, model.Ok);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TriggerUpdateResponse { Active = true, Ok = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TriggerUpdateResponse { Active = true, Ok = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TriggerUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        bool expectedOk = true;

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedOk, deserialized.Ok);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TriggerUpdateResponse { Active = true, Ok = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TriggerUpdateResponse { Active = true, Ok = true };

        TriggerUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
