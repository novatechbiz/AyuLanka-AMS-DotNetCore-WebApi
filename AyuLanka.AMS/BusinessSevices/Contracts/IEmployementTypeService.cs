using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface IEmployementTypeService
    {
        Task<IEnumerable<EmploymentType>> GetAllEmployementTypesAsync();
    }
}
