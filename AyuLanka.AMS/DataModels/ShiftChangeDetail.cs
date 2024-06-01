using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class ShiftChangeDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShiftChangeMasterId { get; set; }

        [Required]
        public int StaffRosterId { get; set; }
        [Required]
        public int ShiftPre { get; set; }

        [Required]
        public int ShiftPost { get; set; }
        public int? ExchangeWithPre { get; set; }
        public int? ExchangeWithPost { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [ForeignKey(nameof(StaffRosterId))]
        public StaffRoster StaffRoster { get; set; }

        [ForeignKey(nameof(ShiftChangeMasterId))]
        public ShiftChangeMaster ShiftChangeMaster { get; set; }

        [ForeignKey(nameof(ShiftPre))]
        public ShiftMaster ShiftMasterPre { get; set; }

        [ForeignKey(nameof(ShiftPost))]
        public ShiftMaster ShiftMasterPost { get; set; }
    }
}
