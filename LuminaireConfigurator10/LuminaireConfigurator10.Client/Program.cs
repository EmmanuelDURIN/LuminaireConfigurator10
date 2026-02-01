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
            await builder.Build().RunAsync();
        }
    }
}
