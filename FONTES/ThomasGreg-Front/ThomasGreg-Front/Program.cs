using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ThomasGreg.Domain.Entities;
using ThomasGreg.Domain.Interfaces.Repository;
using ThomasGreg.Domain.Interfaces.Service;
using ThomasGreg.Repository.Repository.Implementations;
using ThomasGreg.Service.Services.Implementations;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ILogradouroService, LogradouroService>();
builder.Services.AddScoped<IApiService, ApiService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddScoped<IApiRepository, ApiRepository>();


// Register the repository to be used by the services
builder.Services.AddHttpClient<IApiRepository, ApiRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure settings
builder.Services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
builder.Services.Configure<AuthApiSettings>(configuration.GetSection("AuthApiSettings"));


// Register API HttpClient
builder.Services.AddHttpClient("ApiHttpClient", (serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseApiUrl);
});

// Register Auth API HttpClient
builder.Services.AddHttpClient("AuthApiHttpClient", (serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<AuthApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseApiUrl);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
