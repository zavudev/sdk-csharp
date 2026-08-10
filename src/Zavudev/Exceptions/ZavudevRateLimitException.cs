using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevRateLimitException : Zavudev4xxException
{
    public ZavudevRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
