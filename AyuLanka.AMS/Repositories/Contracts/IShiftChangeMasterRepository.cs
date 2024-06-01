using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IShiftChangeMasterRepository
    {
        Task<IEnumerable<ShiftChangeMaster>> GetAllShiftChangeMastersAsync();
        Task<ShiftChangeMaster> GetShiftChangeMasterByIdAsync(int id);
        Task<ShiftChangeMaster> AddShiftChangeMasterAsync(ShiftChangeMaster shiftChangeMaster);
        Task<ShiftChangeMaster> UpdateShiftChangeMasterAsync(ShiftChangeMaster shiftChangeMaster);
        Task DeleteShiftChangeMasterAsync(int id);
    }
}
