using System.Net.Http;

namespace Zavudev.Exceptions;

public class Zavudev5xxException : ZavudevApiException
{
    public Zavudev5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
