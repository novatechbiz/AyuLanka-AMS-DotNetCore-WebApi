using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface ITreatmentTypeService
    {
        Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesAsync();
        Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesByLocationAsync(int locationId);
    }
}
