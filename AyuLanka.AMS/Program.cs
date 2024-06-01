using AyuLanka.AMS.BusinessSevices.Contracts;
using AyuLanka.AMS.BusinessSevices;
using AyuLanka.AMS.Data;
using AyuLanka.AMS.Repositories.Contracts;
using AyuLanka.AMS.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployementTypeRepository, EmployementTypeRepository>();
builder.Services.AddScoped<IEmployementTypeService, EmployementTypeService>();
builder.Services.AddScoped<IShiftMasterRepository, ShiftMasterRepository>();
builder.Services.AddScoped<IShiftMasterService, ShiftMasterService>();
builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();
builder.Services.AddScoped<IDesignationService, DesignationService>();
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<IStaffLeaveRepository, StaffLeaveRepository>();
builder.Services.AddScoped<IStaffLeaveService, StaffLeaveService>();
builder.Services.AddScoped<ITreatmentTypeRepository, TreatmentTypeRepository>();
builder.Services.AddScoped<ITreatmentTypeService, TreatmentTypeService>();
builder.Services.AddScoped<ITreatmentLocationRepository, TreatmentLocationRepository>();
builder.Services.AddScoped<ITreatmentLocationService, TreatmentLocationService>();
builder.Services.AddScoped<IAppointmentScheduleRepository, AppointmentScheduleRepository>();
builder.Services.AddScoped<IAppointmentScheduleService, AppointmentScheduleService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IStaffRosterService, StaffRosterService>();
builder.Services.AddScoped<IStaffRosterMasterRepository, StaffRosterMasterRepository>();
builder.Services.AddScoped<IStaffRosterRepository, StaffRosterRepository>();
builder.Services.AddScoped<IDayOffChangeMasterService, DayOffChangeMasterService>();
builder.Services.AddScoped<IDayOffChangeMasterRepository, DayOffChangeMasterRepository>();
builder.Services.AddScoped<IDayOffChangeDetailRepository, DayOffChangeDetailRepository>();
builder.Services.AddScoped<IShiftChangeMasterService, ShiftChangeMasterService>();
builder.Services.AddScoped<IShiftChangeMasterRepository, ShiftChangeMasterRepository>();
builder.Services.AddScoped<IShiftChangeDetailRepository, ShiftChangeDetailRepository>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // React app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
