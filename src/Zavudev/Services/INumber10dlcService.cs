using System;
using Zavudev.Core;
using Zavudev.Services.Number10dlc;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INumber10dlcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumber10dlcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumber10dlcService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBrandService Brands { get; }

    ICampaignService Campaigns { get; }
}

/// <summary>
/// A view of <see cref="INumber10dlcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumber10dlcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumber10dlcServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBrandServiceWithRawResponse Brands { get; }

    ICampaignServiceWithRawResponse Campaigns { get; }
}
