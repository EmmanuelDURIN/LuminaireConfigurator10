using Microsoft.AspNetCore.Components;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class CustomSelect<TItem, TValue, TDisplay>
    {
        [Parameter]
        public int Size { get; set; } = 1;

        [Parameter]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter, EditorRequired]
        public Func<TItem, TValue> ValueSelector { get; set; } = null!;

        [Parameter, EditorRequired]
        public Func<TItem, TDisplay> DisplaySelector { get; set; } = null!;

        [Parameter, EditorRequired]
        public TItem? Selected { get; set; }

        private async Task OnSelectedChanged(ChangeEventArgs e)
        {
            Selected = Items.FirstOrDefault(i => ValueSelector(i)?.ToString()?.Equals(e.Value?.ToString()) == true);
            await SelectedChanged.InvokeAsync(Selected);
        }

        [Parameter]
        public EventCallback<TItem> SelectedChanged { get; set; }

        private TValue? selectedValue { get; set; }
        public TValue? SelectedValue
        {
            get => selectedValue;
            set
            {
                selectedValue = value;
                Selected = Items.FirstOrDefault(i => ValueSelector(i)?.ToString()?.Equals(value?.ToString()) == true);
                SelectedChanged.InvokeAsync(Selected);
            }
        }
    }
}
