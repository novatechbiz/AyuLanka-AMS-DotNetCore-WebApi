using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class ShiftChangeMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StaffRosterMasterId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ShiftChangeReasonId { get; set; }

        [ForeignKey(nameof(ShiftChangeReasonId))]
        public DayOffChangeReason DayOffChangeReason { get; set; }

        [ForeignKey(nameof(StaffRosterMasterId))]
        public StaffRosterMaster StaffRosterMaster { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
