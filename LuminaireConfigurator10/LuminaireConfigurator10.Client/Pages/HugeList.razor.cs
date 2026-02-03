using LuminaireConfigurator10.Client.Model;

namespace LuminaireConfigurator10.Client.Pages
{
  public partial class HugeList
  {
    private LuminaireConfiguration[]? luminaireConfigurations;
    public LuminaireConfiguration[]? LuminaireConfigurations
    {
      get => luminaireConfigurations;
      set => luminaireConfigurations = value;
    }
    protected override Task OnInitializedAsync()
    {
      Console.WriteLine("Before Enumerable.Range");
      LuminaireConfigurations = Enumerable.Range(1, 50_000)
                                          .Select(
                                            i => new LuminaireConfiguration
                                            {
                                              Id = i,
                                              Name = "Luminaire" + i,
                                              CreationTime = DateTime.Now,
                                              LampColor = 3000 + (i % 2000),
                                              Optic = "OM" + (i % 10),
                                              LampFlux = 1000,
                                            })
                                          .ToArray();
      Console.WriteLine("After Enumerable.Range");

      return Task.FromResult(0);
    }
  }
}
