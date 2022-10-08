using Microsoft.AspNetCore.Authentication.Cookies;
using SecondTestApp.Web;
using Microsoft.EntityFrameworkCore;
using MessengerV3.DAL.EntitiyFramework;
using MessengerV3.DAL.Interfaces;
using System.Configuration;
using MessengerV3.DAL.Repositories;
using MessengerV3.BLL.Interfaces;
using MessengerV3.BLL.Services;
using MessengerV3.DAL.Entities;
using ScrollMessenger.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

const string databaseSettingName = "name=ConnectionStrings:SQLConnection";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MessengerV3DbContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(databaseSettingName));
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IChatRepository<Chat>, ChatRepository>();
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<IMessageRepository<Message>, MessageRepository>();
//builder.Services.AddScoped<IRepository<Chat>, ChatRepository>();
//builder.Services.AddScoped<IRepository<User>, UserRepository>();
//builder.Services.AddScoped<IRepository<Message>, MessageRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    { 
        options.LoginPath = new PathString("/Authentication");
        options.ExpireTimeSpan = TimeSpan.FromHours(12);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Authentication/Failed/";
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
