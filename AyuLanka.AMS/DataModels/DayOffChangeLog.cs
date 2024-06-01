using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class DayOffChangeLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DayOffChangeMasterId { get; set; }

        [Required]
        public int StaffRosterId { get; set; }

        [Required]
        public bool IsDayOffPre { get; set; }

        [Required]
        public bool IsDayOffPost { get; set; }

        [ForeignKey(nameof(DayOffChangeMasterId))]
        public DayOffChangeMaster DayOffChangeMaster { get; set; }

        [ForeignKey(nameof(StaffRosterId))]
        public StaffRoster StaffRoster { get; set; }
    }
}
