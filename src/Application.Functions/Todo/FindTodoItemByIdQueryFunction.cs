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
using System.Net;
using System.Threading.Tasks;

namespace Application.Functions.Todo
{
    public static class FindTodoItemByIdQueryFunction
    {
        [FunctionName("FindTodoItemByIdQueryFunction")]
        [OpenApiOperation(operationId: "todo", tags: new[] { "todo" }, Summary = "FindTodoItemById", Description = "Get specific ToDo-Item by ID", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(TodoItem), Description = nameof(HttpStatusCode.OK))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Description = nameof(HttpStatusCode.NotFound))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Unauthorized, Description = nameof(HttpStatusCode.Unauthorized))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo/{id:guid}")] HttpRequest req, ILogger log, Guid id)
        {
            Task<IActionResult> result = null;

            try
            {
                var query = (await req.ConvertRequestToCommand<FindTodoItemByIdQuery>())
                    .AddPathParamToCommand(nameof(id), id);

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