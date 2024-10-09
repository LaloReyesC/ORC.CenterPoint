namespace ORC.CenterPoint.API.Core.Exceptions;

public class NotFoundException(string message)
    : Exception(message)
{ }