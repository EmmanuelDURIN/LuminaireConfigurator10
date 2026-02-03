using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace LuminaireConfigurator10.Client.Components
{
    public partial class CustomSelect<TItem, TValue, TDisplay>
                                      : ComponentBase
    {
        // EditContext is inherited from the EditForm
        [CascadingParameter]
        private EditContext? CascadedEditContext { get; set; }
        // Got it from SelectedExpression in SetParametersAsync
        protected internal FieldIdentifier FieldIdentifier { get; set; }
        // A standardly named property is also in the convention
        // for easy to use databinding
        [Parameter, EditorRequired]
        public TItem? Selected
        {
            get => field;
            set
            {
                if (field == null && value == null)
                    return;
                if (field?.Equals(value) != true)
                {
                    field = value;
                    SelectedChanged.InvokeAsync(value);
                    SelectedValue = value != null ? ValueSelector(value) : default;
                    // SelectedValueChanged.InvokeAsync(selectedValue);
                    if (CascadedEditContext != null)
                    {
                        CascadedEditContext.NotifyFieldChanged(FieldIdentifier);
                        CascadedEditContext.NotifyValidationStateChanged();
                    }
                }
            }
        }
        [Parameter]
        public EventCallback<TValue> SelectedValueChanged { get; set; }
        public TValue? SelectedValue
        {
            get => field;
            set
            {
                if (field == null && value == null)
                    return;
                if (field?.Equals(value) != true)
                {
                    field = value;
                    Selected = Items.FirstOrDefault(i => value?.Equals(ValueSelector(i)) == true);
                }
            }
        }
        [Parameter] public EventCallback<TItem> SelectedChanged { get; set; }
        // {PropertyName}Expression if the convention for adequate databinding of property
        // selectedExpression is useful later for getting the name of the property  in 
        // order to get the name of FieldIdentifier in SetParametersAsync
        [Parameter]
        public Expression<Func<TItem>>? SelectedExpression { get; set; }
        [Parameter, EditorRequired]
        public Func<TItem, TDisplay> DisplaySelector { get; set; } = null!;
        [Parameter, EditorRequired]
        public IEnumerable<TItem> Items { get; set; } = Enumerable.Empty<TItem>();
        [Parameter, EditorRequired]
        public Func<TItem, TValue> ValueSelector { get; set; } = null!;
        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            if (SelectedExpression != null)
                FieldIdentifier = FieldIdentifier.Create(SelectedExpression);
            if (CascadedEditContext != null)
                CascadedEditContext.OnValidationStateChanged += OnValidateStateChanged;
            return base.SetParametersAsync(ParameterView.Empty);
        }
        private void OnValidateStateChanged(object? sender, ValidationStateChangedEventArgs eventArgs)
        {
            StateHasChanged();
        }
    }
}
