namespace AyuLanka.AMS.AMSWeb.Models.RequestModels
{
    public class AppoinmentTreatmentRequestModel
    {
        public int Id { get; set; }
        public int? AppoinmentId { get; set; }
        public int TreatmentTypeId { get; set; }
    }
}
