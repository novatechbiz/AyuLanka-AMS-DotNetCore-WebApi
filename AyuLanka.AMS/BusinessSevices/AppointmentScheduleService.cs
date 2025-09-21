using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class AppointmentScheduleService : IAppointmentScheduleService
    {
        private readonly IAppointmentScheduleRepository _appointmentScheduleRepository;
        private readonly ILocationRepository _locationRepository;

        public AppointmentScheduleService(IAppointmentScheduleRepository appointmentScheduleRepository, ILocationRepository locationRepository)
        {
            _appointmentScheduleRepository = appointmentScheduleRepository;
            _locationRepository = locationRepository;
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

        public async Task<IEnumerable<AppointmentSchedule?>> GetPrimeCareAppointmentScheduleByDateAsync(DateTime date)
        {
            return await _appointmentScheduleRepository.GetPrimeCareAppointmentScheduleByDateAsync(date);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetTokensByDateAsync(DateTime date)
        {
            return await _appointmentScheduleRepository.GetTokensByDateAsync(date);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetIssuedTokensByDateAsync()
        {
            return await _appointmentScheduleRepository.GetIssuedTokensByDateAsync();
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetDeletedAppoitmentByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetDeletedAppoitmentByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetCompletedPreScheduledAppointmentAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetCompletedPreScheduledAppointmentAsync(startDate, endDate);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetAllPreScheduledAppointmentAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetAllPreScheduledAppointmentAsync(startDate, endDate);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetAppointmentScheduleByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<AppointmentSchedule?>> GetPrimeCareAppointmentScheduleByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _appointmentScheduleRepository.GetPrimeCareAppointmentScheduleByDateRangeAsync(startDate, endDate);
        }

        public async Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentScheduleRequestModel appointmentScheduleRequestModel)
        {
            if (appointmentScheduleRequestModel.Id == 0)
            {
                int location_id;
                if (appointmentScheduleRequestModel.MainTreatmentArea.HasValue && appointmentScheduleRequestModel.MainTreatmentArea == 1)
                {
                    var location = await _locationRepository.GetPrimeCareLocationByNameAsync("Doctor Room Waiting");
                    location_id = location.Id;
                }else
                {
                    location_id = (int)appointmentScheduleRequestModel.LocationId;
                }

                var AppointmentSchedule = new AppointmentSchedule()
                {
                    CustomerName = appointmentScheduleRequestModel.CustomerName,
                    ContactNo = appointmentScheduleRequestModel.ContactNo,
                    EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null,
                    SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null,
                    DoctorEmployeeId = appointmentScheduleRequestModel.DoctorEmployeeId != 0 ? appointmentScheduleRequestModel.DoctorEmployeeId : null,
                    ScheduleDate = appointmentScheduleRequestModel.ScheduleDate,
                    LocationId = location_id,
                    FromTime = appointmentScheduleRequestModel.FromTime,
                    ToTime = appointmentScheduleRequestModel.ToTime,
                    ActualFromTime = appointmentScheduleRequestModel.ActualFromTime,
                    ActualToTime = appointmentScheduleRequestModel.ActualToTime,
                    ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond,
                    ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond,
                    EnteredBy = appointmentScheduleRequestModel.EnteredBy,
                    Remarks = appointmentScheduleRequestModel.Remarks,
                    EnteredDate = DateTime.Now,
                    TokenNo = appointmentScheduleRequestModel.TokenNo,
                    TokenIssueTime = DateTime.Now,
                    MainTreatmentArea = appointmentScheduleRequestModel?.MainTreatmentArea,
            };


                return await _appointmentScheduleRepository.AddAppointmentScheduleAsync(AppointmentSchedule);
            } else
            {
                var existingAppoinment = await _appointmentScheduleRepository.GetAppointmentScheduleByIdAsync(appointmentScheduleRequestModel.Id);

                // Get max chitNo from repository
                var maxChitNo = await _appointmentScheduleRepository.GetMaxChitNoAsync(appointmentScheduleRequestModel.ScheduleDate);

                existingAppoinment.CustomerName = appointmentScheduleRequestModel.CustomerName;
                existingAppoinment.ContactNo = appointmentScheduleRequestModel.ContactNo;
                existingAppoinment.EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null;
                existingAppoinment.SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null;
                existingAppoinment.DoctorEmployeeId = appointmentScheduleRequestModel.DoctorEmployeeId != 0 ? appointmentScheduleRequestModel.DoctorEmployeeId : null;
                existingAppoinment.ScheduleDate = appointmentScheduleRequestModel.ScheduleDate;
                existingAppoinment.LocationId = appointmentScheduleRequestModel.LocationId;
                existingAppoinment.FromTime = appointmentScheduleRequestModel.FromTime;
                existingAppoinment.ToTime = appointmentScheduleRequestModel.ToTime;
                existingAppoinment.ActualFromTime = appointmentScheduleRequestModel.ActualFromTime;
                existingAppoinment.ActualToTime = appointmentScheduleRequestModel.ActualToTime;
                existingAppoinment.ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond;
                existingAppoinment.ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond;
                existingAppoinment.UpdatedBy = appointmentScheduleRequestModel.EnteredBy;
                existingAppoinment.UpdatedDate = DateTime.Now;
                existingAppoinment.TokenNo = appointmentScheduleRequestModel.TokenNo;

                if (appointmentScheduleRequestModel.IsTokenIssued)
                {
                    existingAppoinment.ChitNo = maxChitNo + 1;
                }

                if (existingAppoinment.TokenNo == null && appointmentScheduleRequestModel.TokenNo != null)
                {
                    existingAppoinment.TokenIssueTime = DateTime.Now;
                }
                existingAppoinment.Remarks = appointmentScheduleRequestModel.Remarks;

                return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(existingAppoinment);
            }
        }

        public async Task<AppointmentSchedule> UpdateAppointmentScheduleAsync(AppointmentSchedule AppointmentSchedule)
        {
            return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(AppointmentSchedule);
        }

        public async Task DeleteAppointmentScheduleAsync(int id, int deletedByUserId, string remark)
        {
            await _appointmentScheduleRepository.DeleteAppointmentScheduleAsync(id, deletedByUserId, remark);
        }
    }
}
