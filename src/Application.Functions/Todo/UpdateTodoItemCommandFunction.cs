using System;
using System.Threading.Tasks;
using Application.Todo;
using Functions.Extension.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Application.Functions.Todo
{
    public static class UpdateTodoItemCommandFunction
    {
        [FunctionName("UpdateTodoItemCommandFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "Todo/{id:guid}")] HttpRequest req, ILogger log, Guid id)
        {
            var command = await req.ConvertRequestToCommand<UpdateTodoItemCommand>();
            command.AddPathParamToCommand(nameof(id), id);

            // Access Database
            // todo

            return new OkObjectResult(command);
        }
    }
}