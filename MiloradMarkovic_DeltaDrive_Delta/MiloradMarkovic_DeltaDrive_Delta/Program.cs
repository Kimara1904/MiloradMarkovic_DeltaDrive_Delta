using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Infrastructure;
using MiloradMarkovic_DeltaDrive_Delta.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DriveDatabaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DriveDB")));
builder.Services.AddScoped<DbContext, DriveDatabaseContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
