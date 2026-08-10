using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            MaxTokens = 0,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            Temperature = 0,
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        string expectedID = "agent_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedEnabled = true;
        string expectedModel = "gpt-4o-mini";
        string expectedName = "Customer Support Agent";
        ApiEnum<string, AgentProvider> expectedProvider = AgentProvider.OpenAI;
        string expectedSenderID = "sender_12345";
        string expectedSystemPrompt = "systemPrompt";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedContextWindowMessages = 0;
        bool expectedIncludeContactMetadata = true;
        long expectedMaxTokens = 0;
        List<string> expectedSenderIds = ["string"];
        Stats expectedStats = new()
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };
        double expectedTemperature = 0;
        List<string> expectedTriggerOnChannels = ["sms", "whatsapp"];
        List<string> expectedTriggerOnMessageTypes = ["text"];
        AgentAgentVoice expectedVoice = new()
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedContextWindowMessages, model.ContextWindowMessages);
        Assert.Equal(expectedIncludeContactMetadata, model.IncludeContactMetadata);
        Assert.Equal(expectedMaxTokens, model.MaxTokens);
        Assert.NotNull(model.SenderIds);
        Assert.Equal(expectedSenderIds.Count, model.SenderIds.Count);
        for (int i = 0; i < expectedSenderIds.Count; i++)
        {
            Assert.Equal(expectedSenderIds[i], model.SenderIds[i]);
        }
        Assert.Equal(expectedStats, model.Stats);
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.NotNull(model.TriggerOnChannels);
        Assert.Equal(expectedTriggerOnChannels.Count, model.TriggerOnChannels.Count);
        for (int i = 0; i < expectedTriggerOnChannels.Count; i++)
        {
            Assert.Equal(expectedTriggerOnChannels[i], model.TriggerOnChannels[i]);
        }
        Assert.NotNull(model.TriggerOnMessageTypes);
        Assert.Equal(expectedTriggerOnMessageTypes.Count, model.TriggerOnMessageTypes.Count);
        for (int i = 0; i < expectedTriggerOnMessageTypes.Count; i++)
        {
            Assert.Equal(expectedTriggerOnMessageTypes[i], model.TriggerOnMessageTypes[i]);
        }
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            MaxTokens = 0,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            Temperature = 0,
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            MaxTokens = 0,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            Temperature = 0,
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedEnabled = true;
        string expectedModel = "gpt-4o-mini";
        string expectedName = "Customer Support Agent";
        ApiEnum<string, AgentProvider> expectedProvider = AgentProvider.OpenAI;
        string expectedSenderID = "sender_12345";
        string expectedSystemPrompt = "systemPrompt";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedContextWindowMessages = 0;
        bool expectedIncludeContactMetadata = true;
        long expectedMaxTokens = 0;
        List<string> expectedSenderIds = ["string"];
        Stats expectedStats = new()
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };
        double expectedTemperature = 0;
        List<string> expectedTriggerOnChannels = ["sms", "whatsapp"];
        List<string> expectedTriggerOnMessageTypes = ["text"];
        AgentAgentVoice expectedVoice = new()
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedContextWindowMessages, deserialized.ContextWindowMessages);
        Assert.Equal(expectedIncludeContactMetadata, deserialized.IncludeContactMetadata);
        Assert.Equal(expectedMaxTokens, deserialized.MaxTokens);
        Assert.NotNull(deserialized.SenderIds);
        Assert.Equal(expectedSenderIds.Count, deserialized.SenderIds.Count);
        for (int i = 0; i < expectedSenderIds.Count; i++)
        {
            Assert.Equal(expectedSenderIds[i], deserialized.SenderIds[i]);
        }
        Assert.Equal(expectedStats, deserialized.Stats);
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.NotNull(deserialized.TriggerOnChannels);
        Assert.Equal(expectedTriggerOnChannels.Count, deserialized.TriggerOnChannels.Count);
        for (int i = 0; i < expectedTriggerOnChannels.Count; i++)
        {
            Assert.Equal(expectedTriggerOnChannels[i], deserialized.TriggerOnChannels[i]);
        }
        Assert.NotNull(deserialized.TriggerOnMessageTypes);
        Assert.Equal(expectedTriggerOnMessageTypes.Count, deserialized.TriggerOnMessageTypes.Count);
        for (int i = 0; i < expectedTriggerOnMessageTypes.Count; i++)
        {
            Assert.Equal(expectedTriggerOnMessageTypes[i], deserialized.TriggerOnMessageTypes[i]);
        }
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            MaxTokens = 0,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            Temperature = 0,
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxTokens = 0,
            Temperature = 0,
        };

        Assert.Null(model.ContextWindowMessages);
        Assert.False(model.RawData.ContainsKey("contextWindowMessages"));
        Assert.Null(model.IncludeContactMetadata);
        Assert.False(model.RawData.ContainsKey("includeContactMetadata"));
        Assert.Null(model.SenderIds);
        Assert.False(model.RawData.ContainsKey("senderIds"));
        Assert.Null(model.Stats);
        Assert.False(model.RawData.ContainsKey("stats"));
        Assert.Null(model.TriggerOnChannels);
        Assert.False(model.RawData.ContainsKey("triggerOnChannels"));
        Assert.Null(model.TriggerOnMessageTypes);
        Assert.False(model.RawData.ContainsKey("triggerOnMessageTypes"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxTokens = 0,
            Temperature = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxTokens = 0,
            Temperature = 0,

            // Null should be interpreted as omitted for these properties
            ContextWindowMessages = null,
            IncludeContactMetadata = null,
            SenderIds = null,
            Stats = null,
            TriggerOnChannels = null,
            TriggerOnMessageTypes = null,
            Voice = null,
        };

        Assert.Null(model.ContextWindowMessages);
        Assert.False(model.RawData.ContainsKey("contextWindowMessages"));
        Assert.Null(model.IncludeContactMetadata);
        Assert.False(model.RawData.ContainsKey("includeContactMetadata"));
        Assert.Null(model.SenderIds);
        Assert.False(model.RawData.ContainsKey("senderIds"));
        Assert.Null(model.Stats);
        Assert.False(model.RawData.ContainsKey("stats"));
        Assert.Null(model.TriggerOnChannels);
        Assert.False(model.RawData.ContainsKey("triggerOnChannels"));
        Assert.Null(model.TriggerOnMessageTypes);
        Assert.False(model.RawData.ContainsKey("triggerOnMessageTypes"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MaxTokens = 0,
            Temperature = 0,

            // Null should be interpreted as omitted for these properties
            ContextWindowMessages = null,
            IncludeContactMetadata = null,
            SenderIds = null,
            Stats = null,
            TriggerOnChannels = null,
            TriggerOnMessageTypes = null,
            Voice = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        Assert.Null(model.MaxTokens);
        Assert.False(model.RawData.ContainsKey("maxTokens"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },

            MaxTokens = null,
            Temperature = null,
        };

        Assert.Null(model.MaxTokens);
        Assert.True(model.RawData.ContainsKey("maxTokens"));
        Assert.Null(model.Temperature);
        Assert.True(model.RawData.ContainsKey("temperature"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },

            MaxTokens = null,
            Temperature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentAgent
        {
            ID = "agent_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Enabled = true,
            Model = "gpt-4o-mini",
            Name = "Customer Support Agent",
            Provider = AgentProvider.OpenAI,
            SenderID = "sender_12345",
            SystemPrompt = "systemPrompt",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ContextWindowMessages = 0,
            IncludeContactMetadata = true,
            MaxTokens = 0,
            SenderIds = ["string"],
            Stats = new()
            {
                TotalCost = 0,
                TotalInvocations = 0,
                TotalTokensUsed = 0,
            },
            Temperature = 0,
            TriggerOnChannels = ["sms", "whatsapp"],
            TriggerOnMessageTypes = ["text"],
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
                VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
                VoicemailMessage = "voicemailMessage",
                VoiceSpeed = 0.5,
            },
        };

        AgentAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stats
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        double expectedTotalCost = 0;
        long expectedTotalInvocations = 0;
        long expectedTotalTokensUsed = 0;

        Assert.Equal(expectedTotalCost, model.TotalCost);
        Assert.Equal(expectedTotalInvocations, model.TotalInvocations);
        Assert.Equal(expectedTotalTokensUsed, model.TotalTokensUsed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Stats
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stats>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stats
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stats>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedTotalCost = 0;
        long expectedTotalInvocations = 0;
        long expectedTotalTokensUsed = 0;

        Assert.Equal(expectedTotalCost, deserialized.TotalCost);
        Assert.Equal(expectedTotalInvocations, deserialized.TotalInvocations);
        Assert.Equal(expectedTotalTokensUsed, deserialized.TotalTokensUsed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Stats
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Stats { };

        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("totalCost"));
        Assert.Null(model.TotalInvocations);
        Assert.False(model.RawData.ContainsKey("totalInvocations"));
        Assert.Null(model.TotalTokensUsed);
        Assert.False(model.RawData.ContainsKey("totalTokensUsed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Stats { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Stats
        {
            // Null should be interpreted as omitted for these properties
            TotalCost = null,
            TotalInvocations = null,
            TotalTokensUsed = null,
        };

        Assert.Null(model.TotalCost);
        Assert.False(model.RawData.ContainsKey("totalCost"));
        Assert.Null(model.TotalInvocations);
        Assert.False(model.RawData.ContainsKey("totalInvocations"));
        Assert.Null(model.TotalTokensUsed);
        Assert.False(model.RawData.ContainsKey("totalTokensUsed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Stats
        {
            // Null should be interpreted as omitted for these properties
            TotalCost = null,
            TotalInvocations = null,
            TotalTokensUsed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Stats
        {
            TotalCost = 0,
            TotalInvocations = 0,
            TotalTokensUsed = 0,
        };

        Stats copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentAgentVoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentAgentVoice
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
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
        ApiEnum<string, AgentAgentVoiceVoicemailAction> expectedVoicemailAction =
            AgentAgentVoiceVoicemailAction.Hangup;
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
        var model = new AgentAgentVoice
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentAgentVoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentAgentVoice
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentAgentVoice>(
            element,
            ModelBase.SerializerOptions
        );
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
        ApiEnum<string, AgentAgentVoiceVoicemailAction> expectedVoicemailAction =
            AgentAgentVoiceVoicemailAction.Hangup;
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
        var model = new AgentAgentVoice
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentAgentVoice { Enabled = true };

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
        var model = new AgentAgentVoice { Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AgentAgentVoice
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
        var model = new AgentAgentVoice
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
        var model = new AgentAgentVoice
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
            VoicemailAction = AgentAgentVoiceVoicemailAction.Hangup,
            VoicemailMessage = "voicemailMessage",
            VoiceSpeed = 0.5,
        };

        AgentAgentVoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentAgentVoiceVoicemailActionTest : TestBase
{
    [Theory]
    [InlineData(AgentAgentVoiceVoicemailAction.Hangup)]
    [InlineData(AgentAgentVoiceVoicemailAction.LeaveMessage)]
    public void Validation_Works(AgentAgentVoiceVoicemailAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentAgentVoiceVoicemailAction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentAgentVoiceVoicemailAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentAgentVoiceVoicemailAction.Hangup)]
    [InlineData(AgentAgentVoiceVoicemailAction.LeaveMessage)]
    public void SerializationRoundtrip_Works(AgentAgentVoiceVoicemailAction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentAgentVoiceVoicemailAction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentAgentVoiceVoicemailAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentAgentVoiceVoicemailAction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AgentAgentVoiceVoicemailAction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
