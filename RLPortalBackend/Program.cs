using RLPortal.Repositories.Impl;
using RLPortal.Repositories;
using RLPortal.Services.Impl;
using RLPortal.Services;
using RLPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Connection to the MongoDB
builder.Services.Configure<PortalGeographyMongoDBSettings>(
    builder.Configuration.GetSection("RLPortalMongoDB"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
