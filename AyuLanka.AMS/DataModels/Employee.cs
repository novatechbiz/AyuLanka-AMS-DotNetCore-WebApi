using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int ShiftMasterId { get; set; }
        public int EmploymentTypeId { get; set; }
        public int DesignationId { get; set; }
        public int FullName { get; set; }
        public int Address { get; set; }
        public int NIC { get; set; }
        public int JoinedDate { get; set; }

        [ForeignKey(nameof(DesignationId))]
        public Designation Designation { get; set; }

        [ForeignKey(nameof(EmploymentTypeId))]
        public EmploymentType EmploymentType { get; set; }

        [ForeignKey(nameof(ShiftMasterId))]
        public ShiftMaster ShiftMaster { get; set; }
    }
}
