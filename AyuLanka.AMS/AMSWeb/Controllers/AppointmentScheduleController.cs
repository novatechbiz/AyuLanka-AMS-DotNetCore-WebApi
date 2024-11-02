using AyuLanka.AMS.AMSWeb.Models.RequestModels;
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
        public async Task<ActionResult> DeleteAppointmentSchedule(int id)
        {
            await _appointmentScheduleService.DeleteAppointmentScheduleAsync(id);
            return NoContent();
        }
    }
}
