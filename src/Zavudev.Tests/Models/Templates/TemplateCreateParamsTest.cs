using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Templates = Zavudev.Models.Templates;

namespace Zavudev.Tests.Models.Templates;

public class TemplateCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Body = "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
            Language = "en",
            Name = "order_confirmation",
            AddSecurityRecommendation = true,
            Buttons =
            [
                new()
                {
                    Type = Templates::Type.QuickReply,
                    Example = "ORD-12345",
                    OtpType = Templates::OtpType.CopyCode,
                    PackageName = "packageName",
                    PhoneNumber = "phoneNumber",
                    SignatureHash = "signatureHash",
                    Text = "text",
                    Url = "https://example.com",
                },
            ],
            CodeExpirationMinutes = 1,
            Footer = "footer",
            HeaderContent = "headerContent",
            HeaderType = Templates::HeaderType.Text,
            InstagramBody = "instagramBody",
            SmsBody = "smsBody",
            TelegramBody = "telegramBody",
            Variables = ["customer_name", "order_id"],
            WhatsappCategory = Templates::WhatsappCategory.Utility,
        };

        string expectedBody =
            "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.";
        string expectedLanguage = "en";
        string expectedName = "order_confirmation";
        bool expectedAddSecurityRecommendation = true;
        List<Templates::Button> expectedButtons =
        [
            new()
            {
                Type = Templates::Type.QuickReply,
                Example = "ORD-12345",
                OtpType = Templates::OtpType.CopyCode,
                PackageName = "packageName",
                PhoneNumber = "phoneNumber",
                SignatureHash = "signatureHash",
                Text = "text",
                Url = "https://example.com",
            },
        ];
        long expectedCodeExpirationMinutes = 1;
        string expectedFooter = "footer";
        string expectedHeaderContent = "headerContent";
        ApiEnum<string, Templates::HeaderType> expectedHeaderType = Templates::HeaderType.Text;
        string expectedInstagramBody = "instagramBody";
        string expectedSmsBody = "smsBody";
        string expectedTelegramBody = "telegramBody";
        List<string> expectedVariables = ["customer_name", "order_id"];
        ApiEnum<string, Templates::WhatsappCategory> expectedWhatsappCategory =
            Templates::WhatsappCategory.Utility;

        Assert.Equal(expectedBody, parameters.Body);
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedAddSecurityRecommendation, parameters.AddSecurityRecommendation);
        Assert.NotNull(parameters.Buttons);
        Assert.Equal(expectedButtons.Count, parameters.Buttons.Count);
        for (int i = 0; i < expectedButtons.Count; i++)
        {
            Assert.Equal(expectedButtons[i], parameters.Buttons[i]);
        }
        Assert.Equal(expectedCodeExpirationMinutes, parameters.CodeExpirationMinutes);
        Assert.Equal(expectedFooter, parameters.Footer);
        Assert.Equal(expectedHeaderContent, parameters.HeaderContent);
        Assert.Equal(expectedHeaderType, parameters.HeaderType);
        Assert.Equal(expectedInstagramBody, parameters.InstagramBody);
        Assert.Equal(expectedSmsBody, parameters.SmsBody);
        Assert.Equal(expectedTelegramBody, parameters.TelegramBody);
        Assert.NotNull(parameters.Variables);
        Assert.Equal(expectedVariables.Count, parameters.Variables.Count);
        for (int i = 0; i < expectedVariables.Count; i++)
        {
            Assert.Equal(expectedVariables[i], parameters.Variables[i]);
        }
        Assert.Equal(expectedWhatsappCategory, parameters.WhatsappCategory);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Body = "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
            Language = "en",
            Name = "order_confirmation",
        };

        Assert.Null(parameters.AddSecurityRecommendation);
        Assert.False(parameters.RawBodyData.ContainsKey("addSecurityRecommendation"));
        Assert.Null(parameters.Buttons);
        Assert.False(parameters.RawBodyData.ContainsKey("buttons"));
        Assert.Null(parameters.CodeExpirationMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("codeExpirationMinutes"));
        Assert.Null(parameters.Footer);
        Assert.False(parameters.RawBodyData.ContainsKey("footer"));
        Assert.Null(parameters.HeaderContent);
        Assert.False(parameters.RawBodyData.ContainsKey("headerContent"));
        Assert.Null(parameters.HeaderType);
        Assert.False(parameters.RawBodyData.ContainsKey("headerType"));
        Assert.Null(parameters.InstagramBody);
        Assert.False(parameters.RawBodyData.ContainsKey("instagramBody"));
        Assert.Null(parameters.SmsBody);
        Assert.False(parameters.RawBodyData.ContainsKey("smsBody"));
        Assert.Null(parameters.TelegramBody);
        Assert.False(parameters.RawBodyData.ContainsKey("telegramBody"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
        Assert.Null(parameters.WhatsappCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("whatsappCategory"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Body = "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
            Language = "en",
            Name = "order_confirmation",

            // Null should be interpreted as omitted for these properties
            AddSecurityRecommendation = null,
            Buttons = null,
            CodeExpirationMinutes = null,
            Footer = null,
            HeaderContent = null,
            HeaderType = null,
            InstagramBody = null,
            SmsBody = null,
            TelegramBody = null,
            Variables = null,
            WhatsappCategory = null,
        };

        Assert.Null(parameters.AddSecurityRecommendation);
        Assert.False(parameters.RawBodyData.ContainsKey("addSecurityRecommendation"));
        Assert.Null(parameters.Buttons);
        Assert.False(parameters.RawBodyData.ContainsKey("buttons"));
        Assert.Null(parameters.CodeExpirationMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("codeExpirationMinutes"));
        Assert.Null(parameters.Footer);
        Assert.False(parameters.RawBodyData.ContainsKey("footer"));
        Assert.Null(parameters.HeaderContent);
        Assert.False(parameters.RawBodyData.ContainsKey("headerContent"));
        Assert.Null(parameters.HeaderType);
        Assert.False(parameters.RawBodyData.ContainsKey("headerType"));
        Assert.Null(parameters.InstagramBody);
        Assert.False(parameters.RawBodyData.ContainsKey("instagramBody"));
        Assert.Null(parameters.SmsBody);
        Assert.False(parameters.RawBodyData.ContainsKey("smsBody"));
        Assert.Null(parameters.TelegramBody);
        Assert.False(parameters.RawBodyData.ContainsKey("telegramBody"));
        Assert.Null(parameters.Variables);
        Assert.False(parameters.RawBodyData.ContainsKey("variables"));
        Assert.Null(parameters.WhatsappCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("whatsappCategory"));
    }

    [Fact]
    public void Url_Works()
    {
        Templates::TemplateCreateParams parameters = new()
        {
            Body = "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
            Language = "en",
            Name = "order_confirmation",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/templates"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Templates::TemplateCreateParams
        {
            Body = "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
            Language = "en",
            Name = "order_confirmation",
            AddSecurityRecommendation = true,
            Buttons =
            [
                new()
                {
                    Type = Templates::Type.QuickReply,
                    Example = "ORD-12345",
                    OtpType = Templates::OtpType.CopyCode,
                    PackageName = "packageName",
                    PhoneNumber = "phoneNumber",
                    SignatureHash = "signatureHash",
                    Text = "text",
                    Url = "https://example.com",
                },
            ],
            CodeExpirationMinutes = 1,
            Footer = "footer",
            HeaderContent = "headerContent",
            HeaderType = Templates::HeaderType.Text,
            InstagramBody = "instagramBody",
            SmsBody = "smsBody",
            TelegramBody = "telegramBody",
            Variables = ["customer_name", "order_id"],
            WhatsappCategory = Templates::WhatsappCategory.Utility,
        };

        Templates::TemplateCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ButtonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,
            Example = "ORD-12345",
            OtpType = Templates::OtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "https://example.com",
        };

        ApiEnum<string, Templates::Type> expectedType = Templates::Type.QuickReply;
        string expectedExample = "ORD-12345";
        ApiEnum<string, Templates::OtpType> expectedOtpType = Templates::OtpType.CopyCode;
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedExample, model.Example);
        Assert.Equal(expectedOtpType, model.OtpType);
        Assert.Equal(expectedPackageName, model.PackageName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedSignatureHash, model.SignatureHash);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,
            Example = "ORD-12345",
            OtpType = Templates::OtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "https://example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Button>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,
            Example = "ORD-12345",
            OtpType = Templates::OtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "https://example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Templates::Button>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Templates::Type> expectedType = Templates::Type.QuickReply;
        string expectedExample = "ORD-12345";
        ApiEnum<string, Templates::OtpType> expectedOtpType = Templates::OtpType.CopyCode;
        string expectedPackageName = "packageName";
        string expectedPhoneNumber = "phoneNumber";
        string expectedSignatureHash = "signatureHash";
        string expectedText = "text";
        string expectedUrl = "https://example.com";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedExample, deserialized.Example);
        Assert.Equal(expectedOtpType, deserialized.OtpType);
        Assert.Equal(expectedPackageName, deserialized.PackageName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedSignatureHash, deserialized.SignatureHash);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,
            Example = "ORD-12345",
            OtpType = Templates::OtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Templates::Button { Type = Templates::Type.QuickReply };

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
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Templates::Button { Type = Templates::Type.QuickReply };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,

            // Null should be interpreted as omitted for these properties
            Example = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            SignatureHash = null,
            Text = null,
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
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,

            // Null should be interpreted as omitted for these properties
            Example = null,
            OtpType = null,
            PackageName = null,
            PhoneNumber = null,
            SignatureHash = null,
            Text = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Templates::Button
        {
            Type = Templates::Type.QuickReply,
            Example = "ORD-12345",
            OtpType = Templates::OtpType.CopyCode,
            PackageName = "packageName",
            PhoneNumber = "phoneNumber",
            SignatureHash = "signatureHash",
            Text = "text",
            Url = "https://example.com",
        };

        Templates::Button copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Templates::Type.QuickReply)]
    [InlineData(Templates::Type.Url)]
    [InlineData(Templates::Type.Phone)]
    [InlineData(Templates::Type.Otp)]
    [InlineData(Templates::Type.RequestContactInfo)]
    public void Validation_Works(Templates::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::Type.QuickReply)]
    [InlineData(Templates::Type.Url)]
    [InlineData(Templates::Type.Phone)]
    [InlineData(Templates::Type.Otp)]
    [InlineData(Templates::Type.RequestContactInfo)]
    public void SerializationRoundtrip_Works(Templates::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OtpTypeTest : TestBase
{
    [Theory]
    [InlineData(Templates::OtpType.CopyCode)]
    [InlineData(Templates::OtpType.OneTap)]
    public void Validation_Works(Templates::OtpType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::OtpType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::OtpType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::OtpType.CopyCode)]
    [InlineData(Templates::OtpType.OneTap)]
    public void SerializationRoundtrip_Works(Templates::OtpType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::OtpType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::OtpType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::OtpType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::OtpType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class HeaderTypeTest : TestBase
{
    [Theory]
    [InlineData(Templates::HeaderType.Text)]
    [InlineData(Templates::HeaderType.Image)]
    [InlineData(Templates::HeaderType.Video)]
    [InlineData(Templates::HeaderType.Document)]
    public void Validation_Works(Templates::HeaderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::HeaderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::HeaderType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Templates::HeaderType.Text)]
    [InlineData(Templates::HeaderType.Image)]
    [InlineData(Templates::HeaderType.Video)]
    [InlineData(Templates::HeaderType.Document)]
    public void SerializationRoundtrip_Works(Templates::HeaderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Templates::HeaderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::HeaderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Templates::HeaderType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Templates::HeaderType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
