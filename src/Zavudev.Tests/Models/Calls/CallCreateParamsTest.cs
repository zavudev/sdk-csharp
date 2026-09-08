using System;
using System.Collections.Generic;
using Zavudev.Models.Calls;

namespace Zavudev.Tests.Models.Calls;

public class CallCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CallCreateParams
        {
            To = "+56912345678",
            Greeting = "greeting",
            Language = "es-ES",
            MaxDurationMinutes = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            SenderID = "sender_12345",
        };

        string expectedTo = "+56912345678";
        string expectedGreeting = "greeting";
        string expectedLanguage = "es-ES";
        long expectedMaxDurationMinutes = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedSenderID = "sender_12345";

        Assert.Equal(expectedTo, parameters.To);
        Assert.Equal(expectedGreeting, parameters.Greeting);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedMaxDurationMinutes, parameters.MaxDurationMinutes);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CallCreateParams { To = "+56912345678" };

        Assert.Null(parameters.Greeting);
        Assert.False(parameters.RawBodyData.ContainsKey("greeting"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.MaxDurationMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("maxDurationMinutes"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CallCreateParams
        {
            To = "+56912345678",

            // Null should be interpreted as omitted for these properties
            Greeting = null,
            Language = null,
            MaxDurationMinutes = null,
            Metadata = null,
            SenderID = null,
        };

        Assert.Null(parameters.Greeting);
        Assert.False(parameters.RawBodyData.ContainsKey("greeting"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.MaxDurationMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("maxDurationMinutes"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawBodyData.ContainsKey("senderId"));
    }

    [Fact]
    public void Url_Works()
    {
        CallCreateParams parameters = new() { To = "+56912345678" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/calls"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CallCreateParams
        {
            To = "+56912345678",
            Greeting = "greeting",
            Language = "es-ES",
            MaxDurationMinutes = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            SenderID = "sender_12345",
        };

        CallCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
