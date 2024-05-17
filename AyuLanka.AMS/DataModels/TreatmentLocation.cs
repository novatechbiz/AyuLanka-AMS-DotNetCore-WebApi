using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class TreatmentLocation
    {
        [Key]
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int TreatmentTypeId { get; set; }
        [ForeignKey(nameof(TreatmentTypeId))]
        public TreatmentType TreatmentType { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }
    }
}
