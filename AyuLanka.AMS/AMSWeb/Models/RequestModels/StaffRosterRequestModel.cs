using AyuLanka.AMS.DataModels;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class StaffRosterRequestModel
    {
        public StaffRosterMasterRequestModel rosterMaster { get; set; }
        public IEnumerable<StaffRosterDetailRequestModel> staffRosters { get; set; }


    }
}
