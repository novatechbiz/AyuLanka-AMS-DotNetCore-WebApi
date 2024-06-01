using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace AyuLanka.AMS.AMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentTypeController : ControllerBase
    {
        private readonly ITreatmentTypeService _treatmentTypeService;

        public TreatmentTypeController(ITreatmentTypeService treatmentTypeService)
        {
            _treatmentTypeService = treatmentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentType>>> GetAllTreatmentTypesAsync()
        {
            var treatmentTypes = await _treatmentTypeService.GetAllTreatmentTypesAsync();
            return Ok(treatmentTypes);
        }

        [HttpGet("location/{locationId}")]
        public async Task<ActionResult<IEnumerable<TreatmentType>>> GetAllTreatmentTypesByLocationAsync(int locationId)
        {
            var treatmentTypes = await _treatmentTypeService.GetAllTreatmentTypesByLocationAsync(locationId);
            return Ok(treatmentTypes);
        }
    }
}
