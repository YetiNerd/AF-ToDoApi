namespace Application.Functions
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using AzureFunctions.Extensions.Swashbuckle;
    using AzureFunctions.Extensions.Swashbuckle.Attribute;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;

    public static class SwaggerController
    {
        [SwaggerIgnore]
        [FunctionName("OpenApiJson")]
        public static Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/json")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerDocumentResponse(req));
        }

        [SwaggerIgnore]
        [FunctionName("OpenApiUi")]
        public static Task<HttpResponseMessage> Run2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/ui")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
        }
    }
}