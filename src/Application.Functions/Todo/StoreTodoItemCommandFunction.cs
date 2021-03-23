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
    public static class StoreTodoItemCommandFunction
    {
        [FunctionName("StoreTodoItemCommandFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "Todo")] HttpRequest req, ILogger log)
        {
            var command = await req.ConvertRequestToCommand<StoreTodoItemCommand>();

            // Access Database and Delete
            // todo

            return new OkObjectResult(command);
        }
    }
}