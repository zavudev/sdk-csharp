using System;
using System.Collections.Generic;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Tests.Models.Contacts.Channels;

public class ChannelUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Label = "label",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
        };

        string expectedContactID = "contactId";
        string expectedChannelID = "channelId";
        string expectedLabel = "label";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedVerified = true;

        Assert.Equal(expectedContactID, parameters.ContactID);
        Assert.Equal(expectedChannelID, parameters.ChannelID);
        Assert.Equal(expectedLabel, parameters.Label);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedVerified, parameters.Verified);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Label = "label",
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Verified);
        Assert.False(parameters.RawBodyData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Label = "label",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Verified = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Verified);
        Assert.False(parameters.RawBodyData.ContainsKey("verified"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
        };

        Assert.Null(parameters.Label);
        Assert.False(parameters.RawBodyData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,

            Label = null,
        };

        Assert.Null(parameters.Label);
        Assert.True(parameters.RawBodyData.ContainsKey("label"));
    }

    [Fact]
    public void Url_Works()
    {
        ChannelUpdateParams parameters = new() { ContactID = "contactId", ChannelID = "channelId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/contacts/contactId/channels/channelId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChannelUpdateParams
        {
            ContactID = "contactId",
            ChannelID = "channelId",
            Label = "label",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Verified = true,
        };

        ChannelUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
