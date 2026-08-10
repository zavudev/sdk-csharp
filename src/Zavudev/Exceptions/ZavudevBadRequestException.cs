using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevBadRequestException : Zavudev4xxException
{
    public ZavudevBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
