using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Portfolio.Web.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// IOC Container


//builder.Services.AddScoped<PortfolioContext>();
//builder.Services.AddTransient<PortfolioContext>();
//builder.Services.AddSingleton<PortfolioContext>();

builder.Services.AddDbContext<PortfolioContext>();

builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromSeconds(30);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(Option =>
                {
                    Option.Cookie.Name = "PortfolioCookie";
                    Option.LoginPath = "/Auth/Login";
                    Option.LogoutPath = "/Auth/Logout";
                    Option.ExpireTimeSpan=TimeSpan.FromMinutes(30);
                    Option.SlidingExpiration = true;
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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
