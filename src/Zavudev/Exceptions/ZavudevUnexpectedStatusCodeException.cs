using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevUnexpectedStatusCodeException : ZavudevApiException
{
    public ZavudevUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
