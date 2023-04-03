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
    public static class UpdateTodoItemCommandFunction
    {
        [FunctionName("UpdateTodoItemCommandFunction")]
        [OpenApiOperation(operationId: "todo", tags: new[] { "todo" }, Summary = "UpdateTodoItem", Description = "Update an existing ToDo-Item", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "application/json", typeof(UpdateTodoItemCommand))]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(Guid))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(TodoItem), Description = nameof(HttpStatusCode.OK))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Description = nameof(HttpStatusCode.NotFound))]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Unauthorized, Description = nameof(HttpStatusCode.Unauthorized))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "Todo/{id:guid}")] HttpRequest req,
            ILogger log, Guid id)
        {
            Task<IActionResult> result = null;

            try
            {
                var command = (await req.ConvertRequestToCommand<UpdateTodoItemCommand>())
                    .AddPathParamToCommand(nameof(id), id);

                // Access Database
                // todo

                result = req.CreateHttpResponse()
                    .AddHeaderEntry("MyHeader", "MyKey")
                    .Send(command);
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