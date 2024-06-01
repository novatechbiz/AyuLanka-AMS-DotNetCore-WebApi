using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace AyuLanka.AMS.AMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployementTypeController : ControllerBase
    {
        private readonly IEmployementTypeService _employementTypeService;

        public EmployementTypeController(IEmployementTypeService employementTypeService)
        {
            _employementTypeService = employementTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentType>>> GetAllEmployementTypesAsync()
        {
            var employmentTypes = await _employementTypeService.GetAllEmployementTypesAsync();
            return Ok(employmentTypes);
        }
    }
}
