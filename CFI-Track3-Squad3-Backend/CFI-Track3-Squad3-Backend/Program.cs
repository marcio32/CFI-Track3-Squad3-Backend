// Comentarios en el c�digo para explicar su funcionalidad y configuraci�n

using CFI_Track3_Squad3_Backend.DTOs;
using CFI_Track3_Squad3_Backend.Services;
using Microsoft.EntityFrameworkCore;
using CFI_Track3_Squad3_Backend.DataAccess.DatabaseSeeding;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Configuraci�n de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorizaci�n JWT",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new string[]{}
        }
    });
});

// Configuraci�n de DbContext para la base de datos
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuraci�n de pol�ticas de autorizaci�n
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
    option.AddPolicy("Consultant", policy => policy.RequireClaim(ClaimTypes.Role, "2"));
    option.AddPolicy("AdministratorAndConsultant", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "1", "2");
    });
});

// Configuraci�n de AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Configuraci�n de servicios inyectables
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();

// Configuraci�n de autenticaci�n JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false
    });

var app = builder.Build();

// Configuraci�n del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
