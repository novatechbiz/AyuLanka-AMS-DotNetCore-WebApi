using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AyuLanka.AMS.DataModels
{
    public class AppoinmentTreatment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppoinmentId { get; set; }

        [Required]
        public int TreatmentTypeId { get; set; }

        [ForeignKey(nameof(TreatmentTypeId))]
        public TreatmentType TreatmentType { get; set; }

        [JsonIgnore] // This will prevent serialization of this reference
        [ForeignKey(nameof(AppoinmentId))]
        public AppointmentSchedule AppointmentSchedule { get; set; }
    }
}
