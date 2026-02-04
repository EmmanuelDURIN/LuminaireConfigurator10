using LuminaireConfigurator10.Client.Model;

public interface IDeliveryCenterNotification
{
  Task OnConfigurationDelivered(LuminaireConfiguration configuration);
}
