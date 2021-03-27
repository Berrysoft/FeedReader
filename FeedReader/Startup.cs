using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace FeedReader
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
