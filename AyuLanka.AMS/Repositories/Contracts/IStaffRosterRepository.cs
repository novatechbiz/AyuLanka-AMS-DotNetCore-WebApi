using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IStaffRosterRepository
    {

        Task<IEnumerable<StaffRoster>> GetDayOffsByDateAsync(DateTime date);
        Task<IEnumerable<StaffRoster>> GetWorkingShiftsByDate(DateTime date);
        Task<IEnumerable<StaffRoster>> CreateStaffRostersAsync(IEnumerable<StaffRoster> rosters);
        Task DeleteStaffRostersByRosterMasterIdAsync(int rosterMasterId);
        Task<StaffRoster> GetRosterByIdAsync(int rosterId);
        Task<IEnumerable<StaffRoster>> GetRosterByRosterMasterIdAsync(int rosterMasterId);
        Task<IEnumerable<StaffRoster>> GetApprovedRosterDatesAsync(int employeeId, int rosterMasterId);
        Task<StaffRoster> GetEmployeeScheduleAsync(int employeeId, string scheduledate);
        Task UpdateStaffRosterAsync(StaffRoster staffRoster);
    }
}
