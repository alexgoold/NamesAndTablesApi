namespace NamesAndTablesApi.Exceptions;

public class FailedDependencyException : Exception
{
    public FailedDependencyException(string message) : base(message)
    {
    }
}