using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class DayOffChangeMaster
    {
        [Key]
        public int Id { get; set; }
        public int StaffRosterId { get; set; }
        public int DayOffChangeReasonId { get; set; }
        public int ChangeTo { get; set; }
        public int ChangeWith { get; set; }
        [ForeignKey(nameof(DayOffChangeReasonId))]
        public DayOffChangeReason DayOffChangeReason { get; set; }
        [ForeignKey(nameof(StaffRosterId))]
        public StaffRoster StaffRoster { get; set; }
    }
}
