using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IAppointmentScheduleRepository
    {
        Task<IEnumerable<AppointmentSchedule>> GetAllAppointmentSchedulesAsync();
        Task<AppointmentSchedule?> GetAppointmentScheduleByIdAsync(int id);
        Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateAsync(DateTime date);
        Task<IEnumerable<AppointmentSchedule?>> GetDeletedAppoitmentByDate(DateTime date);
        Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentSchedule appointmentSchedule);
        Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule appointmentSchedule);
        Task DeleteAppointmentScheduleAsync(int id, int deletedByUserId);
    }
}
