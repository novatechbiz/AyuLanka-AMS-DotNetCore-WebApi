using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AyuLanka.AMS.Repositories
{
    public class StaffRosterRepository : IStaffRosterRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRosterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaffRoster>> CreateStaffRostersAsync(IEnumerable<StaffRoster> rosters)
        {
            _context.StaffRosters.AddRange(rosters);
            await _context.SaveChangesAsync();
            return rosters;
        }

        public async Task<IEnumerable<StaffRoster>> GetRosterByRosterMasterIdAsync(int rosterMasterId)
        {
            return await _context.StaffRosters
                                 .Include(r => r.Employee)
                                 .Include(r => r.ShiftMaster)
                                 .Include(r => r.StaffRosterMaster)
                                 .Where(r => r.RosterMasterId == rosterMasterId).ToListAsync();
        }

        public async Task<IEnumerable<StaffRoster>> GetApprovedRosterDatesAsync(int employeeId, int rosterMasterId)
        {
            return await _context.StaffRosters
                                 .Include(r => r.Employee)
                                 .Include(r => r.ShiftMaster)
                                 .Include(r => r.StaffRosterMaster)
                                 .Where(r => r.StaffRosterMaster.IsApproved == true
                                 && r.RosterMasterId == rosterMasterId
                                 && r.EmployeeId == employeeId).ToListAsync();
        }
        
        public async Task<StaffRoster> GetEmployeeScheduleAsync(int employeeId, string scheduledate)
        {
            var format = "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz '(India Standard Time)'";
            DateTimeOffset parsedDate;

            if (!DateTimeOffset.TryParseExact(scheduledate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                throw new ArgumentException("Invalid date format", nameof(scheduledate));
            }

            var dateOnly = parsedDate.Date;

            var employeeRoster = await _context.StaffRosters
                                .Include(r => r.Employee)
                                .Include(r => r.ShiftMaster)
                                .Include(r => r.StaffRosterMaster)
                                .Where(r => r.StaffRosterMaster.IsApproved == true
                                        && !r.IsDayOff
                                        && r.EmployeeId == employeeId
                                        && r.DayOffDate.Date == dateOnly)
                                .FirstOrDefaultAsync();

            return employeeRoster;
        }

        public async Task<StaffRoster> GetRosterByIdAsync(int rosterId)
        {
            return await _context.StaffRosters
                                 .FirstOrDefaultAsync(r => r.Id == rosterId);
        }

        public async Task UpdateStaffRosterAsync(StaffRoster staffRoster)
        {
            _context.StaffRosters.Update(staffRoster);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaffRostersByRosterMasterIdAsync(int rosterMasterId)
        {
            var staffRosters = _context.StaffRosters.Where(sr => sr.RosterMasterId == rosterMasterId);
            _context.StaffRosters.RemoveRange(staffRosters);
            await _context.SaveChangesAsync();
        }
    }
}
