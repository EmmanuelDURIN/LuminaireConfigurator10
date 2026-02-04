using LuminaireConfigurator10.Client.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class DeliveryCenter
    {
        private HubConnection hubConnection;
        private readonly NavigationManager navigationManager;
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
        public DeliveryCenter(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
            hubConnection = GetHubConnection();
        }
        private HubConnection GetHubConnection()
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/deliveryhub"))
                .Build();
            hubConnection.On<LuminaireConfiguration>(nameof(IDeliveryCenterNotification.OnConfigurationDelivered),
              (lumConf) =>
              {
                  Console.WriteLine("Client got delivery removed");
                  LuminaireConfigurations?.Remove(lumConf);
                  InvokeAsync(() => StateHasChanged());
              });
            return hubConnection;
        }        
        protected override async Task OnInitializedAsync()
        {

Console.WriteLine( $"RendererInfo.Name : {RendererInfo.Name}");
Console.WriteLine($"OperatingSystem.IsBrowser() {OperatingSystem.IsBrowser()}");
            await hubConnection.StartAsync();
        }
        protected async Task Deliver()
        {
            await hubConnection.InvokeAsync("ConfigurationDelivered", SelectedConfiguration, CancellationToken.None);
        }
    }
}