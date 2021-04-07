using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Functions.Extension.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Functions.Extension.Handler
{
    public static partial class HttpHandler
    {
        private static readonly string DefaultContentTypeApplicationJson = "application/json";

        #region Response

        public static Task<IActionResult> Send<TResult>(this HttpResponseBuilder builder, TResult result)
        {
            var response = builder.Build();

            response.StatusCode = response.StatusCode ?? (int)HttpStatusCode.OK;
            response.ContentType = !string.IsNullOrEmpty(response.ContentType) ? response.ContentType : DefaultContentTypeApplicationJson;

            if (response.ContentType == DefaultContentTypeApplicationJson)
            {
                if (result != null)
                {
                    response.Content = JsonSerializer.Serialize(result, JsonOptions);
                }
            }
            else
            {
                response.Content = result.ToString();
            }

            return Task.FromResult((IActionResult)response);
        }

        public static Task<IActionResult> SendFromException(this HttpResponseBuilder builder, Exception ex)
        {
            var response = builder.Build();

            response.Content = JsonSerializer.Serialize(new { StatusCode = (int)HttpStatusCode.InternalServerError, Message = ex.Message }, JsonOptions);
            response.StatusCode = response.StatusCode ?? (int)HttpStatusCode.InternalServerError;
            response.ContentType = DefaultContentTypeApplicationJson;

            return Task.FromResult((IActionResult)response);
        }

        #endregion

        #region Builder

        public static HttpResponseBuilder CreateHttpResponse(this HttpRequest req)
        {
            var responseBuilder = new HttpResponseBuilder();

            return responseBuilder;
        }

        public static HttpResponseBuilder AddHeaderEntry(this HttpResponseBuilder builder, string headerKey, string headerValue)
        {
            builder.AddHeaderEntry(headerKey, headerValue);
            return builder;
        }

        public static HttpResponseBuilder SetStatusCode(this HttpResponseBuilder builder, HttpStatusCode httpStatusCode)
        {
            builder.StatusCode = (int)httpStatusCode;
            return builder;
        }

        public static HttpResponseBuilder SetContentType(this HttpResponseBuilder builder, string contentType)
        {
            builder.ContentType = contentType;
            return builder;
        }

        #endregion
    }
}