using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class StaffRosterMasterRequestModel
    {
        public int? Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime Todate { get; set; }
        public bool IsApproved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
