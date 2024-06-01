using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IDayOffChangeMasterRepository
    {
        Task<IEnumerable<DayOffChangeMaster>> GetAllDayOffChangeMastersAsync();
        Task<DayOffChangeMaster> GetDayOffChangeMasterByIdAsync(int id);
        Task<DayOffChangeMaster> AddDayOffChangeMasterAsync(DayOffChangeMaster dayOffChangeMaster);
        Task<DayOffChangeMaster> UpdateDayOffChangeMasterAsync(DayOffChangeMaster dayOffChangeMaster);
        Task DeleteDayOffChangeMasterAsync(int id);
    }
}
