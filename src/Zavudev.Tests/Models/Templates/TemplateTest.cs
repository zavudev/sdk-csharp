using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Template
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
        };

        string expectedID = "id";
        string expectedBody = "Hi {{1}}, your order {{2}} has shipped.";
        ApiEnum<string, WhatsappCategory> expectedCategory = WhatsappCategory.Utility;
        string expectedLanguage = "en";
        string expectedName = "order_confirmation";
        bool expectedAddSecurityRecommendation = true;
        List<TemplateButton> expectedButtons =
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
        ];
        long expectedCodeExpirationMinutes = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFooter = "footer";
        string expectedHeaderContent = "headerContent";
        string expectedHeaderType = "headerType";
        string expectedInstagramBody = "instagramBody";
        string expectedSmsBody = "smsBody";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedTelegramBody = "telegramBody";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVariables = ["string"];
        Whatsapp expectedWhatsapp = new()
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddSecurityRecommendation, model.AddSecurityRecommendation);
        Assert.NotNull(model.Buttons);
        Assert.Equal(expectedButtons.Count, model.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], model.Buttons[i]);
        }
        Assert.Equal(expectedCodeExpirationMinutes, model.CodeExpirationMinutes);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeaderContent, model.HeaderContent);
        Assert.Equal(expectedHeaderType, model.HeaderType);
        Assert.Equal(expectedInstagramBody, model.InstagramBody);
        Assert.Equal(expectedSmsBody, model.SmsBody);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTelegramBody, model.TelegramBody);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.Variables);
        Assert.Equal(expectedVariables.Count, model.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], model.Variables[i]);
        }
        Assert.Equal(expectedWhatsapp, model.Whatsapp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Template
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Template
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Template>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBody = "Hi {{1}}, your order {{2}} has shipped.";
        ApiEnum<string, WhatsappCategory> expectedCategory = WhatsappCategory.Utility;
        string expectedLanguage = "en";
        string expectedName = "order_confirmation";
        bool expectedAddSecurityRecommendation = true;
        List<TemplateButton> expectedButtons =
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
        ];
        long expectedCodeExpirationMinutes = 1;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFooter = "footer";
        string expectedHeaderContent = "headerContent";
        string expectedHeaderType = "headerType";
        string expectedInstagramBody = "instagramBody";
        string expectedSmsBody = "smsBody";
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedTelegramBody = "telegramBody";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedVariables = ["string"];
        Whatsapp expectedWhatsapp = new()
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddSecurityRecommendation, deserialized.AddSecurityRecommendation);
        Assert.NotNull(deserialized.Buttons);
        Assert.Equal(expectedButtons.Count, deserialized.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], deserialized.Buttons[i]);
        }
        Assert.Equal(expectedCodeExpirationMinutes, deserialized.CodeExpirationMinutes);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeaderContent, deserialized.HeaderContent);
        Assert.Equal(expectedHeaderType, deserialized.HeaderType);
        Assert.Equal(expectedInstagramBody, deserialized.InstagramBody);
        Assert.Equal(expectedSmsBody, deserialized.SmsBody);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTelegramBody, deserialized.TelegramBody);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.Variables);
        Assert.Equal(expectedVariables.Count, deserialized.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], deserialized.Variables[i]);
        }
        Assert.Equal(expectedWhatsapp, deserialized.Whatsapp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Template
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Template
        {
            ID = "id",
            Body = "Hi {{1}}, your order {{2}} has shipped.",
            Category = WhatsappCategory.Utility,
            Language = "en",
            Name = "order_confirmation",
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.CodeExpirationMinutes);
        Assert.False(model.RawData.ContainsKey("codeExpirationMinutes"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.HeaderContent);
        Assert.False(model.RawData.ContainsKey("headerContent"));
        Assert.Null(model.HeaderType);
        Assert.False(model.RawData.ContainsKey("headerType"));
        Assert.Null(model.InstagramBody);
        Assert.False(model.RawData.ContainsKey("instagramBody"));
        Assert.Null(model.SmsBody);
        Assert.False(model.RawData.ContainsKey("smsBody"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TelegramBody);
        Assert.False(model.RawData.ContainsKey("telegramBody"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Template
        {
            ID = "id",
            Body = "Hi {{1}}, your order {{2}} has shipped.",
            Category = WhatsappCategory.Utility,
            Language = "en",
            Name = "order_confirmation",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Template
        {
            ID = "id",
            Body = "Hi {{1}}, your order {{2}} has shipped.",
            Category = WhatsappCategory.Utility,
            Language = "en",
            Name = "order_confirmation",

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
            Buttons = null,
            CodeExpirationMinutes = null,
            CreatedAt = null,
            Footer = null,
            HeaderContent = null,
            HeaderType = null,
            InstagramBody = null,
            SmsBody = null,
            Status = null,
            TelegramBody = null,
            UpdatedAt = null,
            Variables = null,
            Whatsapp = null,
        };

        Assert.Null(model.AddSecurityRecommendation);
        Assert.False(model.RawData.ContainsKey("addSecurityRecommendation"));
        Assert.Null(model.Buttons);
        Assert.False(model.RawData.ContainsKey("buttons"));
        Assert.Null(model.CodeExpirationMinutes);
        Assert.False(model.RawData.ContainsKey("codeExpirationMinutes"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.HeaderContent);
        Assert.False(model.RawData.ContainsKey("headerContent"));
        Assert.Null(model.HeaderType);
        Assert.False(model.RawData.ContainsKey("headerType"));
        Assert.Null(model.InstagramBody);
        Assert.False(model.RawData.ContainsKey("instagramBody"));
        Assert.Null(model.SmsBody);
        Assert.False(model.RawData.ContainsKey("smsBody"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TelegramBody);
        Assert.False(model.RawData.ContainsKey("telegramBody"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
        Assert.Null(model.Variables);
        Assert.False(model.RawData.ContainsKey("variables"));
        Assert.Null(model.Whatsapp);
        Assert.False(model.RawData.ContainsKey("whatsapp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Template
        {
            ID = "id",
            Body = "Hi {{1}}, your order {{2}} has shipped.",
            Category = WhatsappCategory.Utility,
            Language = "en",
            Name = "order_confirmation",

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
            Buttons = null,
            CodeExpirationMinutes = null,
            CreatedAt = null,
            Footer = null,
            HeaderContent = null,
            HeaderType = null,
            InstagramBody = null,
            SmsBody = null,
            Status = null,
            TelegramBody = null,
            UpdatedAt = null,
            Variables = null,
            Whatsapp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Template
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
        };

        Template copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateButton
        {
            Example = "example",
            OtpType = TemplateButtonOtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Type = TemplateButtonType.QuickReply,
            Url = "url",
        };

        string expectedExample = "example";
        ApiEnum<string, TemplateButtonOtpType> expectedOtpType = TemplateButtonOtpType.CopyCode;
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        ApiEnum<string, TemplateButtonType> expectedType = TemplateButtonType.QuickReply;
        string expectedUrl = "url";

        Assert.Equal(expectedExample, model.Example);
        Assert.Equal(expectedOtpType, model.OtpType);
        Assert.Equal(expectedPackageName, model.PackageName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSignatureHash, model.SignatureHash);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateButton
        {
            Example = "example",
            OtpType = TemplateButtonOtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Type = TemplateButtonType.QuickReply,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateButton>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateButton
        {
            Example = "example",
            OtpType = TemplateButtonOtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Type = TemplateButtonType.QuickReply,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplateButton>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExample = "example";
        ApiEnum<string, TemplateButtonOtpType> expectedOtpType = TemplateButtonOtpType.CopyCode;
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        ApiEnum<string, TemplateButtonType> expectedType = TemplateButtonType.QuickReply;
        string expectedUrl = "url";

        Assert.Equal(expectedExample, deserialized.Example);
        Assert.Equal(expectedOtpType, deserialized.OtpType);
        Assert.Equal(expectedPackageName, deserialized.PackageName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSignatureHash, deserialized.SignatureHash);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateButton
        {
            Example = "example",
            OtpType = TemplateButtonOtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Type = TemplateButtonType.QuickReply,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateButton { };

        Assert.Null(model.Example);
        Assert.False(model.RawData.ContainsKey("example"));
        Assert.Null(model.OtpType);
        Assert.False(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.False(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.SignatureHash);
        Assert.False(model.RawData.ContainsKey("signatureHash"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateButton { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplateButton
        {
            // Null should be interpreted as omitted for these properties
            Example = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            SignatureHash = null,
            Text = null,
            Type = null,
            Url = null,
        };

        Assert.Null(model.Example);
        Assert.False(model.RawData.ContainsKey("example"));
        Assert.Null(model.OtpType);
        Assert.False(model.RawData.ContainsKey("otpType"));
        Assert.Null(model.PackageName);
        Assert.False(model.RawData.ContainsKey("packageName"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phoneNumber"));
        Assert.Null(model.SignatureHash);
        Assert.False(model.RawData.ContainsKey("signatureHash"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateButton
        {
            // Null should be interpreted as omitted for these properties
            Example = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            SignatureHash = null,
            Text = null,
            Type = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplateButton
        {
            Example = "example",
            OtpType = TemplateButtonOtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Type = TemplateButtonType.QuickReply,
            Url = "url",
        };

        TemplateButton copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplateButtonOtpTypeTest : TestBase
{
    [Theory]
    [InlineData(TemplateButtonOtpType.CopyCode)]
    [InlineData(TemplateButtonOtpType.OneTap)]
    public void Validation_Works(TemplateButtonOtpType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateButtonOtpType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonOtpType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TemplateButtonOtpType.CopyCode)]
    [InlineData(TemplateButtonOtpType.OneTap)]
    public void SerializationRoundtrip_Works(TemplateButtonOtpType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateButtonOtpType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonOtpType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonOtpType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonOtpType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TemplateButtonTypeTest : TestBase
{
    [Theory]
    [InlineData(TemplateButtonType.QuickReply)]
    [InlineData(TemplateButtonType.Url)]
    [InlineData(TemplateButtonType.Phone)]
    [InlineData(TemplateButtonType.Otp)]
    [InlineData(TemplateButtonType.RequestContactInfo)]
    public void Validation_Works(TemplateButtonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateButtonType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TemplateButtonType.QuickReply)]
    [InlineData(TemplateButtonType.Url)]
    [InlineData(TemplateButtonType.Phone)]
    [InlineData(TemplateButtonType.Otp)]
    [InlineData(TemplateButtonType.RequestContactInfo)]
    public void SerializationRoundtrip_Works(TemplateButtonType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplateButtonType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TemplateButtonType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WhatsappTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        string expectedNamespace = "namespace";
        string expectedStatus = "status";
        string expectedTemplateName = "templateName";

        Assert.Equal(expectedNamespace, model.Namespace);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTemplateName, model.TemplateName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Whatsapp
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Whatsapp
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Whatsapp>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNamespace = "namespace";
        string expectedStatus = "status";
        string expectedTemplateName = "templateName";

        Assert.Equal(expectedNamespace, deserialized.Namespace);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTemplateName, deserialized.TemplateName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Whatsapp
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Whatsapp { };

        Assert.Null(model.Namespace);
        Assert.False(model.RawData.ContainsKey("namespace"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("templateName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Whatsapp { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Whatsapp
        {
            // Null should be interpreted as omitted for these properties
            Namespace = null,
            Status = null,
            TemplateName = null,
        };

        Assert.Null(model.Namespace);
        Assert.False(model.RawData.ContainsKey("namespace"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TemplateName);
        Assert.False(model.RawData.ContainsKey("templateName"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Whatsapp
        {
            // Null should be interpreted as omitted for these properties
            Namespace = null,
            Status = null,
            TemplateName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Whatsapp
        {
            Namespace = "namespace",
            Status = "status",
            TemplateName = "templateName",
        };

        Whatsapp copied = new(model);

        Assert.Equal(model, copied);
    }
}
