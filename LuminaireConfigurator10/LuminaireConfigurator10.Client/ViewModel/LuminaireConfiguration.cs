using System.ComponentModel.DataAnnotations;
using LuminaireConfigurator10.Client.Model;

namespace LuminaireConfigurator10.Client.ViewModel
{
    public class LuminaireConfiguration
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(1,1E10)]
        public double LampFlux { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Optic? Optic { get; set; }
        [Required]
        [Range(1,1E6)]
        public int? LampColor { get; set; }
    }
}
