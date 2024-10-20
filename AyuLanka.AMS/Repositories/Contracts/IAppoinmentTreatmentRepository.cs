using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IAppoinmentTreatmentRepository
    {
        Task<IEnumerable<AppoinmentTreatment>> GetAllAppointmentTreatmentAsync();
        Task<AppoinmentTreatment?> GetAppointmentTreatmentByIdAsync(int id);
        Task<AppoinmentTreatment> AddAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment);
        Task<AppoinmentTreatment> UpdateAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment);
        Task DeleteAppointmentTreatmentAsync(int appoinmentId);
    }
}
