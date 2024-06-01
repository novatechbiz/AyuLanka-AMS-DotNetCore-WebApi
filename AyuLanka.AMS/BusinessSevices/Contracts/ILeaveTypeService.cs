using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.BusinessSevices.Contracts
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync();
    }
}
