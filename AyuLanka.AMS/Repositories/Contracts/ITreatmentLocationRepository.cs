using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface ITreatmentLocationRepository
    {
        Task<IEnumerable<TreatmentLocation>> GetAllTreatmentLocationAsync();
    }
}
