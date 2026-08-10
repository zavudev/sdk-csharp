using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Broadcasts;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Tests.Models.Broadcasts.Contacts;

public class ContactListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
            NextCursor = "nextCursor",
        };

        List<BroadcastContact> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContactListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BroadcastContact> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContactListPageResponse
        {
            Items =
            [
                new()
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
                    TemplateButtonVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateHeaderVariables = new Dictionary<string, string>()
                    {
                        { "foo", "string" },
                    },
                    TemplateVariables = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
            NextCursor = "nextCursor",
        };

        ContactListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
