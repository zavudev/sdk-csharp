using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevNotFoundException : Zavudev4xxException
{
    public ZavudevNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
