using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class ShiftMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan FromTime { get; set; }

        [Required]
        public TimeSpan ToTime { get; set; }
    }
}
