using System;
using System.Net.Http;

namespace Zavudev.Exceptions;

public class ZavudevIOException : ZavudevException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public ZavudevIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
