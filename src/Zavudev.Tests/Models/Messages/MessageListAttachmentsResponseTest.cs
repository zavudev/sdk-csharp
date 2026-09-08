using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageListAttachmentsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageListAttachmentsResponse
        {
            Items =
            [
                new()
                {
                    ID = "jd7x2k3m4n5p6q7r8s9t0",
                    ContentID = "logo",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DownloadUrl = "https://example.com",
                    Filename = "invoice.pdf",
                    IsInline = true,
                    MimeType = "application/pdf",
                    Size = 102400,
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "jd7x2k3m4n5p6q7r8s9t0",
                ContentID = "logo",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DownloadUrl = "https://example.com",
                Filename = "invoice.pdf",
                IsInline = true,
                MimeType = "application/pdf",
                Size = 102400,
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageListAttachmentsResponse
        {
            Items =
            [
                new()
                {
                    ID = "jd7x2k3m4n5p6q7r8s9t0",
                    ContentID = "logo",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DownloadUrl = "https://example.com",
                    Filename = "invoice.pdf",
                    IsInline = true,
                    MimeType = "application/pdf",
                    Size = 102400,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageListAttachmentsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageListAttachmentsResponse
        {
            Items =
            [
                new()
                {
                    ID = "jd7x2k3m4n5p6q7r8s9t0",
                    ContentID = "logo",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DownloadUrl = "https://example.com",
                    Filename = "invoice.pdf",
                    IsInline = true,
                    MimeType = "application/pdf",
                    Size = 102400,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageListAttachmentsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "jd7x2k3m4n5p6q7r8s9t0",
                ContentID = "logo",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DownloadUrl = "https://example.com",
                Filename = "invoice.pdf",
                IsInline = true,
                MimeType = "application/pdf",
                Size = 102400,
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageListAttachmentsResponse
        {
            Items =
            [
                new()
                {
                    ID = "jd7x2k3m4n5p6q7r8s9t0",
                    ContentID = "logo",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DownloadUrl = "https://example.com",
                    Filename = "invoice.pdf",
                    IsInline = true,
                    MimeType = "application/pdf",
                    Size = 102400,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageListAttachmentsResponse
        {
            Items =
            [
                new()
                {
                    ID = "jd7x2k3m4n5p6q7r8s9t0",
                    ContentID = "logo",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DownloadUrl = "https://example.com",
                    Filename = "invoice.pdf",
                    IsInline = true,
                    MimeType = "application/pdf",
                    Size = 102400,
                },
            ],
        };

        MessageListAttachmentsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            ContentID = "logo",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "https://example.com",
            Filename = "invoice.pdf",
            IsInline = true,
            MimeType = "application/pdf",
            Size = 102400,
        };

        string expectedID = "jd7x2k3m4n5p6q7r8s9t0";
        string expectedContentID = "logo";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDownloadUrl = "https://example.com";
        string expectedFilename = "invoice.pdf";
        bool expectedIsInline = true;
        string expectedMimeType = "application/pdf";
        long expectedSize = 102400;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContentID, model.ContentID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIsInline, model.IsInline);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedSize, model.Size);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            ContentID = "logo",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "https://example.com",
            Filename = "invoice.pdf",
            IsInline = true,
            MimeType = "application/pdf",
            Size = 102400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            ContentID = "logo",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "https://example.com",
            Filename = "invoice.pdf",
            IsInline = true,
            MimeType = "application/pdf",
            Size = 102400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "jd7x2k3m4n5p6q7r8s9t0";
        string expectedContentID = "logo";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDownloadUrl = "https://example.com";
        string expectedFilename = "invoice.pdf";
        bool expectedIsInline = true;
        string expectedMimeType = "application/pdf";
        long expectedSize = 102400;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContentID, deserialized.ContentID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIsInline, deserialized.IsInline);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedSize, deserialized.Size);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            ContentID = "logo",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "https://example.com",
            Filename = "invoice.pdf",
            IsInline = true,
            MimeType = "application/pdf",
            Size = 102400,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "jd7x2k3m4n5p6q7r8s9t0",
            ContentID = "logo",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = "https://example.com",
            Filename = "invoice.pdf",
            IsInline = true,
            MimeType = "application/pdf",
            Size = 102400,
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
