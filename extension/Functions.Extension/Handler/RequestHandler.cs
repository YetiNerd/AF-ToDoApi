using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Functions.Extension.Attributes;
using Microsoft.AspNetCore.Http;

namespace Functions.Extension.Handler
{
    public static partial class HttpHandler
    {
        public static async Task<TCommand> ConvertRequestToCommand<TCommand>(this HttpRequest req,
            JsonSerializerOptions jsonSerializerOptions = null)
        {
            if (jsonSerializerOptions == null)
            {
                jsonSerializerOptions = JsonOptions;
            }

            var body = await new StreamReader(req.Body).ReadToEndAsync();

            if (string.IsNullOrEmpty(body))
            {
                body = "{}";
            }

            var command = JsonSerializer.Deserialize<TCommand>(body, jsonSerializerOptions);

            if (command != null)
            {
                var properties = command.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(false);

                    var propertyType = property.PropertyType;

                    // Assign Headers if they exist in Request
                    var headerMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(RequestHeader));

                    if (headerMapping != null)
                    {
                        var requestHeaderName = headerMapping as RequestHeader;

                        var hasHeaderKey =
                            req.Headers.TryGetValue(
                                requestHeaderName?.GetName(),
                                out var requestHeaderValues);

                        if (hasHeaderKey)
                        {
                            var headerValue = requestHeaderValues.FirstOrDefault();

                            var castedHeaderValue = Convert.ChangeType(headerValue, propertyType);

                            command.GetType().GetProperty(property.Name)?.SetValue(command, castedHeaderValue);
                            continue;
                        }
                    }

                    // Assign Query-Parameter if they exist in Request
                    var queryMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(RequestQuery));

                    if (queryMapping != null)
                    {
                        var requestQueryName = queryMapping as RequestQuery;
                        var hasQueryKey =
                            req.Query.TryGetValue(
                                requestQueryName?.GetName(),
                                out var requestQueryValues);

                        if (hasQueryKey)
                        {
                            var queryValue = requestQueryValues.FirstOrDefault();

                            var castedQueryValue = Convert.ChangeType(queryValue, propertyType);

                            command.GetType().GetProperty(property.Name)?.SetValue(command, castedQueryValue);
                        }
                    }
                }
            }

            return command;
        }

        public static TCommand AddPathParamToCommand<TCommand, TPathParam>(this TCommand command, string pathParamName, TPathParam pathParamValue)
        {
            var properties = command.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);

                var pathMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(RequestPathParam));

                if (pathMapping != null)
                {
                    var pathRequestName = pathMapping as RequestPathParam;

                    if (string.Equals(pathParamName, pathRequestName?.GetName()))
                    {
                        command.GetType().GetProperty(property.Name)?.SetValue(command, pathParamValue);
                    }
                }
            }

            return command;
        }
    }
}