using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class DayOffChangeMasterRequestModel
    {
        public int Id { get; set; }
        public int StaffRosterMasterId { get; set; }
        public int EmployeeId { get; set; }
        public int DayOffChangeReasonId { get; set; }
    }
}
