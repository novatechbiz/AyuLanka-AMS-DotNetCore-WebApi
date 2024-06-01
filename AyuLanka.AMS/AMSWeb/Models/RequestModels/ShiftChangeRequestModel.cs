namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class ShiftChangeRequestModel
    {
        public ShiftChangeMasterRequestModel shiftChangeMasterRequest { get; set; }
        public IEnumerable<ShiftChangeDetailRequestModel> shiftChangeDetails { get; set; }
    }
}
