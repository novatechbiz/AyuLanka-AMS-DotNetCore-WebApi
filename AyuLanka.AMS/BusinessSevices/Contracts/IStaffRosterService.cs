using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface IStaffRosterService
    {
        Task<List<StaffRosterMaster>> GetRosterDateRangesAsync();
        Task<IEnumerable<StaffRoster>> GetApprovedRosterDatesAsync(int employeeId, int rosterMasterId);
        Task<StaffRoster> GetEmployeeScheduleAsync(int employeeId, string scheduledate);
        Task<StaffRosterMaster> SaveRoster(StaffRosterRequestModel staffRosterRequestModel);
        Task<IEnumerable<StaffRoster>> GetRosterByRosterMasterIdAsync(int rosterMasterId);
        Task<StaffRosterMaster> UpdateRoster(int rosterId, StaffRosterRequestModel staffRosterRequestModel);
    }
}
