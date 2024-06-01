using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class DayOffChangeDetailRequestModel
    {
        public int Id { get; set; }
        public int StaffRosterId { get; set; }
        public int DayOffChangeMasterId { get; set; }
        public DateTime DayOffPre { get; set; }
        public DateTime DayOffPost { get; set; }
        public DateTime? ExchangeWithPre { get; set; }
        public DateTime? ExchangeWithPost { get; set; }
        public bool IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
