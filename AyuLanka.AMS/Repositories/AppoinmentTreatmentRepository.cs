using AyuLanka.AMS.Data;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Repositories
{
    public class AppoinmentTreatmentRepository : IAppoinmentTreatmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppoinmentTreatmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppoinmentTreatment>> GetAllAppointmentTreatmentAsync()
        {
            return await _context.AppoinmentTreatments
                        .Include(at => at.TreatmentLocation) // Include TreatmentLocation within AppointmentTreatments
                                .ThenInclude(tl => tl.TreatmentType) // Include TreatmentType within TreatmentLocation
                        .ToListAsync();
        }

        public async Task<AppoinmentTreatment?> GetAppointmentTreatmentByIdAsync(int id)
        {
            return await _context.AppoinmentTreatments
                        .Include(at => at.TreatmentLocation) // Include TreatmentLocation within AppointmentTreatments
                                .ThenInclude(tl => tl.TreatmentType) // Include TreatmentType within TreatmentLocation
                        .Where(a => a.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<AppoinmentTreatment> AddAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment)
        {
            _context.AppoinmentTreatments.Add(appoinmentTreatment);
            await _context.SaveChangesAsync();
            return appoinmentTreatment;
        }

        public async Task<AppoinmentTreatment> UpdateAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment)
        {
            _context.Entry(appoinmentTreatment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return appoinmentTreatment;
        }

        public async Task DeleteAppointmentTreatmentAsync(int appointmentId)
        {
            // Find all treatments associated with the appointmentId
            var appointmentTreatments = await _context.AppoinmentTreatments
                                            .Where(a => a.AppoinmentId == appointmentId)
                                            .ToListAsync();

            // Check if any treatments exist for the given appointmentId
            if (appointmentTreatments.Any())
            {
                _context.AppoinmentTreatments.RemoveRange(appointmentTreatments); // Remove all treatments
                await _context.SaveChangesAsync(); // Save changes to the database
            }
        }
    }
}
