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
        
        public async Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateAsync(DateTime date)
        {
            return await _appointmentScheduleRepository.GetAppointmentScheduleByDateAsync(date);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetDeletedAppoitmentByDate(DateTime date)
        {
            return await _appointmentScheduleRepository.GetDeletedAppoitmentByDate(date);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetAppointmentScheduleByDateRangeAsync(startDate, endDate);
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
                    SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null,
                    ScheduleDate = appointmentScheduleRequestModel.ScheduleDate,
                    LocationId = appointmentScheduleRequestModel.LocationId,
                    FromTime = appointmentScheduleRequestModel.FromTime,
                    ToTime = appointmentScheduleRequestModel.ToTime,
                    ActualFromTime = appointmentScheduleRequestModel.ActualFromTime,
                    ActualToTime = appointmentScheduleRequestModel.ActualToTime,
                    ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond,
                    ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond,
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
                existingAppoinment.SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null;
                existingAppoinment.ScheduleDate = appointmentScheduleRequestModel.ScheduleDate;
                existingAppoinment.LocationId = appointmentScheduleRequestModel.LocationId;
                existingAppoinment.FromTime = appointmentScheduleRequestModel.FromTime;
                existingAppoinment.ToTime = appointmentScheduleRequestModel.ToTime;
                existingAppoinment.ActualFromTime = appointmentScheduleRequestModel.ActualFromTime;
                existingAppoinment.ActualToTime = appointmentScheduleRequestModel.ActualToTime;
                existingAppoinment.ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond;
                existingAppoinment.ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond;
                existingAppoinment.EnteredBy = appointmentScheduleRequestModel.EnteredBy;
                existingAppoinment.EnteredDate = DateTime.UtcNow;
                existingAppoinment.TokenNo = appointmentScheduleRequestModel.TokenNo;

                if (existingAppoinment.TokenNo == null && appointmentScheduleRequestModel.TokenNo != null)
                {
                    existingAppoinment.TokenIssueTime = DateTime.UtcNow;
                }
                existingAppoinment.Remarks = appointmentScheduleRequestModel.Remarks;

                return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(existingAppoinment);
            }
        }

        public async Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule AppointmentSchedule)
        {
            return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(AppointmentSchedule);
        }

        public async Task DeleteAppointmentScheduleAsync(int id, int deletedByUserId)
        {
            await _appointmentScheduleRepository.DeleteAppointmentScheduleAsync(id, deletedByUserId);
        }
    }
}
