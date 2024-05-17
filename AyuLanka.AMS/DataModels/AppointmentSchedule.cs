using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class AppointmentSchedule
    {
        [Key]
        public int Id { get; set; }
        public int ScheduleDate { get; set; }
        public int TreatmentTypeId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerName { get; set; }
        public int ContactNo { get; set; }
        public int FromTime { get; set; }
        public int ToTime { get; set; }
        public int EnteredBy { get; set; }
        public int EnteredDate { get; set; }
        public int TokenNo { get; set; }
        public int TokenIssueTime { get; set; }
        [ForeignKey(nameof(TreatmentTypeId))]
        public TreatmentType TreatmentType { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
