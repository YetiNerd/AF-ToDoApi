using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Functions.Extension.ResponseHandler
{
    public class HttpResponse : ContentResult
    {
        public HttpResponse(int? statusCode, string contentType, string content, IDictionary<string, string> headers)
        {
            this.StatusCode = statusCode;
            this.ContentType = contentType;
            this.Content = content;
            this.Headers = headers;
        }

        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        public override Task ExecuteResultAsync(ActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext));
            }

            foreach (var keyValuePair in this.Headers)
            {
                actionContext.HttpContext.Response.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return base.ExecuteResultAsync(actionContext);
        }
    }
}
