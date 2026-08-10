using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Tests.Models.Broadcasts.Contacts;

public class ContactAddResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
            Errors = [new() { Reason = "reason", Recipient = "recipient" }],
        };

        long expectedAdded = 0;
        long expectedDuplicates = 0;
        long expectedInvalid = 0;
        List<Error> expectedErrors = [new() { Reason = "reason", Recipient = "recipient" }];

        Assert.Equal(expectedAdded, model.Added);
        Assert.Equal(expectedDuplicates, model.Duplicates);
        Assert.Equal(expectedInvalid, model.Invalid);
        Assert.NotNull(model.Errors);
        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
            Errors = [new() { Reason = "reason", Recipient = "recipient" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactAddResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
            Errors = [new() { Reason = "reason", Recipient = "recipient" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactAddResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAdded = 0;
        long expectedDuplicates = 0;
        long expectedInvalid = 0;
        List<Error> expectedErrors = [new() { Reason = "reason", Recipient = "recipient" }];

        Assert.Equal(expectedAdded, deserialized.Added);
        Assert.Equal(expectedDuplicates, deserialized.Duplicates);
        Assert.Equal(expectedInvalid, deserialized.Invalid);
        Assert.NotNull(deserialized.Errors);
        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
            Errors = [new() { Reason = "reason", Recipient = "recipient" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,

            // Null should be interpreted as omitted for these properties
            Errors = null,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,

            // Null should be interpreted as omitted for these properties
            Errors = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactAddResponse
        {
            Added = 0,
            Duplicates = 0,
            Invalid = 0,
            Errors = [new() { Reason = "reason", Recipient = "recipient" }],
        };

        ContactAddResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error { Reason = "reason", Recipient = "recipient" };

        string expectedReason = "reason";
        string expectedRecipient = "recipient";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRecipient, model.Recipient);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error { Reason = "reason", Recipient = "recipient" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error { Reason = "reason", Recipient = "recipient" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedReason = "reason";
        string expectedRecipient = "recipient";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error { Reason = "reason", Recipient = "recipient" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Error { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Error { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Error
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
            Recipient = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Error
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
            Recipient = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error { Reason = "reason", Recipient = "recipient" };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}
