using System.Net.Http;

namespace apiClientDotNet.Clients
{
    public class SymClientResponse<T>
    {
        public T ParsedObject { get; private set; }
        public HttpResponseMessage HttpResponse { get; private set; }

        public SymClientResponse (T parsedObject, HttpResponseMessage response)
        {
            ParsedObject = parsedObject;
            HttpResponse = response;
        }
    }
}