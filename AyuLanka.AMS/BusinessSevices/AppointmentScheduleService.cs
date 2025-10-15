using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Transactions;

namespace AyuLanka.AMS.BusinessSevices
{
    public class AppointmentScheduleService : IAppointmentScheduleService
    {
        private readonly IAppointmentScheduleRepository _appointmentScheduleRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;

        public AppointmentScheduleService(IAppointmentScheduleRepository appointmentScheduleRepository, 
            ILocationRepository locationRepository,
            IEmployeeRepository employeeRepository,
            IConfiguration configuration)
        {
            _appointmentScheduleRepository = appointmentScheduleRepository;
            _locationRepository = locationRepository;
            _employeeRepository = employeeRepository;
            _configuration = configuration;
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

        //public async Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentScheduleRequestModel appointmentScheduleRequestModel)
        //{
        //    if (appointmentScheduleRequestModel.Id == 0)
        //    {
        //        int location_id;
        //        if (appointmentScheduleRequestModel.MainTreatmentArea.HasValue && appointmentScheduleRequestModel.MainTreatmentArea == 1)
        //        {
        //            var location = await _locationRepository.GetPrimeCareLocationByNameAsync("Doctor Room Waiting");
        //            location_id = location.Id;
        //        }else
        //        {
        //            location_id = (int)appointmentScheduleRequestModel.LocationId;
        //        }

        //        var AppointmentSchedule = new AppointmentSchedule()
        //        {
        //            CustomerName = appointmentScheduleRequestModel.CustomerName,
        //            ContactNo = appointmentScheduleRequestModel.ContactNo,
        //            EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null,
        //            SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null,
        //            DoctorEmployeeId = appointmentScheduleRequestModel.DoctorEmployeeId != 0 ? appointmentScheduleRequestModel.DoctorEmployeeId : null,
        //            ScheduleDate = appointmentScheduleRequestModel.ScheduleDate,
        //            LocationId = location_id,
        //            FromTime = appointmentScheduleRequestModel.FromTime,
        //            ToTime = appointmentScheduleRequestModel.ToTime,
        //            ActualFromTime = appointmentScheduleRequestModel.ActualFromTime,
        //            ActualToTime = appointmentScheduleRequestModel.ActualToTime,
        //            ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond,
        //            ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond,
        //            EnteredBy = appointmentScheduleRequestModel.EnteredBy,
        //            Remarks = appointmentScheduleRequestModel.Remarks,
        //            EnteredDate = DateTime.Now,
        //            TokenNo = appointmentScheduleRequestModel.TokenNo,
        //            TokenIssueTime = DateTime.Now,
        //            MainTreatmentArea = appointmentScheduleRequestModel?.MainTreatmentArea,
        //        };


        //        return await _appointmentScheduleRepository.AddAppointmentScheduleAsync(AppointmentSchedule);
        //    } else
        //    {
        //        var existingAppoinment = await _appointmentScheduleRepository.GetAppointmentScheduleByIdAsync(appointmentScheduleRequestModel.Id);

        //        // Get max chitNo from repository
        //        var maxChitNo = await _appointmentScheduleRepository.GetMaxChitNoAsync(appointmentScheduleRequestModel.ScheduleDate);

        //        existingAppoinment.CustomerName = appointmentScheduleRequestModel.CustomerName;
        //        existingAppoinment.ContactNo = appointmentScheduleRequestModel.ContactNo;
        //        existingAppoinment.EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null;
        //        existingAppoinment.SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null;
        //        existingAppoinment.DoctorEmployeeId = appointmentScheduleRequestModel.DoctorEmployeeId != 0 ? appointmentScheduleRequestModel.DoctorEmployeeId : null;
        //        existingAppoinment.ScheduleDate = appointmentScheduleRequestModel.ScheduleDate;
        //        existingAppoinment.LocationId = appointmentScheduleRequestModel.LocationId;
        //        existingAppoinment.FromTime = appointmentScheduleRequestModel.FromTime;
        //        existingAppoinment.ToTime = appointmentScheduleRequestModel.ToTime;
        //        existingAppoinment.ActualFromTime = appointmentScheduleRequestModel.ActualFromTime;
        //        existingAppoinment.ActualToTime = appointmentScheduleRequestModel.ActualToTime;
        //        existingAppoinment.ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond;
        //        existingAppoinment.ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond;
        //        existingAppoinment.UpdatedBy = appointmentScheduleRequestModel.EnteredBy;
        //        existingAppoinment.UpdatedDate = DateTime.Now;
        //        existingAppoinment.TokenNo = appointmentScheduleRequestModel.TokenNo;
        //        existingAppoinment.MainTreatmentArea = appointmentScheduleRequestModel.MainTreatmentArea;

        //        if (appointmentScheduleRequestModel.IsTokenIssued)
        //        {
        //            existingAppoinment.ChitNo = maxChitNo + 1;
        //        }

        //        if (existingAppoinment.TokenNo == null && appointmentScheduleRequestModel.TokenNo != null)
        //        {
        //            existingAppoinment.TokenIssueTime = DateTime.Now;
        //        }
        //        existingAppoinment.Remarks = appointmentScheduleRequestModel.Remarks;

        //        return await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(existingAppoinment);
        //    }
        //}


        public async Task<AppointmentSchedule> AddAppointmentScheduleAsync(AppointmentScheduleRequestModel appointmentScheduleRequestModel)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                AppointmentSchedule appointmentResult = null;

                if (appointmentScheduleRequestModel.Id == 0)
                {
                    int location_id;
                    if (appointmentScheduleRequestModel.MainTreatmentArea.HasValue && appointmentScheduleRequestModel.MainTreatmentArea == 1)
                    {
                        var location = await _locationRepository.GetPrimeCareLocationByNameAsync("Doctor Room Waiting");
                        location_id = location.Id;
                    }
                    else
                    {
                        location_id = (int)appointmentScheduleRequestModel.LocationId;
                    }

                    var newAppointment = new AppointmentSchedule()
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

                    appointmentResult = await _appointmentScheduleRepository.AddAppointmentScheduleAsync(newAppointment);

                    var enterdByUser = await _employeeRepository.GetEmployeeByIdAsync(appointmentResult.EnteredBy);
                    appointmentResult.EnteredByEmployee = enterdByUser;
                    //appointmentResult.Location = new Location()
                    //{
                    //    Id = appointmentResult.Location.Id,
                    //    Name = appointmentResult.Location.Name,
                    //    LocationType = new LocationType()
                    //    {
                    //        Id = (int)appointmentResult.Location.LocationTypeId,
                    //        TypeName = appointmentResult.Location?.LocationTypeId == 1 ? "Prime Care Wing" : "Elite Care Wing"
                    //    }
                    //};

                    var locationSub = appointmentResult.Location;
                    var locationTypeName = locationSub.LocationTypeId == 1 ? "Prime Care Wing" : "Elite Care Wing";

                    // 🔹 Insert into other DB if TokenNo is not null
                    if (appointmentScheduleRequestModel.TokenNo != null)
                    {
                        await InsertDailyTokenAsync(appointmentResult, locationSub, locationTypeName);
                    }
                }
                else
                {
                    var existingAppointment = await _appointmentScheduleRepository.GetAppointmentScheduleByIdAsync(appointmentScheduleRequestModel.Id);

                    // Get max chitNo from repository
                    var maxChitNo = await _appointmentScheduleRepository.GetMaxChitNoAsync(appointmentScheduleRequestModel.ScheduleDate);

                    existingAppointment.CustomerName = appointmentScheduleRequestModel.CustomerName;
                    existingAppointment.ContactNo = appointmentScheduleRequestModel.ContactNo;
                    existingAppointment.EmployeeId = appointmentScheduleRequestModel.EmployeeId != 0 ? appointmentScheduleRequestModel.EmployeeId : null;
                    existingAppointment.SecondaryEmployeeId = appointmentScheduleRequestModel.SecondaryEmployeeId != 0 ? appointmentScheduleRequestModel.SecondaryEmployeeId : null;
                    existingAppointment.DoctorEmployeeId = appointmentScheduleRequestModel.DoctorEmployeeId != 0 ? appointmentScheduleRequestModel.DoctorEmployeeId : null;
                    existingAppointment.ScheduleDate = appointmentScheduleRequestModel.ScheduleDate;
                    existingAppointment.LocationId = appointmentScheduleRequestModel.LocationId;
                    existingAppointment.FromTime = appointmentScheduleRequestModel.FromTime;
                    existingAppointment.ToTime = appointmentScheduleRequestModel.ToTime;
                    existingAppointment.ActualFromTime = appointmentScheduleRequestModel.ActualFromTime;
                    existingAppointment.ActualToTime = appointmentScheduleRequestModel.ActualToTime;
                    existingAppointment.ActualFromTimeSecond = appointmentScheduleRequestModel.ActualFromTimeSecond;
                    existingAppointment.ActualToTimeSecond = appointmentScheduleRequestModel.ActualToTimeSecond;
                    existingAppointment.UpdatedBy = appointmentScheduleRequestModel.EnteredBy;
                    existingAppointment.UpdatedDate = DateTime.Now;
                    existingAppointment.TokenNo = appointmentScheduleRequestModel.TokenNo;
                    existingAppointment.MainTreatmentArea = appointmentScheduleRequestModel.MainTreatmentArea;
                    existingAppointment.Remarks = appointmentScheduleRequestModel.Remarks;

                    if (appointmentScheduleRequestModel.IsTokenIssued)
                        existingAppointment.ChitNo = maxChitNo + 1;

                    if (existingAppointment.TokenNo == null && appointmentScheduleRequestModel.TokenNo != null)
                        existingAppointment.TokenIssueTime = DateTime.Now;

                    appointmentResult = await _appointmentScheduleRepository.UpdateAppointmentScheduleAsync(existingAppointment);

                    var enterdByUser = await _employeeRepository.GetEmployeeByIdAsync(appointmentResult.EnteredBy);
                    appointmentResult.EnteredByEmployee = enterdByUser;
                    //appointmentResult.Location = new Location()
                    //{
                    //    Id = appointmentResult.Location.Id,
                    //    Name = appointmentResult.Location.Name,
                    //    LocationType = new LocationType()
                    //    {
                    //        Id = (int)appointmentResult.Location.LocationTypeId,
                    //        TypeName = appointmentResult.Location?.LocationTypeId == 1 ? "Prime Care Wing" : "Elite Care Wing"
                    //    }
                    //};

                    var locationSub = appointmentResult.Location;
                    var locationTypeName = locationSub.LocationTypeId == 1 ? "Prime Care Wing" : "Elite Care Wing";

                    // 🔹 Insert into other DB if TokenNo newly issued
                    if (appointmentScheduleRequestModel.TokenNo != null)
                    {
                        await InsertDailyTokenAsync(appointmentResult, locationSub, locationTypeName);
                    }
                }

                scope.Complete();
                return appointmentResult;
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

        private async Task InsertDailyTokenAsync(AppointmentSchedule appointment, Location location, string locationTypeName)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("sp_InsertDailyToken", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AppointmentScheduleId", appointment.Id);
                        command.Parameters.AddWithValue("@TokenDate", appointment.ScheduleDate);
                        command.Parameters.AddWithValue("@TokenNo", appointment.TokenNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@TreatmentLocationName", locationTypeName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@SubLocationName", location.Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PatientName", appointment.CustomerName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PhoneNo", appointment.ContactNo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EnteredBy", appointment.EnteredByEmployee.Username ?? (object)DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // log or handle error without interrupting main save
                Console.WriteLine($"Error inserting Daily Token: {ex.Message}");
                throw;
            }
        }

    }
}
