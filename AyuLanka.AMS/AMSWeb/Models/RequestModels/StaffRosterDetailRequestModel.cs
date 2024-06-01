using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class StaffRosterDetailRequestModel
    {
        public int? Id { get; set; }
        public int EmployeeId { get; set; }
        public int? RosterMasterId { get; set; }
        public int ShiftMasterId { get; set; }
        public bool IsDayOff { get; set; }
        public DateTime DayOffDate { get; set; }
    }
}
