using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAllDesignationsAsync();
    }
}
