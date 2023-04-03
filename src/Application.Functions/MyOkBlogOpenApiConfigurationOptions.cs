using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;

namespace Application.Functions
{
    public class MyOkBlogOpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = GetOpenApiDocVersion(),
            Title = "OKBlog ToDo-Functions",
            Description = "Das ist eine Beschreibung für meine OKBlog ToDo-Function-App",
            TermsOfService = new Uri("https://blog.objektkultur.de"),
            Contact = new OpenApiContact()
            {
                Name = "Objektkultur",
                Email = "kontakt@objektkultur.de",
                Url = new Uri("https://objektkultur.de"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = GetOpenApiVersion();
    }
}
