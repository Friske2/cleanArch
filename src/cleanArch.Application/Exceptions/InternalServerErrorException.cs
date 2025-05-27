using System;

namespace cleanArch.Application.Exceptions;

public class InternalServerErrorException : Exception
{
    public InternalServerErrorException(string message = "Unexpected server error")
       : base(message) { }
}
