using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Addresses;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAddressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a regulatory address for phone number purchases. Some countries require a
    /// verified address before phone numbers can be activated.
    /// </summary>
    Task<AddressCreateResponse> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific regulatory address.
    /// </summary>
    Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<AddressRetrieveResponse> Retrieve(
        string addressID,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List regulatory addresses for this project.
    /// </summary>
    Task<AddressListPage> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a regulatory address. Cannot delete addresses that are in use.
    /// </summary>
    Task Delete(AddressDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AddressDeleteParams, CancellationToken)"/>
    Task Delete(
        string addressID,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAddressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAddressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAddressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/addresses</c>, but is otherwise the
    /// same as <see cref="IAddressService.Create(AddressCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddressCreateResponse>> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/addresses/{addressId}</c>, but is otherwise the
    /// same as <see cref="IAddressService.Retrieve(AddressRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AddressRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string addressID,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/addresses</c>, but is otherwise the
    /// same as <see cref="IAddressService.List(AddressListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddressListPage>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/addresses/{addressId}</c>, but is otherwise the
    /// same as <see cref="IAddressService.Delete(AddressDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AddressDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string addressID,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
