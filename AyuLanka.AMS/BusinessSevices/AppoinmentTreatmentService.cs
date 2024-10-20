using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class AppoinmentTreatmentService : IAppoinmentTreatmentService
    {
        private readonly IAppoinmentTreatmentRepository _appointmentTreatmentRepository;

        public AppoinmentTreatmentService(IAppoinmentTreatmentRepository appointmentTreatmentRepository)
        {
            _appointmentTreatmentRepository = appointmentTreatmentRepository;
        }

        public async Task<IEnumerable<AppoinmentTreatment>> GetAllAppointmentTreatmentsAsync()
        {
            return await _appointmentTreatmentRepository.GetAllAppointmentTreatmentAsync();
        }

        public async Task<AppoinmentTreatment> GetAppointmentTreatmentByIdAsync(int id)
        {
            return await _appointmentTreatmentRepository.GetAppointmentTreatmentByIdAsync(id);
        }

        public async Task<AppoinmentTreatment> AddAppointmentTreatmentAsync(AppoinmentTreatmentRequestModel appoinmentTreatmentRequestModel)
        {
            if (appoinmentTreatmentRequestModel.Id == 0)
            {
                var AppointmentTreatment = new AppoinmentTreatment()
                {
                    AppoinmentId = (int)appoinmentTreatmentRequestModel.AppoinmentId,
                    TreatmentTypeId = appoinmentTreatmentRequestModel.TreatmentTypeId
                };


                return await _appointmentTreatmentRepository.AddAppointmentTreatmentAsync(AppointmentTreatment);
            }
            else
            {
                var existingAppoinment = await _appointmentTreatmentRepository.GetAppointmentTreatmentByIdAsync(appoinmentTreatmentRequestModel.Id);


                existingAppoinment.AppoinmentId = (int)appoinmentTreatmentRequestModel.AppoinmentId;
                existingAppoinment.TreatmentTypeId = appoinmentTreatmentRequestModel.TreatmentTypeId;

                return await _appointmentTreatmentRepository.UpdateAppointmentTreatmentAsync(existingAppoinment);
            }
        }

        public async Task<AppoinmentTreatment> UpdateAppointmentTreatmentAsync(AppoinmentTreatment appoinmentTreatment)
        {
            return await _appointmentTreatmentRepository.UpdateAppointmentTreatmentAsync(appoinmentTreatment);
        }

        public async Task DeleteAppointmentTreatmentAsync(int appoinmentId)
        {
            await _appointmentTreatmentRepository.DeleteAppointmentTreatmentAsync(appoinmentId);
        }
    }
}
