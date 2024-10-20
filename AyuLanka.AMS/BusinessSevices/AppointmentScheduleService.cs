using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class AppointmentScheduleService : IAppointmentScheduleService
    {
        private readonly IAppointmentScheduleRepository _appointmentScheduleRepository;

        public AppointmentScheduleService(IAppointmentScheduleRepository appointmentScheduleRepository)
        {
            _appointmentScheduleRepository = appointmentScheduleRepository;
        }

        public async Task<IEnumerable<AppointmentSchedule>> GetAllAppointmentSchedulesAsync()
        {
            return await _appointmentScheduleRepository.GetAllAppointmentSchedulesAsync();
        }

        public async Task<AppointmentSchedule> GetAppointmentScheduleByIdAsync(int id)
        {
            return await _appointmentScheduleRepository.GetAppointmentScheduleByIdAsync(id);
        }

        public async Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentScheduleRequestModel appointmentScheduleRequestModel)
        {
            if (appointmentScheduleRequestModel.Id == 0)
            {
                var AppointmentSchedule = new AppointmentSchedule()
                {
                    CustomerName = appointmentScheduleRequestModel.CustomerName,
                    ContactNo = appointmentScheduleRequestModel.ContactNo,
                    EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null,
                    ScheduleDate = appointmentScheduleRequestModel.ScheduleDate,
                    //TreatmentTypeId = appointmentScheduleRequestModel.TreatmentTypeId,
                    FromTime = appointmentScheduleRequestModel.FromTime,
                    ToTime = appointmentScheduleRequestModel.ToTime,
                    EnteredBy = appointmentScheduleRequestModel.EnteredBy,
                    Remarks = appointmentScheduleRequestModel.Remarks,
                    EnteredDate = DateTime.UtcNow
                };


                return await _appointmentScheduleRepository.AddAppointmentScheduleAsync(AppointmentSchedule);
            } else
            {
                var existingAppoinment = await _appointmentScheduleRepository.GetAppointmentScheduleByIdAsync(appointmentScheduleRequestModel.Id);


                existingAppoinment.CustomerName = appointmentScheduleRequestModel.CustomerName;
                existingAppoinment.ContactNo = appointmentScheduleRequestModel.ContactNo;
                existingAppoinment.EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null;
                existingAppoinment.ScheduleDate = appointmentScheduleRequestModel.ScheduleDate;
                //existingAppoinment.TreatmentTypeId = appointmentScheduleRequestModel.TreatmentTypeId;
                existingAppoinment.FromTime = appointmentScheduleRequestModel.FromTime;
                existingAppoinment.ToTime = appointmentScheduleRequestModel.ToTime;
                existingAppoinment.EnteredBy = appointmentScheduleRequestModel.EnteredBy;
                existingAppoinment.EnteredDate = DateTime.UtcNow;
                existingAppoinment.TokenNo = appointmentScheduleRequestModel.TokenNo;
                existingAppoinment.TokenIssueTime = appointmentScheduleRequestModel.TokenIssueTime;
                existingAppoinment.Remarks = appointmentScheduleRequestModel.Remarks;

                return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(existingAppoinment);
            }
        }

        public async Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule AppointmentSchedule)
        {
            return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(AppointmentSchedule);
        }

        public async Task DeleteAppointmentScheduleAsync(int id)
        {
            await _appointmentScheduleRepository.DeleteAppointmentScheduleAsync(id);
        }
    }
}
