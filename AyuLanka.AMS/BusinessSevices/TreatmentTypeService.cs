using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class TreatmentTypeService : ITreatmentTypeService
    {
        private readonly ITreatmentTypeRepository _treatmentTypeRepository;

        public TreatmentTypeService(ITreatmentTypeRepository treatmentTypeRepository)
        {
            _treatmentTypeRepository = treatmentTypeRepository;
        }

        public async Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesAsync()
        {
            return await _treatmentTypeRepository.GetAllTreatmentTypesAsync();
        }

        public async Task<IEnumerable<TreatmentType>> GetAllTreatmentTypesByLocationAsync(int locationId)
        {
            return await _treatmentTypeRepository.GetAllTreatmentTypesByLocationAsync(locationId);
        }
    }
}
