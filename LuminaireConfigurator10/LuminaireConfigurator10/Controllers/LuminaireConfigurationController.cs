using LuminaireConfigurator10.Client.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWeatherForeCast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LuminaireConfigurationController
     : ControllerBase
    {
        private List<LuminaireConfiguration> luminaireConfigurations = new List<LuminaireConfiguration>()
            {
              new LuminaireConfiguration
              {
                Id=1,
                CreationTime = new DateTime(2020,11,8),
                LampColor = 5400,
                LampFlux = 2000,
                Optic = "OM10",
                Name="Luminaires Nanterre"
              },
              new LuminaireConfiguration
              {
                Id=2,
                CreationTime = new DateTime(2020,12,9),
                LampColor = 5700,
                LampFlux = 3000,
                Optic = "OM11",
                Name="Luminaires Courbevoie"
              },
              new LuminaireConfiguration
              {
                Id=3,
                CreationTime = new DateTime(2021,1,4),
                LampColor = 5700,
                LampFlux = 10000,
                Optic = "OM12",
                Name="Luminaires Puteaux"
              },
            };
        [HttpGet]
        public List<LuminaireConfiguration> GetAll()
            => luminaireConfigurations;
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            LuminaireConfiguration? lumConf = luminaireConfigurations
                                               .FirstOrDefault(l => l.Id == id);
            if (lumConf == null)
                return NotFound("No Luminaire with id=" + id);
            return Ok(lumConf);
        }
    }
}
