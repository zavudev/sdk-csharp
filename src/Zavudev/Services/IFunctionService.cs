using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Functions;
using Zavudev.Services.Functions;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFunctionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFunctionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISecretService Secrets { get; }

    ITriggerService Triggers { get; }

    IGitLinkService GitLink { get; }

    /// <summary>
    /// Create a new Zavu Function. The function starts in `draft` status. A dedicated
    /// API key is auto-provisioned and injected as the `ZAVU_API_KEY` secret so the
    /// function can call back into the Zavu API without manual setup.
    ///
    /// <para>Provide `sourceCode` to seed the draft. Call `POST
    /// /v1/functions/{functionId}/deploy` afterwards to publish.</para>
    /// </summary>
    Task<FunctionCreateResponse> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get function
    /// </summary>
    Task<FunctionRetrieveResponse> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<FunctionRetrieveResponse> Retrieve(
        string functionID,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing function. `sourceCode` / `dependencies` edit the draft
    /// without triggering a build — they go live on the next `POST
    /// /v1/functions/{functionId}/deploy`. `httpEnabled` is applied to the deployed
    /// function immediately, so turning the public endpoint on or off does not require
    /// a redeploy.
    /// </summary>
    Task<FunctionUpdateResponse> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<FunctionUpdateResponse> Update(
        string functionID,
        FunctionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a function and cascade: triggers, secrets, deployment
    /// history, managed agents+tools, and revoke the auto-provisioned API key. The AWS
    /// Lambda + log group are torn down asynchronously.
    /// </summary>
    Task<FunctionDeleteResponse> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task<FunctionDeleteResponse> Delete(
        string functionID,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publish the function. If `sourceCode` or `dependencies` are provided in the
    /// body, they replace the current draft before deployment. Returns immediately with
    /// a deployment ID — poll `GET /v1/functions/deployments/{deploymentId}` until
    /// status is `active` or `failed`.
    /// </summary>
    Task<FunctionDeployResponse> Deploy(
        FunctionDeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deploy(FunctionDeployParams, CancellationToken)"/>
    Task<FunctionDeployResponse> Deploy(
        string functionID,
        FunctionDeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch a deployment to poll its status during a deploy.
    /// </summary>
    Task<FunctionGetDeploymentResponse> GetDeployment(
        FunctionGetDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDeployment(FunctionGetDeploymentParams, CancellationToken)"/>
    Task<FunctionGetDeploymentResponse> GetDeployment(
        string deploymentID,
        FunctionGetDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List a function's deployment history, newest first. Source code is omitted;
    /// fetch a single deployment via GET /v1/functions/deployments/{deploymentId} for
    /// full details.
    /// </summary>
    Task<FunctionListDeploymentsResponse> ListDeployments(
        FunctionListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeployments(FunctionListDeploymentsParams, CancellationToken)"/>
    Task<FunctionListDeploymentsResponse> ListDeployments(
        string functionID,
        FunctionListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the event types a function trigger can subscribe to. Includes the special
    /// type `cron`, which fires on a schedule (see POST
    /// /v1/functions/{functionId}/triggers) rather than on a messaging event.
    /// </summary>
    Task<FunctionListEventTypesResponse> ListEventTypes(
        FunctionListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Re-deploy a previous version by copying its source, dependencies, and runtime
    /// pin onto the function's draft, then deploying. Returns immediately with a
    /// deployment ID — poll GET /v1/functions/deployments/{deploymentId} until status
    /// is active or failed. Secrets are not rolled back.
    /// </summary>
    Task<FunctionRollbackDeploymentResponse> RollbackDeployment(
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RollbackDeployment(FunctionRollbackDeploymentParams, CancellationToken)"/>
    Task<FunctionRollbackDeploymentResponse> RollbackDeployment(
        string functionID,
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch invocation logs for a function. Logs are paginated via `nextToken`. Pass
    /// `startTime` / `endTime` (Unix epoch milliseconds) to bound the window, or
    /// `filterPattern` to filter messages.
    /// </summary>
    Task<FunctionTailLogsResponse> TailLogs(
        FunctionTailLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TailLogs(FunctionTailLogsParams, CancellationToken)"/>
    Task<FunctionTailLogsResponse> TailLogs(
        string functionID,
        FunctionTailLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFunctionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFunctionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISecretServiceWithRawResponse Secrets { get; }

    ITriggerServiceWithRawResponse Triggers { get; }

    IGitLinkServiceWithRawResponse GitLink { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Create(FunctionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionCreateResponse>> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Retrieve(FunctionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionRetrieveResponse>> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FunctionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FunctionRetrieveResponse>> Retrieve(
        string functionID,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/functions/{functionId}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Update(FunctionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionUpdateResponse>> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FunctionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FunctionUpdateResponse>> Update(
        string functionID,
        FunctionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/functions/{functionId}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Delete(FunctionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionDeleteResponse>> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FunctionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FunctionDeleteResponse>> Delete(
        string functionID,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions/{functionId}/deploy</c>, but is otherwise the
    /// same as <see cref="IFunctionService.Deploy(FunctionDeployParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionDeployResponse>> Deploy(
        FunctionDeployParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deploy(FunctionDeployParams, CancellationToken)"/>
    Task<HttpResponse<FunctionDeployResponse>> Deploy(
        string functionID,
        FunctionDeployParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/deployments/{deploymentId}</c>, but is otherwise the
    /// same as <see cref="IFunctionService.GetDeployment(FunctionGetDeploymentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionGetDeploymentResponse>> GetDeployment(
        FunctionGetDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDeployment(FunctionGetDeploymentParams, CancellationToken)"/>
    Task<HttpResponse<FunctionGetDeploymentResponse>> GetDeployment(
        string deploymentID,
        FunctionGetDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}/deployments</c>, but is otherwise the
    /// same as <see cref="IFunctionService.ListDeployments(FunctionListDeploymentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionListDeploymentsResponse>> ListDeployments(
        FunctionListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListDeployments(FunctionListDeploymentsParams, CancellationToken)"/>
    Task<HttpResponse<FunctionListDeploymentsResponse>> ListDeployments(
        string functionID,
        FunctionListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/event-types</c>, but is otherwise the
    /// same as <see cref="IFunctionService.ListEventTypes(FunctionListEventTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionListEventTypesResponse>> ListEventTypes(
        FunctionListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions/{functionId}/rollback</c>, but is otherwise the
    /// same as <see cref="IFunctionService.RollbackDeployment(FunctionRollbackDeploymentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionRollbackDeploymentResponse>> RollbackDeployment(
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RollbackDeployment(FunctionRollbackDeploymentParams, CancellationToken)"/>
    Task<HttpResponse<FunctionRollbackDeploymentResponse>> RollbackDeployment(
        string functionID,
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}/logs</c>, but is otherwise the
    /// same as <see cref="IFunctionService.TailLogs(FunctionTailLogsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FunctionTailLogsResponse>> TailLogs(
        FunctionTailLogsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TailLogs(FunctionTailLogsParams, CancellationToken)"/>
    Task<HttpResponse<FunctionTailLogsResponse>> TailLogs(
        string functionID,
        FunctionTailLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
