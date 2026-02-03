using LuminaireConfigurator10.Client.Model;

namespace LuminaireConfigurator10.Client.Services
{
    public interface ILuminaireConfigurationService
    {
        Task<LuminaireConfiguration?> GetLuminaireConfigurationById(int id);
        Task<List<LuminaireConfiguration>?> GetLuminaireConfigurations();
        Task<LuminaireConfiguration?> PostAsync(LuminaireConfigurator10.Client.Model.LuminaireConfiguration? lumConf);

        Task<(LuminaireConfiguration[] Configurations, int TotalConfigurations)>
            GetRangeWithDelay(int startIndex, int count, CancellationToken cancellationToken);
        Task<(LuminaireConfiguration[] Configurations, int TotalConfigurations)>
            GetRange(int startIndex, int count, CancellationToken cancellationToken);
    }
}
