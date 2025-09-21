using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationAsync();
        Task<IEnumerable<Location>> GetPrimeCareLocationAsync();
        Task<IEnumerable<Location>> GetEliteCareLocationAsync();
    }
}
