using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        List<Template> expectedItems =
        [
            new()
            {
                ID = "id",
                Body = "Hi {{1}}, your order {{2}} has shipped.",
                Category = WhatsappCategory.Utility,
                Language = "en",
                Name = "order_confirmation",
                AddSecurityRecommendation = true,
                Buttons =
                [
                    new()
                    {
                        Example = "example",
                        OtpType = TemplateButtonOtpType.CopyCode,
                        PackageName = "packageName",
                        PhoneNumber = "phoneNumber",
                        SignatureHash = "signatureHash",
                        Text = "text",
                        Type = TemplateButtonType.QuickReply,
                        Url = "url",
                    },
                ],
                CodeExpirationMinutes = 1,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Footer = "footer",
                HeaderContent = "headerContent",
                HeaderType = "headerType",
                InstagramBody = "instagramBody",
                SmsBody = "smsBody",
                Status = Status.Draft,
                TelegramBody = "telegramBody",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
                Whatsapp = new()
                {
                    Namespace = "namespace",
                    Status = "status",
                    TemplateName = "templateName",
                },
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
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Template> expectedItems =
        [
            new()
            {
                ID = "id",
                Body = "Hi {{1}}, your order {{2}} has shipped.",
                Category = WhatsappCategory.Utility,
                Language = "en",
                Name = "order_confirmation",
                AddSecurityRecommendation = true,
                Buttons =
                [
                    new()
                    {
                        Example = "example",
                        OtpType = TemplateButtonOtpType.CopyCode,
                        PackageName = "packageName",
                        PhoneNumber = "phoneNumber",
                        SignatureHash = "signatureHash",
                        Text = "text",
                        Type = TemplateButtonType.QuickReply,
                        Url = "url",
                    },
                ],
                CodeExpirationMinutes = 1,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Footer = "footer",
                HeaderContent = "headerContent",
                HeaderType = "headerType",
                InstagramBody = "instagramBody",
                SmsBody = "smsBody",
                Status = Status.Draft,
                TelegramBody = "telegramBody",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Variables = ["string"],
                Whatsapp = new()
                {
                    Namespace = "namespace",
                    Status = "status",
                    TemplateName = "templateName",
                },
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
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
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
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Body = "Hi {{1}}, your order {{2}} has shipped.",
                    Category = WhatsappCategory.Utility,
                    Language = "en",
                    Name = "order_confirmation",
                    AddSecurityRecommendation = true,
                    Buttons =
                    [
                        new()
                        {
                            Example = "example",
                            OtpType = TemplateButtonOtpType.CopyCode,
                            PackageName = "packageName",
                            PhoneNumber = "phoneNumber",
                            SignatureHash = "signatureHash",
                            Text = "text",
                            Type = TemplateButtonType.QuickReply,
                            Url = "url",
                        },
                    ],
                    CodeExpirationMinutes = 1,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Footer = "footer",
                    HeaderContent = "headerContent",
                    HeaderType = "headerType",
                    InstagramBody = "instagramBody",
                    SmsBody = "smsBody",
                    Status = Status.Draft,
                    TelegramBody = "telegramBody",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Variables = ["string"],
                    Whatsapp = new()
                    {
                        Namespace = "namespace",
                        Status = "status",
                        TemplateName = "templateName",
                    },
                },
            ],
            NextCursor = "nextCursor",
        };

        TemplateListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
