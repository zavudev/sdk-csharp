using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRecipient = "recipient";
        ApiEnum<string, RecipientType> expectedRecipientType = RecipientType.Phone;
        ApiEnum<string, BroadcastContactStatus> expectedStatus = BroadcastContactStatus.Pending;
        double expectedCost = 0;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedMessageID = "messageId";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedTemplateButtonVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateHeaderVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedRecipientType, model.RecipientType);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedErrorCode, model.ErrorCode);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedMessageID, model.MessageID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
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
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastContact>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastContact>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedRecipient = "recipient";
        ApiEnum<string, RecipientType> expectedRecipientType = RecipientType.Phone;
        ApiEnum<string, BroadcastContactStatus> expectedStatus = BroadcastContactStatus.Pending;
        double expectedCost = 0;
        string expectedErrorCode = "errorCode";
        string expectedErrorMessage = "errorMessage";
        string expectedMessageID = "messageId";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedTemplateButtonVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateHeaderVariables = new() { { "foo", "string" } };
        Dictionary<string, string> expectedTemplateVariables = new() { { "foo", "string" } };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedRecipientType, deserialized.RecipientType);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedErrorCode, deserialized.ErrorCode);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
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
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processedAt"));
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
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            MessageID = null,
            ProcessedAt = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateVariables = null,
        };

        Assert.Null(model.ErrorCode);
        Assert.False(model.RawData.ContainsKey("errorCode"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processedAt"));
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
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,

            // Null should be interpreted as omitted for these properties
            ErrorCode = null,
            ErrorMessage = null,
            MessageID = null,
            ProcessedAt = null,
            TemplateButtonVariables = null,
            TemplateHeaderVariables = null,
            TemplateVariables = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.Cost);
        Assert.False(model.RawData.ContainsKey("cost"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },

            Cost = null,
        };

        Assert.Null(model.Cost);
        Assert.True(model.RawData.ContainsKey("cost"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },

            Cost = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastContact
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Recipient = "recipient",
            RecipientType = RecipientType.Phone,
            Status = BroadcastContactStatus.Pending,
            Cost = 0,
            ErrorCode = "errorCode",
            ErrorMessage = "errorMessage",
            MessageID = "messageId",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TemplateButtonVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateHeaderVariables = new Dictionary<string, string>() { { "foo", "string" } },
            TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
        };

        BroadcastContact copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(RecipientType.Phone)]
    [InlineData(RecipientType.Email)]
    public void Validation_Works(RecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RecipientType.Phone)]
    [InlineData(RecipientType.Email)]
    public void SerializationRoundtrip_Works(RecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
