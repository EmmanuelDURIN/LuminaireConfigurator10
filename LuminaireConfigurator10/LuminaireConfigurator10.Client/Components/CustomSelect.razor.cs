using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class CustomSelect<TItem>
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
    }
}
