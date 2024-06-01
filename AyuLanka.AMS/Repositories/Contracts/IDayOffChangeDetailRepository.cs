using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IDayOffChangeDetailRepository
    {
        Task<IEnumerable<DayOffChangeDetail>> GetAllDayOffChangeDetailsAsync();
        Task<DayOffChangeDetail> GetDayOffChangeDetailByDatePreAndRosterAsync(DateTime dayOffPre, int staffRosterId);
        Task<DayOffChangeDetail> GetDayOffChangeDetailByIdAsync(int Id);
        Task<DayOffChangeDetail> CreateDayOffChangeDetailAsync(DayOffChangeDetail dayOffChangeDetail);
        Task<DayOffChangeDetail> UpdateDayOffChangeDetailAsync(DayOffChangeDetail dayOffChangeDetail);
    }
}
