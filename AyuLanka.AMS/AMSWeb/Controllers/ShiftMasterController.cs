using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace AyuLanka.AMS.AMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftMasterController : ControllerBase
    {
        private readonly IShiftMasterService _shiftMasterService;

        public ShiftMasterController(IShiftMasterService shiftMasterService)
        {
            _shiftMasterService = shiftMasterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftMaster>>> GetAllShiftMastersAsync()
        {
            var shiftMasters = await _shiftMasterService.GetAllShiftMastersAsync();
            return Ok(shiftMasters);
        }
    }
}
