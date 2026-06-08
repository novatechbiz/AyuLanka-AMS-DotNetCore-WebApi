namespace AyuLanka.AMS.AMSWeb.Models.ResponseModels
{
    public class DashboardDateChartDto
    {
        public DateTime Date { get; set; }
        public int OpdNew { get; set; }
        public int OpdRepeat { get; set; }
        public int WellnessNew { get; set; }
        public int WellnessRepeat { get; set; }
        public int OpdWellnessNew { get; set; }
        public int OpdWellnessRepeat { get; set; }

        public int OpdToWellnessConverted { get; set; }
    }
}
