namespace AyuLanka.AMS.AMSWeb.Models.ResponseModels
{
    public class DashboardSummaryDto
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }  // "New", "Repeat", "Converted"
        public int Count { get; set; }
    }
}
