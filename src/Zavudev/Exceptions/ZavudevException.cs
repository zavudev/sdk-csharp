using System;
using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevException : Exception
{
    public ZavudevException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected ZavudevException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
