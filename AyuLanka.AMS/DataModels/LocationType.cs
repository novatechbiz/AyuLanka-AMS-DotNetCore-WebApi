using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class LocationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        // Navigation property (one-to-many)
        public ICollection<Location> Locations { get; set; }
    }
}
