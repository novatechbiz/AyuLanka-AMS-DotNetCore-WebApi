﻿// <auto-generated />
using System;
using AyuLanka.AMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AyuLanka.AMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240528164506_UpdateDayOffChangeMasterV4")]
    partial class UpdateDayOffChangeMasterV4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AyuLanka.AMS.DataModels.AppointmentSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EnteredBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnteredDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("FromTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ToTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("TokenIssueTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TokenNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreatmentTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TreatmentTypeId");

                    b.ToTable("AppointmentSchedules");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.DayOffChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayOffChangeMasterId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDayOffPost")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDayOffPre")
                        .HasColumnType("bit");

                    b.Property<int>("StaffRosterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayOffChangeMasterId");

                    b.HasIndex("StaffRosterId");

                    b.ToTable("DayOffChangeLogs");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.DayOffChangeMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOffChangeReasonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayOffPost")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DayOffPre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExchangeWithPost")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExchangeWithPre")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("StaffRosterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayOffChangeReasonId");

                    b.HasIndex("StaffRosterId");

                    b.ToTable("DayOffChangeMasters");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.DayOffChangeReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DayOffChangeReasons");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<int>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ShiftMasterId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DesignationId");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("ShiftMasterId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.EmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.ShiftMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("FromTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ToTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ShiftMasters");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("StaffAttendances");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffLeave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("LeaveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LeaveTypeId");

                    b.ToTable("StaffLeaves");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffRoster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DayOffDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDayOff")
                        .HasColumnType("bit");

                    b.Property<int>("RosterMasterId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RosterMasterId");

                    b.HasIndex("ShiftMasterId");

                    b.ToTable("StaffRosters");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffRosterMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Todate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StaffRosterMasters");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.TreatmentLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TreatmentTypeId");

                    b.ToTable("TreatmentLocations");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.TreatmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DurationHours")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TreatmentTypes");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.AppointmentSchedule", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.TreatmentType", "TreatmentType")
                        .WithMany()
                        .HasForeignKey("TreatmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TreatmentType");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.DayOffChangeLog", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.DayOffChangeMaster", "DayOffChangeMaster")
                        .WithMany()
                        .HasForeignKey("DayOffChangeMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.StaffRoster", "StaffRoster")
                        .WithMany()
                        .HasForeignKey("StaffRosterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DayOffChangeMaster");

                    b.Navigation("StaffRoster");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.DayOffChangeMaster", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.DayOffChangeReason", "DayOffChangeReason")
                        .WithMany()
                        .HasForeignKey("DayOffChangeReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.StaffRoster", "StaffRoster")
                        .WithMany()
                        .HasForeignKey("StaffRosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOffChangeReason");

                    b.Navigation("StaffRoster");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.Employee", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.ShiftMaster", "ShiftMaster")
                        .WithMany()
                        .HasForeignKey("ShiftMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Designation");

                    b.Navigation("EmploymentType");

                    b.Navigation("ShiftMaster");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffAttendance", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffLeave", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("LeaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.StaffRoster", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.StaffRosterMaster", "StaffRosterMaster")
                        .WithMany()
                        .HasForeignKey("RosterMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.ShiftMaster", "ShiftMaster")
                        .WithMany()
                        .HasForeignKey("ShiftMasterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("ShiftMaster");

                    b.Navigation("StaffRosterMaster");
                });

            modelBuilder.Entity("AyuLanka.AMS.DataModels.TreatmentLocation", b =>
                {
                    b.HasOne("AyuLanka.AMS.DataModels.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AyuLanka.AMS.DataModels.TreatmentType", "TreatmentType")
                        .WithMany()
                        .HasForeignKey("TreatmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("TreatmentType");
                });
#pragma warning restore 612, 618
        }
    }
}
