using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string DesignationCode { get; set; }
    }
}
