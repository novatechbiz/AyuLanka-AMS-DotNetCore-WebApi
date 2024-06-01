using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface IShiftMasterRepository
    {
        Task<IEnumerable<ShiftMaster>> GetAllShiftMastersAsync();
    }
}
