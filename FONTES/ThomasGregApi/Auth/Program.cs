using Microsoft.EntityFrameworkCore;
using Auth.Data;
using Auth.Services.Implementations;
using Auth.Models;
using Microsoft.AspNetCore.Identity;
using Auth.Services.Interfaces;
using Auth.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Configuração do DbContext
services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Configurando o serviço UserManager e Identity
services.AddIdentity<Usuario, IdentityRole>(options =>
{
    // Regras
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<AuthDbContext>();

// Injeção de Dependências
services.AddScoped<IAuthService, AuthService>();
services.AddSingleton<IConfiguration>(builder.Configuration);
services.AddSingleton(configuration.GetSection("Jwt").Get<JwtSettings>());

// Adicionando os serviços dos controladores
builder.Services.AddControllers();

// Configuração da Autenticação
var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

services.AddAuthorization();
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});


// Configuração do Swagger
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configuração do Middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configuração do Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
