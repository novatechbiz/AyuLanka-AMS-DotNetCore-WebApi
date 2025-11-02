using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AyuLanka.AMS.Repositories
{
    public class AppointmentScheduleRepository : IAppointmentScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentSchedule>> GetAllAppointmentSchedulesAsync()
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee)       // Include Employee in the query
                        .Where(a => a.IsDeleted != true)
                        .OrderBy(a => a.Employee.EmployeeNumber)
                        .ToListAsync();
        }

        public async Task<AppointmentSchedule?> GetAppointmentScheduleByIdAsync(int id)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .OrderBy(a => a.Employee.EmployeeNumber)
                        .Where(a => a.Id == id)
                        .Where(a => a.IsDeleted != true)
                        .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateAsync(DateTime date)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .OrderBy(a => a.TokenNo)
                        .Where(a => a.ScheduleDate >= date.Date && a.ScheduleDate < date.Date.AddDays(1))
                        .Where(a => a.IsDeleted != true)
                        .Where(a => a.Location != null && a.Location.LocationTypeId == 2)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetPrimeCareAppointmentScheduleByDateAsync(DateTime date)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .OrderBy(a => a.TokenNo)
                        .Where(a => a.ScheduleDate >= date.Date && a.ScheduleDate < date.Date.AddDays(1))
                        .Where(a => a.IsDeleted != true)
                        .Where(a => a.Location != null && a.Location.LocationTypeId == 1)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetTokensByDateAsync(DateTime date)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .Include(a => a.ChildAppointments)
                        .OrderBy(a => a.TokenNo)
                        .Where(a => a.ScheduleDate >= date.Date && a.ScheduleDate < date.Date.AddDays(1))
                        .Where(a => a.TokenNo != null)
                        .Where(a => a.IsDeleted != true)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetIssuedTokensByDateAsync()
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .OrderBy(a => a.TokenNo)
                        .Where(a => a.ScheduleDate >= DateTime.Now.Date && a.ScheduleDate < DateTime.Now.Date.AddDays(1))
                        .Where(a => a.TokenNo != null)
                        .Where(a => a.ChitNo != null)
                        .Where(a => a.IsDeleted != true)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetDeletedAppoitmentByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.DeletedByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
                        .OrderBy(a => a.TokenNo)
                        .Where(a => a.ScheduleDate >= startDate.Date && a.ScheduleDate < endDate.Date.AddDays(1))
                        .Where(a => a.IsDeleted == true)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
            .OrderBy(a => a.TokenNo)
            .Where(a => a.ScheduleDate >= startDate.Date && a.ScheduleDate < endDate.Date.AddDays(1))
            .Where(a => a.IsDeleted != true)
            .Where(a => a.Location != null && a.Location.LocationTypeId == 2)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetPrimeCareAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
            .OrderBy(a => a.TokenNo)
            .Where(a => a.ScheduleDate >= startDate.Date && a.ScheduleDate < endDate.Date.AddDays(1))
            .Where(a => a.IsDeleted != true)
            .Where(a => a.Location != null && a.Location.LocationTypeId == 1)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetCompletedPreScheduledAppointmentAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
            .OrderBy(a => a.TokenNo)
            .Where(a => a.ScheduleDate >= startDate.Date && a.ScheduleDate < endDate.Date.AddDays(1))
            .Where(a => a.ActualFromTime != null && a.ActualToTime != null)
            .Where(a => a.EnteredDate < a.ScheduleDate)
            .Where(a => a.IsDeleted != true)
                        .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetAllPreScheduledAppointmentAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AppointmentSchedules
                        .Include(a => a.Location)
                        .Include(a => a.EnteredByEmployee)
                        .Include(a => a.AppointmentTreatments) // Include related AppointmentTreatments
                            .ThenInclude(at => at.TreatmentType) // Include TreatmentLocation within AppointmentTreatments
                        .Include(a => a.Employee) // Include Employee
            .OrderBy(a => a.TokenNo)
            .Where(a => a.ScheduleDate >= startDate.Date && a.ScheduleDate < endDate.Date.AddDays(1))
            .Where(a => a.EnteredDate < a.ScheduleDate)
            .Where(a => a.IsDeleted != true)
                        .ToListAsync();
        }

        public async Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentSchedule appointmentSchedule)
        {
            _context.AppointmentSchedules.Add(appointmentSchedule);
            await _context.SaveChangesAsync();
            return appointmentSchedule;
        }

        public async Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule appointmentSchedule)
        {
            _context.Entry(appointmentSchedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appointmentSchedule;
        }

        public async Task DeleteAppointmentScheduleAsync(int id, int deletedByUserId, string remark)
        {
            var appointmentSchedule = await _context.AppointmentSchedules.FindAsync(id);
            if (appointmentSchedule != null)
            {
                appointmentSchedule.Remarks = remark;
                appointmentSchedule.IsDeleted = true;
                appointmentSchedule.DeletedBy = deletedByUserId;
                appointmentSchedule.DeletedDate = DateTime.Now;

                _context.Entry(appointmentSchedule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetMaxChitNoAsync(DateTime scheduleDate)
        {
            var maxChitNo = await _context.AppointmentSchedules
                .Where(a => a.ScheduleDate.Date == scheduleDate.Date)
                .MaxAsync(a => (int?)a.ChitNo) ?? 0;
            return maxChitNo;
        }

    }
}
