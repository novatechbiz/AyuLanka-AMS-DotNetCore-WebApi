using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class TreatmentLocationService : ITreatmentLocationService
    {
        private readonly ITreatmentLocationRepository _treatmentLocationRepository;

        public TreatmentLocationService(ITreatmentLocationRepository treatmentLocationRepository)
        {
            _treatmentLocationRepository = treatmentLocationRepository;
        }

        public async Task<IEnumerable<TreatmentLocation>> GetAllTreatmentLocationAsync()
        {
            return await _treatmentLocationRepository.GetAllTreatmentLocationAsync();
        }
    }
}
