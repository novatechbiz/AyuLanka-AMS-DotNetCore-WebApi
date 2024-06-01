using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class DayOffChangeDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DayOffChangeMasterId { get; set; }

        [Required]
        public int StaffRosterId { get; set; }
        [Required]
        public DateTime DayOffPre { get; set; }

        [Required]
        public DateTime DayOffPost { get; set; }
        public DateTime? ExchangeWithPre { get; set; }
        public DateTime? ExchangeWithPost { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        //[ForeignKey(nameof(StaffRosterId))]
        //public StaffRoster StaffRoster { get; set; }

        [ForeignKey(nameof(DayOffChangeMasterId))]
        public DayOffChangeMaster DayOffChangeMaster { get; set; }
    }
}
