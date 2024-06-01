using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IEmployementTypeRepository
    {
        Task<IEnumerable<EmploymentType>> GetAllEmployementTypesAsync();
    }
}
