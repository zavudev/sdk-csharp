using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevUnauthorizedException : Zavudev4xxException
{
    public ZavudevUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
