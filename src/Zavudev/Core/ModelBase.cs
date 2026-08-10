using System.Text.Json;
using Zavudev.Exceptions;
using Zavudev.Models.Addresses;
using Zavudev.Models.Broadcasts;
using Zavudev.Models.Introspect;
using Zavudev.Models.Messages;
using Zavudev.Models.PhoneNumbers;
using Zavudev.Models.Senders;
using Zavudev.Models.Senders.Agent;
using Zavudev.Models.Senders.Agent.Flows;
using Zavudev.Models.SubAccounts.ApiKeys;
using Brands = Zavudev.Models.Number10dlc.Brands;
using Campaigns = Zavudev.Models.Number10dlc.Campaigns;
using Channels = Zavudev.Models.Contacts.Channels;
using Contacts = Zavudev.Models.Contacts;
using Functions = Zavudev.Models.Functions;
using Invitations = Zavudev.Models.Invitations;
using PhoneNumbers = Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;
using RegulatoryDocuments = Zavudev.Models.RegulatoryDocuments;
using SubAccounts = Zavudev.Models.SubAccounts;
using Templates = Zavudev.Models.Templates;
using Tools = Zavudev.Models.Senders.Agent.Tools;
using Urls = Zavudev.Models.Urls;
using WhatsappSync = Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, MessageChannel>(),
            new ApiEnumConverter<string, CtaHeaderType>(),
            new ApiEnumConverter<string, MessageStatus>(),
            new ApiEnumConverter<string, MessageType>(),
            new ApiEnumConverter<string, Channel>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Templates::TemplateButtonOtpType>(),
            new ApiEnumConverter<string, Templates::TemplateButtonType>(),
            new ApiEnumConverter<string, Templates::Status>(),
            new ApiEnumConverter<string, Templates::WhatsappCategory>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, Templates::OtpType>(),
            new ApiEnumConverter<string, Templates::HeaderType>(),
            new ApiEnumConverter<string, SignatureVersion>(),
            new ApiEnumConverter<string, WebhookEvent>(),
            new ApiEnumConverter<string, WhatsappBusinessProfileVertical>(),
            new ApiEnumConverter<string, WebhookSignatureVersion>(),
            new ApiEnumConverter<string, SenderUpdateParamsWebhookSignatureVersion>(),
            new ApiEnumConverter<string, MimeType>(),
            new ApiEnumConverter<string, AgentAgentVoiceVoicemailAction>(),
            new ApiEnumConverter<string, AgentExecutionStatus>(),
            new ApiEnumConverter<string, AgentProvider>(),
            new ApiEnumConverter<string, VoicemailAction>(),
            new ApiEnumConverter<string, AgentUpdateParamsVoiceVoicemailAction>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, FlowTriggerType>(),
            new ApiEnumConverter<string, Tools::Type>(),
            new ApiEnumConverter<string, WhatsappSync::Status>(),
            new ApiEnumConverter<string, WhatsappSync::WhatsAppSyncHistoryStatus>(),
            new ApiEnumConverter<string, WhatsappSync::WhatsAppSyncStatusStatus>(),
            new ApiEnumConverter<string, Contacts::ContactDefaultChannel>(),
            new ApiEnumConverter<string, Contacts::ContactChannelChannel>(),
            new ApiEnumConverter<string, Contacts::ChannelChannel>(),
            new ApiEnumConverter<string, Contacts::DefaultChannel>(),
            new ApiEnumConverter<string, Channels::Channel>(),
            new ApiEnumConverter<string, BroadcastChannel>(),
            new ApiEnumConverter<string, RecipientType>(),
            new ApiEnumConverter<string, BroadcastContactStatus>(),
            new ApiEnumConverter<string, BroadcastMessageType>(),
            new ApiEnumConverter<string, BroadcastStatus>(),
            new ApiEnumConverter<string, LineType>(),
            new ApiEnumConverter<string, PhoneNumberStatus>(),
            new ApiEnumConverter<string, PhoneNumberType>(),
            new ApiEnumConverter<string, RequirementFieldType>(),
            new ApiEnumConverter<string, AddressStatus>(),
            new ApiEnumConverter<string, RegulatoryDocuments::RegulatoryDocumentDocumentType>(),
            new ApiEnumConverter<string, RegulatoryDocuments::Status>(),
            new ApiEnumConverter<string, RegulatoryDocuments::DocumentType>(),
            new ApiEnumConverter<string, Invitations::InvitationStatus>(),
            new ApiEnumConverter<string, Invitations::Channel>(),
            new ApiEnumConverter<string, Invitations::InvitationConnectionType>(),
            new ApiEnumConverter<string, Invitations::ConnectionType>(),
            new ApiEnumConverter<string, Invitations::Status>(),
            new ApiEnumConverter<string, Urls::VerifiedUrlStatus>(),
            new ApiEnumConverter<string, Urls::ApprovalType>(),
            new ApiEnumConverter<string, Urls::Status>(),
            new ApiEnumConverter<string, SubAccounts::SubAccountStatus>(),
            new ApiEnumConverter<string, SubAccounts::Status>(),
            new ApiEnumConverter<string, ApiKeyEnvironment>(),
            new ApiEnumConverter<string, ItemEnvironment>(),
            new ApiEnumConverter<string, Environment>(),
            new ApiEnumConverter<string, Brands::TenDlcBrandEntityType>(),
            new ApiEnumConverter<string, Brands::Status>(),
            new ApiEnumConverter<string, Brands::EntityType>(),
            new ApiEnumConverter<string, Brands::BrandUpdateParamsEntityType>(),
            new ApiEnumConverter<string, Campaigns::Status>(),
            new ApiEnumConverter<string, PhoneNumbers::Status>(),
            new ApiEnumConverter<string, Functions::FunctionRuntime>(),
            new ApiEnumConverter<string, Functions::Status>(),
            new ApiEnumConverter<string, Functions::FunctionRetrieveResponseFunctionRuntime>(),
            new ApiEnumConverter<string, Functions::FunctionRetrieveResponseFunctionStatus>(),
            new ApiEnumConverter<string, Functions::FunctionUpdateResponseFunctionRuntime>(),
            new ApiEnumConverter<string, Functions::FunctionUpdateResponseFunctionStatus>(),
            new ApiEnumConverter<string, Functions::DeploymentStatus>(),
            new ApiEnumConverter<
                string,
                Functions::FunctionGetDeploymentResponseDeploymentStatus
            >(),
            new ApiEnumConverter<long, Functions::MemoryMB>(),
            new ApiEnumConverter<string, Functions::Runtime>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ZavudevInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
