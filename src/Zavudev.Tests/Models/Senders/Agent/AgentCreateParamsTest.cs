using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentCreateParams
        {
            SenderID = "senderId",
            Model = "gpt-4o-mini",
            Name = "Customer Support",
            Provider = AgentProvider.OpenAI,
            SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",
            ApiKey = "sk-...",
            ContextWindowMessages = 1,
            IncludeContactMetadata = true,
            MaxTokens = 1,
            Temperature = 0,
            TriggerOnChannels = ["string"],
            TriggerOnMessageTypes = ["string"],
            Voice = new()
            {
                Enabled = true,
                Greeting = "Hi, thanks for calling Acme. How can I help you today?",
                Greetings = new Dictionary<string, string>()
                {
                    { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
                },
                Interruptible = true,
                Language = "en",
                MaxCallDurationMinutes = 1,
                MaxIdleSeconds = 5,
                Model = "openai/gpt-4o",
                RecordCalls = true,
                SttModel = "sttModel",
                SttProvider = "sttProvider",
                TransferPhoneNumber = "+14155551234",
                TtsProvider = "ttsProvider",
                TtsVoiceID = "aria",
                VoicemailAction = VoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        string expectedSenderID = "senderId";
        string expectedModel = "gpt-4o-mini";
        string expectedName = "Customer Support";
        ApiEnum<string, AgentProvider> expectedProvider = AgentProvider.OpenAI;
        string expectedSystemPrompt =
            "You are a helpful customer support agent. Be friendly and concise.";
        string expectedApiKey = "sk-...";
        long expectedContextWindowMessages = 1;
        bool expectedIncludeContactMetadata = true;
        long expectedMaxTokens = 1;
        double expectedTemperature = 0;
        List<string> expectedTriggerOnChannels = ["string"];
        List<string> expectedTriggerOnMessageTypes = ["string"];
        Voice expectedVoice = new()
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedModel, parameters.Model);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedProvider, parameters.Provider);
        Assert.Equal(expectedSystemPrompt, parameters.SystemPrompt);
        Assert.Equal(expectedApiKey, parameters.ApiKey);
        Assert.Equal(expectedContextWindowMessages, parameters.ContextWindowMessages);
        Assert.Equal(expectedIncludeContactMetadata, parameters.IncludeContactMetadata);
        Assert.Equal(expectedMaxTokens, parameters.MaxTokens);
        Assert.Equal(expectedTemperature, parameters.Temperature);
        Assert.NotNull(parameters.TriggerOnChannels);
        Assert.Equal(expectedTriggerOnChannels.Count, parameters.TriggerOnChannels.Count);
        for (int i = 0; i < expectedTriggerOnChannels.Count; i++)
        {
            Assert.Equal(expectedTriggerOnChannels[i], parameters.TriggerOnChannels[i]);
        }
        Assert.NotNull(parameters.TriggerOnMessageTypes);
        Assert.Equal(expectedTriggerOnMessageTypes.Count, parameters.TriggerOnMessageTypes.Count);
        for (int i = 0; i < expectedTriggerOnMessageTypes.Count; i++)
        {
            Assert.Equal(expectedTriggerOnMessageTypes[i], parameters.TriggerOnMessageTypes[i]);
        }
        Assert.Equal(expectedVoice, parameters.Voice);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentCreateParams
        {
            SenderID = "senderId",
            Model = "gpt-4o-mini",
            Name = "Customer Support",
            Provider = AgentProvider.OpenAI,
            SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",
        };

        Assert.Null(parameters.ApiKey);
        Assert.False(parameters.RawBodyData.ContainsKey("apiKey"));
        Assert.Null(parameters.ContextWindowMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("contextWindowMessages"));
        Assert.Null(parameters.IncludeContactMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("includeContactMetadata"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("maxTokens"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.TriggerOnChannels);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerOnChannels"));
        Assert.Null(parameters.TriggerOnMessageTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerOnMessageTypes"));
        Assert.Null(parameters.Voice);
        Assert.False(parameters.RawBodyData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentCreateParams
        {
            SenderID = "senderId",
            Model = "gpt-4o-mini",
            Name = "Customer Support",
            Provider = AgentProvider.OpenAI,
            SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",

            // Null should be interpreted as omitted for these properties
            ApiKey = null,
            ContextWindowMessages = null,
            IncludeContactMetadata = null,
            MaxTokens = null,
            Temperature = null,
            TriggerOnChannels = null,
            TriggerOnMessageTypes = null,
            Voice = null,
        };

        Assert.Null(parameters.ApiKey);
        Assert.False(parameters.RawBodyData.ContainsKey("apiKey"));
        Assert.Null(parameters.ContextWindowMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("contextWindowMessages"));
        Assert.Null(parameters.IncludeContactMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("includeContactMetadata"));
        Assert.Null(parameters.MaxTokens);
        Assert.False(parameters.RawBodyData.ContainsKey("maxTokens"));
        Assert.Null(parameters.Temperature);
        Assert.False(parameters.RawBodyData.ContainsKey("temperature"));
        Assert.Null(parameters.TriggerOnChannels);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerOnChannels"));
        Assert.Null(parameters.TriggerOnMessageTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("triggerOnMessageTypes"));
        Assert.Null(parameters.Voice);
        Assert.False(parameters.RawBodyData.ContainsKey("voice"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentCreateParams parameters = new()
        {
            SenderID = "senderId",
            Model = "gpt-4o-mini",
            Name = "Customer Support",
            Provider = AgentProvider.OpenAI,
            SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/agent"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentCreateParams
        {
            SenderID = "senderId",
            Model = "gpt-4o-mini",
            Name = "Customer Support",
            Provider = AgentProvider.OpenAI,
            SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",
            ApiKey = "sk-...",
            ContextWindowMessages = 1,
            IncludeContactMetadata = true,
            MaxTokens = 1,
            Temperature = 0,
            TriggerOnChannels = ["string"],
            TriggerOnMessageTypes = ["string"],
            Voice = new()
            {
                Enabled = true,
                Greeting = "Hi, thanks for calling Acme. How can I help you today?",
                Greetings = new Dictionary<string, string>()
                {
                    { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
                },
                Interruptible = true,
                Language = "en",
                MaxCallDurationMinutes = 1,
                MaxIdleSeconds = 5,
                Model = "openai/gpt-4o",
                RecordCalls = true,
                SttModel = "sttModel",
                SttProvider = "sttProvider",
                TransferPhoneNumber = "+14155551234",
                TtsProvider = "ttsProvider",
                TtsVoiceID = "aria",
                VoicemailAction = VoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        AgentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Voice
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        bool expectedEnabled = true;
        string expectedGreeting = "Hi, thanks for calling Acme. How can I help you today?";
        Dictionary<string, string> expectedGreetings = new()
        {
            { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
        };
        bool expectedInterruptible = true;
        string expectedLanguage = "en";
        long expectedMaxCallDurationMinutes = 1;
        long expectedMaxIdleSeconds = 5;
        string expectedModel = "openai/gpt-4o";
        bool expectedRecordCalls = true;
        string expectedSttModel = "sttModel";
        string expectedSttProvider = "sttProvider";
        string expectedTransferPhoneNumber = "+14155551234";
        string expectedTtsProvider = "ttsProvider";
        string expectedTtsVoiceID = "aria";
        ApiEnum<string, VoicemailAction> expectedVoicemailAction = VoicemailAction.Hangup;
        string expectedVoicemailMessage = "voicemailMessage";
        double expectedVoiceSpeed = 0.5;

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedGreeting, model.Greeting);
        Assert.NotNull(model.Greetings);
        Assert.Equal(expectedGreetings.Count, model.Greetings.Count);
        foreach (var item in expectedGreetings)
        {
            Assert.True(model.Greetings.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Greetings[item.Key]);
        }
        Assert.Equal(expectedInterruptible, model.Interruptible);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedMaxCallDurationMinutes, model.MaxCallDurationMinutes);
        Assert.Equal(expectedMaxIdleSeconds, model.MaxIdleSeconds);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedRecordCalls, model.RecordCalls);
        Assert.Equal(expectedSttModel, model.SttModel);
        Assert.Equal(expectedSttProvider, model.SttProvider);
        Assert.Equal(expectedTransferPhoneNumber, model.TransferPhoneNumber);
        Assert.Equal(expectedTtsProvider, model.TtsProvider);
        Assert.Equal(expectedTtsVoiceID, model.TtsVoiceID);
        Assert.Equal(expectedVoicemailAction, model.VoicemailAction);
        Assert.Equal(expectedVoicemailMessage, model.VoicemailMessage);
        Assert.Equal(expectedVoiceSpeed, model.VoiceSpeed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Voice
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Voice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Voice
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Voice>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        string expectedGreeting = "Hi, thanks for calling Acme. How can I help you today?";
        Dictionary<string, string> expectedGreetings = new()
        {
            { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
        };
        bool expectedInterruptible = true;
        string expectedLanguage = "en";
        long expectedMaxCallDurationMinutes = 1;
        long expectedMaxIdleSeconds = 5;
        string expectedModel = "openai/gpt-4o";
        bool expectedRecordCalls = true;
        string expectedSttModel = "sttModel";
        string expectedSttProvider = "sttProvider";
        string expectedTransferPhoneNumber = "+14155551234";
        string expectedTtsProvider = "ttsProvider";
        string expectedTtsVoiceID = "aria";
        ApiEnum<string, VoicemailAction> expectedVoicemailAction = VoicemailAction.Hangup;
        string expectedVoicemailMessage = "voicemailMessage";
        double expectedVoiceSpeed = 0.5;

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedGreeting, deserialized.Greeting);
        Assert.NotNull(deserialized.Greetings);
        Assert.Equal(expectedGreetings.Count, deserialized.Greetings.Count);
        foreach (var item in expectedGreetings)
        {
            Assert.True(deserialized.Greetings.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Greetings[item.Key]);
        }
        Assert.Equal(expectedInterruptible, deserialized.Interruptible);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedMaxCallDurationMinutes, deserialized.MaxCallDurationMinutes);
        Assert.Equal(expectedMaxIdleSeconds, deserialized.MaxIdleSeconds);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedRecordCalls, deserialized.RecordCalls);
        Assert.Equal(expectedSttModel, deserialized.SttModel);
        Assert.Equal(expectedSttProvider, deserialized.SttProvider);
        Assert.Equal(expectedTransferPhoneNumber, deserialized.TransferPhoneNumber);
        Assert.Equal(expectedTtsProvider, deserialized.TtsProvider);
        Assert.Equal(expectedTtsVoiceID, deserialized.TtsVoiceID);
        Assert.Equal(expectedVoicemailAction, deserialized.VoicemailAction);
        Assert.Equal(expectedVoicemailMessage, deserialized.VoicemailMessage);
        Assert.Equal(expectedVoiceSpeed, deserialized.VoiceSpeed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Voice
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Voice { Enabled = true };

        Assert.Null(model.Greeting);
        Assert.False(model.RawData.ContainsKey("greeting"));
        Assert.Null(model.Greetings);
        Assert.False(model.RawData.ContainsKey("greetings"));
        Assert.Null(model.Interruptible);
        Assert.False(model.RawData.ContainsKey("interruptible"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.MaxCallDurationMinutes);
        Assert.False(model.RawData.ContainsKey("maxCallDurationMinutes"));
        Assert.Null(model.MaxIdleSeconds);
        Assert.False(model.RawData.ContainsKey("maxIdleSeconds"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.RecordCalls);
        Assert.False(model.RawData.ContainsKey("recordCalls"));
        Assert.Null(model.SttModel);
        Assert.False(model.RawData.ContainsKey("sttModel"));
        Assert.Null(model.SttProvider);
        Assert.False(model.RawData.ContainsKey("sttProvider"));
        Assert.Null(model.TransferPhoneNumber);
        Assert.False(model.RawData.ContainsKey("transferPhoneNumber"));
        Assert.Null(model.TtsProvider);
        Assert.False(model.RawData.ContainsKey("ttsProvider"));
        Assert.Null(model.TtsVoiceID);
        Assert.False(model.RawData.ContainsKey("ttsVoiceId"));
        Assert.Null(model.VoicemailAction);
        Assert.False(model.RawData.ContainsKey("voicemailAction"));
        Assert.Null(model.VoicemailMessage);
        Assert.False(model.RawData.ContainsKey("voicemailMessage"));
        Assert.Null(model.VoiceSpeed);
        Assert.False(model.RawData.ContainsKey("voiceSpeed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Voice { Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Voice
        {
            Enabled = true,

            // Null should be interpreted as omitted for these properties
            Greeting = null,
            Greetings = null,
            Interruptible = null,
            Language = null,
            MaxCallDurationMinutes = null,
            MaxIdleSeconds = null,
            Model = null,
            RecordCalls = null,
            SttModel = null,
            SttProvider = null,
            TransferPhoneNumber = null,
            TtsProvider = null,
            TtsVoiceID = null,
            VoicemailAction = null,
            VoicemailMessage = null,
            VoiceSpeed = null,
        };

        Assert.Null(model.Greeting);
        Assert.False(model.RawData.ContainsKey("greeting"));
        Assert.Null(model.Greetings);
        Assert.False(model.RawData.ContainsKey("greetings"));
        Assert.Null(model.Interruptible);
        Assert.False(model.RawData.ContainsKey("interruptible"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.MaxCallDurationMinutes);
        Assert.False(model.RawData.ContainsKey("maxCallDurationMinutes"));
        Assert.Null(model.MaxIdleSeconds);
        Assert.False(model.RawData.ContainsKey("maxIdleSeconds"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.RecordCalls);
        Assert.False(model.RawData.ContainsKey("recordCalls"));
        Assert.Null(model.SttModel);
        Assert.False(model.RawData.ContainsKey("sttModel"));
        Assert.Null(model.SttProvider);
        Assert.False(model.RawData.ContainsKey("sttProvider"));
        Assert.Null(model.TransferPhoneNumber);
        Assert.False(model.RawData.ContainsKey("transferPhoneNumber"));
        Assert.Null(model.TtsProvider);
        Assert.False(model.RawData.ContainsKey("ttsProvider"));
        Assert.Null(model.TtsVoiceID);
        Assert.False(model.RawData.ContainsKey("ttsVoiceId"));
        Assert.Null(model.VoicemailAction);
        Assert.False(model.RawData.ContainsKey("voicemailAction"));
        Assert.Null(model.VoicemailMessage);
        Assert.False(model.RawData.ContainsKey("voicemailMessage"));
        Assert.Null(model.VoiceSpeed);
        Assert.False(model.RawData.ContainsKey("voiceSpeed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Voice
        {
            Enabled = true,

            // Null should be interpreted as omitted for these properties
            Greeting = null,
            Greetings = null,
            Interruptible = null,
            Language = null,
            MaxCallDurationMinutes = null,
            MaxIdleSeconds = null,
            Model = null,
            RecordCalls = null,
            SttModel = null,
            SttProvider = null,
            TransferPhoneNumber = null,
            TtsProvider = null,
            TtsVoiceID = null,
            VoicemailAction = null,
            VoicemailMessage = null,
            VoiceSpeed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Voice
        {
            Enabled = true,
            Greeting = "Hi, thanks for calling Acme. How can I help you today?",
            Greetings = new Dictionary<string, string>()
            {
                { "es", "Hola, soy Atlas. Preguntame lo que quieras." },
            },
            Interruptible = true,
            Language = "en",
            MaxCallDurationMinutes = 1,
            MaxIdleSeconds = 5,
            Model = "openai/gpt-4o",
            RecordCalls = true,
            SttModel = "sttModel",
            SttProvider = "sttProvider",
            TransferPhoneNumber = "+14155551234",
            TtsProvider = "ttsProvider",
            TtsVoiceID = "aria",
            VoicemailAction = VoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        Voice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VoicemailActionTest : TestBase
{
    [Theory]
    [InlineData(VoicemailAction.Hangup)]
    [InlineData(VoicemailAction.LeaveMessage)]
    public void Validation_Works(VoicemailAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoicemailAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoicemailAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VoicemailAction.Hangup)]
    [InlineData(VoicemailAction.LeaveMessage)]
    public void SerializationRoundtrip_Works(VoicemailAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VoicemailAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoicemailAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VoicemailAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VoicemailAction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
