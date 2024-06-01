using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class ShiftChangeDetailRequestModel
    {
        public int Id { get; set; }
        public int ShiftChangeMasterId { get; set; }
        public int StaffRosterId { get; set; }
        public int ShiftPre { get; set; }
        public int ShiftPost { get; set; }
        public int? ExchangeWithPre { get; set; }
        public int? ExchangeWithPost { get; set; }
        public bool IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
