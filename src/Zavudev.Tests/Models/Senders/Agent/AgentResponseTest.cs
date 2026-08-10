using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentResponse
        {
            Agent = new()
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
            },
        };

        AgentAgent expectedAgent = new()
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

        Assert.Equal(expectedAgent, model.Agent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentResponse
        {
            Agent = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentResponse
        {
            Agent = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentAgent expectedAgent = new()
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

        Assert.Equal(expectedAgent, deserialized.Agent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentResponse
        {
            Agent = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentResponse
        {
            Agent = new()
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
            },
        };

        AgentResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
