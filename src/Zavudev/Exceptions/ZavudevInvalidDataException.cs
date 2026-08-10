using System;

namespace Zavudev.Exceptions;

public class ZavudevInvalidDataException : ZavudevException
{
    public ZavudevInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
