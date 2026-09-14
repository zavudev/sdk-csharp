using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Templates;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a WhatsApp message template. Note: Templates must be approved by Meta
    /// before use.
    /// </summary>
    Task<Template> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get template
    /// </summary>
    Task<Template> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<Template> Retrieve(
        string templateID,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List WhatsApp message templates for this project.
    /// </summary>
    Task<TemplateListPage> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete template
    /// </summary>
    Task Delete(TemplateDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task Delete(
        string templateID,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a WhatsApp template to Meta for approval. The template must be in draft
    /// status and associated with a sender that has a WhatsApp Business Account
    /// configured.
    /// </summary>
    Task<Template> Submit(
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(TemplateSubmitParams, CancellationToken)"/>
    Task<Template> Submit(
        string templateID,
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reconcile this project's templates against WhatsApp. Two things happen per
    /// connected WhatsApp Business Account: templates that exist on Meta but not in
    /// Zavu are imported (or linked to an existing template with the same name), and
    /// the approval status of the templates Zavu already knows about is refreshed from
    /// Meta.
    ///
    /// <para>This is what to call when a template was created outside Zavu — in Meta
    /// Business Manager, or by another tool — or when a `template.status_changed`
    /// webhook was missed and a template is stuck in `pending`. Status changes normally
    /// arrive by webhook; this endpoint is the recovery path and the only path for a
    /// template Zavu never created.</para>
    ///
    /// <para>Templates that Meta reports as rejected or disabled are not imported; they
    /// are counted in `skipped`. Existing local templates are matched first by Meta
    /// template ID, then by name.</para>
    ///
    /// <para>By default every sender in the project with a WhatsApp Business Account is
    /// synced. Pass `senderId` to sync only that sender's account. The call is
    /// synchronous — it waits for Meta and returns what changed — so it can take a few
    /// seconds per account. A failure on one account does not fail the request: it is
    /// reported in `errors` and the remaining accounts are still synced.</para>
    /// </summary>
    Task<TemplateSyncResponse> Sync(
        TemplateSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Template>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/templates/{templateId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Template>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Template>> Retrieve(
        string templateID,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListPage>> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/templates/{templateId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Delete(TemplateDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string templateID,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/templates/{templateId}/submit</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Submit(TemplateSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Template>> Submit(
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(TemplateSubmitParams, CancellationToken)"/>
    Task<HttpResponse<Template>> Submit(
        string templateID,
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/templates/sync</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Sync(TemplateSyncParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateSyncResponse>> Sync(
        TemplateSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
