using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class StaffAttendance
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AttendanceDate { get; set; }
        public int InTime { get; set; }
        public int OutTime { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
