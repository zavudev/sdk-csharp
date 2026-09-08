using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Services.Functions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGitLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGitLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGitLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// The link and its last deploy. Never returns the webhook secret.
    /// </summary>
    Task<GitLinkRetrieveResponse> Retrieve(
        GitLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(GitLinkRetrieveParams, CancellationToken)"/>
    Task<GitLinkRetrieveResponse> Retrieve(
        string functionID,
        GitLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change the branch, the root directory, or whether pushes deploy. Pass at least
    /// one field. `rootDir: null` clears the subdirectory.
    /// </summary>
    Task<GitLinkUpdateResponse> Update(
        GitLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(GitLinkUpdateParams, CancellationToken)"/>
    Task<GitLinkUpdateResponse> Update(
        string functionID,
        GitLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the linked branch and deploy it without waiting for a push. Returns
    /// immediately; follow the outcome with `GET /v1/functions/{functionId}/git-link`,
    /// whose `lastStatus` and `lastError` describe the run.
    /// </summary>
    Task<GitLinkDeployNowResponse> DeployNow(
        GitLinkDeployNowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeployNow(GitLinkDeployNowParams, CancellationToken)"/>
    Task<GitLinkDeployNowResponse> DeployNow(
        string functionID,
        GitLinkDeployNowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bind a repository to this function so every push to `branch` deploys it. A
    /// function holds at most one link; linking again returns 400.
    ///
    /// <para>**The server decides how the link authenticates.** If the project has the
    /// Zavu GitHub App installed, the link uses that installation: private repositories
    /// work and there is nothing to configure in the repository. Otherwise it falls
    /// back to a manual link and the response carries a `webhookSecret` you add to the
    /// repository yourself. `connection` says which one you got.</para>
    ///
    /// <para>The repository is not checked against GitHub here, because it cannot be:
    /// an owner/repo that does not exist, or that the installation cannot see, is
    /// accepted and fails on the first deploy with a fetch error.</para>
    /// </summary>
    Task<GitLinkLinkResponse> Link(
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Link(GitLinkLinkParams, CancellationToken)"/>
    Task<GitLinkLinkResponse> Link(
        string functionID,
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove the link. The function and its deployments stay. A manual webhook left in
    /// the repository stops being accepted, so remove it there too.
    /// </summary>
    Task Unlink(GitLinkUnlinkParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Unlink(GitLinkUnlinkParams, CancellationToken)"/>
    Task Unlink(
        string functionID,
        GitLinkUnlinkParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGitLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGitLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGitLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}/git-link</c>, but is otherwise the
    /// same as <see cref="IGitLinkService.Retrieve(GitLinkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GitLinkRetrieveResponse>> Retrieve(
        GitLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(GitLinkRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GitLinkRetrieveResponse>> Retrieve(
        string functionID,
        GitLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/functions/{functionId}/git-link</c>, but is otherwise the
    /// same as <see cref="IGitLinkService.Update(GitLinkUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GitLinkUpdateResponse>> Update(
        GitLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(GitLinkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<GitLinkUpdateResponse>> Update(
        string functionID,
        GitLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions/{functionId}/git-link/deploy</c>, but is otherwise the
    /// same as <see cref="IGitLinkService.DeployNow(GitLinkDeployNowParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GitLinkDeployNowResponse>> DeployNow(
        GitLinkDeployNowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeployNow(GitLinkDeployNowParams, CancellationToken)"/>
    Task<HttpResponse<GitLinkDeployNowResponse>> DeployNow(
        string functionID,
        GitLinkDeployNowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions/{functionId}/git-link</c>, but is otherwise the
    /// same as <see cref="IGitLinkService.Link(GitLinkLinkParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GitLinkLinkResponse>> Link(
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Link(GitLinkLinkParams, CancellationToken)"/>
    Task<HttpResponse<GitLinkLinkResponse>> Link(
        string functionID,
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/functions/{functionId}/git-link</c>, but is otherwise the
    /// same as <see cref="IGitLinkService.Unlink(GitLinkUnlinkParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unlink(
        GitLinkUnlinkParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unlink(GitLinkUnlinkParams, CancellationToken)"/>
    Task<HttpResponse> Unlink(
        string functionID,
        GitLinkUnlinkParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
