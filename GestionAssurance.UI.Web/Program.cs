using GestionAssurance.ApplicationCore.Interfaces;
using GestionAssurance.ApplicationCore.Services;
using GestionAssurance.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injection de dépendance
builder.Services.AddScoped<ISinistreService, SinistreService>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<IExpertiseService, ExpertiseService>();
builder.Services.AddScoped<IAssuranceService, AssuranceService>();

builder.Services.AddDbContext<DbContext, GestionAssuranceContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home1}/{action=Index}/{id?}");

app.Run();
