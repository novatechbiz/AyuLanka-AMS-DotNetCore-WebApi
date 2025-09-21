using AyuLanka.AMS.AMSWeb.Models.RequestModels;
using AyuLanka.AMS.BusinessSevices;
using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace AyuLanka.AMS.AMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentScheduleController : ControllerBase
    {
        private readonly IAppointmentScheduleService _appointmentScheduleService;
        private readonly IAppoinmentTreatmentService _appoinmentTreatmentService;

        public AppointmentScheduleController(IAppointmentScheduleService appointmentScheduleService, IAppoinmentTreatmentService appoinmentTreatmentService)
        {
            _appointmentScheduleService = appointmentScheduleService;
            _appoinmentTreatmentService = appoinmentTreatmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentSchedule>>> GetAllAppointmentSchedules()
        {
            var AppointmentSchedules = await _appointmentScheduleService.GetAllAppointmentSchedulesAsync();
            return Ok(AppointmentSchedules);
        }

        [HttpGet("DeletedAppointmentsByDateRange")]
        public async Task<ActionResult<AppointmentSchedule>> GetDeletedAppoitmentByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetDeletedAppoitmentByDateRangeAsync(startDate, endDate);
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpGet("ByDate/{date}")]
        public async Task<ActionResult<AppointmentSchedule>> GetAppointmentScheduleByDate(DateTime date)
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetAppointmentScheduleByDateAsync(date);
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpGet("PrimeCareByDate/{date}")]
        public async Task<ActionResult<AppointmentSchedule>> GetPrimeCareAppointmentScheduleByDate(DateTime date)
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetPrimeCareAppointmentScheduleByDateAsync(date);
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpGet("tokensbydate")]
        public async Task<ActionResult<AppointmentSchedule>> GetTokensByDate([FromQuery] DateTime date)
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetTokensByDateAsync(date);
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpGet("issuedtokens")]
        public async Task<ActionResult<AppointmentSchedule>> GetIssuedTokensByDate()
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetIssuedTokensByDateAsync();
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpGet("bydaterange")]
        public async Task<ActionResult<IEnumerable<StaffLeave>>> GetStaffLeavesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            var result = await _appointmentScheduleService.GetAppointmentScheduleByDateRangeAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("primecarebydaterange")]
        public async Task<ActionResult<IEnumerable<StaffLeave>>> GetPrimeCareAppointmentScheduleByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            var result = await _appointmentScheduleService.GetPrimeCareAppointmentScheduleByDateRangeAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("getAllPreScheduledScheduledAppointments")]
        public async Task<ActionResult<IEnumerable<StaffLeave>>> GetAllPreScheduledAppointment([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            var result = await _appointmentScheduleService.GetAllPreScheduledAppointmentAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("getCompletedPreScheduledScheduledAppointments")]
        public async Task<ActionResult<IEnumerable<StaffLeave>>> GetCompletedPreScheduledAppointment([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            var result = await _appointmentScheduleService.GetCompletedPreScheduledAppointmentAsync(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentSchedule>> GetAppointmentScheduleById(int id)
        {
            var AppointmentSchedule = await _appointmentScheduleService.GetAppointmentScheduleByIdAsync(id);
            if (AppointmentSchedule == null)
            {
                return NotFound();
            }
            return Ok(AppointmentSchedule);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentSchedule>> AddAppointmentSchedule(AppointmentScheduleRequestModel appointmentScheduleRequestModel)
        {
            var createdAppointmentSchedule = await _appointmentScheduleService.AddAppointmentScheduleAsync(appointmentScheduleRequestModel);

            await _appoinmentTreatmentService.DeleteAppointmentTreatmentAsync(createdAppointmentSchedule.Id);
            foreach (var val in appointmentScheduleRequestModel.appoinmentTreatments)
            {
                val.AppoinmentId = createdAppointmentSchedule.Id;
                await _appoinmentTreatmentService.AddAppointmentTreatmentAsync(val);
            }
            
            return CreatedAtAction(nameof(GetAppointmentScheduleById), new { id = createdAppointmentSchedule.Id }, createdAppointmentSchedule);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointmentSchedule(int id, AppointmentSchedule appointmentSchedule)
        {
            if (id != appointmentSchedule.Id)
            {
                return BadRequest();
            }

            await _appointmentScheduleService.UpdateAppointmentScheduleAsync(appointmentSchedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointmentSchedule(int id, int deletedByUserId, string remark)
        {
            await _appointmentScheduleService.DeleteAppointmentScheduleAsync(id, deletedByUserId, remark);
            return NoContent();
        }
    }
}
