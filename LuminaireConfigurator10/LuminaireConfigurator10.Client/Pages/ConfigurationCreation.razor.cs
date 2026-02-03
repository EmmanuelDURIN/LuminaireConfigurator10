using LuminaireConfigurator10.Client.ViewModel;
using Microsoft.AspNetCore.Components.Forms;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class ConfigurationCreation
    {
        private ValidationMessageStore messageStore;
        public LuminaireConfiguration Configuration { get; set; } = new();
        public EditContext EditContext { get; set; }
        public bool IsModified => EditContext.IsModified();
        public ConfigurationCreation()
        {
            EditContext = new(Configuration);
            EditContext.OnValidationRequested += HandleValidationRequested;
            EditContext.OnFieldChanged += EditContextFieldChanged;
            messageStore = new(EditContext);
        }
        private void EditContextFieldChanged(object? sender, FieldChangedEventArgs e)
        {
        }
        private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
        {
            messageStore.Clear();
            //if (Custom validation logic not satisfied)
            //{
            //  messageStore?.Add(() => Configuration.Optic, "Error on Optic");
            //  messageStore?.Add(() => Configuration, "Global error on Configuration.");
            //}
        }
        public void Create()
        {
            Console.WriteLine("configuration created");
        }
        public int?[] LampColors { get; set; } = [null, 2200, 2700, 3000, 4000, 5700];
        public string?[] Optics { get; set; } = [null, "ON10", "ON11", "OL10", "OL11", "OM10", "OM11"];
    }
}
