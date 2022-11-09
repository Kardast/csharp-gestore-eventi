// See https://aka.ms/new-console-template for more information
//creare classe eccezioni per il programma
public class GestoreEventiException : Exception
{
    public GestoreEventiException()
    {
    }

    public GestoreEventiException(string? message) : base(message)
    {
    }
}