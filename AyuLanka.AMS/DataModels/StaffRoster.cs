using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class StaffRoster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int RosterMasterId { get; set; }

        [Required]
        public int ShiftMasterId { get; set; }

        [Required]
        public bool IsDayOff { get; set; }

        [Required]
        public DateTime DayOffDate { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [ForeignKey(nameof(ShiftMasterId))]
        public ShiftMaster ShiftMaster { get; set; }

        [ForeignKey(nameof(RosterMasterId))]
        public StaffRosterMaster StaffRosterMaster { get; set; }
    }
}
