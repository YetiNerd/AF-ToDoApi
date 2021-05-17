using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Todo;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
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
        [ApiExplorerSettings(GroupName = "todo")]
        [ProducesResponseType(typeof(IEnumerable<GetTodoItemsQuery>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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