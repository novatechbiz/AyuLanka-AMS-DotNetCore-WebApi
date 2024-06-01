using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class AppointmentSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ScheduleDate { get; set; }

        [Required]
        public int TreatmentTypeId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(15)]
        public string ContactNo { get; set; }

        [Required]
        public TimeSpan FromTime { get; set; }

        [Required]
        public TimeSpan ToTime { get; set; }

        [Required]
        public int EnteredBy { get; set; }

        [Required]
        public DateTime EnteredDate { get; set; }

        public string? TokenNo { get; set; }

        public DateTime TokenIssueTime { get; set; }

        [ForeignKey(nameof(TreatmentTypeId))]
        public TreatmentLocation TreatmentLocation { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
