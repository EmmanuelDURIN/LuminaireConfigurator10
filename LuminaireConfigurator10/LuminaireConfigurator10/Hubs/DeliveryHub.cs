using LuminaireConfigurator10.Client.Model;
using Microsoft.AspNetCore.SignalR;
using WebApiWeatherForeCast.Controllers;

public class DeliveryHub : Hub<IDeliveryCenterNotification>
{
    public List<LuminaireConfiguration> GetDeliveries()
        => LuminaireConfigurationController.LuminaireConfigurations;
    public void ConfigurationDelivered(LuminaireConfiguration configuration)
    {
        LuminaireConfigurationController.LuminaireConfigurations.Remove(configuration);

        Console.WriteLine("Call made on server");
        // Add code to call OnConfigurationDelivered on client side
        // through SignalR, passing the LuminaireConfiguration
        Clients.All.OnConfigurationDelivered(configuration);
    }
}
