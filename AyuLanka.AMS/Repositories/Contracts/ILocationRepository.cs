using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface ILocationRepository
    {
        Task<Location> GetLocationByLocationIdAsync(int locationId);
        Task<IEnumerable<Location>> GetAllLocationAsync();
        Task<IEnumerable<Location>> GetPrimeCareLocationAsync();
        Task<IEnumerable<Location>> GetEliteCareLocationAsync();
        Task<Location> GetTreatmentLocationByNameAsync(string locationName);
    }
}
