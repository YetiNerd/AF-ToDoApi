using System.Reflection;
using Application.Functions;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Application.Functions
{
    using AzureFunctions.Extensions.Swashbuckle.Settings;

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
            {
                opts.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "Swagger Application.Functions",
                        Description = "Description",
                        Version = "v1"
                    }
                };
                opts.Title = "Swagger Documentation for my Azure Functions";
            });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
            var context = builder.GetContext();
        }
    }
}