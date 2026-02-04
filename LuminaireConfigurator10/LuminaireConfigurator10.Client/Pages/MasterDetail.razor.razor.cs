using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components.Forms;
using LuminaireConfigurator10.Client.Model;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class MasterDetail
    {

        [Parameter]
        public LuminaireConfiguration? SelectedConfiguration
        {
            get;
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
    }
}
