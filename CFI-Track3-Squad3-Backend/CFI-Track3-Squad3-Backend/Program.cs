
using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.EntityFrameworkCore;
using CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "1"));

    option.AddPolicy("Consultant", policy => policy.RequireClaim(ClaimTypes.Role, "2"));


    option.AddPolicy("AdministratorAndConsultant", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "1", "2");
    });

});

builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();

builder.Services.AddScoped<IEntitySeeder, AccountsSeeder>();


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

