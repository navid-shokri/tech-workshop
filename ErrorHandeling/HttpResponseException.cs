using System.Net;

namespace ErrorHandeling;

public class HttpResponseException : Exception
{
    public HttpResponseException(int code, string message)
    {
        (Code, Message) = (code, message);
    }

    public int Code { get; private set; }
    public string Message { get; private set; }
}