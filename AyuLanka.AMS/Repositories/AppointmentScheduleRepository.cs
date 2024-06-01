using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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
                .Include(a => a.TreatmentLocation)  // Include TreatmentType in the query
                .Include(a => a.TreatmentLocation.Location)
                .Include(a => a.TreatmentLocation.TreatmentType)
                .Include(a => a.Employee)       // Include Employee in the query
                .ToListAsync();
        }

        public async Task<AppointmentSchedule> GetAppointmentScheduleByIdAsync(int id)
        {
            return await _context.AppointmentSchedules
                .Include(a => a.TreatmentLocation)  // Include TreatmentType in the query
                .Include(a => a.TreatmentLocation.Location)
                .Include(a => a.TreatmentLocation.TreatmentType)
                .Include(a => a.Employee)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
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

        public async Task DeleteAppointmentScheduleAsync(int id)
        {
            var appointmentSchedule = await _context.AppointmentSchedules.FindAsync(id);
            if (appointmentSchedule != null)
            {
                _context.AppointmentSchedules.Remove(appointmentSchedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}
