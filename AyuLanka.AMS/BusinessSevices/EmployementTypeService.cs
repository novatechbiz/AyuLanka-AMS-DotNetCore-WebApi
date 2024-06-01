using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class EmployementTypeService : IEmployementTypeService
    {
        private readonly IEmployementTypeRepository _employementTypeRepository;

        public EmployementTypeService(IEmployementTypeRepository employementTypeRepository)
        {
            _employementTypeRepository = employementTypeRepository;
        }

        public async Task<IEnumerable<EmploymentType>> GetAllEmployementTypesAsync()
        {
            return await _employementTypeRepository.GetAllEmployementTypesAsync();
        }
    }
}
