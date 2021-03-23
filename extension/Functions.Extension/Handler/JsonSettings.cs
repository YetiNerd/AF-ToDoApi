using System.Text.Encodings.Web;
using System.Text.Json;

namespace Functions.Extension.Handler
{
    public static partial class HttpHandler
    {
        private static JsonSerializerOptions JsonOptions => new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
}
