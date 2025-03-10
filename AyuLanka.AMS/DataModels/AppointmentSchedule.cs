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

        public int? EmployeeId { get; set; }
        public int? SecondaryEmployeeId { get; set; }

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
        
        public TimeSpan? ActualFromTime { get; set; }

        public TimeSpan? ActualToTime { get; set; }

        public TimeSpan? ActualFromTimeSecond { get; set; }

        public TimeSpan? ActualToTimeSecond { get; set; }

        [Required]
        public int EnteredBy { get; set; }

        [Required]
        public DateTime EnteredDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string? TokenNo { get; set; }
        public string? Remarks { get; set; }

        public DateTime TokenIssueTime { get; set; }
        [Required]
        public int LocationId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [ForeignKey(nameof(SecondaryEmployeeId))] 
        public Employee SecondaryEmployee { get; set; }

        [ForeignKey(nameof(EnteredBy))]
        public Employee EnteredByEmployee { get; set; }

        [ForeignKey(nameof(DeletedBy))]
        public Employee DeletedByEmployee { get; set; }

        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }

        public ICollection<AppoinmentTreatment> AppointmentTreatments { get; set; }
    }
}
