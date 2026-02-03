using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components.Forms;
using LuminaireConfigurator10.Client.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace LuminaireConfigurator10.Client.Pages
{
    public partial class ConfigurationCreation
    {
        private ValidationMessageStore messageStore;
        public ViewModel.LuminaireConfiguration Configuration { get; set; } = new();
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
        public List<Optic?> Optics { get; set; } = new List<Optic?>();
        [Required]
        public Optic? Optic { get; set; } = nullOptic;
        private static  Optic? nullOptic = new Optic(Id: 0, Name: "Please select one");
        protected async override Task OnInitializedAsync()
        {
            var opticService = new OpticService();
            Optics = new List<Optic?>{nullOptic}
                         .Concat((await opticService.GetOptics()))
                         .ToList();
            await base.OnInitializedAsync();
        }
    }
}
