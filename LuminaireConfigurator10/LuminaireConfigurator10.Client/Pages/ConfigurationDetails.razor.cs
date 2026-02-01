using LuminaireConfigurator10.Client.Model;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class ConfigurationDetails
    {
        [Parameter]
        public int Id { get; set; }
        public bool Loaded { get; set; }
        private LuminaireConfiguration? configuration;
        public LuminaireConfiguration? Configuration
        {
            get => configuration;
            set => configuration = value;
        }
        protected override async Task OnInitializedAsync()
        {
            LuminaireConfigurationService luminaireConfigurationService = new LuminaireConfigurationService();
            Configuration = await luminaireConfigurationService.GetLuminaireConfigurationById(Id);
            Loaded = true;
        }
    }
}
