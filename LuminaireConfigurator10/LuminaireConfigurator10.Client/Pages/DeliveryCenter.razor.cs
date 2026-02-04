using LuminaireConfigurator10.Client.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class DeliveryCenter(NavigationManager navigationManager)
    {
        public List<LuminaireConfiguration>? LuminaireConfigurations { get; set; }
        [Parameter]
        public LuminaireConfiguration? SelectedConfiguration
        {
            get { return field; }
            set
            {
                if (field != value)
                {
                    field = value;
                    SelectedConfigurationChanged.InvokeAsync(value);
                }
            }
        }
        [Parameter]
        public EventCallback<LuminaireConfiguration?> SelectedConfigurationChanged { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ConnectToHub();
        }
        protected async Task Deliver()
        {
            await hubConnection?.InvokeAsync("ConfigurationDelivered", SelectedConfiguration);
        }
        private HubConnection? hubConnection = null;
        private async Task ConnectToHub()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/deliveryhub"))
                .Build();
            hubConnection.On<LuminaireConfiguration>(nameof(IDeliveryCenterNotification.OnConfigurationDelivered),
              (lumConf) =>
              {
                  Console.WriteLine("Client got delivery removed");
                  LuminaireConfigurations?.Remove(lumConf);
                  InvokeAsync(() => StateHasChanged());
              });
            await hubConnection.StartAsync();
            LuminaireConfigurations = await hubConnection.InvokeAsync<List<LuminaireConfiguration>>("GetDeliveries");
        }
    }
}