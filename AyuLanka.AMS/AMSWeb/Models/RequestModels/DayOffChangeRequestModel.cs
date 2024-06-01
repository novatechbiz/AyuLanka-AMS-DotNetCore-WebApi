namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class DayOffChangeRequestModel
    {
        public DayOffChangeMasterRequestModel dayOffChangeMaster { get; set; }
        public IEnumerable<DayOffChangeDetailRequestModel> dayOffChangeDetails { get; set; }
    }
}
