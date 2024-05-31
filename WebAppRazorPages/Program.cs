using Microsoft.AspNetCore.Hosting.Server;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Project.Hubs;
using Project.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); // SignalR

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMotocycle, SqlMotocycleRepository>();

//����������� ++
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
    });

//builder.Services.AddControllersWithViews();
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
//����������� --

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();//����������� ++

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chathub"); // ������� ��� SignalR ����

app.MapRazorPages();

app.MapControllers();

app.Run();

//test git