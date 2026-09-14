using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Introspect;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIntrospectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIntrospectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrospectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Heuristic email validation to run before sending: catches invalid syntax, dead
    /// domains (no MX/A records), disposable inboxes, role-based addresses (info@,
    /// contacto@, sales@), and addresses already on your project's suppression list.
    /// Use it to clean a list before a broadcast and keep your bounce rate low.
    ///
    /// <para>No mailbox-level (SMTP) probe is performed, so a `deliverable` verdict is
    /// not a delivery guarantee — it means no negative signal was found. Treat `risky`
    /// addresses with care and drop `undeliverable` ones.</para>
    ///
    /// <para>Accepts a single `email` or an `emails` batch (max 100 per request).</para>
    /// </summary>
    Task<IntrospectValidateEmailResponse> ValidateEmail(
        IntrospectValidateEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validate a phone number and check if a WhatsApp conversation window is open.
    /// </summary>
    Task<IntrospectValidatePhoneResponse> ValidatePhone(
        IntrospectValidatePhoneParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIntrospectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIntrospectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIntrospectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/introspect/email</c>, but is otherwise the
    /// same as <see cref="IIntrospectService.ValidateEmail(IntrospectValidateEmailParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrospectValidateEmailResponse>> ValidateEmail(
        IntrospectValidateEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/introspect/phone</c>, but is otherwise the
    /// same as <see cref="IIntrospectService.ValidatePhone(IntrospectValidatePhoneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IntrospectValidatePhoneResponse>> ValidatePhone(
        IntrospectValidatePhoneParams parameters,
        CancellationToken cancellationToken = default
    );
}
