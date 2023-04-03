using Application.Todo;
using Domain;
using Functions.Extension.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Functions.Todo
{
    public static class GetTodoItemsQueryFunction
    {
        [FunctionName("GetTodoItemsQueryFunction")]
        [OpenApiOperation(operationId: "todo", tags: new[] { "todo" }, Summary = "GetTodoItems", Description = "Get ToDo-Items", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "x-sampleHeader", In = ParameterLocation.Header, Required = true, Type = typeof(string))]
        [OpenApiParameter(name: "isStarted", In = ParameterLocation.Query, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<TodoItem>), Description = nameof(HttpStatusCode.OK))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Description = nameof(HttpStatusCode.NotFound))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Unauthorized, Description = nameof(HttpStatusCode.Unauthorized))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo")] HttpRequest req, ILogger log)
        {
            Task<IActionResult> result = null;

            try
            {
                var query = await req.ConvertRequestToCommand<GetTodoItemsQuery>();

                // Access Database and Delete
                // todo

                result = req.CreateHttpResponse()
                    .AddHeaderEntry("MyHeader", "MyKey")
                    .Send(query);
            }
            catch (Exception ex)
            {
                result = req.CreateHttpResponse()
                    .SendFromException(ex);
            }
            return await result;
        }
    }
}