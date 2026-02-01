using LuminaireConfigurator10.Client.ViewModel;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class ConfigurationCreation
    {
        public LuminaireConfiguration Configuration { get; set; } = new();
        public void Create()
        {
            Console.WriteLine("configuration created");
        }
        public int[] LampColors { get; set; } = new int[]{2200,2700,3000,4000,5700};
        public string[] Optics { get; set; } = new string[]{"ON10","ON11","OL10","OL11","OM10","OM11"};
    }
}
