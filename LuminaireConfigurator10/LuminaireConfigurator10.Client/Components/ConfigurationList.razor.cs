using LuminaireConfigurator10.Client.Model;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class ConfigurationList(ILuminaireConfigurationService luminaireConfigurationService)
    {
        private List<LuminaireConfiguration>? luminaireConfigurations = null;
        public List<LuminaireConfiguration>? LuminaireConfigurations
        {
            get => luminaireConfigurations;
            set => luminaireConfigurations = value;
        }
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
        public EventCallback<LuminaireConfiguration?> SelectedConfigurationChanged
        { get; set; }

        protected override async Task OnInitializedAsync()
        {
            luminaireConfigurations = await luminaireConfigurationService.GetLuminaireConfigurations();
        }
    }
}