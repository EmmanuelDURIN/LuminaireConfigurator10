using LuminaireConfigurator10.Client.Model;
using System.Net.Http.Json;

namespace LuminaireConfigurator10.Client.Services
{
  public class LuminaireConfigurationService(HttpClient httpClient) 
    : ILuminaireConfigurationService
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
    public async Task<(LuminaireConfiguration[] Configurations, int TotalConfigurations)>
       GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken)
    {
      await Task.Delay(1000);
      return await GetRange(startIndex, count, cancellationToken);
    }
    public async Task<(LuminaireConfiguration[] Configurations, int TotalConfigurations)>
        GetRange(int startIndex, int count, CancellationToken cancellationToken)
    {
      int totalConfigurations = await httpClient.GetFromJsonAsync<int>("api/LuminaireConfiguration/count");
      var numConfigurations = Math.Min(count, totalConfigurations - startIndex);
      LuminaireConfiguration[] luminaireConfigurations = [];
      try
      {
        luminaireConfigurations = await httpClient.GetFromJsonAsync<LuminaireConfiguration[]>
              (
              $"api/LuminaireConfiguration/range?startIndex={startIndex}&numConfigurations={numConfigurations}"
              , cancellationToken
              )
          ?? new LuminaireConfiguration[0];
      }
      catch (TaskCanceledException)
      {
        Console.WriteLine("Task cancelled");
      }
      catch (OperationCanceledException)
      {
        Console.WriteLine("Operation cancelled");
      }
      Console.WriteLine($"returning from {startIndex} to {startIndex + numConfigurations}");
      return (luminaireConfigurations, totalConfigurations);
    }
  }
}
