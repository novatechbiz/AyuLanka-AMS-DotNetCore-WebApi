using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class AppointmentScheduleRequestModel
    {
        public int Id { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int TreatmentTypeId { get; set; }
        public int EmployeeId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public string? TokenNo { get; set; }
        public DateTime TokenIssueTime { get; set; }
    }
}
