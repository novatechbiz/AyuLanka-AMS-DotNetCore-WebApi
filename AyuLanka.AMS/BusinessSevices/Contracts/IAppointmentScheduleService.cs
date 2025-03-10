using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface IAppointmentScheduleService
    {
        Task<IEnumerable<AppointmentSchedule>> GetAllAppointmentSchedulesAsync();
        Task<AppointmentSchedule> GetAppointmentScheduleByIdAsync(int id);
        Task<IEnumerable<AppointmentSchedule>> GetAppointmentScheduleByDateAsync(DateTime date);
        Task<IEnumerable<AppointmentSchedule>> GetDeletedAppoitmentByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AppointmentSchedule>> GetAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentScheduleRequestModel appointmentScheduleRequestModel);
        Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule appointmentScheduleRequestModel);
        Task DeleteAppointmentScheduleAsync(int id, int deletedByUserId, string remark);
    }
}
