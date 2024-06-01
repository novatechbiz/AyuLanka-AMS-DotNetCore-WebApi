using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface IShiftMasterService
    {
        Task<IEnumerable<ShiftMaster>> GetAllShiftMastersAsync();
    }
}
