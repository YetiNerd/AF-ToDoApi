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
    public static class GetTodoItemsQueryFunction
    {
        [FunctionName("GetTodoItemsQueryFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo")] HttpRequest req, ILogger log)
        {
            var query = await req.ConvertRequestToCommand<GetTodoItemsQuery>();

            // Access Database and Delete
            // todo

            return new OkObjectResult(query);
        }
    }
}