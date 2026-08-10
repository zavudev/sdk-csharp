using System.Net.Http;

namespace Zavudev.Exceptions;

public class Zavudev4xxException : ZavudevApiException
{
    public Zavudev4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
