using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class ShiftMaster
    {
        [Key]
        public int Id { get; set; }
        public int FromTime { get; set; }
        public int ToTime { get; set; }
    }
}
