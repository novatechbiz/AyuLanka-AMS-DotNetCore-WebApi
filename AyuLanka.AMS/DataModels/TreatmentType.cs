using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class TreatmentType
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int DurationHours { get; set; }
    }
}
