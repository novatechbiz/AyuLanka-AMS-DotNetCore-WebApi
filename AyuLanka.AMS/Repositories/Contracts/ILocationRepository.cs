using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocationAsync();
        Task<IEnumerable<Location>> GetPrimeCareLocationAsync();
        Task<IEnumerable<Location>> GetEliteCareLocationAsync();
        Task<Location> GetPrimeCareLocationByNameAsync(string locationName);
    }
}
