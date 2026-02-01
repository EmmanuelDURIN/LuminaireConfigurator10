using LuminaireConfigurator10.Client.ViewModel;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class CustomSelect
    {
        [Parameter]
        public IEnumerable<string> Items { get; set; } = Enumerable.Empty<string>();
    }
}
