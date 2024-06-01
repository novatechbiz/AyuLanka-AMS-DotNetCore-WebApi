using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface ITreatmentTypeRepository
    {
        Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesAsync();
        Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesByLocationAsync(int locationId);
    }
}
