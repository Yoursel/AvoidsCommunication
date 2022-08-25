using AvoidsCommunication;
using AvoidsCommunication.DAL;
using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.DAL.Repositories;
using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Service.Implementations;
using AvoidsCommunication.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
    });

builder.Services.InitializeRepositories();
builder.Services.InitializeServices();


var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();