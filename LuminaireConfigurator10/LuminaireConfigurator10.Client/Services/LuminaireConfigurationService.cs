using LuminaireConfigurator10.Client.Model;
using System.Net.Http.Json;

namespace LuminaireConfigurator10.Client.Services
{
  public class LuminaireConfigurationService(HttpClient httpClient) : ILuminaireConfigurationService
  {
    public async Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id)
    {
      // await Task.Delay(500);
      return await httpClient.GetFromJsonAsync<LuminaireConfiguration>(requestUri: $"api/luminaireconfiguration/{id}", CancellationToken.None);
    }
    public async Task<List<LuminaireConfiguration>?> GetLuminaireConfigurations()
    {
      // await Task.Delay(500);
      List<LuminaireConfiguration>? luminaireConfigurations = await httpClient.GetFromJsonAsync<List<LuminaireConfiguration>>(requestUri: $"api/luminaireconfiguration", CancellationToken.None);
      return luminaireConfigurations;
    }
    public async Task<LuminaireConfiguration?> PostAsync(LuminaireConfiguration? luminaireConfiguration)
    {
      HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("api/luminaireconfiguration", luminaireConfiguration);
      httpResponseMessage.EnsureSuccessStatusCode();
      if (httpResponseMessage.IsSuccessStatusCode)
      {
        LuminaireConfiguration? createdLuminaireConfiguration = await httpResponseMessage.Content.ReadFromJsonAsync<LuminaireConfiguration>();
        return createdLuminaireConfiguration;
      }
      return null;
    }
  }
}
