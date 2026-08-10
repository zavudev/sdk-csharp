using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevUnprocessableEntityException : Zavudev4xxException
{
    public ZavudevUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
