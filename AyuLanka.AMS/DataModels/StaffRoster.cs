using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class StaffRoster
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int RosterDate { get; set; }
        public int ShiftMasterId { get; set; }
        public int IsDayOff { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [ForeignKey(nameof(ShiftMasterId))]
        public ShiftMaster ShiftMaster { get; set; }
    }
}
