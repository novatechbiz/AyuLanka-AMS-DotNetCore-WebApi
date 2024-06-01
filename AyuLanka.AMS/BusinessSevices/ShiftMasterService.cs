using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.DataModels;
using AyuLanka.AMS.Repositories.Contracts;

namespace AyuLanka.AMS.BusinessSevices
{
    public class ShiftMasterService : IShiftMasterService
    {
        private readonly IShiftMasterRepository _shiftMasterRepository;

        public ShiftMasterService(IShiftMasterRepository shiftMasterRepository)
        {
            _shiftMasterRepository = shiftMasterRepository;
        }

        public async Task<IEnumerable<ShiftMaster>> GetAllShiftMastersAsync()
        {
            return await _shiftMasterRepository.GetAllShiftMastersAsync();
        }
    }
}
