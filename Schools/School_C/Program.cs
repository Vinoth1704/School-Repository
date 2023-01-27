using Microsoft.EntityFrameworkCore;
using School.DAL;
using School.Models;
using School.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("School")));
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentDAL, StudentDAL>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<ISubjectDAL, SubjectDAL>();
builder.Services.AddTransient<IScoreService, ScoreService>();
builder.Services.AddTransient<IScoreDAL, ScoreDAL>();

builder.Services.AddAutoMapper(typeof(AutoMappers).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
