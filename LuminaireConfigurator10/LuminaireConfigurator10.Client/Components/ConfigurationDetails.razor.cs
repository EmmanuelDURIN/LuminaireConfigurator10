using LuminaireConfigurator10.Client.Model;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class ConfigurationDetails(ILuminaireConfigurationService luminaireConfigurationService)
    {
        [Parameter]
        public int Id { get; set; }
        private LuminaireConfiguration? configuration;
        [Parameter]
        public LuminaireConfiguration? Configuration
        {
            get => configuration;
            set => configuration = value;
        }
    }
}
