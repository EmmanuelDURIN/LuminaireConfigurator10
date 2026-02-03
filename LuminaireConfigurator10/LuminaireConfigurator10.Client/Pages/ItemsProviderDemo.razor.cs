using LuminaireConfigurator10.Client.Model;
using LuminaireConfigurator10.Client.Services;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace LuminaireConfigurator10.Client.Pages
{
  public partial class ItemsProviderDemo(ILuminaireConfigurationService luminaireConfigurationService)
  {
    private async ValueTask<ItemsProviderResult<LuminaireConfiguration>> LoadConfigurations(
      ItemsProviderRequest request)
    {
      (var configurations, var totalConfigurations) = await luminaireConfigurationService.GetRange(request.StartIndex,
                                             request.Count,
                                             request.CancellationToken);
      return new ItemsProviderResult<LuminaireConfiguration>(configurations, totalConfigurations);
    }
  }
}
