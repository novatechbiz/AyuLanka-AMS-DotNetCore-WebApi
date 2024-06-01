using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace AyuLanka.AMS.AMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentLocationController : ControllerBase
    {
        private readonly ITreatmentLocationService _treatmentLocationService;

        public TreatmentLocationController(ITreatmentLocationService treatmentLocationService)
        {
            _treatmentLocationService = treatmentLocationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentType>>> GetAllTreatmentLocationAsync()
        {
            var treatmentLocations = await _treatmentLocationService.GetAllTreatmentLocationAsync();
            return Ok(treatmentLocations);
        }
    }
}
