using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class EmploymentType
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
