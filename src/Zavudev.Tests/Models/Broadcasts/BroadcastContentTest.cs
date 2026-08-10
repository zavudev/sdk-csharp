using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastContent
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedFilename = "filename";
        string expectedMediaID = "mediaId";
        string expectedMediaUrl = "mediaUrl";
        string expectedMimeType = "mimeType";
        Dictionary<string, string> expectedTemplateButtonVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateHeaderVariables = new() { { "foo", "string" } };
        string expectedTemplateID = "templateId";
        Dictionary<string, string> expectedTemplateVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedMediaID, model.MediaID);
        Assert.Equal(expectedMediaUrl, model.MediaUrl);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.NotNull(model.TemplateButtonVariables);
        Assert.Equal(expectedTemplateButtonVariables.Count, model.TemplateButtonVariables.Count);
        foreach (var item in expectedTemplateButtonVariables)
        {
            Assert.True(model.TemplateButtonVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateButtonVariables[item.Key]);
        }
        Assert.NotNull(model.TemplateHeaderVariables);
        Assert.Equal(expectedTemplateHeaderVariables.Count, model.TemplateHeaderVariables.Count);
        foreach (var item in expectedTemplateHeaderVariables)
        {
            Assert.True(model.TemplateHeaderVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateHeaderVariables[item.Key]);
        }
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.NotNull(model.TemplateVariables);
        Assert.Equal(expectedTemplateVariables.Count, model.TemplateVariables.Count);
        foreach (var item in expectedTemplateVariables)
        {
            Assert.True(model.TemplateVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.TemplateVariables[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BroadcastContent
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastContent
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFilename = "filename";
        string expectedMediaID = "mediaId";
        string expectedMediaUrl = "mediaUrl";
        string expectedMimeType = "mimeType";
        Dictionary<string, string> expectedTemplateButtonVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateHeaderVariables = new() { { "foo", "string" } };
        string expectedTemplateID = "templateId";
        Dictionary<string, string> expectedTemplateVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedMediaID, deserialized.MediaID);
        Assert.Equal(expectedMediaUrl, deserialized.MediaUrl);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.NotNull(deserialized.TemplateButtonVariables);
        Assert.Equal(
            expectedTemplateButtonVariables.Count,
            deserialized.TemplateButtonVariables.Count
        );
        foreach (var item in expectedTemplateButtonVariables)
        {
            Assert.True(deserialized.TemplateButtonVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateButtonVariables[item.Key]);
        }
        Assert.NotNull(deserialized.TemplateHeaderVariables);
        Assert.Equal(
            expectedTemplateHeaderVariables.Count,
            deserialized.TemplateHeaderVariables.Count
        );
        foreach (var item in expectedTemplateHeaderVariables)
        {
            Assert.True(deserialized.TemplateHeaderVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateHeaderVariables[item.Key]);
        }
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.NotNull(deserialized.TemplateVariables);
        Assert.Equal(expectedTemplateVariables.Count, deserialized.TemplateVariables.Count);
        foreach (var item in expectedTemplateVariables)
        {
            Assert.True(deserialized.TemplateVariables.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.TemplateVariables[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BroadcastContent
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastContent { };

        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BroadcastContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BroadcastContent
        {
            // Null should be interpreted as omitted for these properties
            Filename = null,
            MediaID = null,
            MediaUrl = null,
            MimeType = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateID = null,
            TemplateVariables = null,
        };

        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.MediaID);
        Assert.False(model.RawData.ContainsKey("mediaId"));
        Assert.Null(model.MediaUrl);
        Assert.False(model.RawData.ContainsKey("mediaUrl"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mimeType"));
        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BroadcastContent
        {
            // Null should be interpreted as omitted for these properties
            Filename = null,
            MediaID = null,
            MediaUrl = null,
            MimeType = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateID = null,
            TemplateVariables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastContent
        {
            Filename = "filename",
            MediaID = "mediaId",
            MediaUrl = "mediaUrl",
            MimeType = "mimeType",
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateID = "templateId",
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        BroadcastContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
