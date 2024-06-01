using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class DayOffChangeReason
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]  // Assuming a maximum length of 100 characters for the name
        public string Name { get; set; }
    }
}
