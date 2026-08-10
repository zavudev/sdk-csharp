using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevForbiddenException : Zavudev4xxException
{
    public ZavudevForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
