using LuminaireConfigurator10.Client.Model;
using LuminaireConfigurator10.Client.Services;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class ConfigurationList ( ILuminaireConfigurationService luminaireConfigurationService )
    {
        private List<LuminaireConfiguration>? luminaireConfigurations = null;
        public List<LuminaireConfiguration>? LuminaireConfigurations
        {
            get => luminaireConfigurations;
            set => luminaireConfigurations = value;
        }
        protected override async Task OnInitializedAsync()
        {
           luminaireConfigurations = await luminaireConfigurationService.GetLuminaireConfigurations();
        }
    }
}