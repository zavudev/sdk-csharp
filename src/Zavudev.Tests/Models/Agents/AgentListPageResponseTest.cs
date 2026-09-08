using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Agents;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Agents;

public class AgentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<AgentAgent> expectedItems =
        [
            new()
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
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentAgent> expectedItems =
        [
            new()
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
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        AgentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
