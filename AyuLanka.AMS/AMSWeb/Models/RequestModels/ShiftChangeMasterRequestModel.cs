using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class ShiftChangeMasterRequestModel
    {
        public int Id { get; set; }
        public int StaffRosterMasterId { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftChangeReasonId { get; set; }
    }
}
