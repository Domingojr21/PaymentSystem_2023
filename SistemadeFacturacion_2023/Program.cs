using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemadeFacturacion_2023.Context;
using SistemadeFacturacion_2023.Helpers;
using SistemadeFacturacion_2023.Repository.Interfaces;
using SistemadeFacturacion_2023.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FacturaContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IClienteRepository, ClienteRepositorycs>();
builder.Services.AddTransient<IProductosRepositorycs, ProductosRepository>();
builder.Services.AddTransient<IFacturaRepository, FacturaRepository>();
builder.Services.AddTransient<GenerarPDF>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
