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
    public static class FindTodoItemByIdQueryFunction
    {
        [FunctionName("FindTodoItemByIdQueryFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo/{id:guid}")] HttpRequest req, ILogger log, Guid id)
        {
            var query = await req.ConvertRequestToCommand<FindTodoItemByIdQuery>();
            query.AddPathParamToCommand(nameof(id), id);

            // Access Database and Delete
            // todo

            return new OkObjectResult(query);
        }
    }
}