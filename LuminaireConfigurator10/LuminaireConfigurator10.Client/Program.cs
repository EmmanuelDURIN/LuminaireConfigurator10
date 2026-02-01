using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LuminaireConfigurator10.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddTransient<ILuminaireConfigurationService, LuminaireConfigurationService>();
            builder.Services.AddScoped(http => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });
            await builder.Build().RunAsync();
        }
    }
}
