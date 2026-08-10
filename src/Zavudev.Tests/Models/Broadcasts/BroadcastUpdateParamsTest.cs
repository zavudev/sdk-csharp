using System;
using System.Collections.Generic;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastUpdateParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Filename = "filename",
                MediaID = "mediaId",
                MediaUrl = "mediaUrl",
                MimeType = "mimeType",
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
            },
            EmailHtmlBody = "emailHtmlBody",
            EmailSubject = "emailSubject",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Text = "text",
        };

        string expectedBroadcastID = "broadcastId";
        BroadcastContent expectedContent = new()
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
        string expectedEmailHtmlBody = "emailHtmlBody";
        string expectedEmailSubject = "emailSubject";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        string expectedText = "text";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedEmailHtmlBody, parameters.EmailHtmlBody);
        Assert.Equal(expectedEmailSubject, parameters.EmailSubject);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedText, parameters.Text);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastUpdateParams { BroadcastID = "broadcastId" };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.EmailHtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("emailHtmlBody"));
        Assert.Null(parameters.EmailSubject);
        Assert.False(parameters.RawBodyData.ContainsKey("emailSubject"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastUpdateParams
        {
            BroadcastID = "broadcastId",

            // Null should be interpreted as omitted for these properties
            Content = null,
            EmailHtmlBody = null,
            EmailSubject = null,
            Metadata = null,
            Name = null,
            Text = null,
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.EmailHtmlBody);
        Assert.False(parameters.RawBodyData.ContainsKey("emailHtmlBody"));
        Assert.Null(parameters.EmailSubject);
        Assert.False(parameters.RawBodyData.ContainsKey("emailSubject"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastUpdateParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastUpdateParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Filename = "filename",
                MediaID = "mediaId",
                MediaUrl = "mediaUrl",
                MimeType = "mimeType",
                TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
                TemplateID = "templateId",
                TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
            },
            EmailHtmlBody = "emailHtmlBody",
            EmailSubject = "emailSubject",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Text = "text",
        };

        BroadcastUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
