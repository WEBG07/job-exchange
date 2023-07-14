using JobExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using JobExchange.Areas.Identity.Data;
using JobExchange.Helper;
using Stripe;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddRouting();

builder.Services.AddDbContext<JobExchangeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("JobExchange_Connection")));

//builder.Services.AddDefaultIdentity<JobExchangeUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<JobExchangeContext>();

builder.Services.AddIdentity<JobExchangeUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<JobExchangeContext>()
    .AddDefaultTokenProviders();


var mailsettings = builder.Configuration.GetSection("MailSettings");
builder.Services.AddOptions();  // Kích hoạt Options
builder.Services.Configure<MailSettings>(mailsettings);  // đăng ký để Inject

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.Configure<MailSettings>(builder.Configuration);

//builder.Services.AddTransient<IEmailSender, EmailSender>();

//?ng d?ng s? chuy?n h??ng ng??i d�ng ??n khi h? c?n ??ng nh?p, ??ng xu?t ho?c khi h? b? t? ch?i truy c?p.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidate}/{action=Index}/{id?}");


app.Run();
