using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class StaffLeaveRequestModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int NoOfDays { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
