using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AyuLanka.AMS.DataModels
{
    public class StaffLeave
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int NoOfDays { get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }
        [ForeignKey(nameof(LeaveTypeId))]
        public LeaveType LeaveType { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
