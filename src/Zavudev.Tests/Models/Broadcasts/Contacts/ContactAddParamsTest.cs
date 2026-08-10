using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Tests.Models.Broadcasts.Contacts;

public class ContactAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContactAddParams
        {
            BroadcastID = "broadcastId",
            Contacts =
            [
                new()
                {
                    Recipient = "+14155551234",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "John" },
                        { "order_id", "ORD-001" },
                    },
                },
                new()
                {
                    Recipient = "+14155555678",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "Jane" },
                        { "order_id", "ORD-002" },
                    },
                },
            ],
        };

        string expectedBroadcastID = "broadcastId";
        List<Contact> expectedContacts =
        [
            new()
            {
                Recipient = "+14155551234",
                TemplateButtonVariables = new Dictionary<string, string>()
                {
                    { "0", "abc-report-token" },
                },
                TemplateHeaderVariables = new Dictionary<string, string>()
                {
                    { "1", "Jorge y Laura" },
                },
                TemplateVariables = new Dictionary<string, string>()
                {
                    { "name", "John" },
                    { "order_id", "ORD-001" },
                },
            },
            new()
            {
                Recipient = "+14155555678",
                TemplateButtonVariables = new Dictionary<string, string>()
                {
                    { "0", "abc-report-token" },
                },
                TemplateHeaderVariables = new Dictionary<string, string>()
                {
                    { "1", "Jorge y Laura" },
                },
                TemplateVariables = new Dictionary<string, string>()
                {
                    { "name", "Jane" },
                    { "order_id", "ORD-002" },
                },
            },
        ];

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedContacts.Count, parameters.Contacts.Count);
        for (int i = 0; i < expectedContacts.Count; i++)
        {
            Assert.Equal(expectedContacts[i], parameters.Contacts[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ContactAddParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Contacts =
            [
                new()
                {
                    Recipient = "+14155551234",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "John" },
                        { "order_id", "ORD-001" },
                    },
                },
                new()
                {
                    Recipient = "+14155555678",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "Jane" },
                        { "order_id", "ORD-002" },
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/broadcasts/broadcastId/contacts"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ContactAddParams
        {
            BroadcastID = "broadcastId",
            Contacts =
            [
                new()
                {
                    Recipient = "+14155551234",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "John" },
                        { "order_id", "ORD-001" },
                    },
                },
                new()
                {
                    Recipient = "+14155555678",
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "0", "abc-report-token" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "1", "Jorge y Laura" },
                    },
                    TemplateVariables = new Dictionary<string, string>()
                    {
                        { "name", "Jane" },
                        { "order_id", "ORD-002" },
                    },
                },
            ],
        };

        ContactAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Contact
        {
            Recipient = "+14155551234",
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };

        string expectedRecipient = "+14155551234";
        Dictionary<string, string> expectedTemplateButtonVariables = new()
        {
            { "0", "abc-report-token" },
        };
        Dictionary<string, string> expectedTemplateHeaderVariables = new()
        {
            { "1", "Jorge y Laura" },
        };
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "1", "John" },
            { "2", "ORD-12345" },
        };

        Assert.Equal(expectedRecipient, model.Recipient);
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
        var model = new Contact
        {
            Recipient = "+14155551234",
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Contact
        {
            Recipient = "+14155551234",
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Contact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipient = "+14155551234";
        Dictionary<string, string> expectedTemplateButtonVariables = new()
        {
            { "0", "abc-report-token" },
        };
        Dictionary<string, string> expectedTemplateHeaderVariables = new()
        {
            { "1", "Jorge y Laura" },
        };
        Dictionary<string, string> expectedTemplateVariables = new()
        {
            { "1", "John" },
            { "2", "ORD-12345" },
        };

        Assert.Equal(expectedRecipient, deserialized.Recipient);
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
        var model = new Contact
        {
            Recipient = "+14155551234",
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Contact { Recipient = "+14155551234" };

        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Contact { Recipient = "+14155551234" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Contact
        {
            Recipient = "+14155551234",

            // Null should be interpreted as omitted for these properties
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateVariables = null,
        };

        Assert.Null(model.TemplateButtonVariables);
        Assert.False(model.RawData.ContainsKey("templateButtonVariables"));
        Assert.Null(model.TemplateHeaderVariables);
        Assert.False(model.RawData.ContainsKey("templateHeaderVariables"));
        Assert.Null(model.TemplateVariables);
        Assert.False(model.RawData.ContainsKey("templateVariables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Contact
        {
            Recipient = "+14155551234",

            // Null should be interpreted as omitted for these properties
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateVariables = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Contact
        {
            Recipient = "+14155551234",
            TemplateButtonVariables = new Dictionary<string, string>()
            {
                { "0", "abc-report-token" },
            },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "1", "Jorge y Laura" } },
            TemplateVariables = new Dictionary<string, string>()
            {
                { "1", "John" },
                { "2", "ORD-12345" },
            },
        };

        Contact copied = new(model);

        Assert.Equal(model, copied);
    }
}
