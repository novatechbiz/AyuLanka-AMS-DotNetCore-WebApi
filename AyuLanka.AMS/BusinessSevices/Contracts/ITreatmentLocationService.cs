using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface ITreatmentLocationService
    {
        Task<IEnumerable<TreatmentLocation>> GetAllTreatmentLocationAsync();
    }
}
