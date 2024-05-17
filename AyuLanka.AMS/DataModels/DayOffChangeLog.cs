using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class DayOffChangeLog
    {
        [Key]
        public int Id { get; set; }
        public int DayOffChangeMasterId { get; set; }
        public int StaffRosterId { get; set; }
        public int IsDayOffPre { get; set; }
        public int IsDayOffPost { get; set; }
        [ForeignKey(nameof(DayOffChangeMasterId))]
        public DayOffChangeMaster DayOffChangeMaster { get; set; }
        [ForeignKey(nameof(StaffRosterId))]
        public StaffRoster StaffRoster { get; set; }
    }
}
