using AutoMapper;
using Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Infrastructure;
using MiloradMarkovic_DeltaDrive_Delta.Mapper;
using MiloradMarkovic_DeltaDrive_Delta.Repositories;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VehicleProfile());
    mc.AddProfile(new PassengerProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DriveDatabaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DriveDB")));
builder.Services.AddScoped<DbContext, DriveDatabaseContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddHostedService<LoadDataService>();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));

var configuration = new ConfigurationBuilder()
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();
