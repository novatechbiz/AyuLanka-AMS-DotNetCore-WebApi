using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface IAppoinmentTreatmentService
    {
        Task<IEnumerable<AppoinmentTreatment>> GetAllAppointmentTreatmentsAsync();
        Task<AppoinmentTreatment> GetAppointmentTreatmentByIdAsync(int id);
        Task<AppoinmentTreatment> AddAppointmentTreatmentAsync(AppoinmentTreatmentRequestModel appoinmentTreatmentRequestModel);
        Task<AppoinmentTreatment> UpdateAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment);
        Task DeleteAppointmentTreatmentAsync(int appoinmentId);
    }
}
