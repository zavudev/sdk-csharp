using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateSyncResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateSyncResponse
        {
            AccountsSynced = 0,
            Errors = ["string"],
            Imported = 0,
            Linked = 0,
            Skipped = 0,
            Updated = 0,
        };

        long expectedAccountsSynced = 0;
        List<string> expectedErrors = ["string"];
        long expectedImported = 0;
        long expectedLinked = 0;
        long expectedSkipped = 0;
        long expectedUpdated = 0;

        Assert.Equal(expectedAccountsSynced, model.AccountsSynced);
        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
        }
        Assert.Equal(expectedImported, model.Imported);
        Assert.Equal(expectedLinked, model.Linked);
        Assert.Equal(expectedSkipped, model.Skipped);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateSyncResponse
        {
            AccountsSynced = 0,
            Errors = ["string"],
            Imported = 0,
            Linked = 0,
            Skipped = 0,
            Updated = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateSyncResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateSyncResponse
        {
            AccountsSynced = 0,
            Errors = ["string"],
            Imported = 0,
            Linked = 0,
            Skipped = 0,
            Updated = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateSyncResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAccountsSynced = 0;
        List<string> expectedErrors = ["string"];
        long expectedImported = 0;
        long expectedLinked = 0;
        long expectedSkipped = 0;
        long expectedUpdated = 0;

        Assert.Equal(expectedAccountsSynced, deserialized.AccountsSynced);
        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
        }
        Assert.Equal(expectedImported, deserialized.Imported);
        Assert.Equal(expectedLinked, deserialized.Linked);
        Assert.Equal(expectedSkipped, deserialized.Skipped);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateSyncResponse
        {
            AccountsSynced = 0,
            Errors = ["string"],
            Imported = 0,
            Linked = 0,
            Skipped = 0,
            Updated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateSyncResponse
        {
            AccountsSynced = 0,
            Errors = ["string"],
            Imported = 0,
            Linked = 0,
            Skipped = 0,
            Updated = 0,
        };

        TemplateSyncResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
