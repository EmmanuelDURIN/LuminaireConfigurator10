using LuminaireConfigurator10.Client.Model;

namespace LuminaireConfigurator10.Client.Services
{
  public class OpticService
  {
    private List<Optic> optics = new List<Optic>()
            {
              new Optic(Id:1, Name:"OM10"),
              new Optic(Id:2, Name:"OM11"),
              new Optic(Id:3, Name:"ON11"),
              new Optic(Id:4, Name:"OL10"),
              new Optic(Id:5, Name:"OL11"),
            };
    public async Task<List<Optic>> GetOptics()
    {
      await Task.Delay(300);
      return optics;
    }
  }
}
