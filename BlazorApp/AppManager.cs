
using BlazorApp.Data;
using BlazorApp.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace BlazorApp
{
    internal static class AppManager
    {
        public static IConfigurationSection ConfigurationSection { get; private set; } = null;


        public static void Setup(WebApplicationBuilder builder)
        {
          

            //IConfiguration config = builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();

            //var a = config.GetValue<ArticleSettings>("ArticleSettings");

            //ConfigurationSection = builder.Configuration.GetSection("ArticleSettings");
            //builder.Services.Configure<ArticleSettings>(ConfigurationSection);
        }

    }
}