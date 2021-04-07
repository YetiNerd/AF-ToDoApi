using System.Collections.Generic;

namespace Functions.Extension.ResponseHandler
{
    public class HttpResponseBuilder
    {
        public int? StatusCode { get; set; }

        public string ContentType { get; set; }

        public string Content { get; set; }

        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        public HttpResponse Build()
        {
            var contentResult = new HttpResponse(StatusCode, ContentType, Content, Headers);

            return contentResult;
        }

        public HttpResponseBuilder AddHeaderEntry(string headerKey, string headerValue)
        {
            if (!Headers.ContainsKey(headerKey))
            {
                Headers.Add(headerKey, headerValue);
            }
            else
            {
                Headers[headerKey] = headerValue;
            }

            return this;
        }
    }
}