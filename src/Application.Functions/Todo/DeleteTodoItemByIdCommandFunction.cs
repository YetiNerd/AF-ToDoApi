using System;
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
    public static class DeleteTodoItemByIdCommandFunction
    {
        [FunctionName("DeleteTodoItemByIdCommandFunction")]
        [ApiExplorerSettings(GroupName = "todo")]
        [ProducesResponseType(typeof(DeleteTodoItemByIdCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Todo/{id:guid}")] HttpRequest req, ILogger log, Guid id)
        {
            Task<IActionResult> result = null;

            try
            {
                var command = (await req.ConvertRequestToCommand<DeleteTodoItemByIdCommand>())
                    .AddPathParamToCommand(nameof(id), id);

                // Access Database and Delete
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