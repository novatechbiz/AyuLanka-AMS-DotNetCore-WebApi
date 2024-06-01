using AyuLanka.AMS.DataModels;

namespace AyuLanka.AMS.Repositories.Contracts
{
    public interface ILeaveTypeRepository
    {
        Task<IEnumerable<LeaveType>> GetAllLeaveTypesAsync();
    }
}
