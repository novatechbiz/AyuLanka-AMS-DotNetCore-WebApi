using AyuLanka.AMS.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AyuLanka.AMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TreatmentType> TreatmentTypes { get; set; }
        public DbSet<ShiftMaster> ShiftMasters { get; set; }
        public DbSet<DayOffChangeReason> DayOffChangeReasons { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<TreatmentLocation> TreatmentLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StaffAttendance> StaffAttendances { get; set; }
        public DbSet<StaffRoster> StaffRosters { get; set; }
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }
        public DbSet<StaffLeave> StaffLeaves { get; set; }
        public DbSet<DayOffChangeMaster> DayOffChangeMasters { get; set; }
        public DbSet<DayOffChangeLog> DayOffChangeLogs { get; set; }
        public DbSet<StaffRosterMaster> StaffRosterMasters { get; set; }
        public DbSet<DayOffChangeDetail> DayOffChangeDetails { get; set; }
        public DbSet<ShiftChangeMaster> ShiftChangeMasters { get; set; }
        public DbSet<ShiftChangeDetail> ShiftChangeDetails { get; set; }
        public DbSet<AppoinmentTreatment> AppoinmentTreatments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ShiftMaster)
                .WithMany()
                .HasForeignKey(e => e.ShiftMasterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffRoster>()
                .HasOne(sr => sr.ShiftMaster)
                .WithMany()
                .HasForeignKey(sr => sr.ShiftMasterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffRoster>()
                .HasOne(sr => sr.Employee)
                .WithMany()
                .HasForeignKey(sr => sr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DayOffChangeLog>()
                .HasOne(dcl => dcl.StaffRoster)
                .WithMany()
                .HasForeignKey(dcl => dcl.StaffRosterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DayOffChangeLog>()
                .HasOne(dcl => dcl.DayOffChangeMaster)
                .WithMany()
                .HasForeignKey(dcl => dcl.DayOffChangeMasterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
