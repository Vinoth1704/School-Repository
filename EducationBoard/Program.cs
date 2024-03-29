using EducationBoard.Controllers;
using EducationBoard.DAL;
using EducationBoard.Models;
using EducationBoard.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<EducationBoardDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EducationBoard"));
});

builder.Services.AddTransient<StudentController>();
builder.Services.AddTransient<IStudentDAL, StudentDAL>();
builder.Services.AddTransient<ISubjectDAL, SubjectDAL>();
builder.Services.AddTransient<IPerformanceDAL, PerformanceDAL>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<IPerformanceService, PerformanceService>();
// builder.Services.AddTransient<IMessagingService, MessagingService>();
// builder.Services.AddTransient<IMessagingService, MessagingService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AutoMappers).Assembly);

// var studentService = builder.Services.BuildServiceProvider().GetService<IStudentService>()!;
// var performanceService = builder.Services.BuildServiceProvider().GetService<IPerformanceService>()!;
// var studentController = builder.Services.BuildServiceProvider().GetService<StudentController>()!;

// var message = new MessagingService(studentService, performanceService, studentController);
// message.checkMessage();

builder.Services.AddCors(
    (setup) =>
    {
        setup.AddPolicy(
            "default",
            (options) =>
            {
                options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }
        );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
